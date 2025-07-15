namespace ConfPlan.Shared;

public class RoomResult
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public List<Room>? Rooms { get; set; }
}