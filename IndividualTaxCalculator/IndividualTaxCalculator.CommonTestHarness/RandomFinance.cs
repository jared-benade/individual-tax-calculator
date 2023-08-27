namespace IndividualTaxCalculator.CommonTestHarness;

public static class RandomFinance
{
    public static decimal PositiveAmount()
    {
        return RandomUtil.Faker.Finance.Amount(0, 10000);
    }

    public static decimal NegativeAmount()
    {
        return RandomUtil.Faker.Finance.Amount(-9999, -1);
    }
}