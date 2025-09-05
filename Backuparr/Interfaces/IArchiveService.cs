namespace Backuparr.Interfaces;

public interface IArchiveService
{
    void CreateArchive();
    IEnumerable<FileInfo> GetBackups();
    void DeleteArchive(string fileName);
}

