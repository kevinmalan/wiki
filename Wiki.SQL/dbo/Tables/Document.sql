﻿CREATE TABLE [dbo].[Document]
(
	[Id] UNIQUEIDENTIFIER  NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[CreatedOn] DATETIMEOFFSET NOT NULL,
	[Title] NVARCHAR(255) NULL,
	[ContentUri] NVARCHAR(1000) NULL,
	[ProjectId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES [dbo].[Project] ([Id])
);
GO
CREATE INDEX IX_ProjectId 
ON [dbo].[Document] ([ProjectId])
