using Backuparr.Interfaces;
using Blazorise;
using Microsoft.AspNetCore.Mvc;

namespace Backuparr.Controller;

[Route("api/[controller]")]
[ApiController]
public class ArchiveController : ControllerBase
{
    private readonly IConstants _constants;
    public ArchiveController(IConstants constants)
    {
        _constants = constants;
    }
    [HttpGet("download/{filename}"), DisableRequestSizeLimit]
    public async Task<IActionResult> Download(string filename)
    {
        var memory = new MemoryStream();
        string zipPath = Path.Combine(_constants.GetBackupFolder(), filename);
        await using (var stream = new FileStream(zipPath, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;

        return File(memory, "application/octet-stream", filename);
    }
}

