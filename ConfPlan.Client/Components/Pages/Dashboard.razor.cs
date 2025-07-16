using ConfPlan.Client.States;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Pages;

public partial class Dashboard : ComponentBase
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private UserState _userState { get; set; }
    [Inject] private ConferenceState _conferenceState { get; set; }
    [Inject] private UserConferenceState _userConferenceState { get; set; }
    
    private bool _shouldRedirect = false;
    private List<Conference> conferences = new();
    private string? errorMessage;
    
    private string selectedRoom = "";
    private string selectedDay = "";
    private string selectedSpeaker = "";

    private List<string> roomNames = new();
    private List<string> availableDays = new();
    private List<string> speakerNames = new();

    private IEnumerable<Conference> filteredConferences => conferences
        .Where(c =>
            (string.IsNullOrEmpty(selectedRoom) || c.Room.Name == selectedRoom) &&
            (string.IsNullOrEmpty(selectedDay) || c.Day == selectedDay) &&
            (string.IsNullOrEmpty(selectedSpeaker) || c.Speaker.Name == selectedSpeaker)
        );
    
    protected async override void OnInitialized()
    {
        if (_userState.CurrentUser == null)
        {
            _shouldRedirect = true;
        }
        
        await LoadConferences();

    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _shouldRedirect)
        {
            _navigationManager.NavigateTo("/");
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
            
            roomNames = conferences.Select(c => c.Room.Name).Distinct().ToList();
            availableDays = conferences.Select(c => c.Day).Distinct().ToList();
            speakerNames = conferences.Select(c => c.Speaker.Name).Distinct().ToList();
            
            StateHasChanged();
        }
    }

    private void GoToAdmin()
    {
        _navigationManager.NavigateTo("/admin");
    }
    private void HandleLogout()
    {
        _userState.Logout();
        _navigationManager.NavigateTo("/", forceLoad: true); // forceReload au cas où
    }
    
    private void ResetFilters()
    {
        selectedRoom = "";
        selectedDay = "";
        selectedSpeaker = "";
    }

    private async Task Subscription(Conference conf)
    {
        var userConference = new UserConference
        {
            IdConference = conf.Id,
            IdUser = _userState.CurrentUser.Id
        };
        
        var result = await _userConferenceState.Subscription(userConference);
        
        if (!result.Success)
        {
            errorMessage = result.Message ?? "Une erreur s'est produite lors de l'effacement de la conférence.";
        }
        else
        {
            // await LoadUserConferences();
      
            StateHasChanged();
        }
    }
    
    // private async Task Unsubscription(Conference conf)
    // {
    //     var userConference = new UserConference
    //     {
    //         IdConference = conf.Id,
    //         IdUser = _userState.CurrentUser.Id
    //     };
    //     
    //     var result = await _userConferenceState.Subscription(userConference);
    //     
    //     if (!result.Success)
    //     {
    //         errorMessage = result.Message ?? "Une erreur s'est produite lors de l'effacement de la conférence.";
    //     }
    //     else
    //     {
    //         await LoadUserConferences();
    //   
    //         StateHasChanged();
    //     }
    // }
}