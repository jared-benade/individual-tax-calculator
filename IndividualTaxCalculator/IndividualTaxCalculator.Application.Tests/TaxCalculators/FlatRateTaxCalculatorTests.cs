using FluentAssertions;
using IndividualTaxCalculator.Application.TaxCalculators;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;

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
            const double flatRatePercentage = 10;
            const decimal annualIncomeAmount = 200.45M;
            const decimal expectedTaxAmount = 20.045M;
            var flatRateTaxConfigGateway = FlatRateTaxConfigGatewayTestBuilder.Create()
                .WithFlatRatePercentage(flatRatePercentage)
                .Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();

            var sut = SutFixtureBuilder.Create().WithFlatRateTaxConfigGateway(flatRateTaxConfigGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }

        // Add poor man's acceptance testing until E2E tests can be added
        [TestFixture]
        public class AcceptanceTests
        {
            [Test]
            public async Task GivenRealisticAnnualIncome_ShouldCalculateTax()
            {
                // Arrange
                const double flatRatePercentage = 17.5;
                const decimal annualIncomeAmount = 82000M;
                const decimal expectedTaxAmount = 14350M;
                var flatRateTaxConfigGateway = FlatRateTaxConfigGatewayTestBuilder.Create()
                    .WithFlatRatePercentage(flatRatePercentage)
                    .Build();
                var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();

                var sut = SutFixtureBuilder.Create().WithFlatRateTaxConfigGateway(flatRateTaxConfigGateway).Build();
                // Act
                var result = await sut.CalculateTax(annualIncome);
                // Assert
                result.TaxAmount.Should().Be(expectedTaxAmount);
            }
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