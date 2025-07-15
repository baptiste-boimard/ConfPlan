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

  public User? CurrentUser { get; private set; }
  
  public void SetUser(User user)
  {
    CurrentUser = user;
  }

  public void Logout()
  {
    CurrentUser = null;
  }

  public async Task<AuthResult> RegisterAsync(string email, string password)
  {
    var payload = new User
    {
      Email = email,
      Password = password,
      IdRole = Guid.Empty
    };

   
    var response = await _httpClient.PostAsJsonAsync($"{_configuration["Url:ApiGateway"]}/api/auth/register", payload);
  
    if (response.IsSuccessStatusCode)
    {
      var user = await response.Content.ReadFromJsonAsync<User>();
      SetUser(user);
      return new AuthResult
      {
        Success = true,
        User = user
      };
    }
    else
    {
      var errorResponse = await response.Content.ReadAsStringAsync();
      var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
      return new AuthResult
      {
        Success = false,
        Message = errorText?["message"] ?? "Une erreur s'est produite lors de l'enregistrement."
      };
    }
  }
  
  public async Task<AuthResult> LoginAsync(string email, string password)
  {
    var payload = new
    {
      Email = email,
      Password = password
    };
    
    var response = await _httpClient.PostAsJsonAsync(
      $"{_configuration["Url:ApiGateway"]}/api/auth/login", payload);

    if (response.IsSuccessStatusCode)
    {
      var user = await response.Content.ReadFromJsonAsync<User>();
      SetUser(user);
      return new AuthResult
      {
        Success = true,
        User = user
      };
    }

    var errorResponse = await response.Content.ReadAsStringAsync();
    var errorText = JsonSerializer.Deserialize<Dictionary<string, string>>(errorResponse);
    return new AuthResult
    {
      Success = false,
      Message = errorText?["message"] ?? "Email ou mot de passe incorrect."
    };
  }
}