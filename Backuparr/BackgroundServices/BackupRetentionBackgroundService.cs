using Backuparr.Interfaces;

namespace Backuparr.BackgroundServices;

public class BackupRetentionBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _providerFactory;
    public BackupRetentionBackgroundService(IServiceScopeFactory providerFactory)
    {
        _providerFactory = providerFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _providerFactory.CreateScope();
            var backupRetentionService = scope.ServiceProvider.GetRequiredService<IBackupRetentionService>();
            backupRetentionService.SaveLatestBackups();
            await Task.Delay(60000, stoppingToken);
        }
    }
}

