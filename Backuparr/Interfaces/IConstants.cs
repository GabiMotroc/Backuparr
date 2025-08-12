namespace Backuparr.Interfaces;

public interface IConstants
{
    string GetSourceFolder();
    string GetBackupFolder();
    int GetRetentionSize();
}

