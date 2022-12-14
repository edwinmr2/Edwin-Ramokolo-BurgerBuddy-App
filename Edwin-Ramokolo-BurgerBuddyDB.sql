USE [master]
GO
/****** Object:  Database [Edwin-Ramokolo-BurgerBuddyDB]    Script Date: 9/20/2022 1:22:22 PM ******/
CREATE DATABASE [Edwin-Ramokolo-BurgerBuddyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Edwin-Ramokolo-BurgerBuddyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Edwin-Ramokolo-BurgerBuddyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Edwin-Ramokolo-BurgerBuddyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Edwin-Ramokolo-BurgerBuddyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Edwin-Ramokolo-BurgerBuddyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET  MULTI_USER 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET QUERY_STORE = OFF
GO
USE [Edwin-Ramokolo-BurgerBuddyDB]
GO
/****** Object:  Table [dbo].[ErrorMessages]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Class] [varchar](50) NULL,
	[Method] [varchar](50) NULL,
	[Message] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_ErrorMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlobalVariable]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlobalVariable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_GlobalVariable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[OrderDateTime] [datetime] NOT NULL,
	[PaymentSourceId] [int] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentSource]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/20/2022 1:22:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[HasGift] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GlobalVariable] ON 

INSERT [dbo].[GlobalVariable] ([Id], [Name], [Value]) VALUES (1, N'OparatingHours-Start', N'09:00')
INSERT [dbo].[GlobalVariable] ([Id], [Name], [Value]) VALUES (2, N'OparatingHours-Closing', N'17:00')
SET IDENTITY_INSERT [dbo].[GlobalVariable] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (1, N'Ordered')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (2, N'Preparing')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (3, N'ReadyToCollect')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (4, N'Collected')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentSource] ON 

INSERT [dbo].[PaymentSource] ([Id], [Name]) VALUES (1, N'POS')
INSERT [dbo].[PaymentSource] ([Id], [Name]) VALUES (2, N'Mr.D')
SET IDENTITY_INSERT [dbo].[PaymentSource] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Price], [HasGift]) VALUES (1, N'Burger', CAST(50.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Products] ([Id], [Name], [Price], [HasGift]) VALUES (2, N'Chips', CAST(10.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Products] ([Id], [Name], [Price], [HasGift]) VALUES (3, N'Soda', CAST(15.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Products] ([Id], [Name], [Price], [HasGift]) VALUES (4, N'Smiley meal', CAST(30.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Order__71D1E811] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK__OrderItem__Order__71D1E811]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Produ__440B1D61] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK__OrderItem__Produ__440B1D61]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__OrderSta__5AEE82B9] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__OrderSta__5AEE82B9]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__PaymentS__46E78A0C] FOREIGN KEY([PaymentSourceId])
REFERENCES [dbo].[PaymentSource] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__PaymentS__46E78A0C]
GO
USE [master]
GO
ALTER DATABASE [Edwin-Ramokolo-BurgerBuddyDB] SET  READ_WRITE 
GO
