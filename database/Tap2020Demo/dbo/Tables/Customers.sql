CREATE TABLE [dbo].[Customers]
(
	[Id] UNIQUEIDENTIFIER NOT NULL  DEFAULT newid(), 
    [IdNo] VARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(150) NOT NULL, 
    [LastName] NVARCHAR(150) NOT NULL, 
    [FullName] AS FirstName + ' ' + LastName, 
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
)

GO

CREATE UNIQUE INDEX [IX_Customers_IdNo] ON [dbo].[Customers] ([IdNo])

GO

CREATE INDEX [IX_Customers_FullName] ON [dbo].[Customers] ([FullName])
