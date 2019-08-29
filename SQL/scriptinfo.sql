USE [master]
GO
/****** Object:  Database [Info]    Script Date: 6/6/2019 1:36:56 PM ******/
CREATE DATABASE [Info]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Info', FILENAME = N'C:\Users\sadki\Info.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Info_log', FILENAME = N'C:\Users\sadki\Info_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Info] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Info].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Info] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Info] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Info] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Info] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Info] SET ARITHABORT OFF 
GO
ALTER DATABASE [Info] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Info] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Info] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Info] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Info] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Info] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Info] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Info] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Info] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Info] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Info] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Info] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Info] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Info] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Info] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Info] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Info] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Info] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Info] SET  MULTI_USER 
GO
ALTER DATABASE [Info] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Info] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Info] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Info] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Info] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Info] SET QUERY_STORE = OFF
GO
USE [Info]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Info]
GO
/****** Object:  Table [dbo].[PersonDb]    Script Date: 6/6/2019 1:36:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonDb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LasttName] [nvarchar](max) NULL,
	[BirthYear] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PersonDb] ON 

INSERT [dbo].[PersonDb] ([Id], [FirstName], [LasttName], [BirthYear]) VALUES (8, N'Terje', N'Kolderup', 1975)
INSERT [dbo].[PersonDb] ([Id], [FirstName], [LasttName], [BirthYear]) VALUES (9, N'Per', NULL, 1980)
INSERT [dbo].[PersonDb] ([Id], [FirstName], [LasttName], [BirthYear]) VALUES (10, N'Pål', NULL, 1981)
SET IDENTITY_INSERT [dbo].[PersonDb] OFF
USE [master]
GO
ALTER DATABASE [Info] SET  READ_WRITE 
GO
