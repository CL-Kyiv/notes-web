using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Services.Abstractions;
using System.Threading.Tasks;

namespace Notes.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteService.GetNotesAsync());
        }
    }
}
