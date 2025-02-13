USE [master]
DROP DATABASE [���� ������������ �������]
GO
CREATE DATABASE [���� ������������ �������]
GO

USE [���� ������������ �������]

CREATE TABLE Program
(
IDProgram INTEGER IDENTITY(1,1) PRIMARY KEY,
[Program_name] VARCHAR(50) NOT NULL,
[Description] VARCHAR(100) NULL,
Price MONEY NOT NULL,
Installation_date DATE NOT NULL
)
CREATE TABLE Computer
(
IDComputer INTEGER IDENTITY(1,1) PRIMARY KEY,
Network_name VARCHAR(10) NOT NULL,
IpAddress VARCHAR(20) NOT NULL,
[Location] VARCHAR(50) NOT NULL,
System_unit VARCHAR(50) NOT NULL,
System_board VARCHAR(50) NOT NULL,
Processor VARCHAR(10) NOT NULL,
RAM VARCHAR(10) NOT NULL,
Video_card VARCHAR(50) NULL,
Video_memory VARCHAR(20) NULL,
HDD VARCHAR(50) NOT NULL,
HDD_capacity VARCHAR(20) NOT NULL,
CD_ROM VARCHAR(20) NULL,
Monitor VARCHAR(20) NOT NULL,
Monitor_2 VARCHAR(20) NULL,
Keyboard VARCHAR(20) NOT NULL,
Mouse VARCHAR(20) NOT NULL,
Printer VARCHAR(50) NULL,
Scanner VARCHAR(20) NULL,
Price_all MONEY NOT NULL,
Purchase_date DATE NOT NULL,
OS VARCHAR(50) NOT NULL,
Notes VARCHAR(250) NULL
)
CREATE TABLE [User]
(
IDUser INTEGER IDENTITY(1,1) PRIMARY KEY,
FIO VARCHAR(50) NOT NULL,
Account_name VARCHAR(10) NOT NULL,
[Password] VARCHAR(5) NOT NULL,
Telephone VARCHAR(11) NULL,
Email VARCHAR(50) NULL,
Creation_date DATE NOT NULL
)
CREATE TABLE RaM
(
IDRaM INTEGER IDENTITY(1,1) PRIMARY KEY,
Repair_date DATE NOT NULL,
[Description] VARCHAR(50) NOT NULL,
Type_of_repair VARCHAR(50) NOT NULL,
Price MONEY NOT NULL
)
CREATE TABLE Program_Computer
(
IDProgram_Computer INTEGER IDENTITY(1,1) PRIMARY KEY,
IDProgram INTEGER NOT NULL FOREIGN KEY REFERENCES Program(IDProgram),
IDComputer INTEGER NOT NULL FOREIGN KEY REFERENCES Computer(IDComputer)
)
CREATE TABLE User_Computer
(
IDUser_Computer INTEGER IDENTITY(1,1) PRIMARY KEY,
IDUser INTEGER NOT NULL FOREIGN KEY REFERENCES [User](IDUser),
IDComputer INTEGER NOT NULL FOREIGN KEY REFERENCES Computer(IDComputer)
)
CREATE TABLE RaM_Computer
(
IDRaM_Computer INTEGER IDENTITY(1,1) PRIMARY KEY,
IDRaM INTEGER NOT NULL FOREIGN KEY REFERENCES RaM(IDRaM),
IDComputer INTEGER NOT NULL FOREIGN KEY REFERENCES Computer(IDComputer)
)
GO