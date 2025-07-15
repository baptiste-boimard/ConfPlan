using ConfPlan.Api.Interfaces;
using ConfPlan.Shared;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Repositories;

public class AuthRepository : IAuthRepository
{
  private readonly PostgresDbContext _context;

  public AuthRepository(PostgresDbContext context)
  {
    _context = context;
  }

  public async Task<User> GetOneUserByEmail(User user)
  {
    var existingUser = await _context.Users
      .FirstOrDefaultAsync(u => u.Email == user.Email);

    if (existingUser != null) return existingUser;

    return null;
  }
  
  public async Task<Role> GetRoleByName(string roleName)
  {
    return await _context.Roles
      .FirstOrDefaultAsync(r => r.RoleName == roleName);
  }
  
  public async Task<User> RegisterUser(User user)
  {
    _context.Users.Add(user);
    var result = await _context.SaveChangesAsync();

    if (result <= 0) return null;

    return user;
  }
}