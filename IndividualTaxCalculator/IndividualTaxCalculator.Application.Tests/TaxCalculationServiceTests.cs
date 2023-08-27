using FluentAssertions;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Application.TestHarness.Dtos;
using IndividualTaxCalculator.Application.TestHarness.TaxCalculators;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;
using IndividualTaxCalculator.Domain.ValueObjects;
using NSubstitute;

namespace IndividualTaxCalculator.Application.Tests;

[TestFixture]
public class TaxCalculationServiceTests
{
    [TestFixture]
    public class CalculateTaxForIndividual
    {
        [Test]
        public async Task GivenTaxTypeIsFlatRate_ShouldCalculateTax()
        {
            // Arrange
            var request = TaxCalculationRequestDtoTestBuilder.CreateWithRandomProps().Build();
            var postalCode = PostalCodeTestBuilder.Create().WithCode(request.PostalCode).Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(request.AnnualIncome).Build();

            var taxCalculationTypesMapping = new Dictionary<PostalCode, TaxCalculationType>
            {
                { postalCode, TaxCalculationType.FlatRate }
            };
            var taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create()
                .WithMapping(taxCalculationTypesMapping)
                .Build();
            var returnedTaxCalculationResult = TaxCalculationResultTestBuilder.CreateWithRandomProps().Build();
            var flatRateTaxCalculator = FlatRateTaxCalculatorTestBuilder.Create()
                .WithCalculatedTax(annualIncome, returnedTaxCalculationResult)
                .Build();

            var sut = SutFixtureBuilder.Create()
                .WithTaxCalculationMappingGateway(taxCalculationMappingGateway)
                .WithFlatRateTaxCalculator(flatRateTaxCalculator)
                .Build();
            // Act
            var result = await sut.CalculateTaxForIndividual(request);
            // Assert
            result.TaxAmount.Should().Be(returnedTaxCalculationResult.TaxAmount);
        }

        [Test]
        public async Task GivenTaxTypeIsFlatValue_ShouldCalculateTax()
        {
            // Arrange
            var request = TaxCalculationRequestDtoTestBuilder.CreateWithRandomProps().Build();
            var postalCode = PostalCodeTestBuilder.Create().WithCode(request.PostalCode).Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(request.AnnualIncome).Build();

            var taxCalculationTypesMapping = new Dictionary<PostalCode, TaxCalculationType>
            {
                { postalCode, TaxCalculationType.FlatValue }
            };
            var taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create()
                .WithMapping(taxCalculationTypesMapping)
                .Build();
            var returnedTaxCalculationResult = TaxCalculationResultTestBuilder.CreateWithRandomProps().Build();
            var flatValueTaxCalculator = FlatValueTaxCalculatorTestBuilder.Create()
                .WithCalculatedTax(annualIncome, returnedTaxCalculationResult)
                .Build();

            var sut = SutFixtureBuilder.Create()
                .WithTaxCalculationMappingGateway(taxCalculationMappingGateway)
                .WithFlatValueTaxCalculator(flatValueTaxCalculator)
                .Build();
            // Act
            var result = await sut.CalculateTaxForIndividual(request);
            // Assert
            result.TaxAmount.Should().Be(returnedTaxCalculationResult.TaxAmount);
        }


        [Test]
        public async Task GivenTaxTypeIsProgressive_ShouldCalculateTax()
        {
            // Arrange
            var request = TaxCalculationRequestDtoTestBuilder.CreateWithRandomProps().Build();
            var postalCode = PostalCodeTestBuilder.Create().WithCode(request.PostalCode).Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(request.AnnualIncome).Build();

            var taxCalculationTypesMapping = new Dictionary<PostalCode, TaxCalculationType>
            {
                { postalCode, TaxCalculationType.Progressive }
            };
            var taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create()
                .WithMapping(taxCalculationTypesMapping)
                .Build();
            var returnedTaxCalculationResult = TaxCalculationResultTestBuilder.CreateWithRandomProps().Build();
            var progressiveTaxCalculator = ProgressiveTaxCalculatorTestBuilder.Create()
                .WithCalculatedTax(annualIncome, returnedTaxCalculationResult)
                .Build();

            var sut = SutFixtureBuilder.Create()
                .WithTaxCalculationMappingGateway(taxCalculationMappingGateway)
                .WithProgressiveTaxCalculator(progressiveTaxCalculator)
                .Build();
            // Act
            var result = await sut.CalculateTaxForIndividual(request);
            // Assert
            result.TaxAmount.Should().Be(returnedTaxCalculationResult.TaxAmount);
        }

