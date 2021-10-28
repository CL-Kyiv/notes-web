using Notes.Domain.Models;
using Notes.Repository.Entities;

namespace Notes.Repository.Extensions
{
    public static class NoteExtensions
    {
        public static Note ToDomainModel(this NoteEntity entity) => new Note(
            entity.id,
            entity.title,
            entity.body,
            entity.created_date);
    }
}
