CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin
	select Id, username, password, email, givenName, surname, role
	from dbo.[User]
	where id = @Id;
end
