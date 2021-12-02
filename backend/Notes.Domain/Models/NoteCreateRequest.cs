namespace Notes.Domain.Models
{
    public class NoteCreateData
    {
        public string Title { get; }
        public string Body { get; }

        public NoteCreateData(
            string title,
            string body)
        {
            Title = title;
            Body = body;
        }
    }
}
