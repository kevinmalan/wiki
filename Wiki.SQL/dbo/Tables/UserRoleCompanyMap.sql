﻿CREATE TABLE [dbo].[UserRoleCompanyMap]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[UniqueCompanyId] UNIQUEIDENTIFIER NOT NULL,
	[UniqueUserId] UNIQUEIDENTIFIER NOT NULL,
	[UniqueUserRoleId] UNIQUEIDENTIFIER NOT NULL
);
GO
CREATE INDEX IX_UniqueId
ON [dbo].[UserRoleCompanyMap] ([UniqueId])