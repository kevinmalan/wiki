﻿CREATE TABLE [dbo].[ProjectScope]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
);
GO
CREATE INDEX IX_UniqueId
ON [dbo].[ProjectScope] ([UniqueId])