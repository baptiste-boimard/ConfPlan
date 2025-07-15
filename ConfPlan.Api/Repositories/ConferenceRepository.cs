using ConfPlan.Api.Interfaces;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Repositories;

public class ConferenceRepository : IConferenceRepository
{
  private readonly PostgresDbContext _context;

  public ConferenceRepository(
    PostgresDbContext _context)
  {
    this._context = _context;
  }

  public async Task<List<Conference>> GetAllConferences()
  {
    var conferences = await _context.Conferences
      .Include(c => c.Room)
      .ToListAsync();
    return conferences;
  }
  
  public async Task<Conference> GetConferenceById(Guid id)
  {
    var conference = await _context.Conferences
      .Include(c => c.Room)
      .FirstOrDefaultAsync(c => c.Id == id);

    if (conference != null) return conference;

    return null;
  }
  
  public async Task<Conference> GetConferenceByDayAndTimeSlot(Conference conf)
  { 
    var existingConferenceAtSameDate = await _context.Conferences
      .Include(c => c.Room)
      .FirstOrDefaultAsync(c => c.Day == conf.Day && c.TimeSlot == conf.TimeSlot);

    if (existingConferenceAtSameDate != null) return existingConferenceAtSameDate;

    return null;
  }
  
  public async Task<Conference> AddConference(Conference conf)
  {
    _context.Conferences.Add(conf);
    var result = await _context.SaveChangesAsync();

    if (result <= 0) return null;

    return conf;
  }

  public async Task<Conference> UpdateConference(Conference conf)
  {
    _context.Conferences.Update(conf);
    var result = await _context.SaveChangesAsync();
    
    if(result <= 0) return null;
    
    return conf;
  }

  public async Task<Conference> DeleteConference(Conference conf)
  {
    _context.Conferences.Remove(conf);
    var result = await _context.SaveChangesAsync();
    
    if(result <= 0) return null;
    
    return conf;
  }
}