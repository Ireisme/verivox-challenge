using ProductsService.Interfaces;

namespace ProductsService.Services
{
  public class ElectricityTariffCalculator : IElectricityTariffCalculator
  {
    public double Basic(int kWhYear)
    {
      var perYear = 60;
      var usage = kWhYear * .22;

      return perYear + usage;
    }

    public double Packaged(int kWhYear)
    {
      var perYear = 800;
      var usage = kWhYear > 4000 ? (kWhYear - 4000) * .30 : 0;

      return perYear + usage;
    }
  }
}
