using IndividualTaxCalculator.Application.Dtos;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application;

public class TaxCalculationService : ITaxCalculationService
{
    private readonly IFlatRateTaxCalculator _flatRateTaxCalculator;
    private readonly IFlatValueTaxCalculator _flatValueTaxCalculator;
    private readonly IProgressiveTaxCalculator _progressiveTaxCalculator;
    private readonly ITaxCalculationMappingGateway _taxCalculationMappingGateway;

    public TaxCalculationService(ITaxCalculationMappingGateway taxCalculationMappingGateway,
        IFlatRateTaxCalculator flatRateTaxCalculator, IFlatValueTaxCalculator flatValueTaxCalculator,
        IProgressiveTaxCalculator progressiveTaxCalculator)
    {
        _taxCalculationMappingGateway = taxCalculationMappingGateway ??
                                        throw new ArgumentNullException(nameof(taxCalculationMappingGateway));
        _flatRateTaxCalculator =
            flatRateTaxCalculator ?? throw new ArgumentNullException(nameof(flatRateTaxCalculator));
        _flatValueTaxCalculator =
            flatValueTaxCalculator ?? throw new ArgumentNullException(nameof(flatValueTaxCalculator));
        _progressiveTaxCalculator = progressiveTaxCalculator ??
                                    throw new ArgumentNullException(nameof(progressiveTaxCalculator));
    }

    public async Task<TaxCalculationResultDto> CalculateTaxForIndividual(TaxCalculationRequestDto request)
    {
        var postalCode = PostalCode.Create(request.PostalCode);
        var annualIncome = TaxableAmount.Create(request.AnnualIncome);

        var taxCalculationMapping = await _taxCalculationMappingGateway.GetTaxCalculationMapping();
        var taxCalculationType = taxCalculationMapping[postalCode];

        if (taxCalculationType == TaxCalculationType.FlatRate)
        {
            var taxCalculationResult = await _flatRateTaxCalculator.CalculateTax(annualIncome);
            return new TaxCalculationResultDto(taxCalculationResult.TaxAmount);
        }

        if (taxCalculationType == TaxCalculationType.FlatValue)
        {
            var taxCalculationResult = await _flatValueTaxCalculator.CalculateTax(annualIncome);
            return new TaxCalculationResultDto(taxCalculationResult.TaxAmount);
        }

        var calculationResult = await _progressiveTaxCalculator.CalculateTax(annualIncome);
        return new TaxCalculationResultDto(calculationResult.TaxAmount);
    }
}