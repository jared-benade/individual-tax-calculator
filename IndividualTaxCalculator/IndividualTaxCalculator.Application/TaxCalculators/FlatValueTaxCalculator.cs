﻿using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.TaxCalculators;

public class FlatValueTaxCalculator : IFlatValueTaxCalculator
{
    private readonly IFlatValueTaxConfigGateway _flatValueTaxConfigGateway;

    public FlatValueTaxCalculator(IFlatValueTaxConfigGateway flatValueTaxConfigGateway)
    {
        _flatValueTaxConfigGateway = flatValueTaxConfigGateway ??
                                     throw new ArgumentNullException(nameof(flatValueTaxConfigGateway));
    }

    public async Task<TaxCalculationResult> CalculateTax(TaxableAmount annualIncome)
    {
        var taxConfig = await _flatValueTaxConfigGateway.GetConfig();
        var taxAmount = CalculateTaxAmount(annualIncome, taxConfig);
        return TaxCalculationResult.Create(taxAmount);
    }

    private static decimal CalculateTaxAmount(TaxableAmount annualIncome, FlatValueTaxConfig taxConfig)
    {
        var annualIncomeAmount = annualIncome.Amount;
        return annualIncomeAmount >= taxConfig.AnnualThresholdAmount
            ? taxConfig.FlatValueAmount
            : annualIncome.CalculateTax(taxConfig.TaxPercentage);
    }
}