CREATE TABLE [dbo].[JobThresholdXRef]
(
	[JobId] INT NOT NULL PRIMARY KEY, 
    [ThresholdId] INT NOT NULL, 
    CONSTRAINT [FK_JobThresholdXRef_Job] FOREIGN KEY ([JobId]) REFERENCES [Job]([Id]), 
    CONSTRAINT [FK_JobThresholdXRef_Threshold] FOREIGN KEY ([ThresholdId]) REFERENCES [Threshold]([Id])
)
