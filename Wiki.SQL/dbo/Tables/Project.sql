CREATE TABLE [dbo].[Project]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[CompanyId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Company]([Id])
);
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[Project] ([UniqueId]);
GO
CREATE INDEX IX_CompanyId 
ON [dbo].[Project] ([CompanyId]);