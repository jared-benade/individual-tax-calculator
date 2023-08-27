using IndividualTaxCalculator.CommonTestHarness;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;

public class TaxCalculationResultTestBuilder
{
    private decimal _amount;

    private TaxCalculationResultTestBuilder()
    {
        _amount = 0;
    }

    private static TaxCalculationResultTestBuilder Create()
    {
        return new TaxCalculationResultTestBuilder();
    }

    public static TaxCalculationResultTestBuilder CreateWithRandomProps()
    {
        return Create().WithRandomProps();
    }

    public TaxCalculationResult Build()
    {
        return TaxCalculationResult.Create(_amount);
    }

    private TaxCalculationResultTestBuilder WithRandomProps()
    {
        _amount = RandomFinance.PositiveAmount();
        return this;
    }
}