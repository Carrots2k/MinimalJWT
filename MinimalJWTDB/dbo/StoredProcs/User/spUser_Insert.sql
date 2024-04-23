CREATE PROCEDURE [dbo].[spUser_Insert]
	@username nvarchar(50),
	@password nvarchar(50),
	@email nvarchar(50),
	@givenName nvarchar(50),
	@surname nvarchar(50),
	@role nvarchar(50)
AS
begin
	insert into dbo.[User] (username, password, email, givenName, surname, role)
	values (@username, @password, @email, @givenName, @surname, @role);
end

