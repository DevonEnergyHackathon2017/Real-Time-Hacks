CREATE TABLE [dbo].[JobCostStructureXRef]
(
	[JobId] INT NOT NULL , 
    [CostStructureId] INT NOT NULL, 
    PRIMARY KEY ([JobId], [CostStructureId]), 
    CONSTRAINT [FK_JobCostStructureXRef_Job] FOREIGN KEY ([JobId]) REFERENCES [Job]([Id]), 
    CONSTRAINT [FK_JobCostStructureXRef_CostStructure] FOREIGN KEY ([CostStructureId]) REFERENCES [CostStructure]([Id])
)
