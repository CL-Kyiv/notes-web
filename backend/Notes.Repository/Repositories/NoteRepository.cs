using Dapper;
using Microsoft.Data.SqlClient;
using Notes.Domain.Models;
using Notes.Repository.Abstractions.Base;
using Notes.Repository.Abstractions.Repositories;
using Notes.Repository.Base;
using Notes.Repository.Entities;
using Notes.Repository.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Repository.Repositories
{
    public class NoteRepository : DbObjectRepository, INoteRepository
    {
        public NoteRepository(ISqlConnectionObjectFactory connectionFactory)
            : base(connectionFactory)
        {
        }
        public async Task<List<Note>> GetNotesAsync()
        {
            return (await QueryAsync<NoteEntity>("SELECT * FROM note"))
                .Select(noteEtity => noteEtity.ToDomainModel()).ToList();
        }
    }
}
