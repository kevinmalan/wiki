CREATE TABLE [dbo].[Document]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[Title] NVARCHAR(255) NULL,
	[ContentUri] NVARCHAR(1000) NULL,
	[ProjectId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Project] ([Id]),
	[CreatedById] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id])
);
GO
CREATE INDEX IX_ProjectId 
ON [dbo].[Document] ([ProjectId])
GO
CREATE INDEX IX_UserId
ON [dbo].[Document]([CreatedById])
GO
CREATE INDEX IX_UniqueId
ON [dbo].[Document] ([UniqueId])