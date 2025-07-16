namespace ConfPlan.Shared;

public class UserConference
{
  public Guid Id { get; set; }
  public Guid IdUser { get; set; }
  public Guid IdConference { get; set; }
  
  public User User { get; set; }
  public Conference Conference { get; set; }
}