CREATE TABLE [dbo].[ProjectUserCon]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User] ([Id]),
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project]([Id]),
	[ProjectScopeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[ProjectScope]([Id])
);
GO
CREATE UNIQUE INDEX Unique_UserId_ProjectId
ON [dbo].[ProjectUserCon]([UserId], [ProjectId])
GO
CREATE INDEX IX_UserId
ON [dbo].[ProjectUserCon]([UserId])
GO
CREATE INDEX IX_ProjectId
ON [dbo].[ProjectUserCon]([ProjectId])
GO
CREATE INDEX IX_ProjectScopeId
ON [dbo].[ProjectUserCon]([ProjectScopeId])