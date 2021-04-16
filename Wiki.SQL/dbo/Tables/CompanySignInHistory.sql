CREATE TABLE [dbo].[CompanySignInHistory]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[CompanyId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Company]([Id]),
	[CreatedOn] DATETIMEOFFSET NOT NULL
);
GO
CREATE INDEX IX_UserId
ON [dbo].[CompanySignInHistory]([UserId])
GO
CREATE INDEX IX_CompanyId
ON [dbo].[CompanySignInHistory]([CompanyId])
GO
CREATE INDEX IX_UniqueId
ON [dbo].[CompanySignInHistory] ([UniqueId])