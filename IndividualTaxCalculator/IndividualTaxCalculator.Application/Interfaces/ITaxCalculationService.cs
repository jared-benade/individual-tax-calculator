using IndividualTaxCalculator.Application.Dtos;

namespace IndividualTaxCalculator.Application.Interfaces;

public interface ITaxCalculationService
{
    TaxCalculationResultDto CalculateTaxForIndividual(TaxCalculationRequestDto request);
}