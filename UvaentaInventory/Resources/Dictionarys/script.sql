USE [master]
GO
/****** Object:  Database [EquipmentUventa]    Script Date: 31.05.2023 14:14:27 ******/
CREATE DATABASE [EquipmentUventa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EquipmentUventa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EquipmentUventa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EquipmentUventa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EquipmentUventa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EquipmentUventa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EquipmentUventa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EquipmentUventa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EquipmentUventa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EquipmentUventa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EquipmentUventa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EquipmentUventa] SET ARITHABORT OFF 
GO
ALTER DATABASE [EquipmentUventa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EquipmentUventa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EquipmentUventa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EquipmentUventa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EquipmentUventa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EquipmentUventa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EquipmentUventa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EquipmentUventa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EquipmentUventa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EquipmentUventa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EquipmentUventa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EquipmentUventa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EquipmentUventa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EquipmentUventa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EquipmentUventa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EquipmentUventa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EquipmentUventa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EquipmentUventa] SET RECOVERY FULL 
GO
ALTER DATABASE [EquipmentUventa] SET  MULTI_USER 
GO
ALTER DATABASE [EquipmentUventa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EquipmentUventa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EquipmentUventa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EquipmentUventa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EquipmentUventa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EquipmentUventa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EquipmentUventa] SET QUERY_STORE = OFF
GO
USE [EquipmentUventa]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [int] NOT NULL,
	[BrandName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabinet]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabinet](
	[CabinetID] [int] NOT NULL,
	[CabinetName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CabinetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentSN] [char](8) NOT NULL,
	[EquipmentModelID] [int] NOT NULL,
	[CabinetID] [int] NOT NULL,
	[EquipmentTypeID] [int] NOT NULL,
	[ResponsibleID] [int] NOT NULL,
	[EquipmentName] [nvarchar](100) NULL,
	[DatePurchase] [date] NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK__Equipmen__344B648F7EC21350] PRIMARY KEY CLUSTERED 
