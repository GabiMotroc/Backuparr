using Backuparr.Interfaces;

namespace Backuparr.Services;

public class RetentionService : IRetentionService
{
    private readonly IConstants _constants;
    public RetentionService(IConstants constants)
    {
        _constants = constants;
    }

    public void DeleteOldBackups()
    {
        DirectoryInfo backupsDirectory = new DirectoryInfo(_constants.GetBackupFolder());
        int sizeRetention = _constants.GetRetentionSize();
        var backups = backupsDirectory.GetFiles().OrderByDescending(f => f.CreationTime)
            .Skip(sizeRetention);
        foreach (var backup in backups) 
        { 
            backup.Delete();
        }
    }

}

