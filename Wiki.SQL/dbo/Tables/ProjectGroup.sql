CREATE TABLE [dbo].[ProjectGroup]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project] ([Id]),
	[GroupId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Group] ([Id])
);
GO
CREATE NONCLUSTERED INDEX unique_id ON [dbo].[ProjectGroup] ([UniqueId]);
GO
CREATE NONCLUSTERED INDEX project_id ON [dbo].[ProjectGroup] ([ProjectId]);
GO
CREATE NONCLUSTERED INDEX group_id ON [dbo].[ProjectGroup] ([GroupId]);