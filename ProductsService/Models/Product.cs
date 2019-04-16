namespace ProductsService.Models
{
  public class Product
  {
    public string TariffName { get; private set; }
    public double AnnualCosts { get; private set; }

    public Product(string tariffName, double annualCosts)
    {
      this.TariffName = tariffName;
      this.AnnualCosts = annualCosts;
    }
  }
}