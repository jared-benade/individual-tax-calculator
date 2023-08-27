using IndividualTaxCalculator.Application.Dtos;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application;

public class TaxCalculationService : ITaxCalculationService
{
    private readonly ITaxCalculationMappingGateway _taxCalculationMappingGateway;
    private readonly IFlatRateTaxCalculator _flatRateTaxCalculator;

    public TaxCalculationService(ITaxCalculationMappingGateway taxCalculationMappingGateway,
        IFlatRateTaxCalculator flatRateTaxCalculator)
    {
        _taxCalculationMappingGateway = taxCalculationMappingGateway ??
                                        throw new ArgumentNullException(nameof(taxCalculationMappingGateway));
        _flatRateTaxCalculator =
            flatRateTaxCalculator ?? throw new ArgumentNullException(nameof(flatRateTaxCalculator));
    }

    public async Task<TaxCalculationResultDto> CalculateTaxForIndividual(TaxCalculationRequestDto request)
    {
        var postalCode = PostalCode.Create(request.PostalCode);
        var annualIncome = AnnualIncome.Create(request.AnnualIncome);

        var taxCalculationMapping = await _taxCalculationMappingGateway.GetTaxCalculationMapping();
        var taxCalculationType = taxCalculationMapping[postalCode];

        if (taxCalculationType == TaxCalculationType.FlatRate)
        {
            var taxCalculationResult = await _flatRateTaxCalculator.CalculateTax(annualIncome);
            return new TaxCalculationResultDto(taxCalculationResult.TaxAmount);
        }

        throw new NotImplementedException();
    }
}