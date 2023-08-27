using IndividualTaxCalculator.CommonTestHarness;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Tests.ValueObjects;

[TestFixture]
public class TaxableAmountTests
{
    [TestFixture]
    public class Create
    {
        [Test]
        public void GivenNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var amount = RandomFinance.NegativeAmount();
            // Act
            var taxableAmountCreation = () => TaxableAmount.Create(amount);
            // Assert
            taxableAmountCreation.Should().Throw<Exception>().WithMessage("Taxable amount cannot be negative");
        }

        [Test]
        public void GivenAmountIsZero_ShouldNotThrowException()
        {
            // Arrange
            const decimal amount = 0;
            // Act
            var taxableAmountCreation = () => TaxableAmount.Create(amount);
            // Assert
            taxableAmountCreation.Should().NotThrow();
        }

        [Test]
        public void GivenAmountIsPositive_ShouldNotThrowException()
        {
            // Arrange
            var amount = RandomFinance.PositiveAmount();
            // Act
            var taxableAmountCreation = () => TaxableAmount.Create(amount);
            // Assert
            taxableAmountCreation.Should().NotThrow();
        }
    }

    [TestFixture]
    public class CalculateTax
    {
        [Test]
        public void ShouldReturnCalculatedTaxBasedOnTaxPercentage()
        {
            // Arrange
            const double taxPercentage = 15;
            const decimal amount = 200;
            const decimal expectedTaxAmount = 30;

            var sut = TaxableAmount.Create(amount);
            // Act
            var result = sut.CalculateTax(taxPercentage);
            // Assert
            result.Should().Be(expectedTaxAmount);
        }
    }
}