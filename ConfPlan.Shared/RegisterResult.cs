namespace ConfPlan.Shared;

public class RegisterResult
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public User? User { get; set; }
}