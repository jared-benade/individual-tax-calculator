using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class TaxCalculationResult : ValueObject
{
    private TaxCalculationResult(decimal amount)
    {
        Amount = amount;
    }

    public decimal Amount { get; }

    public static TaxCalculationResult Create(decimal amount)
    {
        return new TaxCalculationResult(amount);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}