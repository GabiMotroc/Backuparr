namespace Backuparr.Utils;

public class Constants
{
    private readonly string sourceFolder = Environment.GetEnvironmentVariable("SOURCE_FOLDER");
    private readonly string backupFolder = Environment.GetEnvironmentVariable("DESTINATION_FOLDER");

    public string GetSourceFolder ()
    {
        return sourceFolder;
    }

    public string GetBackupFolder()
    {
        return backupFolder;
    }
}

