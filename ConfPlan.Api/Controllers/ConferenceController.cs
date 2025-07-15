using ConfPlan.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Controllers;

public class ConferenceController : ControllerBase
{
  private readonly PostgresDbContext _context;

  public ConferenceController(PostgresDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var conferences = await _context.Conferences.ToListAsync();
    return Ok(conferences);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] Conference conf)
  {
    conf.Id = Guid.NewGuid();
    _context.Conferences.Add(conf);
    await _context.SaveChangesAsync();
    return Ok(conf);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Guid id, [FromBody] Conference updated)
  {
    var conf = await _context.Conferences.FindAsync(id);
    if (conf == null) return NotFound();

    conf.Day = updated.Day;
    conf.TimeSlot = updated.TimeSlot;
    conf.Title = updated.Title;
    conf.Description = updated.Description;
    conf.SpeakerName = updated.SpeakerName;
    conf.SpeakerBio = updated.SpeakerBio;
    conf.SpeakerPhotoUrl = updated.SpeakerPhotoUrl;

    await _context.SaveChangesAsync();
    return Ok(conf);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var conf = await _context.Conferences.FindAsync(id);
    if (conf == null) return NotFound();

    _context.Conferences.Remove(conf);
    await _context.SaveChangesAsync();
    return NoContent();
  }
}