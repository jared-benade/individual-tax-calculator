using Dapper;
using IndividualTaxCalculator.Domain.Enums;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Domain.ValueObjects;
using IndividualTaxCalculator.Infrastructure;
using IndividualTaxCalculator.Integration.Sql.DataModels;
using Microsoft.Data.SqlClient;

namespace IndividualTaxCalculator.Integration.Sql.Gateways;

public class TaxCalculationMappingGateway : ITaxCalculationMappingGateway
{
    private readonly IApplicationSettings _applicationSettings;

    public TaxCalculationMappingGateway(IApplicationSettings applicationSettings)
    {
        _applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
    }

    public async Task<Dictionary<PostalCode, TaxCalculationType>> GetTaxCalculationMapping()
    {
        await using var connection = new SqlConnection(_applicationSettings.SqlConnectionString);

        const string sql = @"SELECT p.Id, p.Code, p.TaxCalculationTypeId, t.Id, t.TypeId
                FROM PostalCode p 
                INNER JOIN TaxCalculationType t ON p.TaxCalculationTypeId = t.Id";

        var postalCodes =
            await connection.QueryAsync<PostalCodeDataModel, TaxCalculationTypeDataModel, PostalCodeDataModel>(sql,
                (postalCode, taxCalculationType) =>
                {
                    postalCode.TaxCalculationType = taxCalculationType;
                    return postalCode;
                },
                splitOn: "TaxCalculationTypeId");

        return postalCodes.ToDictionary(dataModel => PostalCode.Create(dataModel.Code), dataModel =>
            (TaxCalculationType)dataModel.TaxCalculationType.TypeId);
    }
}