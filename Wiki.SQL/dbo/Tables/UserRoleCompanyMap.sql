CREATE TABLE [dbo].[UserRoleCompanyMap]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[CompanyId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[Company]([Id]),
	[UserId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[UserRoleId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[UserRole]([Id])
);
GO
CREATE INDEX IX_CompanyId
ON [dbo].[UserRoleCompanyMap]([CompanyId])
GO
CREATE INDEX IX_UserId
ON [dbo].[UserRoleCompanyMap]([UserId])
GO
CREATE INDEX IX_UserRoleId
ON [dbo].[UserRoleCompanyMap]([UserRoleId])
