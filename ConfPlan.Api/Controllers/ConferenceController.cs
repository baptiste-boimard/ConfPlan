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
  private readonly ISpeakerRepository _speakerRepository;

  public ConferenceController(
    IConferenceRepository conferenceRepository,
    ISpeakerRepository speakerRepository)
  {
    _conferenceRepository = conferenceRepository;
    _speakerRepository = speakerRepository;
  }

  [HttpGet("getall")]
  public async Task<IActionResult> GetAll()
  {
    var conferences = await _conferenceRepository.GetAllConferences();
    
    return Ok(conferences);
  }

  [HttpGet("getallRooms")]
  public async Task<IActionResult> GetAllRooms()
  {
    var rooms = await _conferenceRepository.GetAllRooms();

    return Ok(rooms);
  }

  [HttpPost ("create")]
  public async Task<IActionResult> Create([FromBody] Conference conf)
  {
    if (string.IsNullOrWhiteSpace(conf.Day) || string.IsNullOrWhiteSpace(conf.TimeSlot))
      return BadRequest( new { message = "Champs requis" });
    
    // Vérifier si une conference existe déjà sur les meme creaneaux et la meme salle
    var existingConferenceAtSameDate= await _conferenceRepository.GetConferenceByDayAndTimeSlot(conf);

    if (existingConferenceAtSameDate != null)
      return Conflict(new { message = "Ce créneau pour cette salle est dèjà pris" });
    
    conf.Id = Guid.NewGuid();

    var newConference = await _conferenceRepository.AddConference(conf);
    
    if(newConference == null)
      return StatusCode(500, new { message = "Erreur lors de l'enregistrement de la conférence." });
    
    return Ok(conf);
  }

  [HttpPost("update")]
  public async Task<IActionResult> Update([FromBody] Conference updated)
  {
    // Vérifier si une conference existe déjà sur les meme creaneaux et la meme salle
    var existingConferenceAtSameDate= await _conferenceRepository.GetConferenceByDayAndTimeSlot(updated);
    
    if(existingConferenceAtSameDate != null && existingConferenceAtSameDate.Id != updated.Id)
      return Conflict(new { message = "Ce créneau ou cette salle sont déjà réservés" });
    
    var conf = await _conferenceRepository.GetConferenceById(updated.Id);
    
    if (conf == null) return NotFound( new { message = "La conférence n'existe pas." });
    
    var room = await _conferenceRepository.GetOneRoomById(updated.IdRoom);
    var speaker = await _speakerRepository.GetOneSpeakersById(updated.IdSpeaker);

    conf.Day = updated.Day;
    conf.TimeSlot = updated.TimeSlot;
    conf.IdRoom = updated.IdRoom;
    conf.Room = room;
    conf.Title = updated.Title;
    conf.Description = updated.Description;
    conf.IdSpeaker = updated.IdSpeaker;
    conf.Speaker = speaker;

    var updatingConference = await _conferenceRepository.UpdateConference(conf);
    
    if(updatingConference == null)
      return StatusCode(500, new { message = "Erreur lors de la mise à jour de la conférence." });
    
    return Ok(conf);
  }

  [HttpPost("delete")]
  public async Task<IActionResult> Delete([FromBody] Conference conf)
  {
    var existingConf = await _conferenceRepository.GetConferenceById(conf.Id);
    
    if (conf == null) return NotFound( new { message = "La conférence n'existe pas." });
    
    var result = await _conferenceRepository.DeleteConference(existingConf);
    
    if(result == null)
      return StatusCode(500, new { message = "Erreur lors de la suppression de la conférence." });
    
    return Ok(conf);
  }
}