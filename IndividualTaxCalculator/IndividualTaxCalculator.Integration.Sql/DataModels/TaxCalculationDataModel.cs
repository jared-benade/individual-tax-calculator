namespace IndividualTaxCalculator.Integration.Sql.DataModels;

public class TaxCalculationDataModel
{
    public int Id { get; set; }
    public decimal AnnualIncome { get; set; }
    public decimal TaxAmount { get; set; }
    public string PostalCode { get; set; } = "";
    public DateTime DateCreated => DateTime.Now;
}