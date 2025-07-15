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
  
  public async Task<SpeakerResult> CreateAsync(Speaker speaker)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/speakers/create", speaker);

    if (response.IsSuccessStatusCode)
    {
      var speakerAdded = await response.Content.ReadFromJsonAsync<Speaker>();
      return new SpeakerResult
      {
        Success = true,
        Speaker =  speakerAdded ?? new Speaker()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new SpeakerResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Problème au niveau de la création du conférencier."
      };
    }
  }
  
  public async Task<SpeakerResult> UpdateAsync(Speaker speaker)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/speakers/update", speaker);

    if (response.IsSuccessStatusCode)
    {
      var speakerAdded = await response.Content.ReadFromJsonAsync<Speaker>();
      return new SpeakerResult
      {
        Success = true,
        Speaker =  speakerAdded ?? new Speaker()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new SpeakerResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Problème au niveau de la création du conférencier."
      };
    }
  }
  
  public async Task<SpeakerResult> DeleteAsync(Speaker speaker)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/speakers/delete", speaker);

    if (response.IsSuccessStatusCode)
    {
      var speakerDeleted = await response.Content.ReadFromJsonAsync<Speaker>();
      return new SpeakerResult
      {
        Success = true,
        Speaker =  speakerDeleted ?? new Speaker()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new SpeakerResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Problème au niveau de la suppression du conférencier."
      };
    }
  }
}