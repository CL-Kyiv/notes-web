using Notes.Domain.Models;
using Notes.Repository.Abstractions.Base;
using Notes.Repository.Abstractions.Repositories;
using Notes.Repository.Base;
using Notes.Repository.Constants;
using Notes.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Notes.Repository.Repositories
{
    public class NoteRepository : DbObjectRepository, INoteRepository
    {
        private readonly IMapper _mapper;

        public NoteRepository(ISqlConnectionObjectFactory connectionFactory,
            IMapper mapper)
            : base(connectionFactory)
        {
            _mapper = mapper;
        }

        public async Task AddNoteAsync(NoteCreateData createRequest)
        {
            await ExecuteAsync(
                NoteSqlCommands.AddNote,
                new
                {
                     Title = createRequest.Title,
                     Body = createRequest.Body,
                     CreatedDate = DateTime.Now,
                     IsActive = true
                });
        }

        public async Task DeleteNoteAsync(int id)
        {
            await ExecuteAsync(
            NoteSqlCommands.DeleteNote, new
            {
                Id = id
            });
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return (await QueryAsync<NoteEntity>(NoteSqlCommands.GetNotes))
                .Select(noteEtity => _mapper.Map<Note>(noteEtity)).ToList();
        }

        public async Task UpdateNoteAsync(int id, NoteUpdateData updateRequest)
        {
            await ExecuteAsync(
                NoteSqlCommands.UpdateNote,
                new
                {
                    Id = id,
                    Title = updateRequest.Title,
                    Body = updateRequest.Body,
                });
        }
    }
}
