CREATE TABLE [dbo].[DocumentGroup]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document] ([Id]),
	[GroupId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Group] ([Id])
);
GO
CREATE NONCLUSTERED INDEX unique_id ON [dbo].[DocumentGroup] ([UniqueId]);
GO
CREATE NONCLUSTERED INDEX document_id ON [dbo].[DocumentGroup] ([DocumentId]);
GO
CREATE NONCLUSTERED INDEX group_id ON [dbo].[DocumentGroup] ([GroupId]);