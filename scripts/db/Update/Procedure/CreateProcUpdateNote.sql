use test_db
go
Create PROCEDURE note_update (@id int
							 ,@title nvarchar(max)
							 ,@body nvarchar(max))
AS
  BEGIN
		UPDATE [dbo].[note]
            SET 
                 [title] = @title
                ,[body] = @body
                
            WHERE [id] = @id;             
  END