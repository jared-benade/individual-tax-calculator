using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.TaxCalculators;

public class FlatRateTaxCalculator : IFlatRateTaxCalculator
{
    private readonly IFlatRateTaxConfigGateway _flatRateTaxConfigGateway;

    public FlatRateTaxCalculator(IFlatRateTaxConfigGateway flatRateTaxConfigGateway)
    {
        _flatRateTaxConfigGateway = flatRateTaxConfigGateway ??
                                    throw new ArgumentNullException(nameof(flatRateTaxConfigGateway));
    }

    public TaxCalculationResult CalculateTax(AnnualIncome annualIncome)
    {
        var flatRatePercentage = _flatRateTaxConfigGateway.GetFlatRatePercentage();
        var taxAmount = annualIncome.Amount * (flatRatePercentage / 100);

        return TaxCalculationResult.Create(taxAmount);
    }
}