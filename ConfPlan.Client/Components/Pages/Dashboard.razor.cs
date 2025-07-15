using ConfPlan.Client.States;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Pages;

public partial class Dashboard : ComponentBase
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private UserState _userState { get; set; }
    [Inject] private ConferenceState _conferenceState { get; set; }
    
    private bool _shouldRedirect = false;
    private List<Conference> conferences = new();
    private string? errorMessage;

    
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
}