using System.Text.Json.Serialization;

namespace ConfPlan.Shared;

public class Speaker
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Bio { get; set; }
  public string PhotoUrl { get; set; }
  
  [JsonIgnore]
  public Conference? Conference{ get; set; }
  [JsonIgnore]
  public ICollection<Conference> Conferences { get; set; } = new List<Conference>();
}