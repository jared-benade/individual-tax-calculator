using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;

namespace IndividualTaxCalculator.Application.Tests;

[TestFixture]
public class TaxCalculationServiceTests
{
    [TestFixture]
    public class CalculateTaxForIndividual
    {
    }

    private class SutFixtureBuilder
    {
        private readonly ITaxCalculationMappingGateway _taxCalculationMappingGateway;

        private SutFixtureBuilder()
        {
            _taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public TaxCalculationService Build()
        {
            return new TaxCalculationService(_taxCalculationMappingGateway);
        }
    }
}