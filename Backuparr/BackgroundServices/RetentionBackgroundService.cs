using Backuparr.Interfaces;

namespace Backuparr.BackgroundServices;

public class RetentionBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _providerFactory;
    public RetentionBackgroundService(IServiceScopeFactory providerFactory)
    {
        _providerFactory = providerFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _providerFactory.CreateScope();
            var backupRetentionService = scope.ServiceProvider.GetRequiredService<IRetentionService>();
            backupRetentionService.DeleteOldBackups();
            await Task.Delay(60000, stoppingToken);
        }
    }
}

