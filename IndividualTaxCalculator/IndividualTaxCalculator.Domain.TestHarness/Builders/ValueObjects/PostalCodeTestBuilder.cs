using IndividualTaxCalculator.Domain.ValueObjects;

namespace IndividualTaxCalculator.Domain.TestHarness.Builders.ValueObjects;

public class PostalCodeTestBuilder
{
    private string _code;

    private PostalCodeTestBuilder()
    {
        _code = "";
    }

    public static PostalCodeTestBuilder Create()
    {
        return new PostalCodeTestBuilder();
    }

    public PostalCode Build()
    {
        return PostalCode.Create(_code);
    }

    public PostalCodeTestBuilder WithCode(string code)
    {
        _code = code;
        return this;
    }
}