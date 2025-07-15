using ConfPlan.Api.Interfaces;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Controllers;

[ApiController]
[Route("api/conferences")]
public class ConferenceController : ControllerBase
{
  private readonly IConferenceRepository _conferenceRepository;
  private readonly PostgresDbContext _context;

  public ConferenceController(
    IConferenceRepository conferenceRepository,
    PostgresDbContext context)
  {
    _conferenceRepository = conferenceRepository;
    _context = context;
  }

  [HttpGet("getall")]
  public async Task<IActionResult> GetAll()
  {
    var conferences = await _conferenceRepository.GetAllConferences();
    
    return Ok(conferences);
  }

  [HttpPost ("create")]
  public async Task<IActionResult> Create([FromBody] Conference conf)
  {
    if (string.IsNullOrWhiteSpace(conf.Day) || string.IsNullOrWhiteSpace(conf.TimeSlot))
      return BadRequest("Champs requis");
    
    // Vérifier si une conference existe déjà sur les meme creanaux
    var existingConferenceAtSameDate= await _conferenceRepository.GetConferenceByDayAndTimeSlot(conf);

    if (existingConferenceAtSameDate != null)
      return Conflict(new { message = "Ce créneau est dèjà pris" });
    
    conf.Id = Guid.NewGuid();

    var newConference = await _conferenceRepository.AddConference(conf);
    
    if(newConference == null)
      return StatusCode(500, new { message = "Erreur lors de l'enregistrement de la conférence." });
    
    return Ok(conf);
  }

  [HttpPost("update")]
  public async Task<IActionResult> Update([FromBody] Conference updated)
  {
    var conf = await _context.Conferences.FindAsync(updated.Id);
    
    if (conf == null) return NotFound( new { message = "La conférence n'existe pas." });

    conf.Day = updated.Day;
    conf.TimeSlot = updated.TimeSlot;
    conf.Title = updated.Title;
    conf.Room = updated.Room;
    conf.Description = updated.Description;
    conf.SpeakerName = updated.SpeakerName;
    conf.SpeakerBio = updated.SpeakerBio;
    conf.SpeakerPhotoUrl = updated.SpeakerPhotoUrl;

    var updatingConference = await _conferenceRepository.UpdateConference(conf);
    
    if(updatingConference == null)
      return StatusCode(500, new { message = "Erreur lors de la mise à jour de la conférence." });
    
    return Ok(conf);
  }

  [HttpPost("delete")]
  public async Task<IActionResult> Delete([FromBody] Conference conf)
  {
    var existingConf = await _context.Conferences.FindAsync(conf.Id);
    
    if (conf == null) return NotFound( new { message = "La conférence n'existe pas." });
    
    var result = await _conferenceRepository.DeleteConference(existingConf);
    
    if(result == null)
      return StatusCode(500, new { message = "Erreur lors de la suppression de la conférence." });
    
    return Ok(conf);
  }
}