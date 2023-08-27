using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness;

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
        private readonly ITaxCalculationMappingGateway _taxCalculationMappingGateway =
            TaxCalculationMappingGatewayTestBuilder.Create().Build();

        private SutFixtureBuilder()
        {
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