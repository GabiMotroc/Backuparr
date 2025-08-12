using Backuparr.Interfaces;

namespace Backuparr.Utils;

public class Constants : IConstants
{
    private readonly string sourceFolder = Environment.GetEnvironmentVariable("SOURCE_FOLDER");
    private readonly string backupFolder = Environment.GetEnvironmentVariable("DESTINATION_FOLDER");
    private readonly string sizeRetention = Environment.GetEnvironmentVariable("SIZE_RETENTION");
    public string GetSourceFolder ()
    {
        return sourceFolder;
    }

    public string GetBackupFolder()
    {
        return backupFolder;
    }

    public int GetLatestBackups()
    {
        return int.Parse(sizeRetention);
    }
    
}

