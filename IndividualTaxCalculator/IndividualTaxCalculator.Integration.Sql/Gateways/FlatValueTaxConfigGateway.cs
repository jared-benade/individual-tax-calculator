using Dapper;
using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Infrastructure;
using IndividualTaxCalculator.Integration.Sql.DataModels;
using Microsoft.Data.SqlClient;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class FlatValueTaxConfigGateway : IFlatValueTaxConfigGateway
{
    private readonly IApplicationSettings _applicationSettings;

    public FlatValueTaxConfigGateway(IApplicationSettings applicationSettings)
    {
        _applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
    }

    public async Task<FlatValueTaxConfig> GetConfig()
    {
        await using var connection = new SqlConnection(_applicationSettings.SqlConnectionString);

        const string sql = "SELECT Id, FlatValueAmount, AnnualThresholdAmount, TaxPercentage FROM FlatValueTaxConfig";

        var dataModel = await connection.QuerySingleAsync<FlatValueTaxConfigDataModel>(sql);

        return FlatValueTaxConfig.Create(dataModel.Id, dataModel.FlatValueAmount, dataModel.AnnualThresholdAmount,
            dataModel.TaxPercentage);
    }
}