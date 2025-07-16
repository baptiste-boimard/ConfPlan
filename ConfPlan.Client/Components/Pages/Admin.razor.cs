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
  [Inject] private SpeakerState _speakerState { get; set; }
  
  private bool isLoaded = false;
  Conference? editingConference = null;
  Speaker? editingSpeaker = null;
  bool isEditing => editingConference != null;
  bool isEditingSpeaker = false;
  private List<Conference> conferences = new();
  private Conference currentConference = new();
  
  private Conference newConference = new();
  private Speaker newSpeaker = new();
  // private Guid selectedSpeakerId;
  // private Speaker? selectSpeaker => speakers.FirstOrDefault(s => s.Id == selectedSpeakerId);
  private List<string> timeSlots = new()
  {
    "9h30 - 10h", "10h - 10h30", "10h30 - 11h", "11h - 12h",
    "13h - 13h30", "13h30 - 14h", "14h30 - 15h", "15h - 16h",
    "16h - 17h", "17h - 18h"
  };

  private List<Room> rooms = new();
  private List<Speaker> speakers = new();
  
  private string? errorMessage;

  
  protected override async Task OnInitializedAsync()
  {
    await LoadConferences();
    await LoadRooms();
    await LoadSpeakers();
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
  
  private async Task LoadRooms()
  {
    var result = await _conferenceState.GetAllRoomsAsync();
    
    if (!result.Success)
    {
      errorMessage = result.Message ?? "Une erreur s'est produite lors du chargement des salles.";
    }
    else
    {
      rooms = result.Rooms;
      StateHasChanged();
    }
  }
  
  private async Task LoadSpeakers()
  {
    var result = await _speakerState.GettAllSpeakersAsync();
    
    if (!result.Success)
    {
      errorMessage = result.Message ?? "Une erreur s'est produite lors du chargement des conférenciés.";
    }
    else
    {
      speakers = result.Speakers;
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
      Room = conf.Room,
      Title = conf.Title,
      Description = conf.Description,
      Speaker = conf.Speaker,
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
  
  private async Task HandleAddSpeaker()
  {
    var result = await _speakerState.CreateAsync(newSpeaker);

    if (!result.Success)
    {
      errorMessage = result.Message ?? "Une erreur s'est produite lors de l'enregistrement.";
    }
    else
    {
      await LoadSpeakers();
      
      newSpeaker = new();
      
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

  // private async Task HandleEditSpeaker()
  // {
  //   if (selectedSpeakerId is null)
  //   {
  //     errorMessage = "Aucun conférencier sélectionné.";
  //     return;
  //   }
  //
  //   editingSpeaker = new Speaker
  //   {
  //     Id = selectSpeaker.Id,
  //     Name = selectSpeaker.Name,
  //     Bio = selectSpeaker.Bio,
  //     PhotoUrl = selectSpeaker.PhotoUrl,
  //   };
  //   isEditingSpeaker = true;
  //   Console.WriteLine("Editing speaker: " + selectSpeaker.Name);
  // }
  
  // private async Task HandleUpdateSpeaker()
  // {
  //   if (editingSpeaker is null) return;
  //
  //   var result = await _speakerState.UpdateAsync(editingSpeaker);
  //
  //   if (result.Success)
  //   {
  //     await LoadSpeakers();
  //     editingSpeaker = null;
  //     StateHasChanged();
  //   }
  //   else
  //   {
  //     errorMessage = result.Message ?? "Erreur lors de la mise à jour du conférencier.";
  //   }
  // }
  
  // private async Task HandleDeleteSpeaker()
  // {
  //   if (selectSpeaker is null)
  //   {
  //     errorMessage = "Aucun conférencier sélectionné.";
  //     return;
  //   }
  //   
  //   var result = await _speakerState.DeleteAsync(selectSpeaker);
  //
  //   if (result.Success)
  //   {
  //     await LoadSpeakers();
  //     StateHasChanged();
  //   }
  //   else
  //   {
  //     errorMessage = result.Message ?? "Erreur lors de la suppression du conférencier.";
  //   }
  // }
  
  private void GoToDashboard()
  {
    _navigationManager.NavigateTo("/dashboard");
  } 
}