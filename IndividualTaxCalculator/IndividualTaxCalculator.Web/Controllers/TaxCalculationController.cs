using IndividualTaxCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndividualTaxCalculator.Web.Controllers;

public class TaxCalculationController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new TaxCalculationRequestViewModel());
    }

    [HttpPost]
    public IActionResult Index(TaxCalculationRequestViewModel viewModel)
    {
        return Index();
    }
}