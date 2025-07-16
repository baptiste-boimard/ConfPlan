using ConfPlan.Api.Interfaces;
using ConfPlan.Api.Repositories;
using ConfPlan.Api.Services;
using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();
builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();
builder.Services.AddScoped<IUserConferenceRepository, UserConferenceRepository>();

builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<PlaceManagement>();

builder.Services.AddControllers();

//* Gestion des cors
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll", policy =>
  {
    policy.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

//* Configuration du DbContext
builder.Services.AddDbContext<PostgresDbContext>(options =>
  options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgresDBContext"]));

var app = builder.Build();

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();