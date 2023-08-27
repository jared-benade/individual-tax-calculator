using IndividualTaxCalculator.Domain.Gateways;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class FlatRateTaxConfigGateway : IFlatRateTaxConfigGateway
{
    public Task<double> GetFlatRatePercentage()
    {
        throw new NotImplementedException();
    }
}