CREATE TABLE [dbo].[UnitOfMeasure]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Abbreviation] NVARCHAR(32) NULL
)
