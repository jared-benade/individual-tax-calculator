namespace IndividualTaxCalculator.Domain.Entities;

public class FlatValueTaxConfig
{
    private FlatValueTaxConfig(Guid id, decimal flatValueAmount, decimal annualThresholdAmount, double taxPercentage)
    {
        Id = id;
        FlatValueAmount = flatValueAmount;
        AnnualThresholdAmount = annualThresholdAmount;
        TaxPercentage = taxPercentage;
    }

    public Guid Id { get; }
    public decimal FlatValueAmount { get; }
    public decimal AnnualThresholdAmount { get; }
    public double TaxPercentage { get; }

    // TODO: Add validation that numeric values cannot be less than or equal to 0
    public static FlatValueTaxConfig Create(Guid id, decimal flatValueAmount, decimal annualThresholdAmount,
        double taxPercentage)
    {
        return new FlatValueTaxConfig(id, flatValueAmount, annualThresholdAmount, taxPercentage);
    }
}