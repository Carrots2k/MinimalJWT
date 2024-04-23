CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@username nvarchar(50),
	@password nvarchar(50),
	@email nvarchar(50),
	@givenName nvarchar(50),
	@surname nvarchar(50),
	@role nvarchar(50)
AS
begin
	update dbo.[User]
	set username = @username, password = @password, email = @email, givenName = @givenName, surname = @surname, role = @role
	where Id = @Id;
end
