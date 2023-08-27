using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;
using NSubstitute;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;

public class TaxCalculationMappingGatewayTestBuilder
{
    private readonly ITaxCalculationMappingGateway _gateway;

    private TaxCalculationMappingGatewayTestBuilder()
    {
        _gateway = Substitute.For<ITaxCalculationMappingGateway>();
    }

    public static TaxCalculationMappingGatewayTestBuilder Create()
    {
        return new TaxCalculationMappingGatewayTestBuilder();
    }

    public ITaxCalculationMappingGateway Build()
    {
        return _gateway;
    }

    public TaxCalculationMappingGatewayTestBuilder WithMapping(Dictionary<PostalCode, TaxCalculationType> mapping)
    {
        _gateway.GetTaxCalculationMapping().Returns(mapping);
        return this;
    }
}