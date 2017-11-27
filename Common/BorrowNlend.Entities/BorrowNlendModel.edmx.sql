
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/10/2015 21:11:35
-- Generated from EDMX file: D:\Dropbox\DailySoft\Projet\BorrowNlend\BorrowNlend.entities\BorrowNlendModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BorrowNlend];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operation] DROP CONSTRAINT [FK_PersonOperation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[Operation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operation];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL
);
GO

-- Creating table 'Operation'
CREATE TABLE [dbo].[Operation] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Type] smallint  NOT NULL,
    [Person_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Operation'
ALTER TABLE [dbo].[Operation]
ADD CONSTRAINT [PK_Operation]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Person_ID] in table 'Operation'
ALTER TABLE [dbo].[Operation]
ADD CONSTRAINT [FK_PersonOperation]
    FOREIGN KEY ([Person_ID])
    REFERENCES [dbo].[Person]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonOperation'
CREATE INDEX [IX_FK_PersonOperation]
ON [dbo].[Operation]
    ([Person_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------