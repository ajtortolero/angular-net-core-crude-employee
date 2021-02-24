CREATE TABLE [dbo].[Area] (
    [AreaID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED ([AreaID] ASC)
);

