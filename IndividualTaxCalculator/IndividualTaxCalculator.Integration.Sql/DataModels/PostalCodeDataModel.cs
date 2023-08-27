namespace IndividualTaxCalculator.Integration.Sql.DataModels;

public class PostalCodeDataModel
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public int TaxCalculationTypeId { get; set; }
    public TaxCalculationTypeDataModel TaxCalculationType { get; set; } = new();
}