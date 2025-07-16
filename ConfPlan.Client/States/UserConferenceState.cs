using System.Text.Json;
using ConfPlan.Shared;

namespace ConfPlan.Client.States;

public class UserConferenceState
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _config;
  private readonly UserState _userState;

  public UserConferenceState(
    HttpClient httpClient,
    IConfiguration config,
    UserState userState)
  {
    _httpClient = httpClient;
    _config = config;
    _userState = userState;
  }

  public async Task<UserConferenceResult> GetAllSubscription()
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/userconferences/getall", _userState.CurrentUser);

    if (response.IsSuccessStatusCode)
    {
      return new UserConferenceResult
      {
        Success = true,
        UserConferences = await response.Content.ReadFromJsonAsync<List<Conference>>()
      };
    }
    else
    {
      // var errorResponse = await response.Content.ReadAsStringAsync();
      // var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new UserConferenceResult
      {
        Success = false,
        Message = "Une erreur s'est produite lors de l'enregistrement."
      };
    }
  }
  
  public async Task<UserConferenceResult> Subscription(UserConference userConf)
  {
    var response = await _httpClient.PostAsJsonAsync(
      $"{_config["Url:ApiGateway"]}/api/userconferences/subscription",
      userConf
    );

    if (response.IsSuccessStatusCode)
    {
      var data = await response.Content.ReadFromJsonAsync<UserConference>();
      return new UserConferenceResult
      {
        Success = true,
        UserConference = data
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();

      string? message = null;

      try
      {
        // Tente de lire un dictionnaire { string, JsonElement }
        var errorJson = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(errorResponse);
        if (errorJson != null && errorJson.TryGetValue("message", out var msg))
        {
          message = msg.GetString();
        }
      }
      catch
      {
        // Si le JSON n'est pas dans le format attendu, ne plante pas
        message = "Erreur serveur (format inconnu).";
      }

      return new UserConferenceResult
      {
        Success = false,
        Message = message ?? "Une erreur s'est produite lors de l'inscription à la conférence."
      };
    }
  }

  
  public async Task<UserConferenceResult> Unsubscription(UserConference userConf)
  {
    var response = await _httpClient.PostAsJsonAsync(
      $"{_config["Url:ApiGateway"]}/api/userconferences/unsubscription",
      userConf
    );

    if (response.IsSuccessStatusCode)
    {
      var data = await response.Content.ReadFromJsonAsync<UserConference>();
      return new UserConferenceResult
      {
        Success = true,
        UserConference = data
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();

      string? message = null;

      try
      {
        // Tente de lire un dictionnaire { string, JsonElement }
        var errorJson = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(errorResponse);
        if (errorJson != null && errorJson.TryGetValue("message", out var msg))
        {
          message = msg.GetString();
        }
      }
      catch
      {
        // Si le JSON n'est pas dans le format attendu, ne plante pas
        message = "Erreur serveur (format inconnu).";
      }

      return new UserConferenceResult
      {
        Success = false,
        Message = message ?? "Une erreur s'est produite lors de l'inscription à la conférence."
      };
    }
  }

}