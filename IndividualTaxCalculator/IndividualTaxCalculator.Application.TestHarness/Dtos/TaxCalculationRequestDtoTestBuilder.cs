using IndividualTaxCalculator.Application.Dtos;
using IndividualTaxCalculator.CommonTestHarness;

namespace IndividualTaxCalculator.Application.TestHarness.Dtos;

public class TaxCalculationRequestDtoTestBuilder
{
    private decimal _annualAmount;
    private string _postalCode;

    private TaxCalculationRequestDtoTestBuilder()
    {
        _postalCode = "";
        _annualAmount = 0;
    }

    private static TaxCalculationRequestDtoTestBuilder Create()
    {
        return new TaxCalculationRequestDtoTestBuilder();
    }

    public static TaxCalculationRequestDtoTestBuilder CreateWithRandomProps()
    {
        return Create().WithRandomProps();
    }

    public TaxCalculationRequestDto Build()
    {
        return new TaxCalculationRequestDto(_postalCode, _annualAmount);
    }

    private TaxCalculationRequestDtoTestBuilder WithRandomProps()
    {
        _postalCode = RandomString.PostalCode();
        _annualAmount = RandomFinance.PositiveAmount();

        return this;
    }
}