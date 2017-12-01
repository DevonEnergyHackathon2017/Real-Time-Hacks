CREATE TABLE [dbo].[Threshold]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StageAttributeId] INT NOT NULL, 
    [Type] NVARCHAR(8) NOT NULL DEFAULT 'MAX', 
    [Value] FLOAT NOT NULL, 
    CONSTRAINT [FK_Threshold_StageAttribute] FOREIGN KEY ([StageAttributeId]) REFERENCES [StageAttribute]([Id])
)
