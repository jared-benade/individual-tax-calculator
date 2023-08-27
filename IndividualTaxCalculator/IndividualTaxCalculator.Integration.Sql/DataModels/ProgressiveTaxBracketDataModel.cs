namespace IndividualTaxCalculator.Integration.Sql.DataModels;

public class ProgressiveTaxBracketDataModel
{
    public int Id { get; set; }
    public double TaxPercentage { get; set; }
    public decimal LowerBound { get; set; }
    public decimal? UpperBound { get; set; }
}