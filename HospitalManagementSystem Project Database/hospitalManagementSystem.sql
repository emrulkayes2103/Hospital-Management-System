USE [master]
GO
/****** Object:  Database [hospitalManagementSystem]    Script Date: 2/4/2015 12:07:03 AM ******/
CREATE DATABASE [hospitalManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hospitalManagemrnSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\hospitalManagemrnSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'hospitalManagemrnSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\hospitalManagemrnSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [hospitalManagementSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hospitalManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hospitalManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hospitalManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hospitalManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hospitalManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hospitalManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hospitalManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [hospitalManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hospitalManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hospitalManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hospitalManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [hospitalManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [hospitalManagementSystem]
GO
/****** Object:  Table [dbo].[Accountant]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accountant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Email] [varchar](40) NOT NULL,
	[pass] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](15) NULL,
	[Sex] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[admin]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admin](
	[Name] [varchar](100) NULL,
	[email] [varchar](50) NOT NULL,
	[pass] [varchar](1000) NULL,
	[address] [varchar](200) NULL,
	[mob] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdmitedPatient]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdmitedPatient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[serialNo] [varchar](50) NULL,
	[Date] [varchar](15) NULL,
	[PatientName] [varchar](50) NULL,
	[dateofBirth] [varchar](20) NULL,
	[age] [varchar](20) NULL,
	[Gender] [varchar](20) NULL,
	[bloodGroup] [varchar](5) NULL,
	[phone] [varchar](20) NULL,
	[emergencyNumber] [varchar](20) NULL,
	[fathersName] [varchar](50) NULL,
	[mothername] [varchar](50) NULL,
	[religion] [varchar](50) NULL,
	[nationality] [varchar](20) NULL,
	[passportNo] [varchar](50) NULL,
	[occupation] [varchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[postalCode] [varchar](20) NULL,
	[Email] [varchar](40) NULL,
	[Paid] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[serialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bloodBank]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bloodBank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BloodGroup] [varchar](5) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bloodDonor]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bloodDonor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](20) NULL,
	[BloodGroup] [varchar](10) NULL,
	[Sex] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepertmentList]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DepertmentList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Doctors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[pass] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](20) NULL,
	[Depertment] [varchar](30) NULL,
	[Sex] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DoctorsSchedule]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DoctorsSchedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Day] [varchar](50) NULL,
	[StartTime] [varchar](20) NULL,
	[EndTime] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[laboratorist]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[laboratorist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Email] [varchar](40) NOT NULL,
	[pass] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](15) NULL,
	[Sex] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nurse]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nurse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](15) NULL,
	[Sex] [varchar](10) NULL,
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](20) NULL,
	[Age] [int] NULL,
	[DOB] [varchar](20) NULL,
	[bloodGroup] [varchar](10) NULL,
	[Sex] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[seialNo] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FathersName] [nvarchar](50) NULL,
	[MothersName] [nvarchar](50) NULL,
	[phone] [nvarchar](30) NULL,
	[PayableAmmount] [int] NULL,
	[PaidAmmount] [int] NULL,
	[due] [int] NULL,
	[Date] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[seialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[recentNews]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recentNews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NewsTitle] [nvarchar](1000) NULL,
	[NewsDetails] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Receptionist]    Script Date: 2/4/2015 12:07:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receptionist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Email] [varchar](40) NOT NULL,
	[pass] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[Phone] [varchar](15) NULL,
	[Sex] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [hospitalManagementSystem] SET  READ_WRITE 
GO
