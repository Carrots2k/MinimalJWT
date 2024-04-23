CREATE PROCEDURE [dbo].[spMovie_Insert]
	@title nvarchar(50),
	@description nvarchar(250),
	@rating nvarchar(5)
AS
begin
	insert into dbo.[Movies] (title, description, rating)
	values (@title, @description, @rating);
end

