CREATE TABLE [dbo].[ProjectScope]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
);
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[ProjectScope] ([UniqueId]);