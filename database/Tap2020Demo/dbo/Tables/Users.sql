CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Users PRIMARY KEY, 
    [Username] VARCHAR(150) NOT NULL, 
    [Email] NCHAR(250) NOT NULL, 
    [PasswordHash] VARCHAR(500) NOT NULL, 
    [ConcurrencyStamp] VARCHAR(500) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_Username] ON [dbo].[Users] ([Username])

GO

CREATE UNIQUE INDEX [IX_Users_Email] ON [dbo].[Users] ([Email])
