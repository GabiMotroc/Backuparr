using Backuparr.Interfaces;

namespace Backuparr.Services;

public class BackupRetentionService : IBackupRetentionService
{
    private readonly IConstants _constants;
    public BackupRetentionService(IConstants constants)
    {
        _constants = constants;
    }

    public void SaveLatestBackups()
    {
        DirectoryInfo backupsDirectory = new DirectoryInfo(_constants.GetBackupFolder());
        int numLatestBackups = _constants.GetLatestBackups();
        var backups = backupsDirectory.GetFiles().OrderByDescending(f => f.CreationTime);
        var backupKeepers = new List<FileInfo>();
        var i = 0;
        foreach (var backup in backups) 
        { 
            if (i < numLatestBackups)
            {
                backupKeepers.Add(backup);
            }
            else
            {
                backup.Delete();
            }
            i++;
        }
    }

}

