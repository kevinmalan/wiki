CREATE TABLE [dbo].[Company]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[CreatedById] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id])
);
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[Company] ([UniqueId])
GO
CREATE INDEX IX_CreatedById
ON [dbo].[Company] ([CreatedById])