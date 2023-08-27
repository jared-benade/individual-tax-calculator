using IndividualTaxCalculator.Domain.Entities;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Entities;

public class ProgressiveTaxBracketTestBuilder
{
    private Guid _id;
    private double _taxPercentage;
    private decimal _lowerBound;
    private decimal? _upperBound;

    private ProgressiveTaxBracketTestBuilder()
    {
        _id = Guid.Empty;
        _taxPercentage = 0;
        _lowerBound = 0;
    }

    public static ProgressiveTaxBracketTestBuilder Create()
    {
        return new ProgressiveTaxBracketTestBuilder();
    }

    public ProgressiveTaxBracket Build()
    {
        return ProgressiveTaxBracket.Create(_id, _taxPercentage, _lowerBound, _upperBound);
    }

    public ProgressiveTaxBracketTestBuilder WithTaxPercentage(double taxPercentage)
    {
        _taxPercentage = taxPercentage;
        return this;
    }

    public ProgressiveTaxBracketTestBuilder WithLowerBound(decimal lowerBound)
    {
        _lowerBound = lowerBound;
        return this;
    }
    
    public ProgressiveTaxBracketTestBuilder WithUpperBound(decimal? upperBound)
    {
        _upperBound = upperBound;
        return this;
    }
}