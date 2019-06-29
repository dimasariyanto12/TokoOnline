USE [master]
GO
/****** Object:  Database [AnyStore]    Script Date: 6/29/2019 9:26:38 AM ******/
CREATE DATABASE [AnyStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AnyStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DIMASSQL\MSSQL\DATA\AnyStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AnyStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DIMASSQL\MSSQL\DATA\AnyStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AnyStore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AnyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AnyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AnyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AnyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [AnyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AnyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AnyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AnyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AnyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AnyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AnyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AnyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AnyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AnyStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AnyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AnyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AnyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AnyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AnyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AnyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AnyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AnyStore] SET RECOVERY FULL 
GO
ALTER DATABASE [AnyStore] SET  MULTI_USER 
GO
ALTER DATABASE [AnyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AnyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AnyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AnyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AnyStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AnyStore', N'ON'
GO
ALTER DATABASE [AnyStore] SET QUERY_STORE = OFF
GO
USE [AnyStore]
GO
/****** Object:  Table [dbo].[tbl_categories]    Script Date: 6/29/2019 9:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[description] [text] NULL,
	[added_date] [datetime] NULL,
	[added_by] [int] NULL,
 CONSTRAINT [PK_tbl_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_dea_cust]    Script Date: 6/29/2019 9:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_dea_cust](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NULL,
	[name] [varchar](150) NULL,
	[email] [varchar](150) NULL,
	[contact] [varchar](15) NULL,
	[address] [text] NULL,
	[added_date] [datetime] NULL,
	[added_by] [int] NULL,
 CONSTRAINT [PK_tbl_dea_cust] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_products]    Script Date: 6/29/2019 9:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[category] [varchar](50) NULL,
	[description] [text] NULL,
	[rate] [decimal](18, 2) NULL,
	[qty] [decimal](18, 2) NULL,
	[added_date] [datetime] NULL,
	[added_by] [int] NOT NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_transaction]    Script Date: 6/29/2019 9:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_transaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NULL,
	[dea_cust_id] [int] NULL,
	[grandTotal] [decimal](18, 2) NULL,
	[transaction_date] [datetime] NULL,
	[tax] [decimal](18, 2) NULL,
	[discount] [decimal](18, 2) NULL,
	[added_by] [int] NULL,
 CONSTRAINT [PK_tbl_transaction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_transaction_detail]    Script Date: 6/29/2019 9:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_transaction_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[rate] [decimal](18, 2) NULL,
	[qty] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
	[dea_cust_id] [int] NULL,
	[added_date] [datetime] NULL,
	[added_by] [int] NULL,
 CONSTRAINT [PK_tbl_transaction_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 6/29/2019 9:26:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[email] [varchar](150) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[contact] [varchar](15) NULL,
	[address] [text] NULL,
	[gender] [varchar](10) NULL,
	[user_type] [varchar](15) NULL,
	[added_date] [datetime] NULL,
	[added_by] [int] NULL,
 CONSTRAINT [PK_tbl_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AnyStore] SET  READ_WRITE 
GO
