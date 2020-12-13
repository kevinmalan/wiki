CREATE TABLE [dbo].[CompanyUserCon]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User] ([Id]),
	[CompanyId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Company]([Id]),
	[CompanyRoleId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[CompanyRole]([Id])
);
GO
CREATE UNIQUE INDEX Unique_UserId_CompanyId
ON [dbo].[CompanyUserCon]([UserId], [CompanyId])
GO
CREATE INDEX IX_UserId
ON [dbo].[CompanyUserCon]([UserId])
GO
CREATE INDEX IX_CompanyId
ON [dbo].[CompanyUserCon]([CompanyId])
GO
CREATE INDEX IX_CompanyRoleId
ON [dbo].[CompanyUserCon]([CompanyRoleId])
