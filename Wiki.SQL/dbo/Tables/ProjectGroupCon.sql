CREATE TABLE [dbo].[ProjectGroupCon]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project] ([Id]),
	[GroupId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Group] ([Id])
);
GO
CREATE INDEX IX_ProjectId 
ON [dbo].[ProjectGroupCon] ([ProjectId]);
GO
CREATE INDEX IX_GroupId 
ON [dbo].[ProjectGroupCon] ([GroupId]);