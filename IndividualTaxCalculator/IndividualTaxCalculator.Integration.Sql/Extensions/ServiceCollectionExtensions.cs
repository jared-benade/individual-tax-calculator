using System.Reflection;
using FluentMigrator.Runner;
using IndividualTaxCalculator.Integration.Sql.Migrations.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace IndividualTaxCalculator.Integration.Sql.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDependencies(this IServiceCollection serviceCollection)
    {
        return AddFluentMigrator(serviceCollection)
            .AddScoped<IMigrationService, MigrationService>();
    }

    private static IServiceCollection AddFluentMigrator(IServiceCollection serviceCollection)
    {
        return serviceCollection.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString("Server=(localdb)\\MSSQLLocalDB;Database=IndividualTaxCalculator;Integrated Security=true")
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .AddLogging(builder => builder.AddFluentMigratorConsole());
    }
}