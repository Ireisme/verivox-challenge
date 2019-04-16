using System.Collections.Generic;
using ProductsService.Models;

namespace ProductsService.Interfaces
{
  public interface IProductService
  {
    IEnumerable<Product> GetElectricalProducts(int kWhYear);
  }
}