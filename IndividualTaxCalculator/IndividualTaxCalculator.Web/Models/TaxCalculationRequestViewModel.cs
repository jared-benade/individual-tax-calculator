using System.ComponentModel;

namespace IndividualTaxCalculator.Web.Models;

public class TaxCalculationRequestViewModel
{
    [DisplayName("Postal Code")]
    public string PostalCode { get; set; } = "";
    
    [DisplayName("Annual Income")]
    public decimal AnnualIncome { get; set; }
}