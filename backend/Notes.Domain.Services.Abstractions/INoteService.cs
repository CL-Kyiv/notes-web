using Notes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Services.Abstractions
{
    public interface INoteService
    {
        Task<List<Note>> GetAsync();
    }
}
