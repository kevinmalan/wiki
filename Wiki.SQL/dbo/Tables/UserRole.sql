﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
);
GO
CREATE NONCLUSTERED INDEX IX_UniqueId 
ON [dbo].[UserRole] ([UniqueId]);
