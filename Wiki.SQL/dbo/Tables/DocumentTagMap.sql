CREATE TABLE [dbo].[DocumentTagMap]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[TagId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Tag]([Id]),
	[DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id])
);
GO
CREATE INDEX IX_TagId
ON [dbo].[DocumentTagMap] ([TagId])
GO
CREATE INDEX IX_DocumentId
ON [dbo].[DocumentTagMap] ([DocumentId])
GO
CREATE INDEX IX_UniqueId
ON [dbo].[DocumentTagMap] ([UniqueId])