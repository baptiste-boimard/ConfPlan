using ConfPlan.Api.Interfaces;

namespace ConfPlan.Api.Services;

public class PlaceManagement
{
  private readonly IConferenceRepository _conferenceRepository;

  public PlaceManagement(IConferenceRepository conferenceRepository)
  {
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
}