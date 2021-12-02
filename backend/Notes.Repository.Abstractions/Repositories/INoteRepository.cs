using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Domain.Models;

namespace Notes.Repository.Abstractions.Repositories
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotesAsync();
        Task UpdateNoteAsync(int id, NoteUpdateData updateRequest);
        Task AddNoteAsync(NoteCreateData createRequest);
        Task DeleteNoteAsync(int id);
    }
}
