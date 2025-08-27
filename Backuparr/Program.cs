using Backuparr.BackgroundServices;
using Backuparr.Components;
using Backuparr.Interfaces;
using Backuparr.Services;
using Backuparr.Utils;
using Blazorise;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHostedService<DailyBackupService>();

builder.Services.AddHostedService<RetentionBackgroundService>();

builder.Services.AddScoped<IArchiveService, ArchiveService>();

builder.Services.AddScoped<IRetentionService, RetentionService>();

builder.Services.AddScoped<IConstants, Constants>();

DotNetEnv.Env.Load();

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
