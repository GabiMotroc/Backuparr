using Backuparr.Interfaces;

namespace Backuparr.Utils;

public class Constants : IConstants
{
    private readonly string sourceFolder = Environment.GetEnvironmentVariable("SOURCE_FOLDER");
    private readonly string backupFolder = Environment.GetEnvironmentVariable("DESTINATION_FOLDER");
    private readonly string retentionSize = Environment.GetEnvironmentVariable("RETENTION_SIZE");
    public string GetSourceFolder ()
    {
        return sourceFolder;
    }

    public string GetBackupFolder()
    {
        return backupFolder;
    }

    public int GetRetentionSize()
    {
        return int.Parse(retentionSize);
    }
    
}

