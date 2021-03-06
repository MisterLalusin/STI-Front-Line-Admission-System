USE [master]
GO
/****** Object:  Database [STILocalDB]    Script Date: 14 Oct 2018 12:55:55 PM ******/
CREATE DATABASE [STILocalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STILocalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\STILocalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'STILocalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\STILocalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [STILocalDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STILocalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STILocalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STILocalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STILocalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STILocalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STILocalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [STILocalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STILocalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STILocalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STILocalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STILocalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STILocalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STILocalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STILocalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STILocalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STILocalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STILocalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STILocalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STILocalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STILocalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STILocalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STILocalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STILocalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STILocalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [STILocalDB] SET  MULTI_USER 
GO
ALTER DATABASE [STILocalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STILocalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STILocalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STILocalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [STILocalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [STILocalDB] SET QUERY_STORE = OFF
GO
USE [STILocalDB]
GO
/****** Object:  Table [dbo].[tblAdmissionOfficers]    Script Date: 14 Oct 2018 12:55:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmissionOfficers](
	[UserID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[FullName] [varchar](50) NULL,
	[Age] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NULL,
	[UserLevel] [varchar](50) NULL,
 CONSTRAINT [PK_tblAdmissionOfficers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMasterPassword]    Script Date: 14 Oct 2018 12:55:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMasterPassword](
	[PasswordID] [int] NULL,
	[MasterPassword] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSTIEnrollees]    Script Date: 14 Oct 2018 12:55:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSTIEnrollees](
	[TRANSACTION_ID] [int] NOT NULL,
	[SCHOOL_LEVEL] [varchar](max) NULL,
	[STUDENT_ID] [varchar](max) NULL,
	[COURSE] [varchar](max) NULL,
	[YEAR_OR_GRADE] [varchar](max) NULL,
	[LRN_OR_ESC] [varchar](max) NULL,
	[STUDENT_NAME] [varchar](max) NULL,
	[BIRTH_DATE] [varchar](max) NULL,
	[BIRTH_PLACE] [varchar](max) NULL,
	[CITIZENSHIP] [varchar](max) NULL,
	[CIVIL_STATUS] [varchar](max) NULL,
	[GENDER] [varchar](max) NULL,
	[CURRENT_ADDRESS] [varchar](max) NULL,
	[PERMANENT_ADDRESS] [varchar](max) NULL,
	[LANDLINE] [varchar](max) NULL,
	[MOBILE] [varchar](max) NULL,
	[EMAIL] [varchar](max) NULL,
	[PREVIOUS_SCHOOL_LEVEL] [varchar](max) NULL,
	[GRADUATION] [varchar](max) NULL,
	[LAST_SCHOOL_ATTENDED] [varchar](max) NULL,
	[PREVIOUS_LEVEL] [varchar](max) NULL,
	[PREVIOUS_SCHOOL_YEAR_ATTENDED] [varchar](max) NULL,
	[PREVIOUS_YEAR_OR_GRADE] [varchar](max) NULL,
	[TERM] [varchar](max) NULL,
	[FATHER_NAME] [varchar](max) NULL,
	[FATHER_CONTACT_NO] [varchar](max) NULL,
	[FATHER_OCCUPATION] [varchar](max) NULL,
	[FATHER_EMAIL] [varchar](max) NULL,
	[MOTHER_NAME] [varchar](max) NULL,
	[MOTHER_CONTACT_NO] [varchar](max) NULL,
	[MOTHER_OCCUPATION] [varchar](max) NULL,
	[MOTHER_EMAIL] [varchar](max) NULL,
	[GUARDIAN_NAME] [varchar](max) NULL,
	[GUARDIAN_CONTACT_NO] [varchar](max) NULL,
	[GUARDIAN_OCCUPATION] [varchar](max) NULL,
	[GUARDIAN_EMAIL] [varchar](max) NULL,
	[TIME_AND_DATE_ENROLLED] [varchar](max) NULL,
	[SCHOOL_YEAR] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [STILocalDB] SET  READ_WRITE 
GO

USE [STILocalDB]
GO

INSERT INTO [dbo].[tblMasterPassword]
           ([PasswordID]
           ,[MasterPassword])
     VALUES
           (1,'12345678')
GO


USE [STILocalDB]
GO

INSERT INTO [dbo].[tblAdmissionOfficers]
           ([UserID]
           ,[UserName]
           ,[Password]
           ,[FullName]
           ,[Age]
           ,[Address]
           ,[ContactNumber]
           ,[UserLevel])
     VALUES
           (1, 'admin@sti.edu', '12345678', 'Lalusin, John Rovic D.', '17', 'Niing, 4324 San Antonio Quezon', '09158869980', 'Admin')
GO


