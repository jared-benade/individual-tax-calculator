using System.Reflection;
using FluentMigrator.Runner;
using IndividualTaxCalculator.Domain.Gateways;
using IndividualTaxCalculator.Integration.Sql.Gateways;
using IndividualTaxCalculator.Integration.Sql.Migrations.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace IndividualTaxCalculator.Integration.Sql.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDependencies(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddFluentMigrator()
            .AddGateways()
            .AddScoped<IMigrationService, MigrationService>();
    }

    private static IServiceCollection AddFluentMigrator(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddFluentMigratorCore()
            .ConfigureRunner(builder => builder
                .AddSqlServer()
                .WithGlobalConnectionString(
                    "Server=(localdb)\\MSSQLLocalDB;Database=IndividualTaxCalculator;Integrated Security=true")
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .AddLogging(builder => builder.AddFluentMigratorConsole());
    }

    private static IServiceCollection AddGateways(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<ITaxCalculationMappingGateway, TaxCalculationMappingGateway>()
            .AddScoped<IFlatRateTaxConfigGateway, FlatRateTaxConfigGateway>()
            .AddScoped<IFlatValueTaxConfigGateway, FlatValueTaxConfigGateway>()
            .AddScoped<IProgressiveTaxGateway, ProgressiveTaxGateway>()
            .AddScoped<ITaxCalculationResultGateway, TaxCalculationResultGateway>();
    }
}