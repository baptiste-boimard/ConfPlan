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

  public async Task<List<Conference>> GetAllAsync()
  {
    return await _httpClient.GetFromJsonAsync<List<Conference>>($"{_config["Url:ApiGateway"]}/api/conferences") ?? new();
  }

  public async Task<bool> CreateAsync(Conference conf)
  {
    var response = await _httpClient.PostAsJsonAsync($"{_config["Url:ApiGateway"]}/api/conferences", conf);
    return response.IsSuccessStatusCode;
  }

  public async Task<bool> UpdateAsync(Conference conf)
  {
    var response = await _httpClient.PutAsJsonAsync($"{_config["Url:ApiGateway"]}/api/conferences/{conf.Id}", conf);
    return response.IsSuccessStatusCode;
  }

  public async Task<bool> DeleteAsync(Guid id)
  {
    var response = await _httpClient.DeleteAsync($"{_config["Url:ApiGateway"]}/api/conferences/{id}");
    return response.IsSuccessStatusCode;
  }
}