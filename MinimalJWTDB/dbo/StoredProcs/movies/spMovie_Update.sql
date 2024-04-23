CREATE PROCEDURE [dbo].[spMovie_Update]
	@Id int,
	@title nvarchar(50),
	@description nvarchar(250),
	@rating nvarchar(5)
AS
begin
	update dbo.[Movies]
	set title = @title, description = @description, rating = @rating
	where Id = @Id;
end
