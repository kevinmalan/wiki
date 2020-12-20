CREATE TABLE [dbo].[CompanySignInHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(100,1),
	[UniqueUserId] UNIQUEIDENTIFIER NOT NULL,
	[UniqueCompanyId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL
);
GO
CREATE INDEX IX_UserUniqueId
ON [dbo].[CompanySignInHistory]([UniqueUserId])
GO
CREATE INDEX IX_CompanyUniqueId
ON [dbo].[CompanySignInHistory]([UniqueCompanyId])
