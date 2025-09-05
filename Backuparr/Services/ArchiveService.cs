using Backuparr.Interfaces;
using Backuparr.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using System.IO.Compression;
using System.Linq;

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
    public void DeleteArchive (string fileName)
    {
        DirectoryInfo backupsDirectory = new DirectoryInfo(_constants.GetBackupFolder());
        var backup = backupsDirectory.GetFiles().FirstOrDefault(f=>f.Name==fileName);
        if (backup == null)
        {
            return;
        }
        backup.Delete();
    }
}

