using System.Text.Json;
using ConfPlan.Shared;

namespace ConfPlan.Client.States;

public class UserState
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _configuration;

  public UserState(
    HttpClient httpClient,
    IConfiguration configuration)
  {
    _httpClient = httpClient;
    _configuration = configuration;
  }

  public async Task<RegisterResult> RegisterAsync(string email, string password)
  {
    var payload = new User
    {
      Email = email,
      Password = password,
      IdRole = Guid.Empty
    };

    try
    {
      var response = await _httpClient.PostAsJsonAsync($"{_configuration["Url:ApiGateway"]}/api/auth/register", payload);
    
      if (response.IsSuccessStatusCode)
      {
        var user = await response.Content.ReadFromJsonAsync<User>();
        return new RegisterResult
        {
          Success = true,
          User = user
        };
      }
      else
      {
        var errorResponse = await response.Content.ReadAsStringAsync();
        var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
        return new RegisterResult
        {
          Success = false,
          Message = errorText?["message"] ?? "Une erreur s'est produite lors de l'enregistrement."
        };
      }


    }
    catch (Exception e)
    {
      return new RegisterResult
      {
        Success = false,
        Message = $"Exception client : {e.Message}"
      };
    }

    
  }
}