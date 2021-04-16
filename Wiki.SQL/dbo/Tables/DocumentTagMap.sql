﻿CREATE TABLE [dbo].[DocumentTagMap]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[UniqueTagId] UNIQUEIDENTIFIER NOT NULL,
	[UniqueDocumentId] UNIQUEIDENTIFIER NOT NULL,
);
GO
CREATE INDEX IX_UniqueId
ON [dbo].[DocumentTagMap] ([UniqueId])