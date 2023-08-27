using IndividualTaxCalculator.Domain.Entities;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Entities;

public class FlatValueTaxConfigTestBuilder
{
    private decimal _annualThresholdAmount;
    private decimal _flatValueAmount;
    private readonly int _id;
    private double _taxPercentage;

    private FlatValueTaxConfigTestBuilder()
    {
        _id = 0;
        _flatValueAmount = 0;
        _annualThresholdAmount = 0;
        _taxPercentage = 0;
    }

    public static FlatValueTaxConfigTestBuilder Create()
    {
        return new FlatValueTaxConfigTestBuilder();
    }

    public FlatValueTaxConfig Build()
    {
        return FlatValueTaxConfig.Create(_id, _flatValueAmount, _annualThresholdAmount, _taxPercentage);
    }

    public FlatValueTaxConfigTestBuilder WithFlatValueAmount(decimal flatValueAmount)
    {
        _flatValueAmount = flatValueAmount;
        return this;
    }

    public FlatValueTaxConfigTestBuilder WithAnnualThresholdAmount(decimal annualThresholdAmount)
    {
        _annualThresholdAmount = annualThresholdAmount;
        return this;
    }

    public FlatValueTaxConfigTestBuilder WithTaxPercentage(double taxPercentage)
    {
        _taxPercentage = taxPercentage;
        return this;
    }
}