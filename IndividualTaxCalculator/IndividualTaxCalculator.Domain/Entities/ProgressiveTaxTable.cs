namespace IndividualTaxCalculator.Domain.Entities;

public class ProgressiveTaxTable
{
    private ProgressiveTaxTable(IEnumerable<ProgressiveTaxBracket> orderedTaxBrackets)
    {
        OrderedTaxBrackets = orderedTaxBrackets;
    }

    public IEnumerable<ProgressiveTaxBracket> OrderedTaxBrackets { get; }

    // TODO: Ensure tax brackets have no gaps and there is only one without an upper bound
    public static ProgressiveTaxTable Create(IEnumerable<ProgressiveTaxBracket> taxBrackets)
    {
        var orderedTaxBrackets = taxBrackets.OrderBy(x => x.LowerBound);
        return new ProgressiveTaxTable(orderedTaxBrackets);
    }
}