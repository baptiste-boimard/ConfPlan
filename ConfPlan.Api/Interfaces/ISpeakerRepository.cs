using ConfPlan.Shared;

namespace ConfPlan.Api.Interfaces;

public interface ISpeakerRepository
{
  Task<List<Speaker>> GetAllSpeakers();
  Task<Speaker> GetOneSpeakersByName(string name);
  Task<Speaker> GetOneSpeakersById(Guid id);
  Task<Speaker> AddSpeaker(Speaker speaker);
  Task<Speaker> UpdateSpeaker(Speaker speaker);
  Task<Speaker> DeleteSpeaker(Speaker speaker);
}