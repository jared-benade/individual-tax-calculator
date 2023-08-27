using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.TaxCalculators;

public class ProgressiveTaxCalculator : IProgressiveTaxCalculator
{
    private readonly IProgressiveTaxGateway _progressiveTaxGateway;

    public ProgressiveTaxCalculator(IProgressiveTaxGateway progressiveTaxGateway)
    {
        _progressiveTaxGateway =
            progressiveTaxGateway ?? throw new ArgumentNullException(nameof(progressiveTaxGateway));
    }

    public async Task<TaxCalculationResult> CalculateTax(TaxableAmount annualIncome)
    {
        var progressiveTaxTable = await _progressiveTaxGateway.GetProgressiveTaxTable();
        var progressiveTaxBrackets = progressiveTaxTable.OrderedTaxBrackets.ToList();
        var annualIncomeAmount = annualIncome.Amount;

        var taxAmount = CalculateTaxAmount(progressiveTaxBrackets, annualIncomeAmount);
        return TaxCalculationResult.Create(taxAmount);
    }

    private static decimal CalculateTaxAmount(IReadOnlyList<ProgressiveTaxBracket> progressiveTaxBrackets,
        decimal annualIncomeAmount)
    {
        var taxAmount = 0M;
        for (var taxBracketNumber = 0; taxBracketNumber < progressiveTaxBrackets.Count; taxBracketNumber++)
        {
            var taxBracket = progressiveTaxBrackets.ElementAt(taxBracketNumber);
            if (AnnualIncomeFallsInCurrentBracket(annualIncomeAmount, taxBracket))
            {
                taxAmount += CalculateTaxForBracket(annualIncomeAmount, progressiveTaxBrackets, taxBracket,
                    taxBracketNumber);
                break;
            }

            var maxTaxableAmountInBracket = taxBracket.UpperBound!.Value;
            taxAmount += CalculateTaxForBracket(maxTaxableAmountInBracket, progressiveTaxBrackets, taxBracket,
                taxBracketNumber);
        }

        return taxAmount;
    }

    private static decimal CalculateTaxForBracket(decimal amount,
        IReadOnlyList<ProgressiveTaxBracket> progressiveTaxBrackets, ProgressiveTaxBracket taxBracket,
        int taxBracketNumber)
    {
        var applicableAmountToTax = GetApplicableAmountToTax(amount, progressiveTaxBrackets, taxBracketNumber);
        return TaxableAmount.Create(applicableAmountToTax).CalculateTax(taxBracket.TaxPercentage);
    }

    private static decimal GetApplicableAmountToTax(decimal amount,
        IReadOnlyList<ProgressiveTaxBracket> progressiveTaxBrackets, int taxBracketNumber)
    {
        var isFirstTaxBracket = taxBracketNumber == 0;
        if (isFirstTaxBracket)
        {
            return amount;
        }

        var previousTaxBracket = progressiveTaxBrackets[taxBracketNumber - 1];
        return amount - previousTaxBracket.UpperBound!.Value;
    }

    private static bool AnnualIncomeFallsInCurrentBracket(decimal annualIncomeAmount, ProgressiveTaxBracket taxBracket)
    {
        return annualIncomeAmount >= taxBracket.LowerBound &&
               (taxBracket.UpperBound is null || annualIncomeAmount <= taxBracket.UpperBound);
    }
}