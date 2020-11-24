﻿CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[UserName] NVARCHAR(100) NOT NULL,
	[Password] NVARCHAR(MAX) NOT NULL,
	[Role] NVARCHAR(100) NOT NULL,
);
GO
CREATE NONCLUSTERED INDEX unique_id ON [dbo].[User] ([UniqueId])