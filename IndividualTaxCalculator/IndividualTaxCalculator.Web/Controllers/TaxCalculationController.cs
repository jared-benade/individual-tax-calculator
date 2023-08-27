using IndividualTaxCalculator.Application.Dtos;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndividualTaxCalculator.Web.Controllers;

public class TaxCalculationController : Controller
{
    private readonly ITaxCalculationService _taxCalculationService;

    public TaxCalculationController(ITaxCalculationService taxCalculationService)
    {
        _taxCalculationService = taxCalculationService ?? throw new ArgumentNullException(nameof(taxCalculationService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new TaxCalculationRequestViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(TaxCalculationRequestViewModel viewModel)
    {
        var requestDto = new TaxCalculationRequestDto(viewModel.PostalCode, viewModel.AnnualIncome);
        var calculationResultDto = await _taxCalculationService.CalculateTaxForIndividual(requestDto);
        return Index();
    }
}