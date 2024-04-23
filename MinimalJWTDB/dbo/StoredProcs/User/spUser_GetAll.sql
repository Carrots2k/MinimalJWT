CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select username, password, email, givenName, surname, role
	from dbo.[User];
end
