using Microsoft.AspNetCore.Mvc;
using DM = Notes.Domain.Models;
using Notes.Domain.Services.Abstractions;
using VM = Notes.WebAPI.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using System;

namespace Notes.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteService noteService,
                               IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
                return Ok(await _noteService.GetNotesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateNoteAsync(VM.NoteCreateRequest createRequest)
        {
            await _noteService.AddNoteAsync(_mapper.Map<DM.NoteCreateRequest>(createRequest));
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
            await _noteService.UpdateNoteAsync(id, _mapper.Map<DM.NoteUpdateRequest>(updateRequest));
            return Ok();
        }
    }
}
