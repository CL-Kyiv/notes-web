using Dapper;
using Microsoft.Data.SqlClient;
using Notes.Domain.Models;
using Notes.Repository.Abstractions.Repositories;
using Notes.Repository.Entities;
using Notes.Repository.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Repository.Repositories
{
    public class NoteRepository : INoteRepository
    {
        string connectionString = null;
        public NoteRepository(string conn)
        {
            connectionString = conn;
        }
        public async Task<List<Note>> GetNotesAsync()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var noteEntities = await db.QueryAsync<NoteEntity>("SELECT * FROM note");
                return noteEntities.Select(noteEtity => noteEtity.ToDomainModel()).ToList();
            }
        }
    }
}
