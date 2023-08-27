using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class ProgressiveTaxGateway : IProgressiveTaxGateway
{
    public Task<ProgressiveTaxTable> GetProgressiveTaxTable()
    {
        throw new NotImplementedException();
    }
}