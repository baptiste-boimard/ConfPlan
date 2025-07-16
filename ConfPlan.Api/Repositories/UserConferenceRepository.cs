using ConfPlan.Api.Interfaces;
using ConfPlan.Shared;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Repositories;

public class UserConferenceRepository : IUserConferenceRepository
{
  private readonly PostgresDbContext _context;

  public UserConferenceRepository(PostgresDbContext context)
  {
    _context = context;
  }
  
  public async Task<List<UserConference>> GetAllUserConferences(Guid id)
  {
    var userConferences = await _context.UserConferences
      .Where(u => u.IdUser == id )
      .Include(u => u.Conference)
      .ThenInclude(c => c.Room)
      .OrderBy(u => u.Conference.Day)
      .ThenBy(u => u.Conference.TimeSlot)
      .ToListAsync();
    return userConferences;
  }
  
  public async Task<UserConference> GetOneUserConference(UserConference userConference)
  {
    var existingUserConference = await _context.UserConferences
      .FirstOrDefaultAsync(uc => uc.IdUser == userConference.IdUser && uc.IdConference == userConference.IdConference);
    
    return existingUserConference;
  }
  
  public async Task<UserConference> AddUserConference(UserConference userConference)
  {
    _context.UserConferences.Add(userConference);
    var result = await _context.SaveChangesAsync();
    
    if(result <= 0)
      return null;
    
    return userConference;
  }
}