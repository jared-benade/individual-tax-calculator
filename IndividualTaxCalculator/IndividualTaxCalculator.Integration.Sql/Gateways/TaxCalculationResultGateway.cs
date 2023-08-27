using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class TaxCalculationResultGateway : ITaxCalculationResultGateway
{
    public Task Save(TaxCalculationResult taxCalculationResult, PostalCode postalCode)
    {
        throw new NotImplementedException();
    }
}