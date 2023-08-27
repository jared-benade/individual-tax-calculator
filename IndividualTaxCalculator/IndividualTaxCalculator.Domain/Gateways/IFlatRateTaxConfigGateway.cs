namespace IndividualTaxCalculator.Domain.Gateways;

public interface IFlatRateTaxConfigGateway
{
    Task<decimal> GetFlatRatePercentage();
}