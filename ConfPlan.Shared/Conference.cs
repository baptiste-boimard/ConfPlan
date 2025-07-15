namespace ConfPlan.Shared;

public class Conference
{
  public Guid Id { get; set; }
    
  public string Day { get; set; } = string.Empty;
  public string TimeSlot { get; set; } = string.Empty;
  public Guid IdRoom { get; set; }

  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;

  public string SpeakerName { get; set; } = string.Empty;
  public string? SpeakerBio { get; set; }
  public string? SpeakerPhotoUrl { get; set; }
  
  public Room? Room { get; set; }
}