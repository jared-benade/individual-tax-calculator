using IndividualTaxCalculator.Domain.Entities;

namespace IndividualTaxCalculator.Domain.Gateways;

public interface IProgressiveTaxGateway
{
    Task<ProgressiveTaxTable> GetProgressiveTaxTable();
}