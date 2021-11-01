using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Domain.Models;

namespace Notes.Repository.Abstractions.Repositories
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotesAsync();
        Task UpdateNoteAsync(int id, NoteUpdateRequest updateRequest);
        Task AddNoteAsync(NoteCreateRequest createRequest);
        Task DeleteNoteAsync(int id);
    }
}
