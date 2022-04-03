CREATE TABLE [dbo].[AdditionalInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CourtId] INT NOT NULL,
	[Title] NVARCHAR(MAX) NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[DateModify] DATETIME NOT NULL
    CONSTRAINT [FK_AdditionalInfo_Court] FOREIGN KEY ([CourtId]) REFERENCES [Court]([Id])
)
