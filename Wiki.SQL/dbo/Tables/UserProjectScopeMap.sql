CREATE TABLE [dbo].[UserProjectScopeMap]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(100,1),
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