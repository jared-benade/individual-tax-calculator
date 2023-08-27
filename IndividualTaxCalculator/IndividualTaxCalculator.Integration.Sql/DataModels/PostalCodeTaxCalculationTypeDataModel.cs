namespace IndividualTaxCalculator.Integration.Sql.DataModels;

public class PostalCodeTaxCalculationTypeDataModel
{
    public int Id { get; set; }
    public int PostalCodeId { get; set; }
    public int TaxCalculationTypeId { get; set; }
}