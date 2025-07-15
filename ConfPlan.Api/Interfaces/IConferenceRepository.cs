using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface IConferenceRepository
{
  Task<List<Conference>> GetAllConferences();
  Task<Conference> GetConferenceById(Guid id);
  Task<Conference> GetConferenceByDayAndTimeSlot(Conference conf);
  Task<Conference> AddConference(Conference conf);
  Task<Conference> DeleteConference(Conference conf);
}