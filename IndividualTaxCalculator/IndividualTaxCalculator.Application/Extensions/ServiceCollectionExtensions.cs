using IndividualTaxCalculator.Application.Interfaces;
using IndividualTaxCalculator.Application.TaxCalculators;
using Microsoft.Extensions.DependencyInjection;

namespace IndividualTaxCalculator.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTaxCalculators()
            .AddScoped<ITaxCalculationService, TaxCalculationService>();
    }

    private static IServiceCollection AddTaxCalculators(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IFlatRateTaxCalculator, FlatRateTaxCalculator>()
            .AddScoped<IFlatValueTaxCalculator, FlatValueTaxCalculator>()
            .AddScoped<IProgressiveTaxCalculator, ProgressiveTaxCalculator>();
    }
}