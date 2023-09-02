
using Domain.Entities;
using Infrastructure.services;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;
public class GptApiService : IGptApiService
{
    private readonly GptApiConfiguration _apiConfig;

    public GptApiService(IOptions<GptApiConfiguration> apiConfig)
    {
        _apiConfig = apiConfig.Value;
    }

    public string GetApiKey()
    {
        return _apiConfig.ApiKey;
    }

    public string GetApiEndpoint()
    {
        return _apiConfig.ApiEndpoint;
    }
}