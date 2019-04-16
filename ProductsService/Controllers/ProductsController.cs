using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Interfaces;
using ProductsService.Models;

namespace ProductsService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    IProductService productService;

    public ProductsController(IProductService productService)
    {
      this.productService = productService;
    }

    [HttpGet("comparison/electrical/{kWhYear}")]
    public ActionResult<List<Product>> Get(int kWhYear)
    {
      return this.productService.GetElectricalProducts(kWhYear).ToList();
    }
  }
}
