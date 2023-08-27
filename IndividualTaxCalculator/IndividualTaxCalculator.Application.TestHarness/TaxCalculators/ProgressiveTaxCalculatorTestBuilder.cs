using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.ValueObjects;
using NSubstitute;

namespace IndividualTaxCalculator.Application.TestHarness.TaxCalculators;

public class ProgressiveTaxCalculatorTestBuilder
{
    private readonly IProgressiveTaxCalculator _calculator;

    private ProgressiveTaxCalculatorTestBuilder()
    {
        _calculator = Substitute.For<IProgressiveTaxCalculator>();
    }

    public static ProgressiveTaxCalculatorTestBuilder Create()
    {
        return new ProgressiveTaxCalculatorTestBuilder();
    }

    public IProgressiveTaxCalculator Build()
    {
        return _calculator;
    }

    public ProgressiveTaxCalculatorTestBuilder WithCalculatedTax(TaxableAmount annualIncome,
        TaxCalculationResult returnedResult)
    {
        _calculator.CalculateTax(annualIncome).Returns(returnedResult);
        return this;
    }
}