namespace IndividualTaxCalculator.CommonTestHarness;

public static class RandomString
{
    public static string PostalCode()
    {
        return RandomUtil.Faker.Address.ZipCode();
    }
}