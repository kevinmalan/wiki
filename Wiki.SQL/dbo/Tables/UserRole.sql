﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Role] NVARCHAR(50) NOT NULL,
);
GO
CREATE NONCLUSTERED INDEX IX_UniqueId 
ON [dbo].[UserRole] ([UniqueId]);
