using ConfPlan.Client.Components;
using ConfPlan.Client.States;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services
builder.Services.AddHttpClient();
builder.Services.AddScoped<UserState>();
builder.Services.AddScoped<ConferenceState>();
builder.Services.AddScoped<SpeakerState>();
builder.Services.AddScoped<UserConferenceState>();


builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();

app.Run();