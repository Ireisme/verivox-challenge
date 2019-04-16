using System;
using Xunit;
using ProductsService.Interfaces;
using ProductsService.Services;
using System.Collections.Generic;
using FakeItEasy;
using ProductsService.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Controllers;

namespace ProductsService.Tests
{
  public class ProductsControllerTests
  {
    IProductService productService = A.Fake<IProductService>();

    ProductsController GetSut()
    {
      return new ProductsController(productService);
    }

    [Fact]
    public void GetComparisonElectrical_ReturnsCorrectProducts()
    {
      var sut = GetSut();
      var kWhYear = 5678;
      var expected = new List<Product>() 
      {
        new Product("first product", 2200),
        new Product("second product", 3000)
      };

      A.CallTo(() => productService.GetElectricalProducts(kWhYear)).Returns(expected);

      var result = sut.Get(kWhYear);

      var actionResult = Assert.IsType<ActionResult<List<Product>>>(result);
      var value = Assert.IsType<List<Product>>(actionResult.Value);
      Assert.Equal(expected, actionResult.Value);
    }
  }
}
