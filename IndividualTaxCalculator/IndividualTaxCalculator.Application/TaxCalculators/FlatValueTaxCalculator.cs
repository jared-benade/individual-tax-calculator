using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.TaxCalculators;

public class FlatValueTaxCalculator
{
    private readonly IFlatValueTaxConfigGateway _flatValueTaxConfigGateway;

    public FlatValueTaxCalculator(IFlatValueTaxConfigGateway flatValueTaxConfigGateway)
    {
        _flatValueTaxConfigGateway = flatValueTaxConfigGateway ??
                                     throw new ArgumentNullException(nameof(flatValueTaxConfigGateway));
    }

    public async Task<TaxCalculationResult> CalculateTax(AnnualIncome annualIncome)
    {
        var taxConfig = await _flatValueTaxConfigGateway.GetConfig();
        var taxAmount = CalculateTaxAmount(annualIncome, taxConfig);
        return TaxCalculationResult.Create(taxAmount);
    }

    private static decimal CalculateTaxAmount(AnnualIncome annualIncome, FlatValueTaxConfig taxConfig)
    {
        var annualIncomeAmount = annualIncome.Amount;
        return annualIncomeAmount >= taxConfig.AnnualThresholdAmount
            ? taxConfig.FlatValueAmount
            : annualIncomeAmount * (decimal)(taxConfig.TaxPercentage / 100);
    }
}