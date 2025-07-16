namespace ConfPlan.Shared;

public class UserConferenceResult
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public UserConference? UserConference { get; set; }
  public List<UserConference>? UserConferences { get; set; }
}