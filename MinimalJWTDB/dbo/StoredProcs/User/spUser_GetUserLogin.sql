CREATE PROCEDURE [dbo].[spUser_GetUserLogin]
	@username nvarchar(50),
	@password nvarchar(50)
AS
begin
	select id, username, email, password, givenName, surname, role
	  from  [dbo].[User]
	  where username = @username AND password = @password;
end
