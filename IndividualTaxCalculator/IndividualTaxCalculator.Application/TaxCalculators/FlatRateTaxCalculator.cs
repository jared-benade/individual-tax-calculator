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

    public async Task<TaxCalculationResult> CalculateTax(TaxableAmount annualIncome)
    {
        var flatRatePercentage = await _flatRateTaxConfigGateway.GetFlatRatePercentage();
        var taxAmount = annualIncome.CalculateTax(flatRatePercentage);

        return TaxCalculationResult.Create(taxAmount);
    }
}