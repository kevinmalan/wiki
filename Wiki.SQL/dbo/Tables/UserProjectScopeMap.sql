CREATE TABLE [dbo].[UserProjectScopeMap]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[ProjectId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[Project]([Id]),
	[ProjectScopeId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[ProjectScope]([Id])
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