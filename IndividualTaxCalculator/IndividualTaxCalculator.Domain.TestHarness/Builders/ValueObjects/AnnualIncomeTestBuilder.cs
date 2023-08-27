using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;

public class AnnualIncomeTestBuilder
{
    private decimal _amount;

    private AnnualIncomeTestBuilder()
    {
        _amount = 0;
    }

    public static AnnualIncomeTestBuilder Create()
    {
        return new AnnualIncomeTestBuilder();
    }

    public TaxableAmount Build()
    {
        return TaxableAmount.Create(_amount);
    }

    public AnnualIncomeTestBuilder WithAmount(decimal amount)
    {
        _amount = amount;
        return this;
    }
}