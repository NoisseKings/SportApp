CREATE TABLE [dbo].[Shedule]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ReservationId] INT NOT NULL,
	[FromDate] DATETIME NOT NULL,
	[ToDate] DATETIME NOT NULL,
	[CreatedAt]	DATETIME NOT NULL,
	[DateModify] DATETIME NOT NULL, 
    CONSTRAINT [FK_Shedule_Reservation] FOREIGN KEY ([ReservationId]) REFERENCES [Reservation]([Id])
)
