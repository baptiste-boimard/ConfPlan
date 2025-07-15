using ConfPlan.Api.Interfaces;
using ConfPlan.Shared;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Repositories;

public class SpeakerRepository : ISpeakerRepository
{
  private readonly PostgresDbContext _context;

  public SpeakerRepository(PostgresDbContext context)
  {
    _context = context;
  }
  
  public async Task<List<Speaker>> GetAllSpeakers()
  {
    var speakers = await _context.Speakers
      .ToListAsync();
    return speakers;
  }
}