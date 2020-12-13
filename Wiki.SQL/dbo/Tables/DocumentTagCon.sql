﻿CREATE TABLE [dbo].[DocumentTagCon]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TagId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Tag]([Id]),
	[DocumentId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Document]([Id]),
);
GO
CREATE INDEX IX_TagId
ON [dbo].[DocumentTagCon]([TagId])
GO
CREATE INDEX IX_DocumentId
ON [dbo].[DocumentTagCon]([DocumentId])