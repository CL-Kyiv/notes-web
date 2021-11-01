using System;

namespace Notes.Repository.Entities
{
    public class NoteEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime created_date { get; set; }
        public bool is_active { get; set; }
    }
}
