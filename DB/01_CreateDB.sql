USE [master]
GO
EXEC sp_configure 'show advanced options' , '1';
GO
reconfigure;
GO
EXEC sp_configure 'clr enabled' , '1'
GO
reconfigure;
-- Turn advanced options back off
EXEC sp_configure 'show advanced options' , '0';
GO    
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'RRStaffDirectory') 
BEGIN 
    ALTER DATABASE [RRStaffDirectory] SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
    DROP DATABASE [RRStaffDirectory] 
END 
GO
CREATE DATABASE [RRStaffDirectory] COLLATE Cyrillic_General_CI_AS;
GO
ALTER DATABASE [RRStaffDirectory] SET TRUSTWORTHY ON
GO