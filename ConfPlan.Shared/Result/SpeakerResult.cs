namespace ConfPlan.Shared;

public class SpeakerResult
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public List<Speaker>? Speakers { get; set; }
}