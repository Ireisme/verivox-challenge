using System;
using Xunit;
using ProductsService.Interfaces;
using ProductsService.Services;
using System.Collections.Generic;

namespace ProductsService.Tests
{
  public class ElectricityTariffCalculatorTests
  {
    IElectricityTariffCalculator GetSut()
    {
      return new ElectricityTariffCalculator();
    }

    [Theory]
    [InlineData(3500, 830)]
    [InlineData(4500, 1050)]
    [InlineData(6000, 1380)]
    public void Basic_ShouldReturnCorrectAmount(int kWhYear, double expected)
    {
      var sut = GetSut();
      var result = sut.Basic(kWhYear);

      Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3500, 800)]
    [InlineData(4500, 950)]
    [InlineData(6000, 1400)]
    public void Packaged_ShouldReturnCorrectAmount(int kWhYear, double expected)
    {
      var sut = GetSut();
      var result = sut.Packaged(kWhYear);

      Assert.Equal(expected, result);
    }
  }
}
