using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IndividualTaxCalculator.Web.Models;

public class TaxCalculationRequestViewModel
{
    [DisplayName("Annual Income")] public decimal AnnualIncome { get; set; }
   
    [DisplayName("Postal Code")] public string PostalCode { get; set; } = "";

    // TODO: Populate postal codes from possible choices in DB
    public IEnumerable<SelectListItem> PostalCodes => new List<SelectListItem>
    {
        new() { Value = "7441", Text = "7441" },
        new() { Value = "A100", Text = "A100" },
        new() { Value = "7000", Text = "7000" },
        new() { Value = "1000", Text = "1000" },
    };
}