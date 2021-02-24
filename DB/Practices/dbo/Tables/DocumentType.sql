CREATE TABLE [dbo].[DocumentType] (
    [DocumentTypeID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED ([DocumentTypeID] ASC)
);

