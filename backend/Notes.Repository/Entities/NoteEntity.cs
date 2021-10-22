using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Repository.Entities
{
    internal class NoteEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime created_date { get; set; }

    }
}
