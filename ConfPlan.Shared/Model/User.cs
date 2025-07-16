using System.Text.Json.Serialization;

namespace ConfPlan.Shared;

public class User
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  
  public Guid IdRole { get; set; }
  public Role? Role { get; set; }
  
  [JsonIgnore]
  public ICollection<UserConference> UserConferences { get; set; } = new List<UserConference>();
}