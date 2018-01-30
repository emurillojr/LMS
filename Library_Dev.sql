USE [master]
GO
/****** Object:  Database [Library_Dev]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE DATABASE [Library_Dev]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library_Dev', FILENAME = N'C:\Users\murilloe\Library_Dev.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_Dev_log', FILENAME = N'C:\Users\murilloe\Library_Dev_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Library_Dev] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library_Dev].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library_Dev] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library_Dev] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library_Dev] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library_Dev] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library_Dev] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library_Dev] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library_Dev] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library_Dev] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library_Dev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library_Dev] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library_Dev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library_Dev] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library_Dev] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library_Dev] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library_Dev] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library_Dev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library_Dev] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library_Dev] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library_Dev] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library_Dev] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library_Dev] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Library_Dev] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library_Dev] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library_Dev] SET  MULTI_USER 
GO
ALTER DATABASE [Library_Dev] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library_Dev] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library_Dev] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library_Dev] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library_Dev] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Library_Dev] SET QUERY_STORE = OFF
GO
USE [Library_Dev]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Library_Dev]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchHours]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NULL,
	[CloseTime] [int] NOT NULL,
	[DayOfWeek] [int] NOT NULL,
	[OpenTime] [int] NOT NULL,
 CONSTRAINT [PK_BranchHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckoutHistories]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckoutHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CheckedIn] [datetime2](7) NULL,
	[CheckedOut] [datetime2](7) NOT NULL,
	[LibraryAssetId] [int] NOT NULL,
	[LibraryCardId] [int] NOT NULL,
 CONSTRAINT [PK_CheckoutHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Checkouts]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checkouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LibraryAssetId] [int] NOT NULL,
	[LibraryCardId] [int] NULL,
	[Since] [datetime2](7) NOT NULL,
	[Until] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Checkouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holds]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoldPlaced] [datetime2](7) NOT NULL,
	[LibraryAssetId] [int] NULL,
	[LibraryCardId] [int] NULL,
 CONSTRAINT [PK_Holds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibraryAssets]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryAssets](
	[Author] [nvarchar](max) NULL,
	[DeweyIndex] [nvarchar](max) NULL,
	[ISBN] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[LocationId] [int] NULL,
	[NumberOfCopies] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Year] [int] NOT NULL,
	[Director] [nvarchar](max) NULL,
 CONSTRAINT [PK_LibraryAssets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibraryBranches]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryBranches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Name] [nvarchar](30) NOT NULL,
	[OpenDate] [datetime2](7) NOT NULL,
	[Telephone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LibraryBranches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibraryCards]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Fees] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_LibraryCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patrons]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patrons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[TelephoneNumber] [nvarchar](max) NULL,
	[HomeLibraryBranchId] [int] NULL,
	[LibraryCardId] [int] NULL,
 CONSTRAINT [PK_Patrons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 1/30/2018 9:37:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180114210435_Initial migration', N'2.0.1-rtm-125')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180115020707_Add initial entity models', N'2.0.1-rtm-125')
SET IDENTITY_INSERT [dbo].[BranchHours] ON 

INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (1, 1, 14, 1, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (2, 1, 18, 2, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (3, 1, 18, 3, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (4, 1, 18, 4, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (5, 1, 18, 5, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (6, 1, 18, 6, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (7, 1, 14, 7, 7)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (8, 2, 20, 1, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (9, 2, 20, 2, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (10, 2, 20, 3, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (11, 2, 20, 4, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (12, 2, 20, 5, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (13, 2, 20, 6, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (14, 2, 20, 7, 6)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (15, 3, 22, 1, 5)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (16, 3, 18, 2, 5)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (17, 3, 18, 3, 5)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (18, 3, 18, 4, 5)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (19, 3, 18, 5, 5)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (20, 3, 22, 6, 5)
INSERT [dbo].[BranchHours] ([Id], [BranchId], [CloseTime], [DayOfWeek], [OpenTime]) VALUES (21, 3, 22, 7, 5)
SET IDENTITY_INSERT [dbo].[BranchHours] OFF
SET IDENTITY_INSERT [dbo].[LibraryAssets] ON 

INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Jane Austen', N'823.123', N'9781519202987', 1, CAST(18.00 AS Decimal(18, 2)), N'Book', N'/images/emma.png', 2, 1, 2, N'Emma', 1815, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Charlotte Brontë', N'822.133', N'9781519133977', 2, CAST(18.00 AS Decimal(18, 2)), N'Book', N'/images/janeeyre.png', 3, 1, 2, N'Jane Eyre', 1847, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Herman Melville', N'821.153', N'9780746062760', 3, CAST(12.99 AS Decimal(18, 2)), N'Book', N'/images/mobydick.png', 2, 1, 2, N'Moby Dick', 1851, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'James Joyce', N'822.556', N'9788854139343', 4, CAST(24.00 AS Decimal(18, 2)), N'Book', N'/images/ulysses.png', 2, 3, 2, N'Ulysses', 1922, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Plato', N'820.119', N'9780758320209', 5, CAST(11.00 AS Decimal(18, 2)), N'Book', N'/images/republic.png', 3, 2, 2, N'Republic', -380, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Bram Stoker', N'821.526', N'9781623750282', 6, CAST(18.00 AS Decimal(18, 2)), N'Book', N'/images/dracula.png', 3, 4, 2, N'Dracula', 1897, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Don Delillo', N'822.436', N'9780670803736', 7, CAST(12.99 AS Decimal(18, 2)), N'Book', N'/images/whitenoise.png', 2, 1, 2, N'White Noise', 1985, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'James Baldwin', N'821.325', N'9780552084574', 8, CAST(16.00 AS Decimal(18, 2)), N'Book', N'/images/anothercountry.png', 2, 2, 2, N'Another Country', 1962, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Virginia Woolf', N'822.888', N'9781904919582', 9, CAST(11.00 AS Decimal(18, 2)), N'Book', N'/images/thewaves.png', 1, 1, 2, N'The Waves', 1931, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Alice Walker', N'820.298', N'9780151191543', 10, CAST(11.99 AS Decimal(18, 2)), N'Book', N'/images/colorpurple.png', 1, 2, 2, N'The Color Purple', 1982, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Gabriel García Márquez', N'821.544', N'9789631420494', 11, CAST(12.50 AS Decimal(18, 2)), N'Book', N'/images/onehundred.png', 1, 1, 2, N'One Hundred Years of Solitude', 1967, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Alice Monroe', N'821.444', N'9788702163452', 12, CAST(22.00 AS Decimal(18, 2)), N'Book', N'/images/friendyouth.png', 1, 1, 2, N'Friend of My Youth', 1990, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Virginia Woolf', N'820.111', N'9780795310522', 13, CAST(13.50 AS Decimal(18, 2)), N'Book', N'/images/tothelighthouse.png', 1, 5, 2, N'To the Lighthouse', 1927, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (N'Virginia Woolf', N'821.254', N'9785457626126', 14, CAST(15.99 AS Decimal(18, 2)), N'Book', N'/images/mrsdalloway.png', 3, 1, 2, N'Mrs Dalloway', 1925, NULL)
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 15, CAST(24.00 AS Decimal(18, 2)), N'Video', N'/images/bluevelvet.png', 1, 1, 2, N'Blue Velvet', 1986, N'David Lynch')
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 16, CAST(24.00 AS Decimal(18, 2)), N'Video', N'/images/redrouge.png', 1, 1, 2, N'Trois Coleurs: Rouge', 1994, N'Krzysztof Kieslowski')
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 17, CAST(30.00 AS Decimal(18, 2)), N'Video', N'/images/citizenkane.png', 1, 1, 2, N'Citizen Kane', 1941, N'Orson Welles')
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 18, CAST(28.00 AS Decimal(18, 2)), N'Video', N'/images/spiritedaway.png', 2, 1, 2, N'Spirited Away', 2002, N'Hayao Miyazaki')
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 19, CAST(23.00 AS Decimal(18, 2)), N'Video', N'/images/departed.png', 2, 1, 2, N'The Departed', 2006, N'Martin Scorsese')
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 20, CAST(17.99 AS Decimal(18, 2)), N'Video', N'/images/taxidriver.png', 2, 1, 2, N'Taxi Driver', 1976, N'Martin Scorsese')
INSERT [dbo].[LibraryAssets] ([Author], [DeweyIndex], [ISBN], [Id], [Cost], [Discriminator], [ImageUrl], [LocationId], [NumberOfCopies], [StatusId], [Title], [Year], [Director]) VALUES (NULL, NULL, NULL, 21, CAST(18.00 AS Decimal(18, 2)), N'Video', N'/images/casa.png', 3, 1, 2, N'Casablanca', 1943, N'Michael Curtiz')
SET IDENTITY_INSERT [dbo].[LibraryAssets] OFF
SET IDENTITY_INSERT [dbo].[LibraryBranches] ON 

INSERT [dbo].[LibraryBranches] ([Id], [Address], [Description], [ImageUrl], [Name], [OpenDate], [Telephone]) VALUES (1, N'150 Empire St', N'It was founded in 1875. The Central Library building at 225 Washington Street opened in 1900 and was constructed in a Renaissance style.', N'/images/branches/1.png', N'Lake Shore Branch', CAST(N'1975-05-13T00:00:00.0000000' AS DateTime2), N'555-1234')
INSERT [dbo].[LibraryBranches] ([Id], [Address], [Description], [ImageUrl], [Name], [OpenDate], [Telephone]) VALUES (2, N'123 Skyline Dr', N'The Mountain View branch contains the largest collection of technical and language learning books in the region. This branch is within walking distance to the University campus', N'/images/branches/2.png', N'Mountain View Branch', CAST(N'1998-06-01T00:00:00.0000000' AS DateTime2), N'555-1235')
INSERT [dbo].[LibraryBranches] ([Id], [Address], [Description], [ImageUrl], [Name], [OpenDate], [Telephone]) VALUES (3, N'540 Inventors Circle', N'The newest Lakeview Library System branch, Pleasant Hill has high-speed wireless access for all patrons and hosts Chess Club every Monday and Wednesday evening at 6 PM.', N'/images/branches/3.png', N'Pleasant Hill Branch', CAST(N'2017-09-20T00:00:00.0000000' AS DateTime2), N'555-1236')
SET IDENTITY_INSERT [dbo].[LibraryBranches] OFF
SET IDENTITY_INSERT [dbo].[LibraryCards] ON 

INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (1, CAST(N'2017-06-20T00:00:00.0000000' AS DateTime2), CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (2, CAST(N'2017-06-20T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (3, CAST(N'2017-06-21T00:00:00.0000000' AS DateTime2), CAST(0.50 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (4, CAST(N'2017-06-21T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (5, CAST(N'2017-06-21T00:00:00.0000000' AS DateTime2), CAST(3.50 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (6, CAST(N'2017-06-23T00:00:00.0000000' AS DateTime2), CAST(1.50 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (7, CAST(N'2017-06-23T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[LibraryCards] ([Id], [Created], [Fees]) VALUES (8, CAST(N'2017-06-23T00:00:00.0000000' AS DateTime2), CAST(8.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[LibraryCards] OFF
SET IDENTITY_INSERT [dbo].[Patrons] ON 

INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (1, N'165 Peace St', CAST(N'1986-07-10T00:00:00.0000000' AS DateTime2), N'Jane', N'Patterson', N'555-1234', 1, 1)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (2, N'324 Shadow Ln', CAST(N'1984-03-12T00:00:00.0000000' AS DateTime2), N'Margaret', N'Smith', N'555-7785', 2, 2)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (3, N'18 Stone Cir', CAST(N'1956-02-10T00:00:00.0000000' AS DateTime2), N'Tomas', N'Galloway', N'555-3467', 2, 3)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (4, N'246 Jennifer St', CAST(N'1997-01-17T00:00:00.0000000' AS DateTime2), N'Mary', N'Li', N'555-1223', 3, 4)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (5, N'1465 Williamson St', CAST(N'1952-09-16T00:00:00.0000000' AS DateTime2), N'Dan', N'Carter', N'555-8884', 3, 5)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (6, N'785 Park Ave', CAST(N'1994-03-24T00:00:00.0000000' AS DateTime2), N'Aruna', N'Adhiban', N'555-9988', 3, 6)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (7, N'5654 Main St', CAST(N'2001-11-23T00:00:00.0000000' AS DateTime2), N'Raj', N'Prasad', N'555-7894', 1, 7)
INSERT [dbo].[Patrons] ([Id], [Address], [DateOfBirth], [FirstName], [LastName], [TelephoneNumber], [HomeLibraryBranchId], [LibraryCardId]) VALUES (8, N'1352 Bicycle Ct', CAST(N'1981-10-16T00:00:00.0000000' AS DateTime2), N'Tatyana', N'Ponomaryova', N'555-4568', 3, 8)
SET IDENTITY_INSERT [dbo].[Patrons] OFF
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([Id], [Description], [Name]) VALUES (1, N'A library asset that has been checked out', N'Checked Out')
INSERT [dbo].[Statuses] ([Id], [Description], [Name]) VALUES (2, N'A library asset that is available for loan', N'Available')
INSERT [dbo].[Statuses] ([Id], [Description], [Name]) VALUES (3, N'A library asset that has been lost', N'Lost')
INSERT [dbo].[Statuses] ([Id], [Description], [Name]) VALUES (4, N'A library asset that has been placed On Hold for loan', N'On Hold')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
/****** Object:  Index [IX_BranchHours_BranchId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_BranchHours_BranchId] ON [dbo].[BranchHours]
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CheckoutHistories_LibraryAssetId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CheckoutHistories_LibraryAssetId] ON [dbo].[CheckoutHistories]
(
	[LibraryAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CheckoutHistories_LibraryCardId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_CheckoutHistories_LibraryCardId] ON [dbo].[CheckoutHistories]
(
	[LibraryCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Checkouts_LibraryAssetId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Checkouts_LibraryAssetId] ON [dbo].[Checkouts]
(
	[LibraryAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Checkouts_LibraryCardId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Checkouts_LibraryCardId] ON [dbo].[Checkouts]
(
	[LibraryCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Holds_LibraryAssetId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Holds_LibraryAssetId] ON [dbo].[Holds]
(
	[LibraryAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Holds_LibraryCardId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Holds_LibraryCardId] ON [dbo].[Holds]
(
	[LibraryCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LibraryAssets_LocationId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_LibraryAssets_LocationId] ON [dbo].[LibraryAssets]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LibraryAssets_StatusId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_LibraryAssets_StatusId] ON [dbo].[LibraryAssets]
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patrons_HomeLibraryBranchId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Patrons_HomeLibraryBranchId] ON [dbo].[Patrons]
(
	[HomeLibraryBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patrons_LibraryCardId]    Script Date: 1/30/2018 9:37:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Patrons_LibraryCardId] ON [dbo].[Patrons]
(
	[LibraryCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BranchHours]  WITH CHECK ADD  CONSTRAINT [FK_BranchHours_LibraryBranches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[LibraryBranches] ([Id])
GO
ALTER TABLE [dbo].[BranchHours] CHECK CONSTRAINT [FK_BranchHours_LibraryBranches_BranchId]
GO
ALTER TABLE [dbo].[CheckoutHistories]  WITH CHECK ADD  CONSTRAINT [FK_CheckoutHistories_LibraryAssets_LibraryAssetId] FOREIGN KEY([LibraryAssetId])
REFERENCES [dbo].[LibraryAssets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CheckoutHistories] CHECK CONSTRAINT [FK_CheckoutHistories_LibraryAssets_LibraryAssetId]
GO
ALTER TABLE [dbo].[CheckoutHistories]  WITH CHECK ADD  CONSTRAINT [FK_CheckoutHistories_LibraryCards_LibraryCardId] FOREIGN KEY([LibraryCardId])
REFERENCES [dbo].[LibraryCards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CheckoutHistories] CHECK CONSTRAINT [FK_CheckoutHistories_LibraryCards_LibraryCardId]
GO
ALTER TABLE [dbo].[Checkouts]  WITH CHECK ADD  CONSTRAINT [FK_Checkouts_LibraryAssets_LibraryAssetId] FOREIGN KEY([LibraryAssetId])
REFERENCES [dbo].[LibraryAssets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Checkouts] CHECK CONSTRAINT [FK_Checkouts_LibraryAssets_LibraryAssetId]
GO
ALTER TABLE [dbo].[Checkouts]  WITH CHECK ADD  CONSTRAINT [FK_Checkouts_LibraryCards_LibraryCardId] FOREIGN KEY([LibraryCardId])
REFERENCES [dbo].[LibraryCards] ([Id])
GO
ALTER TABLE [dbo].[Checkouts] CHECK CONSTRAINT [FK_Checkouts_LibraryCards_LibraryCardId]
GO
ALTER TABLE [dbo].[Holds]  WITH CHECK ADD  CONSTRAINT [FK_Holds_LibraryAssets_LibraryAssetId] FOREIGN KEY([LibraryAssetId])
REFERENCES [dbo].[LibraryAssets] ([Id])
GO
ALTER TABLE [dbo].[Holds] CHECK CONSTRAINT [FK_Holds_LibraryAssets_LibraryAssetId]
GO
ALTER TABLE [dbo].[Holds]  WITH CHECK ADD  CONSTRAINT [FK_Holds_LibraryCards_LibraryCardId] FOREIGN KEY([LibraryCardId])
REFERENCES [dbo].[LibraryCards] ([Id])
GO
ALTER TABLE [dbo].[Holds] CHECK CONSTRAINT [FK_Holds_LibraryCards_LibraryCardId]
GO
ALTER TABLE [dbo].[LibraryAssets]  WITH CHECK ADD  CONSTRAINT [FK_LibraryAssets_LibraryBranches_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[LibraryBranches] ([Id])
GO
ALTER TABLE [dbo].[LibraryAssets] CHECK CONSTRAINT [FK_LibraryAssets_LibraryBranches_LocationId]
GO
ALTER TABLE [dbo].[LibraryAssets]  WITH CHECK ADD  CONSTRAINT [FK_LibraryAssets_Statuses_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LibraryAssets] CHECK CONSTRAINT [FK_LibraryAssets_Statuses_StatusId]
GO
ALTER TABLE [dbo].[Patrons]  WITH CHECK ADD  CONSTRAINT [FK_Patrons_LibraryBranches_HomeLibraryBranchId] FOREIGN KEY([HomeLibraryBranchId])
REFERENCES [dbo].[LibraryBranches] ([Id])
GO
ALTER TABLE [dbo].[Patrons] CHECK CONSTRAINT [FK_Patrons_LibraryBranches_HomeLibraryBranchId]
GO
ALTER TABLE [dbo].[Patrons]  WITH CHECK ADD  CONSTRAINT [FK_Patrons_LibraryCards_LibraryCardId] FOREIGN KEY([LibraryCardId])
REFERENCES [dbo].[LibraryCards] ([Id])
GO
ALTER TABLE [dbo].[Patrons] CHECK CONSTRAINT [FK_Patrons_LibraryCards_LibraryCardId]
GO
USE [master]
GO
ALTER DATABASE [Library_Dev] SET  READ_WRITE 
GO
