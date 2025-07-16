using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface IUserConferenceRepository
{
  Task<List<Conference>> GetAllUserConferences(Guid id);
  Task<UserConference> GetOneUserConference(UserConference userConference);
  Task<UserConference> AddUserConference(UserConference userConference);
  Task<UserConference> RemoveUserConference(UserConference userConference);
}