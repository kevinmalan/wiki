CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[CreatedById] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id])
);
GO
CREATE INDEX IX_CreatedById
ON [dbo].[Company] ([CreatedById])
GO
CREATE INDEX IX_UniqueId
ON [dbo].[Company] ([UniqueId])