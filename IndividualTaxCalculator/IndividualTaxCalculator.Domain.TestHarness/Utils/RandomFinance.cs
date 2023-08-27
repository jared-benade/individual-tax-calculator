using Bogus;

namespace IndividualTaxCalculator.Domain.TestHarness.Utils;

public static class RandomFinance
{
    private static readonly Faker Faker = new();

    public static decimal PositiveAmount()
    {
        return Faker.Finance.Amount(0, 10000);
    }

    public static decimal NegativeAmount()
    {
        return Faker.Finance.Amount(-9999, -1);
    }
}