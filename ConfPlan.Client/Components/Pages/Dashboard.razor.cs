using ConfPlan.Client.States;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Pages;

public partial class Dashboard : ComponentBase
{
    [Inject]
    private NavigationManager _navigationManager { get; set; }
    
    [Inject]
    private UserState _userState { get; set; }
    
    private bool _shouldRedirect = false;
    
    protected override void OnInitialized()
    {
        if (_userState.CurrentUser == null)
        {
            _shouldRedirect = true;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && _shouldRedirect)
        {
            _navigationManager.NavigateTo("/");
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