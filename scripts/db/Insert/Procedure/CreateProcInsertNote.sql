use test_db
go
Create PROCEDURE note_insert (@title NVARCHAR(max),
                              @body NVARCHAR(max),
                              @created_date datetime2,
                              @is_active bit)
AS
  BEGIN
		INSERT INTO note(title,
                         body,
                         created_date,
                         is_active)
         VALUES(@title,
				@body,
				@created_date,
				@is_active)
                         
  END