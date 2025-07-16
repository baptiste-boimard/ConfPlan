using ConfPlan.Api.Interfaces;

namespace ConfPlan.Api.Services;

public class PlaceManagement
{
  private readonly IUserConferenceRepository _userConferenceRepository;
  private readonly IConferenceRepository _conferenceRepository;

  public PlaceManagement(
    IUserConferenceRepository userConferenceRepository,
    IConferenceRepository conferenceRepository)
  {
    _userConferenceRepository = userConferenceRepository;
    _conferenceRepository = conferenceRepository;
  }
  
  public async Task<bool> CheckFreePlace(Guid idConference)
  {
    //Récupération de la conférence
    var conference = await _conferenceRepository.GetConferenceById(idConference);

    if (conference.Room.MaxCapacity - conference.Room.CurrentCapacity > 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
  
  public async Task AddOneParticipant(Guid idConference)
  {
    //Récupération de la conférence
    var conference = await _conferenceRepository.GetConferenceById(idConference);

    //Incrémentation du nombre de participants
    conference.Participant += 1;

    //Mise à jour de la conférence
    await _conferenceRepository.UpdateConference(conference);
  }
  
  public async Task RemoveOneParticipant(Guid idConference)
  {
    //Récupération de la conférence
    var conference = await _conferenceRepository.GetConferenceById(idConference);

    //Incrémentation du nombre de participants
    conference.Participant -= 1;

    //Mise à jour de la conférence
    await _conferenceRepository.UpdateConference(conference);
  }
  
  public async Task<bool> CheckSameTime(Guid idUser, Guid idConference)
  {
    // Récupération de la liste des conférences de l'utilisateur
    var userConferences = await _userConferenceRepository.GetAllUserConferences(idUser);

    // Récupération de la conférence à vérifier
    var conference = await _conferenceRepository.GetConferenceById(idConference);
    
    // Vérification si l'utilisateur a une conférence à la même heure
    if (userConferences.Any(c => c.Day == conference.Day &&
      c.TimeSlot == conference.TimeSlot))
      return true;

    return false;
  }
}