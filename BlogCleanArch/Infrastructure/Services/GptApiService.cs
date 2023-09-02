

using System.Net.Http.Headers;
using System.Text;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.services;

public class GptApiService
{
    private readonly HttpClient _httpClient;
    private readonly GptApiConfiguration _apiConfig;

    public GptApiService(HttpClient httpClient, IOptions<GptApiConfiguration> apiConfig)
    {
        _httpClient = httpClient;
        _apiConfig = apiConfig.Value;
    }

    public async Task<string> DetectHateSpeech(string text)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            prompt = text,
            max_tokens = 1,
            stop = ["safe."]
        };

        var requestJson = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiConfig.ApiKey);

        var response = await _httpClient.PostAsync(_apiConfig.ApiEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
            string generatedText = jsonResponse.choices[0].text;

            return generatedText;
        }
        else
        {
            throw new Exception($"API request failed with status code {response.StatusCode}");
        }
    }
}
