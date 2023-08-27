using IndividualTaxCalculator.Domain.TestHarness;
using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.Tests.ValueObjects;

[TestFixture]
public class IncomeTests
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
            var incomeCreation = () => Income.Create(amount);
            // Assert
            incomeCreation.Should().Throw<Exception>().WithMessage("Income cannot be less than 0");
        }
        
        [Test]
        public void GivenAmountIsZero_ShouldNotThrowException()
        {
            // Arrange
            const decimal amount = 0;
            // Act
            var incomeCreation = () => Income.Create(amount);
            // Assert
            incomeCreation.Should().NotThrow();
        }
        
        [Test]
        public void GivenAmountIsPositive_ShouldNotThrowException()
        {
            // Arrange
            var amount = RandomFinance.PositiveAmount();
            // Act
            var incomeCreation = () => Income.Create(amount);
            // Assert
            incomeCreation.Should().NotThrow();
        }
    }
}