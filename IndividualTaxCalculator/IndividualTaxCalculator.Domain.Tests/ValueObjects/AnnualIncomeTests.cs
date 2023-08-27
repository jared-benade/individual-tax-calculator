using IndividualTaxCalculator.CommonTestHarness;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Tests.ValueObjects;

[TestFixture]
public class AnnualIncomeTests
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
            var annualIncomeCreation = () => AnnualIncome.Create(amount);
            // Assert
            annualIncomeCreation.Should().Throw<Exception>().WithMessage("Annual income cannot be less than 0");
        }

        [Test]
        public void GivenAmountIsZero_ShouldNotThrowException()
        {
            // Arrange
            const decimal amount = 0;
            // Act
            var annualIncomeCreation = () => AnnualIncome.Create(amount);
            // Assert
            annualIncomeCreation.Should().NotThrow();
        }

        [Test]
        public void GivenAmountIsPositive_ShouldNotThrowException()
        {
            // Arrange
            var amount = RandomFinance.PositiveAmount();
            // Act
            var annualIncomeCreation = () => AnnualIncome.Create(amount);
            // Assert
            annualIncomeCreation.Should().NotThrow();
        }
    }
}