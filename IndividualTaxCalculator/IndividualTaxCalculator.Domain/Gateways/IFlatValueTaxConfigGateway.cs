using IndividualTaxCalculator.Domain.Entities;

namespace IndividualTaxCalculator.Domain.Gateways;

public interface IFlatValueTaxConfigGateway
{
    Task<FlatValueTaxConfig> GetConfig();
}