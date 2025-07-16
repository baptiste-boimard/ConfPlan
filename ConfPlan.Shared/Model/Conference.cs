using System.Text.Json.Serialization;

namespace ConfPlan.Shared;

public class Conference
{
  public Guid Id { get; set; }
    
  public string Day { get; set; } = string.Empty;
  public string TimeSlot { get; set; } = string.Empty;
  public Guid IdRoom { get; set; }

  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;

  public Guid IdSpeaker { get; set; }
  
  public int Participant { get; set; } = 0;
  
  public Room? Room { get; set; }
  public Speaker? Speaker { get; set; }
  
  [JsonIgnore]
  public ICollection<UserConference> UserConferences { get; set; } = new List<UserConference>();
}