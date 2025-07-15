using System.Text.Json;
using ConfPlan.Shared;

namespace ConfPlan.Client.States;

public class ConferenceState
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _config;

  public ConferenceState(HttpClient httpClient, IConfiguration config)
  {
    _httpClient = httpClient;
    _config = config;
  }

  public async Task<ConferenceResult> GetAllAsync()
  {
    var response = await _httpClient.GetAsync($"{_config["Url:ApiGateway"]}/api/conferences/getall");

    if (response.IsSuccessStatusCode)
    {
      var conferences = await response.Content.ReadFromJsonAsync<List<Conference>>();
      return new ConferenceResult
      {
        Success = true,
        Conferences = conferences ?? new List<Conference>()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new ConferenceResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Problème au niveau de la récupération des conférence."
      };
    }
  }

  public async Task<RoomResult> GetAllRoomsAsync()
  {
    var response = await _httpClient.GetAsync($"{_config["Url:ApiGateway"]}/api/conferences/getallRooms");

    if (response.IsSuccessStatusCode)
    {
      var rooms = await response.Content.ReadFromJsonAsync<List<Room>>();
      return new RoomResult()
      {
        Success = true,
        Rooms = rooms ?? new List<Room>()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new RoomResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Problème au niveau de la récupération des salles."
      };
    }
  }

  public async Task<ConferenceResult> CreateAsync(Conference conf)
  {
    
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/conferences/create", conf);

    if (response.IsSuccessStatusCode)
    {
      return new ConferenceResult
      {
        Success = true,
        Conference = await response.Content.ReadFromJsonAsync<Conference>()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new ConferenceResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Une erreur s'est produite lors de l'enregistrement."
      };
    }
  }

  public async Task<ConferenceResult> UpdateAsync(Conference conf)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/conferences/update", conf);

    if (response.IsSuccessStatusCode)
    {
      return new ConferenceResult
      {
        Success = true,
        Conference = await response.Content.ReadFromJsonAsync<Conference>()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new ConferenceResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Une erreur s'est produite lors de la mise à jour."
      };
    }
  }

  public async Task<ConferenceResult> DeleteAsync(Conference conf)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/conferences/delete", conf);
    
    if (response.IsSuccessStatusCode)
    {
      return new ConferenceResult
      {
        Success = true
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new ConferenceResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Une erreur s'est produite lors de l'effacement de la conférence."
      };
    }
  }
}