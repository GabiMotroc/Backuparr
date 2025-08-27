using Backuparr.Interfaces;
using Backuparr.Utils;
using System.IO.Compression;

namespace Backuparr.Services;

public class ArchiveService : IArchiveService
{
    private readonly IConstants _constants;
    public ArchiveService(IConstants constants)
    {
        _constants = constants;
    }
    public void CreateArchive()
    {
        string today = DateTime.Now.ToString("yyyy-MM-dd--hh-m-ss");
        string zipPath = Path.Combine(_constants.GetBackupFolder(), $"backup-{today}.zip");

        ZipFile.CreateFromDirectory(_constants.GetSourceFolder(), zipPath, CompressionLevel.Optimal, includeBaseDirectory: false);
    }

    public IEnumerable<FileInfo> GetBackups()
    {
        DirectoryInfo backupsDirectory = new DirectoryInfo(_constants.GetBackupFolder());
        return backupsDirectory.GetFiles().OrderByDescending(f => f.CreationTime).ToList();
    }

    public string GetBackupFile (string fileName)
    {
        var filePath = Path.Combine(_constants.GetBackupFolder(), fileName);
        if (File.Exists(filePath))
        {
            return filePath;
        }
        return null;
    }
    public void DownloadArchive()
    {
        
    }
}

