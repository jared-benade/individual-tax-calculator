using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class PostalCode : ValueObject
{
    private PostalCode(string code)
    {
        Code = code;
    }

    public string Code { get; }

    public static PostalCode Create(string code)
    {
        return new PostalCode(code);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}