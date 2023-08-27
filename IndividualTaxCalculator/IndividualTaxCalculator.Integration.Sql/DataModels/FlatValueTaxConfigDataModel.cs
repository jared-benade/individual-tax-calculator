namespace IndividualTaxCalculator.Integration.Sql.DataModels;

public class FlatValueTaxConfigDataModel
{
    public int Id { get; set; }
    public decimal FlatValueAmount { get; set; }
    public decimal AnnualThresholdAmount { get; set; }
    public double TaxPercentage { get; set; }
}