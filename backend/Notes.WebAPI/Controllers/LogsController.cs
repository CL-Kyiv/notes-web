using Microsoft.AspNetCore.Mvc;
using System;
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

            var path = $"log-{DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)}.txt";

            using (var memory = new MemoryStream())
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Write))
                {
                    await stream.CopyToAsync(memory);
                }
                var contentType = "text/plain";

                return File(memory.ToArray(), contentType);
            }
        }
    }
}
