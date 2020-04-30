CREATE TABLE [dbo].[Accounts] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_Accounts_Id] DEFAULT (newid()) NOT NULL,
    [AccountTypeId] INT NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [Iban]       VARCHAR (32)     NOT NULL,
    [Amount] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Accounts_AccountTypes] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountTypes]([Id]), 
    CONSTRAINT [FK_Accounts_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Accounts]
    ON [dbo].[Accounts]([Iban] ASC);

