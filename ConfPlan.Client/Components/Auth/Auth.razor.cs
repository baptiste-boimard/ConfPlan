using System.ComponentModel.DataAnnotations;
using ConfPlan.Client.States;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Auth;

public partial class Auth : ComponentBase
{
  private readonly NavigationManager _navigationManager;
  private readonly UserState _userState;

  public Auth(
    NavigationManager navigationManager,
    UserState userState)
  {
    _navigationManager = navigationManager;
    _userState = userState;
  }
  
  private AuthForm formModel = new();
  private bool isRegisterMode = false;
  private string? errorMessage;

  protected override void OnInitialized()
  {
    if (_userState.CurrentUser != null)
    {
      _navigationManager.NavigateTo("/dashboard");
    }
  }
  
  private async Task HandleSubmit()
  {
    if (isRegisterMode)
    {
      if (formModel.Password != formModel.ConfirmPassword)
      {
        errorMessage = ("Les mots de passe ne correspondent pas.");
        return;
      }
      
      var result  = await _userState.RegisterAsync(formModel.Email, formModel.Password);

      if (!result.Success)
      {
        errorMessage = result.Message ?? "Une erreur inconnue s'est produite.";
        return;
      }
      else
      {
        // Rediriger vers le dashboard
        _navigationManager.NavigateTo("/dashboard");
      }
      
    }
    else
    {
      var result = await _userState.LoginAsync(formModel.Email, formModel.Password);

      if (!result.Success)
      {
        errorMessage = result.Message ?? "Erreur de connexion.";
        return;
      }

      // Rediriger vers le dashboard
      _navigationManager.NavigateTo("/dashboard");
    }
  }

  private void ToggleMode()
  {
    isRegisterMode = !isRegisterMode;
    formModel = new(); // reset form
  }

  public class AuthForm
  {
    [Required(ErrorMessage = "Email requis")]
    [EmailAddress(ErrorMessage = "Email invalide")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mot de passe requis")]
    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
  }
}