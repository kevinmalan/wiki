CREATE TABLE [dbo].[DocumentTag]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[TagId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Tag]([Id]),
	[DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id]),
);
GO
CREATE NONCLUSTERED INDEX unique_id ON [dbo].[DocumentTag] ([UniqueId]);
GO
CREATE NONCLUSTERED INDEX document_id ON [dbo].[DocumentTag] ([DocumentId]);