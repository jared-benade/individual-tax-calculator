using Microsoft.Extensions.Configuration;

namespace IndividualTaxCalculator.Infrastructure;

public class ApplicationSettings : IApplicationSettings
{
    private readonly IConfiguration _configuration;

    public ApplicationSettings(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string DatabaseName => "IndividualTaxCalculator";

    public string SqlConnectionString =>
        _configuration.GetConnectionString("SqlConnection") ?? throw new InvalidOperationException();
    
    public string SqlMasterConnectionString =>
        _configuration.GetConnectionString("SqlMasterConnection") ?? throw new InvalidOperationException();
}