use test_db
go
Create PROCEDURE note_delete (@id int)
AS
  BEGIN
		UPDATE [dbo].[note]
		SET is_active = 0
		where id = @id                    
  END