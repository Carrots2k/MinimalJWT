CREATE PROCEDURE [dbo].[spMovie_Get]
	@Id int
AS
begin
	select id,title, description, rating
	from dbo.[Movies]
	where id = @Id;
end
