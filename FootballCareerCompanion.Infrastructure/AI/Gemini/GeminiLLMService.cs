using FootballCareerCompanion.Application.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Infrastructure.AI.Gemini
{
    public class GeminiLLMService : ILLMService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiLLMService(
            HttpClient httpClient, 
            IOptions<GeminiOptions> options)
        {
            _httpClient = httpClient;
            _apiKey = options.Value.ApiKey;
        }
        public async Task<string> GenerateAsync(
            string prompt,
            CancellationToken cancellationToken = default)
        {
            var url =
                $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new {text = prompt}
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);

            var response = await _httpClient.PostAsync(
                url,
                new StringContent(json, Encoding.UTF8, "application/json"),
                cancellationToken);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            using var doc = JsonDocument.Parse(responseContent);

            var generatedText =
                doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return generatedText ?? string.Empty;
                
        }
    }
}
