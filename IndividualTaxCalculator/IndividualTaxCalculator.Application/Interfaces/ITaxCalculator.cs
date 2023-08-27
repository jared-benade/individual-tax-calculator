using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface ITaxCalculator
{
    Task<TaxCalculationResult> CalculateTax(TaxableAmount annualIncome);
}