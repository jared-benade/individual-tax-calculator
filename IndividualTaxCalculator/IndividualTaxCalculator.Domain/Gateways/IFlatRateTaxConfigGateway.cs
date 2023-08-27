namespace IndividualTaxCalculator.Domain.Gateways;

public interface IFlatRateTaxConfigGateway
{
    Task<double> GetFlatRatePercentage();
}