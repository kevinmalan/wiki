CREATE TABLE [dbo].[DocumentTagConnection]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[TagId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Tag]([Id]),
	[DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id]),
);
GO
CREATE NONCLUSTERED INDEX unique_id ON [dbo].[DocumentTagConnection] ([UniqueId])