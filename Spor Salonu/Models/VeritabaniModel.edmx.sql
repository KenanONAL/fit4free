
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2022 09:45:53
-- Generated from EDMX file: C:\Users\konal\source\repos\KenanONAL\fit4free\Spor Salonu\Models\VeritabaniModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [veritabani];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[Duyurulars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Duyurulars];
GO
IF OBJECT_ID(N'[dbo].[Kayits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kayits];
GO
IF OBJECT_ID(N'[dbo].[Mesajs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mesajs];
GO
IF OBJECT_ID(N'[dbo].[Uyelers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uyelers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [kullanici_adi] nchar(50)  NOT NULL,
    [sifre] nchar(50)  NOT NULL
);
GO

-- Creating table 'Duyurulars'
CREATE TABLE [dbo].[Duyurulars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [duyuru_adi] nchar(50)  NOT NULL,
    [duyuru_konu] nchar(500)  NOT NULL,
    [tarih] datetime  NOT NULL
);
GO

-- Creating table 'Kayits'
CREATE TABLE [dbo].[Kayits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [adsoyad] nchar(50)  NOT NULL,
    [mail] nchar(50)  NOT NULL,
    [telefon] nchar(50)  NOT NULL,
    [uyelik_suresi] nchar(50)  NOT NULL,
    [tarih] datetime  NOT NULL
);
GO

-- Creating table 'Mesajs'
CREATE TABLE [dbo].[Mesajs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ad] nchar(50)  NOT NULL,
    [soyad] nchar(50)  NOT NULL,
    [mail] nchar(50)  NOT NULL,
    [konu] nchar(50)  NOT NULL,
    [mesaj1] nchar(500)  NOT NULL,
    [tarih] datetime  NOT NULL,
    [okundu_bilgisi] int  NOT NULL
);
GO

-- Creating table 'Uyelers'
CREATE TABLE [dbo].[Uyelers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [uye_adisoyadi] nchar(50)  NOT NULL,
    [telefon] nchar(50)  NOT NULL,
    [mail] nchar(50)  NOT NULL,
    [uyelik_baslangic_tarihi] datetime  NOT NULL,
    [uyelik_bitis_tarihi] datetime  NOT NULL,
    [toplam_ucret] int  NOT NULL,
    [odenen_ucret] int  NOT NULL,
    [kalan_ucret] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Duyurulars'
ALTER TABLE [dbo].[Duyurulars]
ADD CONSTRAINT [PK_Duyurulars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kayits'
ALTER TABLE [dbo].[Kayits]
ADD CONSTRAINT [PK_Kayits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mesajs'
ALTER TABLE [dbo].[Mesajs]
ADD CONSTRAINT [PK_Mesajs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Uyelers'
ALTER TABLE [dbo].[Uyelers]
ADD CONSTRAINT [PK_Uyelers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------