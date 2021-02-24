CREATE TABLE [dbo].[Employee] (
    [EmployeeID]     INT          IDENTITY (1, 1) NOT NULL,
    [DocumentTypeID] INT          NOT NULL,
    [DocumentNumber] VARCHAR (20) NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [LastName]       VARCHAR (50) NOT NULL,
    [BirthDate]      DATETIME     NOT NULL,
    [AreaID]         INT          NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employee_Area] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaID]),
    CONSTRAINT [FK_Employee_DocumentType] FOREIGN KEY ([DocumentTypeID]) REFERENCES [dbo].[DocumentType] ([DocumentTypeID])
);

