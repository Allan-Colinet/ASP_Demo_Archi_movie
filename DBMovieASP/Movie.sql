CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(100) NOT NULL,
	[Description] VARCHAR(500),
	RealisatorId INT

	CONSTRAINT FK_Movie_Realisator FOREIGN KEY (RealisatorId) REFERENCES Person(Id) NOT NULL
)
