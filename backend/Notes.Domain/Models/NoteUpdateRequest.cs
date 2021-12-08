namespace Notes.Domain.Models
{
    public class NoteUpdateData
    {
        public string Title { get; }
        public string Body { get; }

        public NoteUpdateData(
            string title,
            string body)
        {
            Title = title;
            Body = body;
        }
    }
}
