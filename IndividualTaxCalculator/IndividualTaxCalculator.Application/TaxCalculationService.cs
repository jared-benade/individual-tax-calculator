using IndividualTaxCalculator.Application.Dtos;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.Gateways;

namespace IndividualTaxCalculator.Application;

public class TaxCalculationService : ITaxCalculationService
{
    private readonly ITaxCalculationMappingGateway _taxCalculationMappingGateway;

    public TaxCalculationService(ITaxCalculationMappingGateway taxCalculationMappingGateway)
    {
        _taxCalculationMappingGateway = taxCalculationMappingGateway ??
                                        throw new ArgumentNullException(nameof(taxCalculationMappingGateway));
    }

    public TaxCalculationResultDto CalculateTaxForIndividual(TaxCalculationRequestDto request)
    {
        throw new NotImplementedException();
    }
}