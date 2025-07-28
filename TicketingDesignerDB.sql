-- Create database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TicketingDesignerDB')
BEGIN
    CREATE DATABASE TicketingDesignerDB;
END
GO

USE TicketingDesignerDB;
GO

---------------------------------------------------------
-- 1. Bank Table
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Bank')
BEGIN
    CREATE TABLE Bank (
        BankId INT IDENTITY(1,1) PRIMARY KEY,
        BankName NVARCHAR(100) NOT NULL,
        CONSTRAINT UQ_Bank_BankName UNIQUE (BankName)
    );
END
ELSE
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'BankId' AND Object_ID = OBJECT_ID('Bank'))
        ALTER TABLE Bank ADD BankId INT IDENTITY(1,1) PRIMARY KEY;
    
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'BankName' AND Object_ID = OBJECT_ID('Bank'))
        ALTER TABLE Bank ADD BankName NVARCHAR(100) NOT NULL;

    IF NOT EXISTS (
        SELECT * FROM sys.indexes WHERE name = 'UQ_Bank_BankName'
    )
        ALTER TABLE Bank ADD CONSTRAINT UQ_Bank_BankName UNIQUE (BankName);
END
GO

---------------------------------------------------------
-- 2. Screen Table
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Screen')
BEGIN
    CREATE TABLE Screen (
        ScreenId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        BankId INT NOT NULL,
        ScreenName NVARCHAR(100) NOT NULL,
        IsActive BIT NOT NULL DEFAULT 0,
        RowVersion ROWVERSION,
        CONSTRAINT FK_Screen_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId)
    );
END
ELSE
BEGIN
    IF NOT EXISTS (
        SELECT * FROM sys.columns 
        WHERE Name = 'ScreenId' AND Object_ID = OBJECT_ID('Screen')
    )
        ALTER TABLE Screen ADD ScreenId INT IDENTITY(1,1) NOT NULL;

    IF NOT EXISTS (
        SELECT * FROM sys.columns 
        WHERE Name = 'BankId' AND Object_ID = OBJECT_ID('Screen')
    )
        ALTER TABLE Screen ADD BankId INT NOT NULL;

    IF NOT EXISTS (
        SELECT * FROM sys.columns 
        WHERE Name = 'ScreenName' AND Object_ID = OBJECT_ID('Screen')
    )
        ALTER TABLE Screen ADD ScreenName NVARCHAR(100) NOT NULL;

    IF NOT EXISTS (
        SELECT * FROM sys.columns 
        WHERE Name = 'IsActive' AND Object_ID = OBJECT_ID('Screen')
    )
        ALTER TABLE Screen ADD IsActive BIT NOT NULL DEFAULT 0;

    IF NOT EXISTS (
        SELECT * FROM sys.columns 
        WHERE Name = 'RowVersion' AND Object_ID = OBJECT_ID('Screen')
    )
        ALTER TABLE Screen ADD RowVersion ROWVERSION;

    -- Foreign key check
    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Screen_Bank')
        ALTER TABLE Screen ADD CONSTRAINT FK_Screen_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId);
END
GO


---------------------------------------------------------
-- 3. Service Table
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Service')
BEGIN
    CREATE TABLE Service (
        ServiceId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        BankId INT NOT NULL,
        Name NVARCHAR(100) NOT NULL,
        CONSTRAINT FK_Service_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId)
    );
END
ELSE
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'ServiceId' AND Object_ID = OBJECT_ID('Service'))
        ALTER TABLE Service ADD ServiceId INT IDENTITY(1,1) NOT NULL PRIMARY KEY;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'BankId' AND Object_ID = OBJECT_ID('Service'))
        ALTER TABLE Service ADD BankId INT NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'Name' AND Object_ID = OBJECT_ID('Service'))
        ALTER TABLE Service ADD Name NVARCHAR(100) NOT NULL;

    -- Foreign key check
    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Service_Bank')
        ALTER TABLE Service ADD CONSTRAINT FK_Service_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId);
END
GO


---------------------------------------------------------
-- 4. Button Table
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Button')
BEGIN
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
        RowVersion ROWVERSION,
        CONSTRAINT FK_Button_Screen FOREIGN KEY (ScreenId) REFERENCES Screen(ScreenId),
        CONSTRAINT FK_Button_Service FOREIGN KEY (ServiceId) REFERENCES Service(ServiceId),
        CONSTRAINT FK_Button_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId)
    );
END
ELSE
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'ButtonId' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD ButtonId INT IDENTITY(1,1) PRIMARY KEY;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'ScreenId' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD ScreenId INT NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'NameEnglish' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD NameEnglish NVARCHAR(100) NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'NameArabic' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD NameArabic NVARCHAR(100) NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'ButtonType' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD ButtonType INT NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'MessageEnglish' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD MessageEnglish NVARCHAR(255);

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'MessageArabic' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD MessageArabic NVARCHAR(255);

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'ServiceId' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD ServiceId INT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'BankId' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD BankId INT NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'RowVersion' AND Object_ID = OBJECT_ID('Button'))
        ALTER TABLE Button ADD RowVersion ROWVERSION;

    -- Foreign keys
    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Button_Screen')
        ALTER TABLE Button ADD CONSTRAINT FK_Button_Screen FOREIGN KEY (ScreenId) REFERENCES Screen(ScreenId);

    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Button_Service')
        ALTER TABLE Button ADD CONSTRAINT FK_Button_Service FOREIGN KEY (ServiceId) REFERENCES Service(ServiceId);

    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Button_Bank')
        ALTER TABLE Button ADD CONSTRAINT FK_Button_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId);
END

