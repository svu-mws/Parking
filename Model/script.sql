USE [master]
GO
/****** Object:  Database [ADP_Parking]    Script Date: 19/06/2019 10:30:25 AM ******/
CREATE DATABASE [ADP_Parking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ADP_Parking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ADP_Parking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ADP_Parking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ADP_Parking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ADP_Parking] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ADP_Parking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ADP_Parking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ADP_Parking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ADP_Parking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ADP_Parking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ADP_Parking] SET ARITHABORT OFF 
GO
ALTER DATABASE [ADP_Parking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ADP_Parking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ADP_Parking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ADP_Parking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ADP_Parking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ADP_Parking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ADP_Parking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ADP_Parking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ADP_Parking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ADP_Parking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ADP_Parking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ADP_Parking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ADP_Parking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ADP_Parking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ADP_Parking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ADP_Parking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ADP_Parking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ADP_Parking] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ADP_Parking] SET  MULTI_USER 
GO
ALTER DATABASE [ADP_Parking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ADP_Parking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ADP_Parking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ADP_Parking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ADP_Parking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ADP_Parking] SET QUERY_STORE = OFF
GO
USE [ADP_Parking]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 19/06/2019 10:30:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Color] [nvarchar](50) NULL,
	[ArrivalTime] [smalldatetime] NULL,
	[LeavingTime] [smalldatetime] NULL,
	[ParkID] [int] NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK__Cars__3214EC278142B780] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 19/06/2019 10:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Vip] [int] NULL,
	[Password] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 19/06/2019 10:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Floor] [int] NULL,
	[Department] [nvarchar](1) NULL,
	[Place] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisteredCars]    Script Date: 19/06/2019 10:30:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredCars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Customers]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Positions] FOREIGN KEY([ParkID])
REFERENCES [dbo].[Positions] ([ID])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Positions]
GO
ALTER TABLE [dbo].[RegisteredCars]  WITH CHECK ADD  CONSTRAINT [FK_Table_CarID] FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars] ([ID])
GO
ALTER TABLE [dbo].[RegisteredCars] CHECK CONSTRAINT [FK_Table_CarID]
GO
ALTER TABLE [dbo].[RegisteredCars]  WITH CHECK ADD  CONSTRAINT [FK_Table_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[RegisteredCars] CHECK CONSTRAINT [FK_Table_Customer]
GO
USE [master]
GO
ALTER DATABASE [ADP_Parking] SET  READ_WRITE 
GO
