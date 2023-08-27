using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class Income : ValueObject
{
    private Income(decimal amount)
    {
        if (amount < 0)
        {
            throw new Exception("Income cannot be less than 0");
        }

        Amount = amount;
    }

    public static Income Create(decimal amount)
    {
        return new Income(amount);
    }

    public decimal Amount { get; private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}