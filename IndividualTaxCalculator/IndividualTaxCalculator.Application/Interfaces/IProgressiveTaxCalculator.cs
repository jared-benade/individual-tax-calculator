using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface IProgressiveTaxCalculator
{
    Task<TaxCalculationResult> CalculateTax(TaxableAmount annualIncome);
}