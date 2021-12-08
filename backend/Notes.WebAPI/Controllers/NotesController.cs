using Microsoft.AspNetCore.Mvc;
using DM = Notes.Domain.Models;
using Notes.Domain.Services.Abstractions;
using VM = Notes.WebAPI.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Notes.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public NotesController(INoteService noteService,
                               IMapper mapper,
                               ILogger<NotesController> logger)
        {
            _noteService = noteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteService.GetNotesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateNoteAsync(VM.NoteCreateRequest createRequest)
        {
            _logger.LogInformation($"Adding note with \n\t Title : {createRequest.Title} \n\t Body : {createRequest.Body}");
            await _noteService.AddNoteAsync(_mapper.Map<DM.NoteCreateData>(createRequest));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNoteAsync(int id)
        {
            await _noteService.DeleteNoteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNoteAsync(int id, VM.NoteUpdateRequest updateRequest)
        {
            _logger.LogInformation($"Updating note id : {id} \n\t New title : {updateRequest.Title} \n\t New body : {updateRequest.Body}");
            await _noteService.UpdateNoteAsync(id, _mapper.Map<DM.NoteUpdateData>(updateRequest));
            return Ok();
        }
    }
}
