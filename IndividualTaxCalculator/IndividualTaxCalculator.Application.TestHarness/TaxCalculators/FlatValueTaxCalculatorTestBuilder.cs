using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.ValueObjects;
using NSubstitute;

namespace IndividualTaxCalculator.Application.TestHarness.TaxCalculators;

public class FlatValueTaxCalculatorTestBuilder
{
    private readonly IFlatValueTaxCalculator _calculator;

    private FlatValueTaxCalculatorTestBuilder()
    {
        _calculator = Substitute.For<IFlatValueTaxCalculator>();
    }

    public static FlatValueTaxCalculatorTestBuilder Create()
    {
        return new FlatValueTaxCalculatorTestBuilder();
    }

    public IFlatValueTaxCalculator Build()
    {
        return _calculator;
    }

    public FlatValueTaxCalculatorTestBuilder WithCalculatedTax(TaxableAmount annualIncome,
        TaxCalculationResult returnedResult)
    {
        _calculator.CalculateTax(annualIncome).Returns(returnedResult);
        return this;
    }
}