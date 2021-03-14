﻿CREATE TABLE [dbo].[DocumentTagMap]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[TagId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[Tag]([Id]),
	[DocumentId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id]),
);
GO
CREATE INDEX IX_TagId
ON [dbo].[DocumentTagMap]([TagId])
GO
CREATE INDEX IX_DocumentId
ON [dbo].[DocumentTagMap]([DocumentId])