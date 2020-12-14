CREATE TABLE [dbo].[CompanyRole]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Role] NVARCHAR(50) NOT NULL,
	[AllowCreateProject] BIT NOT NULL DEFAULT 0
);
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[CompanyRole] ([UniqueId]);