using Backuparr.Interfaces;
using Backuparr.Services;

namespace Backuparr.BackgroundServices;

public class DailyBackupService : BackgroundService
{
    private readonly IServiceScopeFactory _providerFactory;
    public DailyBackupService (IServiceScopeFactory providerFactory)
    {
        _providerFactory = providerFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _providerFactory.CreateScope();
            var archiveService = scope.ServiceProvider.GetRequiredService<IArchiveService>();
            archiveService.CreateArchive();
            await Task.Delay(86400000, stoppingToken);          
        }
    }
}

