using Dapper;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;
using IndividualTaxCalculator.Infrastructure;
using IndividualTaxCalculator.Integration.Sql.DataModels;
using Microsoft.Data.SqlClient;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class TaxCalculationGateway : ITaxCalculationGateway
{
    private readonly IApplicationSettings _applicationSettings;

    public TaxCalculationGateway(IApplicationSettings applicationSettings)
    {
        _applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
    }

    public async Task Save(TaxableAmount annualIncome, PostalCode postalCode, TaxCalculationResult taxCalculationResult)
    {
        await using var connection = new SqlConnection(_applicationSettings.SqlConnectionString);

        const string sql =
            "INSERT INTO TaxCalculations (AnnualIncome, PostalCode, TaxAmount, DateCreated) VALUES (@AnnualIncome, @PostalCode, @TaxAmount, @DateCreated)";

        var dataModel = new TaxCalculationDataModel
        {
            AnnualIncome = annualIncome.Amount,
            PostalCode = postalCode.Code,
            TaxAmount = taxCalculationResult.TaxAmount
        };

        await connection.ExecuteAsync(sql, dataModel);
    }
}