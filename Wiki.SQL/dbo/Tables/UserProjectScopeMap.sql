CREATE TABLE [dbo].[UserProjectScopeMap]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project]([Id]),
	[ProjectScopeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[ProjectScope]([Id])
);
GO
CREATE INDEX IX_UserId
ON [dbo].[UserProjectScopeMap]([UserId])
GO
CREATE INDEX IX_ProjectId
ON [dbo].[UserProjectScopeMap]([ProjectId])
GO
CREATE INDEX IX_ProjectScopeId
ON [dbo].[UserProjectScopeMap]([ProjectScopeId])
GO
CREATE INDEX IX_UniqueId
ON [dbo].[UserProjectScopeMap] ([UniqueId])