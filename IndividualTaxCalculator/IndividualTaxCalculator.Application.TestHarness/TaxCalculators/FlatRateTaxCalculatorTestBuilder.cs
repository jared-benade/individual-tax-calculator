using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Domain.ValueObjects;
using NSubstitute;

namespace IndividualTaxCalculator.Application.TestHarness.TaxCalculators;

public class FlatRateTaxCalculatorTestBuilder
{
    private readonly IFlatRateTaxCalculator _calculator;

    private FlatRateTaxCalculatorTestBuilder()
    {
        _calculator = Substitute.For<IFlatRateTaxCalculator>();
    }

    public static FlatRateTaxCalculatorTestBuilder Create()
    {
        return new FlatRateTaxCalculatorTestBuilder();
    }

    public IFlatRateTaxCalculator Build()
    {
        return _calculator;
    }

    public FlatRateTaxCalculatorTestBuilder WithCalculatedTax(TaxableAmount annualIncome,
        TaxCalculationResult returnedResult)
    {
        _calculator.CalculateTax(annualIncome).Returns(returnedResult);
        return this;
    }
}