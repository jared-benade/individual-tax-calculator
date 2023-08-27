using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class FlatValueTaxConfigGateway : IFlatValueTaxConfigGateway
{
    public Task<FlatValueTaxConfig> GetConfig()
    {
        throw new NotImplementedException();
    }
}