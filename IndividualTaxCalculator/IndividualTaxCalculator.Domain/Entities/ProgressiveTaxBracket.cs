namespace IndividualTaxCalculator.Domain.Entities;

public class ProgressiveTaxBracket
{
    private ProgressiveTaxBracket(int id, double taxPercentage, decimal lowerBound, decimal? upperBound)
    {
        Id = id;
        TaxPercentage = taxPercentage;
        LowerBound = lowerBound;
        UpperBound = upperBound;
    }

    // TODO: Validate that all fields are positive and that lower bound is less than upper bound
    public static ProgressiveTaxBracket Create(int id, double taxPercentage, decimal lowerBound,
        decimal? upperBound = null)
    {
        return new ProgressiveTaxBracket(id, taxPercentage, lowerBound, upperBound);
    }

    public int Id { get; }
    public double TaxPercentage { get; }
    public decimal LowerBound { get; }
    public decimal? UpperBound { get; }
}