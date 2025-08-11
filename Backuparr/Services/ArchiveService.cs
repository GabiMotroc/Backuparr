using Backuparr.Utils;
using System.IO.Compression;

namespace Backuparr.Services;

public class ArchiveService
{
    private readonly Constants _constants;
    public ArchiveService(Constants constants)
    {
        _constants = constants;
    }
    public void CreateArchive()
    {
        string today = DateTime.Now.ToString("yyyy-MM-dd");
        string zipPath = Path.Combine(_constants.GetBackupFolder(), $"backup-{today}.zip");

        ZipFile.CreateFromDirectory(_constants.GetSourceFolder(), zipPath, CompressionLevel.Optimal, includeBaseDirectory: false);
    }
}

