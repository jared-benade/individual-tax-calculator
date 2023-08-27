namespace IndividualTaxCalculator.Infrastructure;

public interface IApplicationSettings
{
    string DatabaseName { get; }
    string SqlConnectionString { get; }
    string SqlMasterConnectionString { get; }
}