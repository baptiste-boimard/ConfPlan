using System.Text.Json;
using ConfPlan.Shared;

namespace ConfPlan.Client.States;

public class SpeakerState
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _config;

  public SpeakerState(HttpClient httpClient, IConfiguration config)
  {
    _httpClient = httpClient;
    _config = config;
  }

  public async Task<SpeakerResult> GettAllSpeakersAsync()
  {
    var response = await _httpClient.GetAsync($"{_config["Url:ApiGateway"]}/api/speakers/getall");

    if (response.IsSuccessStatusCode)
    {
      var speakers = await response.Content.ReadFromJsonAsync<List<Speaker>>();
      return new SpeakerResult()
      {
        Success = true,
        Speakers =  speakers ?? new List<Speaker>()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new SpeakerResult()
      {
        Success = false,
        Message = errorText?["message"] ?? "Problème au niveau de la récupération des conférenciers."
      };
    }
  }
}