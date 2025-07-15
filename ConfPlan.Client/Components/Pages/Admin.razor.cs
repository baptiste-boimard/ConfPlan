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
  Conference? editingConference = null;
  bool isEditing => editingConference != null;
  // private bool isEditing = false;
  private List<Conference> conferences = new();
  private Conference currentConference = new();
  
  private Conference newConference = new();
  private List<string> timeSlots = new()
  {
    "9h30 - 10h", "10h - 10h30", "10h30 - 11h", "11h - 12h",
    "13h - 13h30", "13h30 - 14h", "14h30 - 15h", "15h - 16h",
    "16h - 17h", "17h - 18h"
  }; 
  
  private List<string> rooms = new()
  {
    "Salle A", "Salle B", "Salle C", "Salle D",
    "Salle E", "Salle F", "Salle G", "Salle H",
    "Salle I", "Salle J"
  };
  
  private string? errorMessage;

  
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
    var result = await _conferenceState.GetAllAsync();
    
    if(!result.Success)
    {
      errorMessage = result.Message ?? "Une erreur s'est produite lors du chargement des conférences.";
    }
    else
    {
      conferences = result.Conferences;
      StateHasChanged();
    }
  }

  private void EditConference(Conference conf)
  {
    editingConference = new Conference
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
  }

  private async Task DeleteConference(Conference conf)
  {
    var result = await _conferenceState.DeleteAsync(conf);
    
    if (!result.Success)
    {
      errorMessage = result.Message ?? "Une erreur s'est produite lors de l'effacement de la conférence.";
    }
    else
    {
      await LoadConferences();
      
      StateHasChanged();
    }
  }
  
  private async Task HandleAdd()
  {
    var result = await _conferenceState.CreateAsync(newConference);

    if (!result.Success)
    {
      errorMessage = result.Message ?? "Une erreur s'est produite lors de l'enregistrement.";
    }
    else
    {
      await LoadConferences();
      
      newConference = new();
      
      StateHasChanged();
    }
  }
  
  private async Task HandleUpdate()
  {
    if (editingConference is null) return;

    var result = await _conferenceState.UpdateAsync(editingConference);

    if (result.Success)
    {
      await LoadConferences();
      editingConference = null;
      StateHasChanged();
    }
    else
    {
      errorMessage = result.Message ?? "Erreur lors de la mise à jour.";
    }
  }
}