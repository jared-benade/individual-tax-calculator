using Bogus;

namespace IndividualTaxCalculator.Domain.TestHarness;

public static class RandomFinance
{
    private static readonly Faker Faker = new Faker();

    public static decimal PositiveAmount() => Faker.Finance.Amount(0, 10000);
    public static decimal NegativeAmount() => Faker.Finance.Amount(-9999, -1);
}