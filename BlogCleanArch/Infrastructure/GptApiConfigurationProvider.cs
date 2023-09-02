using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class GptApiConfigurationProvider
{
    public static GptApiConfiguration Configure(IConfiguration configuration)
    {
        var apiConfig = new GptApiConfiguration();
        configuration.GetSection("GptApi").Bind(apiConfig);
        return apiConfig;
    }
}


