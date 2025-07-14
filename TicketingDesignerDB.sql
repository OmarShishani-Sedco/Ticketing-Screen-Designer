-- Create database (no fixed file paths)
CREATE DATABASE TicketingDesignerDB;
GO

USE TicketingDesignerDB;
GO

-- Create all required tables
CREATE TABLE Bank (
    BankId INT IDENTITY(1,1) PRIMARY KEY,
    BankName NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Bank_BankName UNIQUE (BankName)
);

CREATE TABLE Screen (
    ScreenId INT IDENTITY(1,1) PRIMARY KEY,
    BankId INT NOT NULL,
    ScreenName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);

CREATE TABLE Service (
    ServiceId INT IDENTITY(1,1) PRIMARY KEY,
    BankId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);

CREATE TABLE Button (
    ButtonId INT IDENTITY(1,1) PRIMARY KEY,
    ScreenId INT NOT NULL,
    NameEnglish NVARCHAR(100) NOT NULL,
    NameArabic NVARCHAR(100) NOT NULL,
    ButtonType INT NOT NULL,
    MessageEnglish NVARCHAR(255),
    MessageArabic NVARCHAR(255),
    ServiceId INT NULL,
    BankId INT NOT NULL,
    FOREIGN KEY (ScreenId) REFERENCES Screen(ScreenId),
    FOREIGN KEY (ServiceId) REFERENCES Service(ServiceId),
    FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);

-- Mapping between users and banks (used for RLS)
CREATE TABLE BankUserMapping (
    UserName SYSNAME PRIMARY KEY,
    BankId INT NOT NULL,
    FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);

-- Row-Level Security predicate function
CREATE FUNCTION [dbo].[fn_securitypredicate_userBased](@BankId INT)
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN
    SELECT 1 AS fn_result
    FROM dbo.BankUserMapping
    WHERE (UserName = USER_NAME() AND BankId = @BankId)
       OR USER_NAME() IN ('dbo', 'sa');  -- Add any exempt users here
GO

-- Security policies for RLS
CREATE SECURITY POLICY [dbo].[SecurityPolicy_Bank] 
ADD FILTER PREDICATE [dbo].[fn_securitypredicate_userBased]([BankId]) ON [dbo].[Bank]
WITH (STATE = ON, SCHEMABINDING = ON);
GO

CREATE SECURITY POLICY [dbo].[SecurityPolicy_Button] 
ADD FILTER PREDICATE [dbo].[fn_securitypredicate_userBased]([BankId]) ON [dbo].[Button]
WITH (STATE = ON, SCHEMABINDING = ON);
GO

CREATE SECURITY POLICY [dbo].[SecurityPolicy_Screen] 
ADD FILTER PREDICATE [dbo].[fn_securitypredicate_userBased]([BankId]) ON [dbo].[Screen]
WITH (STATE = ON, SCHEMABINDING = ON);
GO

CREATE SECURITY POLICY [dbo].[SecurityPolicy_Service] 
ADD FILTER PREDICATE [dbo].[fn_securitypredicate_userBased]([BankId]) ON [dbo].[Service]
WITH (STATE = ON, SCHEMABINDING = ON);
GO
