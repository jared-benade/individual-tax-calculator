using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface IFlatValueTaxCalculator
{
    Task<TaxCalculationResult> CalculateTax(TaxableAmount annualIncome);
}