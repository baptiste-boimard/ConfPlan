namespace ConfPlan.Shared;

public class ConferenceResult
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public Conference? Conference { get; set; }
  public List<Conference>? Conferences { get; set; }
}