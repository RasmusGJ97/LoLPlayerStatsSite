using LoLPlayerStatsSite.RiotAPI.DTOs;
using System.Reflection;
using System.Text.Json;

namespace LoLPlayerStatsSite.RiotAPI
{
    public class RiotAPIProvider : IRiotAPIProvider
    {
        private readonly ILogger _log;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public RiotAPIProvider(ILogger<RiotAPIProvider> log, IConfiguration config, HttpClient client)
        {
            _log = log;
            _config = config;
            _httpClient = client;
        }

        public async Task<RiotGetUserResponseDto> GetSingleUserByGameNameAndTag(string gameName, string tag)
        {
            try
            {
                var apiKey = _config["RiotAPIkey:API-key"];
                var apiBaseAddress = _config["RiotAPIkey:BaseAddress"];

                var response = await _httpClient.GetAsync($"riot/account/v1/accounts/by-riot-id/{gameName}/{tag}?api_key={apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonSerializer.Deserialize<RiotGetUserResponseDto>(jsonResponse);
                    return userResponse;
                }
                else
                {
                    _log.LogWarning($"Failed to get user info. StatusCode: {response.StatusCode}", MethodBase.GetCurrentMethod()?.Name ?? "");

                    return null;
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }
    }
}
