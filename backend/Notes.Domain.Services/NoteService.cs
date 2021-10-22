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

        public Task<List<Note>> GetAsync() =>
            _noteRepository.GetAsync();
    }
}
