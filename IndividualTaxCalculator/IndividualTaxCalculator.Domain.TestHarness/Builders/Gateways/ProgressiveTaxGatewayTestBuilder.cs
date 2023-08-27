using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using NSubstitute;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;

public class ProgressiveTaxGatewayTestBuilder
{
    private readonly IProgressiveTaxGateway _gateway;

    private ProgressiveTaxGatewayTestBuilder()
    {
        _gateway = Substitute.For<IProgressiveTaxGateway>();
    }

    public static ProgressiveTaxGatewayTestBuilder Create()
    {
        return new ProgressiveTaxGatewayTestBuilder();
    }

    public IProgressiveTaxGateway Build()
    {
        return _gateway;
    }

    public ProgressiveTaxGatewayTestBuilder WithProgressiveTaxTable(ProgressiveTaxTable progressiveTaxTable)
    {
        _gateway.GetProgressiveTaxTable().Returns(progressiveTaxTable);
        return this;
    }
}