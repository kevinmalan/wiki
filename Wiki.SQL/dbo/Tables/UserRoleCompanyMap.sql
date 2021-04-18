CREATE TABLE [dbo].[UserRoleCompanyMap]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
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
GO
CREATE INDEX IX_UniqueId
ON [dbo].[UserRoleCompanyMap] ([UniqueId])