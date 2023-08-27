using Microsoft.Extensions.DependencyInjection;

namespace IndividualTaxCalculator.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonInfrastructure(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IApplicationSettings, ApplicationSettings>();
    }
}