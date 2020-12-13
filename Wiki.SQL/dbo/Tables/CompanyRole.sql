CREATE TABLE [dbo].[CompanyRole]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UniqueId] UNIQUEIDENTIFIER NOT NULL,
	[Role] NVARCHAR(50) NOT NULL,
);
GO
CREATE INDEX IX_UniqueId 
ON [dbo].[CompanyRole] ([UniqueId]);