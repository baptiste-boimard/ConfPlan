using ConfPlan.Api.Interfaces;
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
}