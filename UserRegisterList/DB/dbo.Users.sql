USE [UserRegister]
GO

/****** Object: Table [dbo].[Users] Script Date: 3/10/2019 5:58:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (200) NULL,
    [Email]        VARCHAR (100)  NULL,
    [Gender]       CHAR (1)       NULL,
    [DateReg]      DATE           NULL,
    [SelectedDays] VARCHAR (50)   NULL,
    [AddRequest]   TEXT           NULL
);


