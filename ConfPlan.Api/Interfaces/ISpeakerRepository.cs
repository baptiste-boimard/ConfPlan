using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface ISpeakerRepository
{
  Task<List<Speaker>> GetAllSpeakers();
}