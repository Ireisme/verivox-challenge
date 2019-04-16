namespace ProductsService.Interfaces
{
  public interface IElectricityTariffCalculator
  {
    double Basic(int kWhYear);
    double Packaged(int kWhYear);
  }
}