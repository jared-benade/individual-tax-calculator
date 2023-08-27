using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using NSubstitute;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;

public class FlatValueTaxConfigGatewayTestBuilder
{
    private readonly IFlatValueTaxConfigGateway _gateway;

    private FlatValueTaxConfigGatewayTestBuilder()
    {
        _gateway = Substitute.For<IFlatValueTaxConfigGateway>();
    }

    public static FlatValueTaxConfigGatewayTestBuilder Create()
    {
        return new FlatValueTaxConfigGatewayTestBuilder();
    }

    public IFlatValueTaxConfigGateway Build()
    {
        return _gateway;
    }

    public FlatValueTaxConfigGatewayTestBuilder WithConfig(FlatValueTaxConfig config)
    {
        _gateway.GetConfig().Returns(config);
        return this;
    }
}