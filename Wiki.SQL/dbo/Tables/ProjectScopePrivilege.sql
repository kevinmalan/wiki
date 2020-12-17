CREATE TABLE [dbo].[ProjectScopePrivilege]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[ProjectScopeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[ProjectScope]([Id]),
	[PrivilegeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Privilege]([Id])
);
GO
CREATE INDEX IX_UniqueId
ON [dbo].[ProjectScopePrivilege]([UniqueId])
GO
CREATE INDEX IX_ProjectScopeId
ON [dbo].[ProjectScopePrivilege]([ProjectScopeId])
GO
CREATE INDEX IX_PrivilegeId
ON [dbo].[ProjectScopePrivilege]([PrivilegeId])