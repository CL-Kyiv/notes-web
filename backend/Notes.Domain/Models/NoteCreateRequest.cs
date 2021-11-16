namespace Notes.Domain.Models
{
    public class NoteCreateRequest
    {
        public string Title { get; }
        public string Body { get; }

        public NoteCreateRequest(
            string title,
            string body)
        {
            Title = title;
            Body = body;
        }
    }
}
