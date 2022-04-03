CREATE TABLE [dbo].[Court]
(
	[Id]                INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [AdressId]          INT NOT NULL,
    [Name]              NVARCHAR(MAX) NOT NULL,
    [Email]             NVARCHAR(MAX) NOT NULL,
    [Password]          NVARCHAR(MAX) NOT NULL,
    [DateOfCreation]    DATETIME NOT NULL,
    [WorkingHours]      NVARCHAR(MAX) NOT NULL,
    [PriceForHour]      NVARCHAR(MAX) NOT NULL,
    [CreatedAt]         DATETIME NOT NULL,
	[DateModify]        DATETIME NOT NULL, 
    [PhoneNumber]       NVARCHAR(MAX) NOT NULL
)
