CREATE TABLE [dbo].[Divisions] (
    [codeDiv] INT      IDENTITY (1, 1) NOT NULL,
    [empId]   INT      NULL,
    [dateDiv] DATETIME NULL,
    [divide]  BIT      NULL,
    CONSTRAINT [PK_dbo.Divisions] PRIMARY KEY CLUSTERED ([codeDiv] ASC)
);

