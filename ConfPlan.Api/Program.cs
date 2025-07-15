using Microsoft.EntityFrameworkCore;
using Service.OAuth.Database;

var builder = WebApplication.CreateBuilder(args);


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