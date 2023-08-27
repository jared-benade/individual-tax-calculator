using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Gateways;

public interface ITaxCalculationResultGateway
{
    Task Save(TaxCalculationResult taxCalculationResult);
}