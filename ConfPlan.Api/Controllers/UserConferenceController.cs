using ConfPlan.Api.Interfaces;
using ConfPlan.Api.Services;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConfPlan.Api.Controllers;

[ApiController]
[Route("api/userconferences")]
public class UserConferenceController : ControllerBase
{
  private readonly IUserConferenceRepository _userConferenceRepository;
  private readonly PlaceManagement _placeManagement;

  public UserConferenceController(
    IUserConferenceRepository userConferenceRepository,
    PlaceManagement placeManagement)
  {
    _userConferenceRepository = userConferenceRepository;
    _placeManagement = placeManagement;
  }

  [HttpPost("getall")]
  public async Task<IActionResult> GetAllUserConferences([FromBody] User user)
  {
    var userConferences = await _userConferenceRepository.GetAllUserConferences(user.Id);
    
    return Ok(userConferences);
  }
  
  [HttpPost("subscription")]
  public async Task<IActionResult> Subscription([FromBody] UserConference userConf)
  {
    if (userConf.IdUser == Guid.Empty || userConf.IdConference == Guid.Empty)
      return BadRequest(new { message = "Champs requis" });
    
    // Vérifier si un userConference existe déjà
    var existingUserConference = await _userConferenceRepository.GetOneUserConference(userConf);
    
    // Vérification s'il reste des places disponibles pour la conférence
    // TODO: Ajouter la vérification des places disponibles
    
    if(existingUserConference != null)
      return Conflict(new { message = "Vous êtes dèjà inscrit à cette conférence." });
    
    userConf.Id = Guid.NewGuid();
    
    var newUserConference = await _userConferenceRepository.AddUserConference(userConf);
    
    if(newUserConference == null)
      return StatusCode(500, new { message = "Erreur lors de l'enregistrement de l'inscription." });
    
    // Il faut augmenter le nombre de participants a cette conference de 1
    await _placeManagement.AddOneParticipant(userConf.IdConference);
    
    return Ok(newUserConference);
  }
}