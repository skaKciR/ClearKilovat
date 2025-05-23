using ClearKilovat.Components;
using ClearKilovat.DB;
using ClearKilovat.Interfaces;
using ClearKilovat.Services;
using Microsoft.EntityFrameworkCore;
using Radzen;


var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

var builder = WebApplication.CreateBuilder(args);
// Настроим контекст для подключения к базе данных
builder.Services.AddDbContext<PostgreDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<IJsonToPostgreLoader, JsonToPostgreLoader>();
builder.Services.AddScoped<IDbManagerService, DbManagerService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
