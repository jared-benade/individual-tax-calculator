using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Gateways;

public interface ITaxCalculationMappingGateway
{
    Dictionary<PostalCode, TaxCalculationType> GetTaxCalculationMapping();
}