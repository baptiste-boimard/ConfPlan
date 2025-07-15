using System.Text.Json.Serialization;

namespace ConfPlan.Shared;

public class Role
{
  public Guid Id { get; set; }
  public string RoleName { get; set; }

  [JsonIgnore]
  public ICollection<User>? Users { get; set; }
}