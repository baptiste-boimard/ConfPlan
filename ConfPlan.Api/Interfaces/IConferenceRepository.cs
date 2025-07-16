using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface IConferenceRepository
{
  Task<List<Conference>> GetAllConferences();
  Task<List<Room>> GetAllRooms();
  Task<Room> GetOneRoomById(Guid id);
  Task<Conference> GetConferenceById(Guid id);
  Task<Conference> GetConferenceByDayAndTimeSlot(Conference conf);
  Task<Conference> AddConference(Conference conf);
  Task<Conference> UpdateConference(Conference conf);
  Task<Conference> DeleteConference(Conference conf);
}