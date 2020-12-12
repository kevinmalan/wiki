﻿CREATE TABLE [dbo].[Tag]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(15) NOT NULL
);
GO
CREATE NONCLUSTERED INDEX unique_id ON [dbo].[Tag] ([UniqueId])