        [Test]
        public async Task ShouldPersistTaxCalculationResult()
        {
            // Arrange
            var request = TaxCalculationRequestDtoTestBuilder.CreateWithRandomProps().Build();
            var postalCode = PostalCodeTestBuilder.Create().WithCode(request.PostalCode).Build();
            var annualIncome = AnnualIncomeTestBuilder.Create().WithAmount(request.AnnualIncome).Build();

            var taxCalculationTypesMapping = new Dictionary<PostalCode, TaxCalculationType>
            {
                { postalCode, TaxCalculationType.FlatRate }
            };
            var taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create()
                .WithMapping(taxCalculationTypesMapping)
                .Build();
            var returnedTaxCalculationResult = TaxCalculationResultTestBuilder.CreateWithRandomProps().Build();
            var flatRateTaxCalculator = FlatRateTaxCalculatorTestBuilder.Create()
                .WithCalculatedTax(annualIncome, returnedTaxCalculationResult)
                .Build();

            TaxCalculationResult? savedTaxCalculationResult = null;
            PostalCode? savedPostalCode = null;
            var taxCalculationResultGateway = Substitute.For<ITaxCalculationResultGateway>();
            await taxCalculationResultGateway.Save(
                Arg.Do<TaxCalculationResult>(arg => savedTaxCalculationResult = arg),
                Arg.Do<PostalCode>(arg => savedPostalCode = arg));

            var sut = SutFixtureBuilder.Create()
                .WithTaxCalculationMappingGateway(taxCalculationMappingGateway)
                .WithFlatRateTaxCalculator(flatRateTaxCalculator)
                .WithTaxCalculationResultGateway(taxCalculationResultGateway)
                .Build();
            // Act
            await sut.CalculateTaxForIndividual(request);
            // Assert
            savedTaxCalculationResult.Should().NotBeNull();
            savedTaxCalculationResult.Should().Be(returnedTaxCalculationResult);

            savedPostalCode.Should().NotBeNull();
            savedPostalCode.Should().Be(postalCode);
        }
    }

    private class SutFixtureBuilder
    {
        private IFlatRateTaxCalculator _flatRateTaxCalculator;
        private ITaxCalculationMappingGateway _taxCalculationMappingGateway;
        private IFlatValueTaxCalculator _flatValueTaxCalculator;
        private IProgressiveTaxCalculator _progressiveTaxCalculator;
        private ITaxCalculationResultGateway _taxCalculationResultGateway;

        private SutFixtureBuilder()
        {
            _taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create().Build();
            _flatRateTaxCalculator = FlatRateTaxCalculatorTestBuilder.Create().Build();
            _flatValueTaxCalculator = FlatValueTaxCalculatorTestBuilder.Create().Build();
            _progressiveTaxCalculator = ProgressiveTaxCalculatorTestBuilder.Create().Build();
            _taxCalculationResultGateway = TaxCalculationResultGatewayTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public TaxCalculationService Build()
        {
            return new TaxCalculationService(_taxCalculationMappingGateway, _flatRateTaxCalculator,
                _flatValueTaxCalculator, _progressiveTaxCalculator, _taxCalculationResultGateway);
        }

        public SutFixtureBuilder WithTaxCalculationMappingGateway(
            ITaxCalculationMappingGateway taxCalculationMappingGateway)
        {
            _taxCalculationMappingGateway = taxCalculationMappingGateway;
            return this;
        }

        public SutFixtureBuilder WithFlatRateTaxCalculator(IFlatRateTaxCalculator flatRateTaxCalculator)
        {
            _flatRateTaxCalculator = flatRateTaxCalculator;
            return this;
        }

        public SutFixtureBuilder WithFlatValueTaxCalculator(IFlatValueTaxCalculator flatValueTaxCalculator)
        {
            _flatValueTaxCalculator = flatValueTaxCalculator;
            return this;
        }

        public SutFixtureBuilder WithProgressiveTaxCalculator(IProgressiveTaxCalculator progressiveTaxCalculator)
        {
            _progressiveTaxCalculator = progressiveTaxCalculator;
            return this;
        }

        public SutFixtureBuilder WithTaxCalculationResultGateway(
            ITaxCalculationResultGateway taxCalculationResultGateway)
        {
            _taxCalculationResultGateway = taxCalculationResultGateway;
            return this;
        }
    }
}