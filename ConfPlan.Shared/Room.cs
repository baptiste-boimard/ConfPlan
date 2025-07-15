using System.Text.Json.Serialization;

namespace ConfPlan.Shared;

public class Room
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public int MaxCapacity { get; set; }
  public int CurrentCapacity { get; set; }
  
  [JsonIgnore]
  public Conference Conference{ get; set; }
}