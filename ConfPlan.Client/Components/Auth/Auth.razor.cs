using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace ConfPlan.Client.Components.Auth;

public partial class Auth : ComponentBase
{
  private readonly NavigationManager _navigationManager;

  public Auth(NavigationManager navigationManager)
  {
    _navigationManager = navigationManager;
  }
  
  private AuthForm formModel = new();
  private bool isRegisterMode = false;

  private async Task HandleSubmit()
  {
    if (isRegisterMode)
    {
      if (formModel.Password != formModel.ConfirmPassword)
      {
        // erreur basique
        Console.WriteLine("Les mots de passe ne correspondent pas.");
        return;
      }

      // TODO: Ajouter la logique d'inscription
      Console.WriteLine($"Inscription de : {formModel.Email}");
    }
    else
    {
      // TODO: Ajouter la logique de connexion
      Console.WriteLine($"Connexion de : {formModel.Email}");
    }

    // Rediriger vers le dashboard
    _navigationManager.NavigateTo("/dashboard");
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