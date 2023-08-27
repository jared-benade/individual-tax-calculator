using IndividualTaxCalculator.Application.Interfaces;
using NSubstitute;

namespace IndividualTaxCalculator.Application.TestHarness.Builders;

public class TaxCalculationServiceTestBuilder
{
    private readonly ITaxCalculationService _service;

    private TaxCalculationServiceTestBuilder()
    {
        _service = Substitute.For<ITaxCalculationService>();
    }

    public static TaxCalculationServiceTestBuilder Create()
    {
        return new TaxCalculationServiceTestBuilder();
    }

    public ITaxCalculationService Build()
    {
        return _service;
    }
}