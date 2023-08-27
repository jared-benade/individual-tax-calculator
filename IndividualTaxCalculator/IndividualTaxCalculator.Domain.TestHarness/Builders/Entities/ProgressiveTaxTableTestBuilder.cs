using IndividualTaxCalculator.Domain.Entities;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Entities;

public class ProgressiveTaxTableTestBuilder
{
    private IEnumerable<ProgressiveTaxBracket> _taxBrackets;

    private ProgressiveTaxTableTestBuilder()
    {
        _taxBrackets = new List<ProgressiveTaxBracket>();
    }

    public static ProgressiveTaxTableTestBuilder Create()
    {
        return new ProgressiveTaxTableTestBuilder();
    }

    public ProgressiveTaxTable Build()
    {
        return ProgressiveTaxTable.Create(_taxBrackets);
    }

    public ProgressiveTaxTableTestBuilder WithTaxBrackets(params ProgressiveTaxBracket[] taxBrackets)
    {
        _taxBrackets = taxBrackets;
        return this;
    }
}