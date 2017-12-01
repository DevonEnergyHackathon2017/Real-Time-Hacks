﻿/*
Deployment script for DVNFracVisualize

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DVNFracVisualize"
:setvar DefaultFilePrefix "DVNFracVisualize"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
PRINT N'Creating [dbo].[JobCostStructureXRef]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TABLE [dbo].[JobCostStructureXRef] (
    [JobId]           INT NOT NULL,
    [CostStructureId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([JobId] ASC, [CostStructureId] ASC)
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[FK_JobCostStructureXRef_Job]...';


GO
ALTER TABLE [dbo].[JobCostStructureXRef] WITH NOCHECK
    ADD CONSTRAINT [FK_JobCostStructureXRef_Job] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Job] ([Id]);


GO
PRINT N'Creating [dbo].[FK_JobCostStructureXRef_CostStructure]...';


GO
ALTER TABLE [dbo].[JobCostStructureXRef] WITH NOCHECK
    ADD CONSTRAINT [FK_JobCostStructureXRef_CostStructure] FOREIGN KEY ([CostStructureId]) REFERENCES [dbo].[CostStructure] ([Id]);


GO
