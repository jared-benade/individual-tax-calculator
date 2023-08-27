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
            var sut = new SutFixtureBuilder().Build();
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
        public TaxCalculationController Build()
        {
            return new TaxCalculationController();
        }
    }
}