using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class AnnualIncome : ValueObject
{
    private AnnualIncome(decimal amount)
    {
        if (amount < 0) throw new Exception("Annual income cannot be less than 0");

        Amount = amount;
    }

    public decimal Amount { get; }

    public static AnnualIncome Create(decimal amount)
    {
        return new AnnualIncome(amount);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}