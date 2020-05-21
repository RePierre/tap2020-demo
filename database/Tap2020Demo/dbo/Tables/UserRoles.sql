CREATE TABLE [dbo].[UserRoles]
(
	[RoleId] UNIQUEIDENTIFIER NOT NULL , 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([RoleId], [UserId]), 
    CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([Id]), 
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
