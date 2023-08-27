using IndividualTaxCalculator.Domain.Common;

namespace IndividualTaxCalculator.Domain.ValueObjects;

public class PostalCode : ValueObject
{
    private PostalCode(string code)
    {
        Code = code;
    }

    public static PostalCode Create(string code)
    {
        return new PostalCode(code);
    }
    
    public string Code { get; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}