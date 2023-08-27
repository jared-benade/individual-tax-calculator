using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class TaxableAmount : ValueObject
{
    private TaxableAmount(decimal amount)
    {
        if (amount < 0) throw new Exception("Taxable amount cannot be negative");

        Amount = amount;
    }

    public decimal Amount { get; }

    public static TaxableAmount Create(decimal amount)
    {
        return new TaxableAmount(amount);
    }

    public decimal CalculateTax(double taxPercentage)
    {
        return Amount * (decimal)(taxPercentage / 100);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}