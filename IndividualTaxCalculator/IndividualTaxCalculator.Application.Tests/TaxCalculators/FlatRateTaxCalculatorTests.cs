using FluentAssertions;
using IndividualTaxCalculator.Application.TaxCalculators;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Application.Tests.TaxCalculators;

[TestFixture]
public class FlatRateTaxCalculatorTests
{
    [TestFixture]
    public class CalculateTax
    {
        [Test]
        public async Task GivenAnnualIncome_ShouldCalculateTax()
        {
            // Arrange
            const decimal flatRatePercentage = 10;
            var flatRateTaxConfigGateway = FlatRateTaxConfigGatewayTestBuilder.Create()
                .WithFlatRatePercentage(flatRatePercentage)
                .Build();
            var annualIncome = AnnualIncome.Create(200.45M);

            var sut = SutFixtureBuilder.Create().WithFlatRateTaxConfigGateway(flatRateTaxConfigGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(20.045M);
        }
    }

    private class SutFixtureBuilder
    {
        private IFlatRateTaxConfigGateway _flatRateTaxConfigGateway;

        private SutFixtureBuilder()
        {
            _flatRateTaxConfigGateway = FlatRateTaxConfigGatewayTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public FlatRateTaxCalculator Build()
        {
            return new FlatRateTaxCalculator(_flatRateTaxConfigGateway);
        }

        public SutFixtureBuilder WithFlatRateTaxConfigGateway(IFlatRateTaxConfigGateway gateway)
        {
            _flatRateTaxConfigGateway = gateway;
            return this;
        }
    }
}