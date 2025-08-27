namespace Backuparr.Interfaces;

public interface IArchiveService
{
    void CreateArchive();
    IEnumerable<FileInfo> GetBackups();
    string GetBackupFile(string fileName);
}

