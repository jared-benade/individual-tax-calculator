using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Gateways;

public interface ITaxCalculationMappingGateway
{
    Task<Dictionary<PostalCode, TaxCalculationType>> GetTaxCalculationMapping();
}