(
	[EquipmentSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentModel]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentModel](
	[EquipmentModelID] [int] NOT NULL,
	[BrandID] [int] NULL,
	[EquipmentModelName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipmentModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentType](
	[EquipmentTypeID] [int] NOT NULL,
	[EquipmentTypeName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionID] [int] NOT NULL,
	[PositionName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestID] [int] NOT NULL,
	[RequestTypeID] [int] NOT NULL,
	[EquipmentSN] [char](8) NOT NULL,
	[ResponsibleID] [int] NOT NULL,
	[RequestName] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestType]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestType](
	[RequestTypeID] [int] NOT NULL,
	[RequestTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_RequestType] PRIMARY KEY CLUSTERED 
(
	[RequestTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responsible]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responsible](
	[ResponsibleID] [int] NOT NULL,
	[ResponsibleFirstName] [nvarchar](100) NULL,
	[ResponsibleSecondName] [nvarchar](100) NULL,
	[IDPosition] [int] NOT NULL,
 CONSTRAINT [PK__Responsi__C95AB055076AD270] PRIMARY KEY CLUSTERED 
(
	[ResponsibleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31.05.2023 14:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NULL,
	[Login] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Brand] ([BrandID], [BrandName]) VALUES (0, N'DELL')
INSERT [dbo].[Brand] ([BrandID], [BrandName]) VALUES (1, N'HP')
INSERT [dbo].[Brand] ([BrandID], [BrandName]) VALUES (2, N'TOHIBA')
INSERT [dbo].[Brand] ([BrandID], [BrandName]) VALUES (3, N'Panasonic')
GO
INSERT [dbo].[Cabinet] ([CabinetID], [CabinetName]) VALUES (0, N'Серверная')
INSERT [dbo].[Cabinet] ([CabinetID], [CabinetName]) VALUES (1, N'Кабинет Директора')
INSERT [dbo].[Cabinet] ([CabinetID], [CabinetName]) VALUES (2, N'Бухгалтерия')
INSERT [dbo].[Cabinet] ([CabinetID], [CabinetName]) VALUES (3, N'Кабинет персонала')
INSERT [dbo].[Cabinet] ([CabinetID], [CabinetName]) VALUES (4, N'Кабинет 52')
GO
INSERT [dbo].[Equipment] ([EquipmentSN], [EquipmentModelID], [CabinetID], [EquipmentTypeID], [ResponsibleID], [EquipmentName], [DatePurchase], [StatusID]) VALUES (N'10456329', 6, 1, 5, 2, N'Телефон директора', CAST(N'2023-05-09' AS Date), 0)
INSERT [dbo].[Equipment] ([EquipmentSN], [EquipmentModelID], [CabinetID], [EquipmentTypeID], [ResponsibleID], [EquipmentName], [DatePurchase], [StatusID]) VALUES (N'37591246', 5, 0, 3, 2, N'Модем основной', CAST(N'2023-01-20' AS Date), 0)
INSERT [dbo].[Equipment] ([EquipmentSN], [EquipmentModelID], [CabinetID], [EquipmentTypeID], [ResponsibleID], [EquipmentName], [DatePurchase], [StatusID]) VALUES (N'47382915', 1, 0, 0, 2, N'Компьютер персональный', CAST(N'2023-05-02' AS Date), 0)
INSERT [dbo].[Equipment] ([EquipmentSN], [EquipmentModelID], [CabinetID], [EquipmentTypeID], [ResponsibleID], [EquipmentName], [DatePurchase], [StatusID]) VALUES (N'73618294', 3, 3, 3, 6, N'Роутер', CAST(N'2023-05-11' AS Date), 0)
INSERT [dbo].[Equipment] ([EquipmentSN], [EquipmentModelID], [CabinetID], [EquipmentTypeID], [ResponsibleID], [EquipmentName], [DatePurchase], [StatusID]) VALUES (N'92837465', 4, 1, 1, 3, N'Принтер струйный', CAST(N'2023-05-18' AS Date), 0)
GO
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (1, 0, N'zq4m7')
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (2, 2, N'xw8n3')
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (3, 1, N'ty6p9')
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (4, 1, N'sv3r5')
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (5, 2, N'ru1t7')
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (6, 2, N'qt9y4')
INSERT [dbo].[EquipmentModel] ([EquipmentModelID], [BrandID], [EquipmentModelName]) VALUES (7, 3, N'ps7x2')
GO
INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeName]) VALUES (0, N'Компьютер')
INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeName]) VALUES (1, N'Принтер')
INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeName]) VALUES (2, N'Смартфон')
INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeName]) VALUES (3, N'Модем')
INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeName]) VALUES (4, N'Сканер')
INSERT [dbo].[EquipmentType] ([EquipmentTypeID], [EquipmentTypeName]) VALUES (5, N'Телефон')
GO
INSERT [dbo].[Position] ([PositionID], [PositionName]) VALUES (0, N'Директор')
INSERT [dbo].[Position] ([PositionID], [PositionName]) VALUES (1, N'Экономист')
INSERT [dbo].[Position] ([PositionID], [PositionName]) VALUES (2, N'Бухгалтер')
INSERT [dbo].[Position] ([PositionID], [PositionName]) VALUES (3, N'Технический специалист')
GO
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (1, N'Анна', N'Смирнова', 0)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (2, N'Иван', N'Петров', 3)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (3, N'Мария', N'Иванова', 1)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (4, N'Дмитрий', N'Сидоров', 3)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (5, N'Елена', N'Кузнецова', 0)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (6, N'Алексей', N'Попов', 2)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (7, N'Софья', N'Васильева', 2)
INSERT [dbo].[Responsible] ([ResponsibleID], [ResponsibleFirstName], [ResponsibleSecondName], [IDPosition]) VALUES (8, N'Роман', N'Новиков', 1)
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (0, N'Админестратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Бухгалтер')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Директор')
GO
INSERT [dbo].[Status] ([StatusID], [StatusName]) VALUES (0, N'В норме')
INSERT [dbo].[Status] ([StatusID], [StatusName]) VALUES (1, N'Сообщение')
GO
INSERT [dbo].[User] ([UserID], [RoleID], [Login], [Password], [UserName]) VALUES (0, 0, N'Admin', N'admin', N'Админестратор')
INSERT [dbo].[User] ([UserID], [RoleID], [Login], [Password], [UserName]) VALUES (1, 2, N'ivanov', N'1234', N'Ivanov')
INSERT [dbo].[User] ([UserID], [RoleID], [Login], [Password], [UserName]) VALUES (3, 1, N'alex', N'1234', N'Alex')
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK__Equipment__Cabin__34C8D9D1] FOREIGN KEY([CabinetID])
REFERENCES [dbo].[Cabinet] ([CabinetID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK__Equipment__Cabin__34C8D9D1]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK__Equipment__Equip__33D4B598] FOREIGN KEY([EquipmentModelID])
REFERENCES [dbo].[EquipmentModel] ([EquipmentModelID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK__Equipment__Equip__33D4B598]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK__Equipment__Equip__35BCFE0A] FOREIGN KEY([EquipmentTypeID])
REFERENCES [dbo].[EquipmentType] ([EquipmentTypeID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK__Equipment__Equip__35BCFE0A]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK__Equipment__Respo__36B12243] FOREIGN KEY([ResponsibleID])
REFERENCES [dbo].[Responsible] ([ResponsibleID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK__Equipment__Respo__36B12243]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Status]
GO
ALTER TABLE [dbo].[EquipmentModel]  WITH CHECK ADD FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Equipment] FOREIGN KEY([EquipmentSN])
REFERENCES [dbo].[Equipment] ([EquipmentSN])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Equipment]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestType] FOREIGN KEY([RequestTypeID])
REFERENCES [dbo].[RequestType] ([RequestTypeID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_RequestType]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Responsible] FOREIGN KEY([ResponsibleID])
REFERENCES [dbo].[Responsible] ([ResponsibleID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Responsible]
GO
ALTER TABLE [dbo].[Responsible]  WITH CHECK ADD  CONSTRAINT [FK_Responsible_Position] FOREIGN KEY([IDPosition])
REFERENCES [dbo].[Position] ([PositionID])
GO
ALTER TABLE [dbo].[Responsible] CHECK CONSTRAINT [FK_Responsible_Position]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
USE [master]
GO
ALTER DATABASE [EquipmentUventa] SET  READ_WRITE 
GO
