CREATE TABLE [dbo].[CostStructureItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[CostStructureId] INT NOT NULL, 
    [ThresholdMin] FLOAT NULL DEFAULT 0, 
    [ThresholdMax] FLOAT NULL DEFAULT 0, 
    [Cost] FLOAT NOT NULL DEFAULT 0, 
    [RateUnitOfMeasureId] INT NOT NULL, 
    CONSTRAINT [FK_CostScheduleItem_CostStructure] FOREIGN KEY ([CostStructureId]) REFERENCES [CostStructure]([Id]), 
    CONSTRAINT [FK_CostScheduleItem_RateUnitOfMeasure] FOREIGN KEY ([RateUnitOfMeasureId]) REFERENCES [RateUnitOfMeasure]([Id])
)
