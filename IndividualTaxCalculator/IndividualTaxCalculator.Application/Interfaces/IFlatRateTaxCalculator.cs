using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface IFlatRateTaxCalculator
{
    Task<TaxCalculationResult> CalculateTax(AnnualIncome annualIncome);
}