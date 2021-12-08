using Notes.Domain.Models;
using Notes.Domain.Services.Abstractions;
using Notes.Repository.Abstractions.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Domain.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(
            INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task AddNoteAsync(NoteCreateData createData) =>
            await _noteRepository.AddNoteAsync(createData);

        public async Task DeleteNoteAsync(int id) =>
            await _noteRepository.DeleteNoteAsync(id);

        public async Task<List<Note>> GetNotesAsync() =>
            await _noteRepository.GetNotesAsync();

        public async Task UpdateNoteAsync(int id, NoteUpdateData updateData) =>
            await _noteRepository.UpdateNoteAsync(id, updateData);
    }
}
