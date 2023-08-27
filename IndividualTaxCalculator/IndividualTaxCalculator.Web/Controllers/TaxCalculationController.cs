using IndividualTaxCalculator.Application.Dtos;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.ValueObjects;
using IndividualTaxCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndividualTaxCalculator.Web.Controllers;

public class TaxCalculationController : Controller
{
    private readonly ITaxCalculationService _taxCalculationService;

    public TaxCalculationController(ITaxCalculationService taxCalculationService)
    {
        _taxCalculationService =
            taxCalculationService ?? throw new ArgumentNullException(nameof(taxCalculationService));
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
        var taxCalculationResultDto = await _taxCalculationService.CalculateTaxForIndividual(requestDto);
        
        return RedirectToAction("Result", taxCalculationResultDto);
    }

    // TODO: Only pass through calculation id and refetch from DB
    public IActionResult Result(TaxCalculationResultDto taxCalculationResultDto)
    {
        var (annualIncome, postalCode, taxAmount) = taxCalculationResultDto;

        return View(new TaxCalculationResultViewModel
        {
            AnnualIncome = annualIncome,
            PostalCode = postalCode,
            TaxAmount = taxAmount
        });
    }
}