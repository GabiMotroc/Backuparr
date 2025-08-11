using Backuparr.Services;

namespace Backuparr.BgService;

public class DailyBackupService : BackgroundService
{
    private readonly ArchiveService _archiveService; 
    public DailyBackupService (ArchiveService archiveService)
    {
        _archiveService = archiveService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (DateTime.UtcNow.Hour != 0)
            {
                await Task.Delay(60000, stoppingToken);
                continue;
            }

            _archiveService.CreateArchive();
        }
    }
}

