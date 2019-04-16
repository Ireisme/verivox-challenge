using System;
using Xunit;
using ProductsService.Interfaces;
using ProductsService.Services;
using System.Collections.Generic;
using FakeItEasy;
using ProductsService.Models;
using System.Linq;

namespace ProductsService.Tests
{
  public class ProductServiceTests
  {
    IElectricityTariffCalculator electricalCalculator = A.Fake<IElectricityTariffCalculator>();

    IProductService GetSut()
    {
      return new ProductService(electricalCalculator);
    }

    [Fact]
    public void GetElectricalProducts_ShouldReturnCorrectProducts()
    {
      var sut = GetSut();
      var kWhYear = 1234;
      
      var basicTariffName = "basic electricity tariff";
      var expectedBasicProduct = new Product(basicTariffName, 2000);

      var packagedTariffName = "Packaged tariff";
      var expectedPackagedProduct = new Product(packagedTariffName, 1500);

      A.CallTo(() => electricalCalculator.Basic(kWhYear)).Returns(expectedBasicProduct.AnnualCosts);
      A.CallTo(() => electricalCalculator.Packaged(kWhYear)).Returns(expectedPackagedProduct.AnnualCosts);

      var result = sut.GetElectricalProducts(kWhYear);

      var basicProduct = result.Single(p => p.TariffName == basicTariffName);
      Assert.Equal(expectedBasicProduct.AnnualCosts, basicProduct.AnnualCosts);

      var packagedProduct = result.Single(p => p.TariffName == packagedTariffName);
      Assert.Equal(expectedPackagedProduct.AnnualCosts, packagedProduct.AnnualCosts);
    }
  }
}
