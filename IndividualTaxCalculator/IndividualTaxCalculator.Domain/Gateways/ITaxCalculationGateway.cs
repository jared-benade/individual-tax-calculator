using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Gateways;

public interface ITaxCalculationGateway
{
    Task Save(TaxableAmount annualIncome, PostalCode postalCode, TaxCalculationResult taxCalculationResult);
}