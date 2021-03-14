CREATE TABLE [dbo].[CompanySignInHistory]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL
);
GO
CREATE INDEX IX_UserId
ON [dbo].[CompanySignInHistory]([UserId])
GO
CREATE INDEX IX_CompanyId
ON [dbo].[CompanySignInHistory]([CompanyId])
