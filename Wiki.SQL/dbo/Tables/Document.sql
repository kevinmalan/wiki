CREATE TABLE [dbo].[Document]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[Title] NVARCHAR(255) NULL,
	[ContentUri] NVARCHAR(1000) NULL,
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project] ([Id])
);
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[Document] ([UniqueId])
GO
CREATE INDEX IX_ProjectId 
ON [dbo].[Document] ([ProjectId])
