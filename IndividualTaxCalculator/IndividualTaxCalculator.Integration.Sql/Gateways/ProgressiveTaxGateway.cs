using Dapper;
using IndividualTaxCalculator.Domain.Entities;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Infrastructure;
using IndividualTaxCalculator.Integration.Sql.DataModels;
using Microsoft.Data.SqlClient;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class ProgressiveTaxGateway : IProgressiveTaxGateway
{
    private readonly IApplicationSettings _applicationSettings;

    public ProgressiveTaxGateway(IApplicationSettings applicationSettings)
    {
        _applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
    }

    public async Task<ProgressiveTaxTable> GetProgressiveTaxTable()
    {
        await using var connection = new SqlConnection(_applicationSettings.SqlConnectionString);

        const string sql = "SELECT Id, TaxPercentage, LowerBound, UpperBound FROM ProgressiveTaxBrackets";

        var dataModels = await connection.QueryAsync<ProgressiveTaxBracketDataModel>(sql);
        var progressiveTaxBrackets = dataModels.Select(CreateProgressiveTaxBracket);

        return ProgressiveTaxTable.Create(progressiveTaxBrackets);
    }

    private static ProgressiveTaxBracket CreateProgressiveTaxBracket(ProgressiveTaxBracketDataModel dataModel)
    {
        return ProgressiveTaxBracket.Create(dataModel.Id, dataModel.TaxPercentage, dataModel.LowerBound,
            dataModel.UpperBound);
    }
}