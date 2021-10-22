using Notes.Domain.Models;
using Notes.Repository.Entities;
using System.Collections.Immutable;
using System.Linq;

namespace Notes.Repository.Extensions
{
    internal static class NoteExtensions
    {
        public static Note ToDomainModel(this NoteEntity entity) => new Note(
            entity.id,
            entity.title,
            entity.body,
            entity.created_date);
    }
}
