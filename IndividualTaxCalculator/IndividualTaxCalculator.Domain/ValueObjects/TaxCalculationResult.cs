using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class TaxCalculationResult : ValueObject
{
    private TaxCalculationResult(decimal taxAmount)
    {
        TaxAmount = taxAmount;
    }

    public decimal TaxAmount { get; }

    public static TaxCalculationResult Create(decimal taxAmount)
    {
        return new TaxCalculationResult(taxAmount);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return TaxAmount;
    }
}