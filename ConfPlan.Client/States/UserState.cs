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

  public async Task<User> RegisterAsync(string email, string password)
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
      return await response.Content.ReadFromJsonAsync<User>();
    }
    else
    {
      var error = await response.Content.ReadAsStringAsync();
      Console.WriteLine($"Error during registration: {error}");

    }

    return null;
  }
}