---------------------------------------------------------
-- Optional: Handle Old String-Based ButtonType
---------------------------------------------------------
IF EXISTS (
    SELECT 1
    FROM sys.columns
    WHERE name = 'ButtonType'
      AND object_id = OBJECT_ID('Button')
      AND system_type_id IN (167, 231) -- varchar/nvarchar
)
BEGIN
    PRINT 'Converting old ButtonType string values to int...';

    -- Drop CHECK constraint if it exists on ButtonType
    DECLARE @ConstraintName NVARCHAR(128);
    SELECT TOP 1 @ConstraintName = dc.name
    FROM sys.check_constraints dc
    INNER JOIN sys.columns c ON dc.parent_object_id = c.object_id AND c.column_id = dc.parent_column_id
    WHERE dc.parent_object_id = OBJECT_ID('Button')
      AND c.name = 'ButtonType';

    IF @ConstraintName IS NOT NULL
    BEGIN
        DECLARE @dropSQL NVARCHAR(MAX) = 'ALTER TABLE Button DROP CONSTRAINT [' + @ConstraintName + ']';
        EXEC sp_executesql @dropSQL;
        PRINT 'Dropped CHECK constraint on ButtonType.';
    END

    -- Update known string values to enum equivalents
    UPDATE Button
    SET ButtonType = CASE 
        WHEN ButtonType = 'Show Message' THEN '0'
        WHEN ButtonType = 'Issue Ticket' THEN '1'
        ELSE '0' -- default fallback
    END;

    -- Change column type to INT
    ALTER TABLE Button
    ALTER COLUMN ButtonType INT NOT NULL;

    PRINT 'ButtonType column converted to INT.';
END
GO


---------------------------------------------------------
-- 5. BankUserMapping Table
---------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BankUserMapping')
BEGIN
    CREATE TABLE BankUserMapping (
        UserName SYSNAME NOT NULL,
        BankId INT NOT NULL,
        CONSTRAINT PK_BankUserMapping PRIMARY KEY (UserName, BankId),
        CONSTRAINT FK_BankUserMapping_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId)
    );
END
ELSE
BEGIN
    -- Ensure columns exist
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'UserName' AND Object_ID = OBJECT_ID('BankUserMapping'))
        ALTER TABLE BankUserMapping ADD UserName SYSNAME NOT NULL;

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'BankId' AND Object_ID = OBJECT_ID('BankUserMapping'))
        ALTER TABLE BankUserMapping ADD BankId INT NOT NULL;

   -- Find the name of the primary key constraint
DECLARE @pkName NVARCHAR(128);
SELECT @pkName = kc.name
FROM sys.key_constraints kc
JOIN sys.index_columns ic ON kc.parent_object_id = ic.object_id AND kc.unique_index_id = ic.index_id
JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE kc.parent_object_id = OBJECT_ID('BankUserMapping')
  AND kc.type = 'PK'
  AND c.name = 'UserName';

-- Drop the primary key using dynamic SQL
IF @pkName IS NOT NULL
BEGIN
    DECLARE @sql NVARCHAR(MAX) = 'ALTER TABLE BankUserMapping DROP CONSTRAINT [' + @pkName + ']';
    EXEC sp_executesql @sql;
END

-- Add composite primary key (UserName, BankId) if not already exists
IF NOT EXISTS (
    SELECT * FROM sys.key_constraints
    WHERE parent_object_id = OBJECT_ID('BankUserMapping')
      AND type = 'PK'
      AND name = 'PK_BankUserMapping'
)
BEGIN
    ALTER TABLE BankUserMapping
    ADD CONSTRAINT PK_BankUserMapping PRIMARY KEY (UserName, BankId);
END



    -- Foreign key check
    IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_BankUserMapping_Bank')
        ALTER TABLE BankUserMapping ADD CONSTRAINT FK_BankUserMapping_Bank FOREIGN KEY (BankId) REFERENCES Bank(BankId);
END
GO



---------------------------------------------------------
-- Drop Security Policies
---------------------------------------------------------

-- Drop Security Policy: Bank
IF EXISTS (SELECT * FROM sys.security_policies WHERE name = 'SecurityPolicy_Bank')
BEGIN
    DROP SECURITY POLICY [dbo].[SecurityPolicy_Bank];
    PRINT 'Security Policy [dbo].[SecurityPolicy_Bank] dropped successfully.';
END
GO

-- Drop Security Policy: Button
IF EXISTS (SELECT * FROM sys.security_policies WHERE name = 'SecurityPolicy_Button')
BEGIN
    DROP SECURITY POLICY [dbo].[SecurityPolicy_Button];
    PRINT 'Security Policy [dbo].[SecurityPolicy_Button] dropped successfully.';
END
GO

-- Drop Security Policy: Screen
IF EXISTS (SELECT * FROM sys.security_policies WHERE name = 'SecurityPolicy_Screen')
BEGIN
    DROP SECURITY POLICY [dbo].[SecurityPolicy_Screen];
    PRINT 'Security Policy [dbo].[SecurityPolicy_Screen] dropped successfully.';
END
GO

-- Drop Security Policy: Service
IF EXISTS (SELECT * FROM sys.security_policies WHERE name = 'SecurityPolicy_Service')
BEGIN
    DROP SECURITY POLICY [dbo].[SecurityPolicy_Service];
    PRINT 'Security Policy [dbo].[SecurityPolicy_Service] dropped successfully.';
END
GO

---------------------------------------------------------
-- Drop Security Predicate Function
---------------------------------------------------------

-- Drop Security Predicate Function
IF OBJECT_ID('dbo.fn_securitypredicate_userBased', 'IF') IS NOT NULL
BEGIN
    DROP FUNCTION dbo.fn_securitypredicate_userBased;
    PRINT 'Function dbo.fn_securitypredicate_userBased dropped successfully.';
END
GO
