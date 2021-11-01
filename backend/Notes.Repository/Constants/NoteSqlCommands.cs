namespace Notes.Repository.Constants
{
    internal static class NoteSqlCommands
    {
        public const string GetNotes = "SELECT * FROM note";

        public const string AddNote = @"
        EXEC [dbo].[note_insert]
            @title = @Title
            ,@body = @Body
            ,@created_date = @CreatedDate
            ,@is_active = @IsActive";

        public const string DeleteNote = @"
        EXEC [dbo].[note_delete]
            @id = @Id";

        public const string UpdateNote = @"
        EXEC [dbo].[note_update]
            @id = @Id
            ,@title = @Title
            ,@body = @Body";
    }
}
