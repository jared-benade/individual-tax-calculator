using Bogus;

namespace IndividualTaxCalculator.CommonTestHarness;

public static class RandomUtil
{
    static RandomUtil()
    {
        Faker = new Faker();
    }

    public static Faker Faker { get; }
}