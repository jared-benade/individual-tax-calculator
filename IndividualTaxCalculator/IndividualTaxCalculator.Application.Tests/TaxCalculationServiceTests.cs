using FluentAssertions;
using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Application.TestHarness;
using IndividualTaxCalculator.Application.TestHarness.Dtos;
using IndividualTaxCalculator.Application.TestHarness.TaxCalculators;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Gateways;
using IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;
using IndividualTaxCalculator.Domain.ValueObjects;

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
    }

    private class SutFixtureBuilder
    {
        private ITaxCalculationMappingGateway _taxCalculationMappingGateway;
        private IFlatRateTaxCalculator _flatRateTaxCalculator;

        private SutFixtureBuilder()
        {
            _taxCalculationMappingGateway = TaxCalculationMappingGatewayTestBuilder.Create().Build();
            _flatRateTaxCalculator = FlatRateTaxCalculatorTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public TaxCalculationService Build()
        {
            return new TaxCalculationService(_taxCalculationMappingGateway, _flatRateTaxCalculator);
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
    }
}