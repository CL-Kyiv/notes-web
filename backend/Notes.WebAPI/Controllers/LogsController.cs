using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Notes.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {

            var path = $"{Directory.GetCurrentDirectory()}\\Logs\\Log-20211203.txt";

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Write))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "text/plain";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
    }
}
