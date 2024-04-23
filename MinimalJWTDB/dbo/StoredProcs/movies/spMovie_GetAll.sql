CREATE PROCEDURE [dbo].[spMovie_GetAll]
AS
begin
	select id, title, description, rating
	from dbo.[Movies];
end
