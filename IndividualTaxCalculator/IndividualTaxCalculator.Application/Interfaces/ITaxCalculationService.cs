using IndividualTaxCalculator.Application.Dtos;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface ITaxCalculationService
{
    Task<TaxCalculationResultDto> CalculateTaxForIndividual(TaxCalculationRequestDto request);
}