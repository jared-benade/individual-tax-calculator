using System.ComponentModel;

namespace IndividualTaxCalculator.Web.Models;

public class TaxCalculationResultViewModel
{
    [DisplayName("Annual Income")] public decimal AnnualIncome { get; set; }

    [DisplayName("Postal Code")] public string PostalCode { get; set; } = "";

    [DisplayName("Calculated Tax Amount")] public decimal TaxAmount { get; set; }
}