CREATE TABLE [dbo].[DocumentGroupCon]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id]),
	[GroupId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Group]([Id]),
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project]([Id])
);
GO
CREATE UNIQUE INDEX Unique_DocumentId_GroupId
ON [dbo].[DocumentGroupCon]([DocumentId], [GroupId])
GO
CREATE INDEX IX_ProjectId
ON [dbo].[DocumentGroupCon]([ProjectId])
GO
CREATE INDEX IX_GroupId
ON [dbo].[DocumentGroupCon]([GroupId])
GO
CREATE INDEX IX_Documentid
ON [dbo].[DocumentGroupCon]([DocumentId])