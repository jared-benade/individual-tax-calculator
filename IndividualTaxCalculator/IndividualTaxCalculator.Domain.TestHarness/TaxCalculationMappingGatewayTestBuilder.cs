using IndividualTaxCalculator.Domain.Gateways;
using NSubstitute;

namespace IndividualTaxCalculator.Domain.TestHarness;

public class TaxCalculationMappingGatewayTestBuilder
{
    private readonly ITaxCalculationMappingGateway _gateway = Substitute.For<ITaxCalculationMappingGateway>();

    private TaxCalculationMappingGatewayTestBuilder()
    {
    }

    public static TaxCalculationMappingGatewayTestBuilder Create()
    {
        return new TaxCalculationMappingGatewayTestBuilder();
    }

    public ITaxCalculationMappingGateway Build()
    {
        return _gateway;
    }
}