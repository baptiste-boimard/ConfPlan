using ConfPlan.Api.Interfaces;
using ConfPlan.Api.Services;
using ConfPlan.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

namespace ConfPlan.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly IAuthRepository _authRepository;
  private readonly PasswordHasher _passwordHasher;

  public AuthController(
    IAuthRepository authRepository,
    PasswordHasher passwordHasher)
  {
    _authRepository = authRepository;
    _passwordHasher = passwordHasher;
  }
  
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] User user)
  {
    if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
      return BadRequest("Champs requis");

    // Vérifier si l'utilisateur existe déjà
    var existingUser= await _authRepository.GetOneUserByEmail(user);
    
    if (existingUser != null)
      return Conflict("Email déjà utilisé");

    var defaultRole = await _authRepository.GetRoleByName("Visiteur");
    if (defaultRole == null)
      return StatusCode(500, "Rôle 'Visiteur' introuvable");

    var hashedPassword = _passwordHasher.HashPassword(user.Password);
    
    // Créer un nouvel utilisateur avec le rôle par défaut    
    var newUser = new User
    {
      Id = Guid.NewGuid(),
      Email = user.Email,
      Password = hashedPassword,
      IdRole = defaultRole.Id
    };
  
    var resultUser = _authRepository.RegisterUser(newUser);
    
    if(resultUser == null)
      return StatusCode(500, "Erreur lors de l'enregistrement de l'utilisateur");

    return Ok(resultUser);
  }
}