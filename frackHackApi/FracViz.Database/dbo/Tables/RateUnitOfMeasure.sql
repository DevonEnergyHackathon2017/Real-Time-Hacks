CREATE TABLE [dbo].[RateUnitOfMeasure]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Abbreviation] NVARCHAR(32) NOT NULL, 
    [NumUnitOfMeasureId] INT NOT NULL, 
    [DenomUnitOfMeasureId] INT NOT NULL, 
    CONSTRAINT [FK_RateUnitOfMeasure_NumUnitOfMeasure] FOREIGN KEY ([NumUnitOfMeasureId]) REFERENCES [UnitOfMeasure]([Id]), 
    CONSTRAINT [FK_RateUnitOfMeasure_DenomUnitOfMeasure] FOREIGN KEY ([DenomUnitOfMeasureId]) REFERENCES [UnitOfMeasure]([Id])
)
