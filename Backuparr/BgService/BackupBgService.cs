
using System.IO.Compression;

namespace Backuparr.BgService
{
    public class BackupBgService : BackgroundService
    {
        private readonly string sourceFolder = Environment.GetEnvironmentVariable("SOURCE_FOLDER");
        private readonly string backupFolder = Environment.GetEnvironmentVariable("DESTINATION_FOLDER");

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (DateTime.UtcNow.Hour != 0)
                {
                    await Task.Delay(60000, stoppingToken);
                    continue;
                }

                string today = DateTime.Now.ToString("yyyy-MM-dd");
                string zipPath = Path.Combine(backupFolder, $"backup-{today}.zip");

                ZipFile.CreateFromDirectory(sourceFolder, zipPath, CompressionLevel.Optimal, includeBaseDirectory: false);
            }
        }
    }
}
