using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.TestHarness.Builders.Entities;

namespace IndividualTaxCalculator.Domain.Tests.Entities;

[TestFixture]
public class ProgressiveTaxTableTests
{
    [TestFixture]
    public class Create
    {
        [Test]
        public void GivenTaxBrackets_ShouldSetOrderedTaxBracketsByLowerBound()
        {
            // Arrange
            var secondTaxBracket = ProgressiveTaxBracketTestBuilder.Create()
                .WithLowerBound(101)
                .WithUpperBound(250)
                .WithTaxPercentage(15)
                .Build();
            var fourthTaxBracket = ProgressiveTaxBracketTestBuilder.Create()
                .WithLowerBound(401)
                .WithTaxPercentage(40)
                .Build();
            var thirdTaxBracket = ProgressiveTaxBracketTestBuilder.Create()
                .WithLowerBound(251)
                .WithUpperBound(400)
                .WithTaxPercentage(30)
                .Build();
            var firstTaxBracket = ProgressiveTaxBracketTestBuilder.Create()
                .WithLowerBound(0)
                .WithUpperBound(100)
                .WithTaxPercentage(5)
                .Build();

            var taxBrackets = new[]
            {
                secondTaxBracket,
                fourthTaxBracket,
                thirdTaxBracket,
                firstTaxBracket
            };
            // Act
            var progressiveTaxTable = ProgressiveTaxTable.Create(taxBrackets);
            // Assert
            progressiveTaxTable.OrderedTaxBrackets.Should().BeEquivalentTo(new[]
            {
                firstTaxBracket,
                secondTaxBracket,
                thirdTaxBracket,
                fourthTaxBracket
            });
        }
    }
}