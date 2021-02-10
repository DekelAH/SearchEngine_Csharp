
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2020 11:02:09
-- Generated from EDMX file: C:\Users\DekelA\Desktop\SearchProject\Search_Method_Events\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SearchDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[resultData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resultData];
GO
IF OBJECT_ID(N'[dbo].[searchData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[searchData];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'searchDatas'
CREATE TABLE [dbo].[searchDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [path] nvarchar(max)  NULL,
    [filename] nvarchar(max)  NULL
);
GO

-- Creating table 'resultDatas'
CREATE TABLE [dbo].[resultDatas] (
    [Id] int  NOT NULL,
    [searchid] int  NULL,
    [resultpath] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'searchDatas'
ALTER TABLE [dbo].[searchDatas]
ADD CONSTRAINT [PK_searchDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'resultDatas'
ALTER TABLE [dbo].[resultDatas]
ADD CONSTRAINT [PK_resultDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------