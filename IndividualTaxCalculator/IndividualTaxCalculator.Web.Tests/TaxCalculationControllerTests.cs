using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Application.TestHarness.Builders;
using IndividualTaxCalculator.Web.Controllers;
using IndividualTaxCalculator.Web.Models;

namespace IndividualTaxCalculator.Web.Tests;

[TestFixture]
public class TaxCalculationControllerTests
{
    [TestFixture]
    public class Index
    {
        [Test]
        public void ShouldReturnViewWithModel()
        {
            // Arrange
            var sut = SutFixtureBuilder.Create().Build();
            // Act
            var result = sut.Index() as ViewResult;
            // Assert
            result.Should().NotBeNull();

            var viewModel = result!.Model as TaxCalculationRequestViewModel;
            viewModel.Should().NotBeNull();
            viewModel!.PostalCode.Should().BeEmpty();
            viewModel.AnnualIncome.Should().Be(0);
        }
    }

    private class SutFixtureBuilder
    {
        private ITaxCalculationService _taxCalculationService;

        private SutFixtureBuilder()
        {
            _taxCalculationService = TaxCalculationServiceTestBuilder.Create().Build();
        }

        public static SutFixtureBuilder Create()
        {
            return new SutFixtureBuilder();
        }

        public TaxCalculationController Build()
        {
            return new TaxCalculationController(_taxCalculationService);
        }
    }
}