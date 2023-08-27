using FluentAssertions;
using IndividualTaxCalculator.Application.TaxCalculators;
using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Entities;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;

namespace IndividualTaxCalculator.Application.Tests.TaxCalculators;

[TestFixture]
public class ProgressiveTaxCalculatorTests
{
    [TestFixture]
    public class CalculateTax
    {
        [Test]
        public async Task GivenAnnualIncomeFallsInFirstBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal expectedTaxAmount = 2.5M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(50).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(0).WithUpperBound(100)
                        .WithTaxPercentage(5).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(101).WithTaxPercentage(30).Build())
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        [Test]
        public async Task GivenAnnualIncomeFallsInSecondBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal expectedTaxAmount = 20M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(200).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(0).WithUpperBound(100).WithTaxPercentage(5).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(101).WithUpperBound(250)
                        .WithTaxPercentage(15).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(251).WithTaxPercentage(30).Build())
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        [Test]
        public async Task GivenAnnualIncomeFallsInMiddleBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal expectedTaxAmount = 65M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(375).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(0).WithUpperBound(100).WithTaxPercentage(5).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(101).WithUpperBound(250)
                        .WithTaxPercentage(15).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(251).WithUpperBound(400).WithTaxPercentage(30).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(401).WithTaxPercentage(40).Build())
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        [Test]
        public async Task GivenAnnualIncomeFallsInLastBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal expectedTaxAmount = 152.5M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(600).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(0).WithUpperBound(100).WithTaxPercentage(5).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(101).WithUpperBound(250)
                        .WithTaxPercentage(15).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(251).WithUpperBound(400).WithTaxPercentage(30).Build(),
                    ProgressiveTaxBracketTestBuilder.Create().WithLowerBound(401).WithTaxPercentage(40).Build())
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        // Add poor man's acceptance testing until E2E tests can be added
        [TestFixture]
        public class AcceptanceTests
        {
            private readonly ProgressiveTaxBracket[] _progressiveTaxBrackets = new []
            {
                ProgressiveTaxBracket.Create(1, 10, 0, 8350),
                ProgressiveTaxBracket.Create(2, 15, 8351, 33950),
                ProgressiveTaxBracket.Create(3, 25, 33951, 82250),
                ProgressiveTaxBracket.Create(4, 28, 82251, 171550),
                ProgressiveTaxBracket.Create(5, 33, 171551, 372950),
                ProgressiveTaxBracket.Create(6, 35, 372951)
            };
            
            [Test]
        public async Task GivenAnnualIncomeFallsInFirstBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal annualIncomeAmount = 7500M;
            const decimal expectedTaxAmount = 750M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(_progressiveTaxBrackets)
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        [Test]
        public async Task GivenAnnualIncomeFallsInSecondBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal annualIncomeAmount = 26000M;
            const decimal expectedTaxAmount = 3482.50M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(_progressiveTaxBrackets)
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        [Test]
        public async Task GivenAnnualIncomeFallsInMiddleBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal annualIncomeAmount = 126452M;
            const decimal expectedTaxAmount = 29126.56M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(_progressiveTaxBrackets)
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        
        [Test]
        public async Task GivenAnnualIncomeFallsInLastBracket_ShouldCalculateTax()
        {
            // Arrange
            const decimal annualIncomeAmount = 475000M;
            const decimal expectedTaxAmount = 143933.50M;
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(annualIncomeAmount).Build();
            var progressiveTaxTable = ProgressiveTaxTableTestBuilder.Create()
                .WithTaxBrackets(_progressiveTaxBrackets)
                .Build();
            var progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create()
                .WithProgressiveTaxTable(progressiveTaxTable)
                .Build();

            var sut = SutFixtureBuilder.Create().WithProgressiveTaxGateway(progressiveTaxGateway).Build();
            // Act
            var result = await sut.CalculateTax(annualIncome);
            // Assert
            result.TaxAmount.Should().Be(expectedTaxAmount);
        }
        }
    }

    private class SutFixtureBuilder
    {
        private IProgressiveTaxGateway _progressiveTaxGateway;

        private SutFixtureBuilder()
        {
            _progressiveTaxGateway = ProgressiveTaxGatewayTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public ProgressiveTaxCalculator Build()
        {
            return new ProgressiveTaxCalculator(_progressiveTaxGateway);
        }

        public SutFixtureBuilder WithProgressiveTaxGateway(IProgressiveTaxGateway gateway)
        {
            _progressiveTaxGateway = gateway;
            return this;
        }
    }
}