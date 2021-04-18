-- SQL Manager Lite for SQL Server 5.0.1.51843
-- ---------------------------------------
-- Host      : PC201
-- Database  : ConvertCurrency
-- Version   : Microsoft SQL Server 2017 (RTM) 14.0.1000.169


CREATE DATABASE ConvertCurrency
ON PRIMARY
  ( NAME = ConvertCurrency,
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ConvertCurrency.mdf',
    SIZE = 8 MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 64 MB )
LOG ON
  ( NAME = ConvertCurrency_log,
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ConvertCurrency_log.ldf',
    SIZE = 8 MB,
    MAXSIZE = 2097152 MB,
    FILEGROWTH = 64 MB )
COLLATE Lithuanian_CI_AS
GO

USE ConvertCurrency
GO

--
-- Definition for table Currency : 
--

CREATE TABLE dbo.Currency (
  ID int IDENTITY(0, 1) NOT NULL,
  NAME varchar(6) COLLATE Lithuanian_CI_AS NOT NULL,
  TITLE varchar(60) COLLATE Lithuanian_CI_AS NOT NULL,
  RSSLINK varchar(max) COLLATE Lithuanian_CI_AS NOT NULL,
  PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table CurrencyByDate : 
--

CREATE TABLE dbo.CurrencyByDate (
  C_ID int NOT NULL,
  DT varchar(10) COLLATE Lithuanian_CI_AS NOT NULL,
  VAL float NULL,
  PRIMARY KEY CLUSTERED (C_ID, DT)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Data for table dbo.Currency  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Currency ON
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (0, N'EUR', N'EUR', N'-')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (1, N'BGN', N'Bulgarian lev (BGN)', N'https://www.ecb.europa.eu/rss/fxref-bgn.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (2, N'USD', N'US dollar (USD)', N'https://www.ecb.europa.eu/rss/fxref-usd.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (4, N'JPY', N'Japanese yen (JPY)', N'https://www.ecb.europa.eu/rss/fxref-jpy.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (5, N'CZK', N'Czech koruna (CZK)', N'https://www.ecb.europa.eu/rss/fxref-czk.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (6, N'DKK', N'Danish krone (DKK)', N'https://www.ecb.europa.eu/rss/fxref-dkk.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (8, N'GPB', N'Pound sterling (GBP)', N'https://www.ecb.europa.eu/rss/fxref-gbp.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (9, N'HUF', N'Hungarian forint (HUF)', N'https://www.ecb.europa.eu/rss/fxref-huf.html')
GO

INSERT INTO dbo.Currency (ID, NAME, TITLE, RSSLINK)
VALUES 
  (10, N'PLN', N'Polish zloty (PLN)', N'https://www.ecb.europa.eu/rss/fxref-pln.html')
GO

SET IDENTITY_INSERT dbo.Currency OFF
GO

--
-- Data for table dbo.CurrencyByDate  (LIMIT 0,500)
--

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (1, N'2021-04-12', 1.95580005645752)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (1, N'2021-04-13', 1.95580005645752)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (1, N'2021-04-14', 1.95580005645752)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (1, N'2021-04-15', 1.95580005645752)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (1, N'2021-04-16', 1.95580005645752)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (2, N'2021-04-12', 1.1904000043869)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (2, N'2021-04-13', 1.18959999084473)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (2, N'2021-04-14', 1.19640004634857)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (2, N'2021-04-15', 1.19700002670288)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (2, N'2021-04-16', 1.19860005378723)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (4, N'2021-04-12', 130.199996948242)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (4, N'2021-04-13', 130.229995727539)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (4, N'2021-04-14', 130.330001831055)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (4, N'2021-04-15', 130.139999389648)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (4, N'2021-04-16', 130.369995117188)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (5, N'2021-04-12', 26.0310001373291)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (5, N'2021-04-13', 26.0160007476807)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (5, N'2021-04-14', 25.9290008544922)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (5, N'2021-04-15', 25.9419994354248)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (5, N'2021-04-16', 25.9270000457764)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (6, N'2021-04-12', 7.43690013885498)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (6, N'2021-04-13', 7.43739986419678)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (6, N'2021-04-14', 7.43720006942749)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (6, N'2021-04-15', 7.43720006942749)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (6, N'2021-04-16', 7.43680000305176)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (8, N'2021-04-12', 0.865180015563965)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (8, N'2021-04-13', 0.866980016231537)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (8, N'2021-04-14', 0.869180023670197)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (8, N'2021-04-15', 0.867529988288879)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (8, N'2021-04-16', 0.867929995059967)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (9, N'2021-04-12', 356.429992675781)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (9, N'2021-04-13', 359.440002441406)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (9, N'2021-04-14', 358.609985351563)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (9, N'2021-04-15', 358.929992675781)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (9, N'2021-04-16', 361.100006103516)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (10, N'2021-04-12', 4.5246000289917)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (10, N'2021-04-13', 4.56680011749268)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (10, N'2021-04-14', 4.55369997024536)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (10, N'2021-04-15', 4.55539989471436)
GO

INSERT INTO dbo.CurrencyByDate (C_ID, DT, VAL)
VALUES 
  (10, N'2021-04-16', 4.55089998245239)
GO

--
-- Definition for indices : 
--

ALTER TABLE dbo.Currency
ADD UNIQUE NONCLUSTERED (NAME)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

