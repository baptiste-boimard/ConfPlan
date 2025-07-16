using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface IUserConferenceRepository
{
  Task<List<UserConference>> GetAllUserConferences(Guid id);
  Task<UserConference> GetOneUserConference(UserConference userConference);
  Task<UserConference> AddUserConference(UserConference userConference);
}