using ConfPlan.Api.Interfaces;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConfPlan.Api.Controllers;

[ApiController]
[Route("api/speakers")]
public class SpeakerController : ControllerBase
{
  private readonly ISpeakerRepository _speakerRepository;

  public SpeakerController(ISpeakerRepository speakerRepository)
  {
    _speakerRepository = speakerRepository;
  }
  
  [HttpGet("getall")]
  public async Task<IActionResult> GetAll()
  {
    var speakers = await _speakerRepository.GetAllSpeakers();
    
    return Ok(speakers);
  }
  
  [HttpPost("create")]
  public async Task<IActionResult> Create([FromBody] Speaker speaker)
  {
    if (string.IsNullOrWhiteSpace(speaker.Name) || string.IsNullOrWhiteSpace(speaker.Bio))
      return BadRequest(new { message = "Champs requis" });
    
    // Vérifier si un conférencier existe déjà avec le même nom
    var existingSpeaker = await _speakerRepository.GetOneSpeakersByName(speaker.Name);
    
    if(existingSpeaker != null) return Conflict(new { message = "Un conférencier avec ce nom existe déjà." });
    
    speaker.Id = Guid.NewGuid();
    
    var newSpeaker = await _speakerRepository.AddSpeaker(speaker);
    
    if (newSpeaker == null)
      return StatusCode(500, new { message = "Erreur lors de l'enregistrement du conférencier." });
    
    return Ok(newSpeaker);
  }
  
  [HttpPost("update")]
  public async Task<IActionResult> Update([FromBody] Speaker speaker)
  {
    if (string.IsNullOrWhiteSpace(speaker.Name) || string.IsNullOrWhiteSpace(speaker.Bio))
      return BadRequest(new { message = "Champs requis" });
    
    // Vérifier si un conférencier existe déjà avec le même nom
    var existingSpeaker = await _speakerRepository.GetOneSpeakersByName(speaker.Name);
    
    if(existingSpeaker != null) return Conflict(new { message = "Un conférencier avec ce nom existe déjà." });
    
    var speakerToUpdate = await _speakerRepository.GetOneSpeakersById(speaker.Id);
    
    
    if (speakerToUpdate == null)
      return NotFound(new { message = "Conférencier non trouvé." });

    speaker.Name = speaker.Name;
    speaker.Bio = speaker.Bio;
    speaker.PhotoUrl = speaker.PhotoUrl;
    
    var newSpeaker = await _speakerRepository.UpdateSpeaker(speaker);
    
    if (newSpeaker == null)
      return StatusCode(500, new { message = "Erreur lors de l'enregistrement du conférencier." });
    
    return Ok(newSpeaker);
  }
  
  [HttpPost("delete")]
  public async Task<IActionResult> Delete([FromBody] Speaker speaker)
  {
    // Vérifier si ce conférencier existe
    var existingSpeaker = await _speakerRepository.GetOneSpeakersById(speaker.Id);
    
    if(existingSpeaker == null) return Conflict(new { message = "Ce conférencier n'existe pas." });
    
    var deletedSpeaker = await _speakerRepository.DeleteSpeaker(existingSpeaker);
    
    if (deletedSpeaker == null)
      return StatusCode(500, new { message = "Erreur lors de l'enregistrement du conférencier." });
    
    return Ok(deletedSpeaker);
  }
}