using System.Text.Json;
using ConfPlan.Client.States;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Pages;

public partial class Admin : ComponentBase
{
  [Inject] private NavigationManager _navigationManager { get; set; }
  [Inject] private UserState _userState { get; set; }
  [Inject] private ConferenceState _conferenceState { get; set; }
  
  private bool isLoaded = false;
  private bool isEditing = false;
  private List<Conference> conferences = new();
  private Conference currentConference = new();
  
  private Conference newConference = new();
  private List<string> timeSlots = new()
  {
    "9h30 - 10h", "10h - 10h30", "10h30 - 11h", "11h - 12h",
    "13h - 13h30", "13h30 - 14h", "14h30 - 15h", "15h - 16h",
    "16h - 17h", "17h - 18h"
  }; 
  
  protected override async Task OnInitializedAsync()
  {
    await LoadConferences();
    isLoaded = true;
  }
  
  protected override void OnAfterRender(bool firstRender)
  {
    if (firstRender)
    {
      if (_userState.CurrentUser == null)
        _navigationManager.NavigateTo("/", forceLoad: true);
      else if (_userState.CurrentUser.Role?.RoleName != "Admin")
        _navigationManager.NavigateTo("/dashboard", forceLoad: true);

      StateHasChanged();
    }
  }
  
  private async Task LoadConferences()
  {
    conferences = await _conferenceState.GetAllAsync();
  }
  
  private async Task HandleSubmit()
  {
    bool success = isEditing
      ? await _conferenceState.UpdateAsync(currentConference)
      : await _conferenceState.CreateAsync(currentConference);

    if (success)
    {
      await LoadConferences();
      currentConference = new();
      isEditing = false;
    }
  }

  private void EditConference(Conference conf)
  {
    currentConference = new Conference
    {
      Id = conf.Id,
      Day = conf.Day,
      TimeSlot = conf.TimeSlot,
      Title = conf.Title,
      Description = conf.Description,
      SpeakerName = conf.SpeakerName,
      SpeakerBio = conf.SpeakerBio,
      SpeakerPhotoUrl = conf.SpeakerPhotoUrl
    };
    isEditing = true;
  }

  private async Task DeleteConference(Guid id)
  {
    await _conferenceState.DeleteAsync(id);
    await LoadConferences();
  }

  private void CancelEdit()
  {
    isEditing = false;
    currentConference = new();
  }
  
  private async Task HandleAdd()
  {
    newConference.Id = Guid.NewGuid();
    
    // Envoyer vers une API si elle existe (ex: via HttpClient)
    Console.WriteLine($"Conférence ajoutée : {JsonSerializer.Serialize(newConference)}");

    // Reset form
    newConference = new();
  }
}