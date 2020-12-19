CREATE TABLE [dbo].[UserRoleCompanyMap]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CompanyId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Company]([Id]),
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[UserRoleId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[UserRole]([Id])
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
