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
    private readonly ITaxCalculationGateway _taxCalculationGateway;
    private readonly ITaxCalculationMappingGateway _taxCalculationMappingGateway;
    private readonly Dictionary<TaxCalculationType, ITaxCalculator> _taxCalculatorStrategies;

    public TaxCalculationService(ITaxCalculationMappingGateway taxCalculationMappingGateway,
        IFlatRateTaxCalculator flatRateTaxCalculator, IFlatValueTaxCalculator flatValueTaxCalculator,
        IProgressiveTaxCalculator progressiveTaxCalculator, ITaxCalculationGateway taxCalculationGateway)
    {
        _taxCalculationMappingGateway = taxCalculationMappingGateway ??
                                        throw new ArgumentNullException(nameof(taxCalculationMappingGateway));
        _flatRateTaxCalculator =
            flatRateTaxCalculator ?? throw new ArgumentNullException(nameof(flatRateTaxCalculator));
        _flatValueTaxCalculator =
            flatValueTaxCalculator ?? throw new ArgumentNullException(nameof(flatValueTaxCalculator));
        _progressiveTaxCalculator = progressiveTaxCalculator ??
                                    throw new ArgumentNullException(nameof(progressiveTaxCalculator));
        _taxCalculationGateway = taxCalculationGateway ??
                                 throw new ArgumentNullException(nameof(taxCalculationGateway));

        _taxCalculatorStrategies = GetTaxCalculatorStrategies();
    }

    public async Task<TaxCalculationResultDto> CalculateTaxForIndividual(TaxCalculationRequestDto request)
    {
        var postalCode = PostalCode.Create(request.PostalCode);
        var annualIncome = TaxableAmount.Create(request.AnnualIncome);

        var taxCalculationMapping = await _taxCalculationMappingGateway.GetTaxCalculationMapping();
        var taxCalculationType = taxCalculationMapping[postalCode];

        var taxCalculationResult = await _taxCalculatorStrategies[taxCalculationType].CalculateTax(annualIncome);
        await _taxCalculationGateway.Save(annualIncome, postalCode, taxCalculationResult);

        return new TaxCalculationResultDto(taxCalculationResult.TaxAmount);
    }

    private Dictionary<TaxCalculationType, ITaxCalculator> GetTaxCalculatorStrategies()
    {
        return new Dictionary<TaxCalculationType, ITaxCalculator>
        {
            {
                TaxCalculationType.FlatValue, _flatValueTaxCalculator
            },
            {
                TaxCalculationType.FlatRate, _flatRateTaxCalculator
            },
            {
                TaxCalculationType.Progressive, _progressiveTaxCalculator
            }
        };
    }
}