using Dapper;
using FluentMigrator.Runner;
using IndividualTaxCalculator.Infrastructure;
using Microsoft.Data.SqlClient;

namespace IndividualTaxCalculator.Integration.Sql.Migrations.Utils;

public class MigrationService : IMigrationService
{
    private readonly IMigrationRunner _runner;
    private readonly IApplicationSettings _applicationSettings;

    public MigrationService(IMigrationRunner runner, IApplicationSettings applicationSettings)
    {
        _runner = runner;
        _applicationSettings = applicationSettings;
    }

    public void MigrateUp()
    {
        EnsureDatabaseExists();
        
        _runner.MigrateUp();
    }
    
    private void EnsureDatabaseExists()
    {
        var masterConnectionString = _applicationSettings.SqlMasterConnectionString;
    
        var parameters = new DynamicParameters();
        parameters.Add("name", _applicationSettings.DatabaseName);
        using var connection = new SqlConnection(masterConnectionString);
        var records = connection.Query
            ("SELECT name FROM sys.databases WHERE name = @name", parameters);
    
        if (!records.Any())
        {
            connection.Execute($"CREATE DATABASE [{_applicationSettings.DatabaseName}]");
        }
    }
}