namespace IndividualTaxCalculator.Domain.Entities;

public class ProgressiveTaxBracket
{
    private ProgressiveTaxBracket(Guid id, double taxPercentage, decimal lowerBound, decimal? upperBound)
    {
        Id = id;
        TaxPercentage = taxPercentage;
        LowerBound = lowerBound;
        UpperBound = upperBound;
    }

    // TODO: Validate that all fields are positive and that lower bound is less than upper bound
    public static ProgressiveTaxBracket Create(Guid id, double taxPercentage, decimal lowerBound, decimal? upperBound)
    {
        return new ProgressiveTaxBracket(id, taxPercentage, lowerBound, upperBound);
    }

    public Guid Id { get; }
    public double TaxPercentage { get; }
    public decimal LowerBound { get; }
    public decimal? UpperBound { get; }
}