using Backuparr.BackgroundServices;
using Backuparr.Components;
using Backuparr.Interfaces;
using Backuparr.Services;
using Backuparr.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHostedService<DailyBackupService>();

builder.Services.AddHostedService<BackupRetentionBackgroundService>();

builder.Services.AddScoped<IArchiveService, ArchiveService>();

builder.Services.AddScoped<IBackupRetentionService, BackupRetentionService>();

builder.Services.AddScoped<IConstants, Constants>();

DotNetEnv.Env.Load();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
