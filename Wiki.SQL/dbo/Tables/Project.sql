CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[CompanyId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Company]([Id]),
	[CreatedById] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id])
);
GO
CREATE INDEX IX_CompanyId 
ON [dbo].[Project] ([CompanyId]);
GO
CREATE INDEX IX_CreatedById
ON [dbo].[Project] ([CreatedById])
GO
CREATE INDEX IX_UniqueId
ON [dbo].[Project] ([UniqueId])