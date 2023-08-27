using FluentAssertions;
using IndividualTaxCalculator.Application.TaxCalculators;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Entities;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;

namespace IndividualTaxCalculator.Application.Tests.TaxCalculators;

[TestFixture]
public class FlatValueTaxCalculatorTests
{
    [TestFixture]
    public class CalculateTax
    {
        [TestCase(300)]
        [TestCase(900)]
        public async Task GivenAnnualIncomeIsNotLessThanAnnualThreshold_ShouldCalculateTaxWithFlatValue(
            decimal annualIncomeAmount)
        {
            // Arrange
            const decimal annualThresholdAmount = 300;
            const decimal flatValueAmount = 500;
            var flatValueTaxConfig = FlatValueTaxConfigTestBuilder.Create()
                .WithAnnualThresholdAmount(annualThresholdAmount)
                .WithFlatValueAmount(flatValueAmount)
                .Build();
            var flatValueTaxConfigGateway = FlatValueTaxConfigGatewayTestBuilder.Create()
                .WithConfig(flatValueTaxConfig)
                .Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();

            var sut = SutFixtureBuilder.Create().WithFlatValueTaxConfigGateway(flatValueTaxConfigGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(flatValueAmount);
        }

        [Test]
        public async Task GivenAnnualIncomeIsLessThanAnnualThreshold_ShouldCalculateTaxBasedOnPercentageOfAnnualIncome()
        {
            // Arrange
            const decimal annualThresholdAmount = 300;
            const decimal annualIncomeAmount = 200;
            const double taxPercentage = 5;
            const decimal expectedTaxAmount = 10;
            var flatValueTaxConfig = FlatValueTaxConfigTestBuilder.Create()
                .WithAnnualThresholdAmount(annualThresholdAmount)
                .WithTaxPercentage(taxPercentage)
                .Build();
            var flatValueTaxConfigGateway = FlatValueTaxConfigGatewayTestBuilder.Create()
                .WithConfig(flatValueTaxConfig)
                .Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();

            var sut = SutFixtureBuilder.Create().WithFlatValueTaxConfigGateway(flatValueTaxConfigGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        // Add poor man's acceptance testing until E2E tests can be added
        [TestFixture]
        public class AcceptanceTests
        {
            private const decimal AnnualThresholdAmount = 200000M;
            private const decimal FlatValueAmount = 10000M;
            private const double TaxPercentage = 5;
            
            [Test]
            public async Task GivenAnnualIncomeIsNotLessThanAnnualThreshold_ShouldCalculateTaxWithFlatValue()
            {
                // Arrange
                const decimal annualIncomeAmount = 400000M;
                var flatValueTaxConfig = FlatValueTaxConfigTestBuilder.Create()
                    .WithAnnualThresholdAmount(AnnualThresholdAmount)
                    .WithFlatValueAmount(FlatValueAmount)
                    .Build();
                var flatValueTaxConfigGateway = FlatValueTaxConfigGatewayTestBuilder.Create()
                    .WithConfig(flatValueTaxConfig)
                    .Build();
                var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();

                var sut = SutFixtureBuilder.Create().WithFlatValueTaxConfigGateway(flatValueTaxConfigGateway).Build();
                // Act
                var result = await sut.CalculateTax(annualIncome);
                // Assert
                result.TaxAmount.Should().Be(FlatValueAmount);
            }
            
            [Test]
            public async Task GivenAnnualIncomeIsLessThanAnnualThreshold_ShouldCalculateTax()
            {
                // Arrange
                const decimal annualIncomeAmount = 150000;
                const decimal expectedTaxAmount = 7500;
                var flatValueTaxConfig = FlatValueTaxConfigTestBuilder.Create()
                    .WithAnnualThresholdAmount(AnnualThresholdAmount)
                    .WithTaxPercentage(TaxPercentage)
                    .Build();
                var flatValueTaxConfigGateway = FlatValueTaxConfigGatewayTestBuilder.Create()
                    .WithConfig(flatValueTaxConfig)
                    .Build();
                var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();

                var sut = SutFixtureBuilder.Create().WithFlatValueTaxConfigGateway(flatValueTaxConfigGateway).Build();
                // Act
                var result = await sut.CalculateTax(annualIncome);
                // Assert
                result.TaxAmount.Should().Be(expectedTaxAmount);
            }
        }
    }

    private class SutFixtureBuilder
    {
        private IFlatValueTaxConfigGateway _flatValueTaxConfigGateway;

        private SutFixtureBuilder()
        {
            _flatValueTaxConfigGateway = FlatValueTaxConfigGatewayTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public FlatValueTaxCalculator Build()
        {
            return new FlatValueTaxCalculator(_flatValueTaxConfigGateway);
        }

        public SutFixtureBuilder WithFlatValueTaxConfigGateway(IFlatValueTaxConfigGateway gateway)
        {
            _flatValueTaxConfigGateway = gateway;
            return this;
        }
    }
}