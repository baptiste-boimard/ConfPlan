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
  
  public async Task<Speaker> GetOneSpeakersByName(string name)
  {
    var speaker = await _context.Speakers
      .FirstOrDefaultAsync(s => s.Name == name);
    
    return speaker;
  }
  
  public async Task<Speaker> GetOneSpeakersById(Guid id)
  {
    var speaker = await _context.Speakers
      .FirstOrDefaultAsync(s => s.Id == id);
    
    return speaker;
  }
  
  public async Task<Speaker> AddSpeaker(Speaker speaker)
  {
    _context.Speakers.Add(speaker);
    var result = await _context.SaveChangesAsync();
    
    if(result <= 0)
      return null;
    
    return speaker;
  }
  
  public async Task<Speaker> UpdateSpeaker(Speaker speaker)
  {
    _context.Speakers.Update(speaker);
    var result = await _context.SaveChangesAsync();
    
    if(result <= 0)
      return null;
    
    return speaker;
  }
  
  public async Task<Speaker> DeleteSpeaker(Speaker speaker)
  {
    _context.Speakers.Remove(speaker);
    var result = await _context.SaveChangesAsync();
    
    if(result <= 0)
      return null;
    
    return speaker;
  }
}