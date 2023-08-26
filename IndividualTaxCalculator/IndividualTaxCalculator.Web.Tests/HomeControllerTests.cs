using IndividualTaxCalculator.Web.Controllers;
using Microsoft.Extensions.Logging;

namespace IndividualTaxCalculator.Web.Tests;

[TestFixture]
public class HomeControllerTests
{
    [TestFixture]
    public class Index
    {
        [Test]
        public void ShouldReturnViewWithNoModel()
        {
            // Arrange
            var sut = new SutFixtureBuilder().Build();
            // Act
            var result = sut.Index() as ViewResult;
            // Assert
            result.Should().NotBeNull();
            result!.Model.Should().BeNull();
        }
    }

    private class SutFixtureBuilder
    {
        private readonly ILogger<HomeController> _logger = Substitute.For<ILogger<HomeController>>();

        public HomeController Build()
        {
            return new HomeController(_logger);
        }
    }
}