using ConfPlan.Client.States;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Pages;

public partial class Admin : ComponentBase
{
  [Inject]
  private NavigationManager _navigationManager { get; set; }
    
  [Inject]
  private UserState _userState { get; set; }
  
  private bool _shouldRedirect = false;
  
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
}