using Notes.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Domain.Services.Abstractions
{
    public interface INoteService
    {
        Task<List<Note>> GetAsync();
    }
}
