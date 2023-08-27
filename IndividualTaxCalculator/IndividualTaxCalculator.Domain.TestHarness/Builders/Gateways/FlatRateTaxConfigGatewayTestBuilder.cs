using IndividualTaxCalculator.Domain.Gateways;
using NSubstitute;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;

public class FlatRateTaxConfigGatewayTestBuilder
{
    private readonly IFlatRateTaxConfigGateway _gateway;

    private FlatRateTaxConfigGatewayTestBuilder()
    {
        _gateway = Substitute.For<IFlatRateTaxConfigGateway>();
    }

    public static FlatRateTaxConfigGatewayTestBuilder Create()
    {
        return new FlatRateTaxConfigGatewayTestBuilder();
    }

    public IFlatRateTaxConfigGateway Build()
    {
        return _gateway;
    }

    public FlatRateTaxConfigGatewayTestBuilder WithFlatRatePercentage(decimal flatRatePercentage)
    {
        _gateway.GetFlatRatePercentage().Returns(flatRatePercentage);
        return this;
    }
}