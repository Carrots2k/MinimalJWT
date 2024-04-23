CREATE PROCEDURE [dbo].[spMovie_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Movies]
	where Id = @Id;
end
