using ClearKilovat.Components;
using ClearKilovat.DB;
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
