CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [title] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(250) NOT NULL, 
    [rating] NVARCHAR(5) NOT NULL
)
