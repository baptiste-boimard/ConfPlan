using System.Text.Json;
using ConfPlan.Shared;

namespace ConfPlan.Client.States;

public class UserConferenceState
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _config;

  public UserConferenceState(
    HttpClient httpClient,
    IConfiguration config)
  {
    _httpClient = httpClient;
    _config = config;
  }

  // public async Task<UserConferenceResult> GetAllSubscription()
  // {
  //   
  // }
  
  public async Task<UserConferenceResult> Subscription(UserConference UserConf)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/userconferences/subscription", UserConf);

    if (response.IsSuccessStatusCode)
    {
      return new UserConferenceResult
      {
        Success = true,
        UserConference = await response.Content.ReadFromJsonAsync<UserConference>()
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new UserConferenceResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Une erreur s'est produite lors de l'enregistrement."
      };
    }
  }
  
  // public async Task<UserConferenceResult> Unsubscription()
  // {
  //   
  // }

}