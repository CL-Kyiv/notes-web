using Notes.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Domain.Services.Abstractions
{
    public interface INoteService
    {
        Task<List<Note>> GetNotesAsync();
        Task UpdateNoteAsync(int id, NoteUpdateRequest updateRequest);
        Task AddNoteAsync(NoteCreateRequest createRequest);
        Task DeleteNoteAsync(int id);
    }
}
