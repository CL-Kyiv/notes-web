using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Domain.Models
{
    public class Note
    {
        public int Id { get;}
        public string Title { get;}
        public string Body { get;}
        public DateTime CreatedDate { get;}

        public Note(
            int id,
            string title,
            string body,
            DateTime createdDate)
        {
            Id = id;
            Title = title;
            Body = body;
            CreatedDate = createdDate;
        }
    }
}
