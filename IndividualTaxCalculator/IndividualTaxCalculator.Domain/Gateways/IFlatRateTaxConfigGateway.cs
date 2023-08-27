namespace IndividualTaxCalculator.Domain.Gateways;

public interface IFlatRateTaxConfigGateway
{
    decimal GetFlatRatePercentage();
}