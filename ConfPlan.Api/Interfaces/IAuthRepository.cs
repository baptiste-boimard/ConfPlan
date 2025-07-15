using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface IAuthRepository
{
  Task<User> GetOneUserByEmail(User user);
  Task<Role> GetRoleByName(string roleName);
  Task<User> RegisterUser(User user);
}