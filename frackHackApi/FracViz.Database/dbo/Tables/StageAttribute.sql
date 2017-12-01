CREATE TABLE [dbo].[StageAttribute]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StageId] INT NOT NULL, 
    [Name] NVARCHAR(256) NOT NULL, 
    CONSTRAINT [FK_StageAttribute_Stage] FOREIGN KEY ([StageId]) REFERENCES [Stage]([Id])
)
