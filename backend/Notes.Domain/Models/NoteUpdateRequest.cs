namespace Notes.Domain.Models
{
    public class NoteUpdateRequest
    {
        public string Title { get; }
        public string Body { get; }

        public NoteUpdateRequest(
            string title,
            string body)
        {
            Title = title;
            Body = body;
        }
    }
}
