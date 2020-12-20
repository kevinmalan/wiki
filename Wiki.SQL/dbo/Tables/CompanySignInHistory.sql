CREATE TABLE [dbo].[CompanySignInHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(100,1),
	[UserUniqueId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyUniqueId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL
);
GO
CREATE INDEX IX_UserUniqueId
ON [dbo].[CompanySignInHistory]([UserUniqueId])
GO
CREATE INDEX IX_CompanyUniqueId
ON [dbo].[CompanySignInHistory]([CompanyUniqueId])
