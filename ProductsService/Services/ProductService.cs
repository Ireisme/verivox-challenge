using System.Collections.Generic;
using ProductsService.Interfaces;
using ProductsService.Models;

namespace ProductsService.Services
{
  public class ProductService : IProductService
  {
    IElectricityTariffCalculator electricalCalculator;

    public ProductService(IElectricityTariffCalculator electricalCalculator)
    {
      this.electricalCalculator = electricalCalculator;
    }

    public IEnumerable<Product> GetElectricalProducts(int kWhYear)
    {
      return new List<Product>()
      {
        new Product("basic electricity tariff", electricalCalculator.Basic(kWhYear)),
        new Product("Packaged tariff", electricalCalculator.Packaged(kWhYear))
      };
    }
  }
}