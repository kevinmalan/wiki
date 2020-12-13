CREATE TABLE [dbo].[DocumentTagCon]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[TagId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Tag]([Id]),
	[DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id]),
);
GO
CREATE NONCLUSTERED INDEX IX_TagId
ON [dbo].[DocumentTagCon]([TagId])
GO
CREATE NONCLUSTERED INDEX IX_DocumentId
ON [dbo].[DocumentTagCon]([DocumentId])