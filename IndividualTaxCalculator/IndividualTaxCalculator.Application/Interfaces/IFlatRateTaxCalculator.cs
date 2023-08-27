using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface IFlatRateTaxCalculator
{
    TaxCalculationResult CalculateTax(AnnualIncome annualIncome);
}