CREATE TABLE [dbo].[User]
(
	[Id]                INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Firstname]         NVARCHAR(MAX) NOT NULL,
    [Lastname]          NVARCHAR(MAX) NOT NULL,
    [Email]             NVARCHAR(MAX) NOT NULL,
    [Username]          NVARCHAR(MAX) NOT NULL,
    [Password]          NVARCHAR(MAX) NOT NULL,
    [PhoneNumber]       NVARCHAR(MAX) NOT NULL,
    [Birthday]          DATE NULL,
    [AddressId]         INT NULL,
    [CreatedAt]         DATETIME NOT NULL,
	[DateModify]        DATETIME NOT NULL, 
    [Country]           NVARCHAR(MAX) NOT NULL, 
    [City]              NVARCHAR(MAX) NOT NULL, 
    [Street]            NVARCHAR(MAX) NOT NULL, 
    [ZipCode ]          NVARCHAR(MAX) NOT NULL
)
