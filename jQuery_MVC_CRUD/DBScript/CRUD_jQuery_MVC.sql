USE master;
GO

DROP DATABASE IF EXISTS AjaxSamples;
GO

CREATE DATABASE AjaxSamples;
GO

USE AjaxSamples;
GO

CREATE TABLE dbo.Customer (
	CustomerId INT IDENTITY(1,1) NOT NULL
	, Name VARCHAR(40) NOT NULL
	, Country VARCHAR(40) NOT NULL
	, CONSTRAINT PK_Customer_CustomerID PRIMARY KEY CLUSTERED (CustomerId)
);
GO


INSERT INTO dbo.Customer (Name, Country)
VALUES ('John Hammond', 'United States')
	, ('Kieth LaTray', 'United States')
	, ('Prabu Ramaswammy', 'India')
	, ('Ivan Kossak', 'Russia')
	, ('Itzik Ben-gan', 'Israel');
