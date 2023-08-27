using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;
using IndividualTaxCalculator.Domain.ValueObjects;
using NSubstitute;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;

public class TaxCalculationResultGatewayTestBuilder
{
    private readonly ITaxCalculationGateway _gateway;

    private TaxCalculationResultGatewayTestBuilder()
    {
        _gateway = Substitute.For<ITaxCalculationGateway>();
    }

    public static TaxCalculationResultGatewayTestBuilder Create()
    {
        return new TaxCalculationResultGatewayTestBuilder();
    }

    public ITaxCalculationGateway Build()
    {
        return _gateway;
    }
}