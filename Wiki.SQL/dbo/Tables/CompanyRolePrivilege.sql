CREATE TABLE [dbo].[CompanyRolePrivilege]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyRoleId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[CompanyRole]([Id]),
	[PrivilegeId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Privilege]([Id]),
)
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[CompanyRolePrivilege] ([UniqueId]);
GO
CREATE INDEX IX_CompanyRoleId
ON [dbo].[CompanyRolePrivilege] ([CompanyRoleId]);
GO
CREATE INDEX IX_PrivilegeId
ON [dbo].[CompanyRolePrivilege] (PrivilegeId);