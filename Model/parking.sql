USE [ADP_Parking]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 14/06/2019 08:12:35 PM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 14/06/2019 08:12:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Vip] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 14/06/2019 08:12:36 PM ******/
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
/****** Object:  Table [dbo].[RegisteredCars]    Script Date: 14/06/2019 08:12:36 PM ******/
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
