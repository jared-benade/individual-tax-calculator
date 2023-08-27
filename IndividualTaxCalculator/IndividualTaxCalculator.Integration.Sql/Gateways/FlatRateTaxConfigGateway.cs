using Dapper;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Infrastructure;
using IndividualTaxCalculator.Integration.Sql.DataModels;
using Microsoft.Data.SqlClient;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class FlatRateTaxConfigGateway : IFlatRateTaxConfigGateway
{
    private readonly IApplicationSettings _applicationSettings;

    public FlatRateTaxConfigGateway(IApplicationSettings applicationSettings)
    {
        _applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
    }

    public async Task<double> GetFlatRatePercentage()
    {
        await using var connection = new SqlConnection(_applicationSettings.SqlConnectionString);

        const string sql = "SELECT Id, FlatRatePercentage FROM FlatRateTaxConfig";

        var dataModel = await connection.QuerySingleAsync<FlatRateTaxConfigDataModel>(sql);

        return dataModel.FlatRatePercentage;
    }
}