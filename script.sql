USE [master]
GO
/****** Object:  Database [Coffee]    Script Date: 11/4/2018 14:12:29 ******/
CREATE DATABASE [Coffee]
 CONTAINMENT = NONE
 ON  PRIMARY 
GO
ALTER DATABASE [Coffee] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Coffee].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Coffee] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Coffee] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Coffee] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Coffee] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Coffee] SET ARITHABORT OFF 
GO
ALTER DATABASE [Coffee] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Coffee] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Coffee] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Coffee] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Coffee] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Coffee] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Coffee] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Coffee] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Coffee] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Coffee] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Coffee] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Coffee] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Coffee] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Coffee] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Coffee] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Coffee] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Coffee] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Coffee] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Coffee] SET  MULTI_USER 
GO
ALTER DATABASE [Coffee] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Coffee] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Coffee] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Coffee] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Coffee] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Coffee] SET QUERY_STORE = OFF
GO
USE [Coffee]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [datetime] NOT NULL,
	[DateCheckOut] [datetime] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[totalPrice] [int] NULL,
	[Cashier] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'admin', N'Chủ quán', N'33354741122871651676713774147412831195', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff1', N'Nhân viên 1', N'33354741122871651676713774147412831195', 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff2', N'Nhân viên 2', N'2122914021714301784233128915223624866126', 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff3', N'Nhân viên 3', N'18833213210117723916811824913021616923162239', 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [Type]) VALUES (N'staff4', N'Nhân viên 4', N'18833213210117723916811824913021616923162239', 0)
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (89, CAST(N'2018-09-27T10:13:43.953' AS DateTime), CAST(N'2018-09-27T10:13:50.150' AS DateTime), 1, 1, 100000, NULL)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (90, CAST(N'2018-09-27T10:18:47.790' AS DateTime), CAST(N'2018-09-27T10:20:08.670' AS DateTime), 2, 1, 124000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (91, CAST(N'2018-09-27T10:33:33.500' AS DateTime), CAST(N'2018-09-27T10:33:38.350' AS DateTime), 2, 1, 100000, N'staff1')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (92, CAST(N'2018-09-27T10:33:41.813' AS DateTime), CAST(N'2018-09-27T10:33:47.390' AS DateTime), 12, 1, 126000, N'staff1')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (93, CAST(N'2018-09-27T10:34:00.987' AS DateTime), CAST(N'2018-09-27T10:34:06.367' AS DateTime), 10, 1, 166000, N'staff4')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (94, CAST(N'2018-09-27T10:51:09.957' AS DateTime), CAST(N'2018-09-27T10:51:15.760' AS DateTime), 8, 1, 126000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (95, CAST(N'2018-09-27T11:22:01.103' AS DateTime), CAST(N'2018-09-27T11:22:07.707' AS DateTime), 12, 1, 505000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (96, CAST(N'2018-09-27T11:38:49.283' AS DateTime), CAST(N'2018-09-27T11:39:01.737' AS DateTime), 7, 1, 200000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (97, CAST(N'2018-09-27T12:15:22.857' AS DateTime), CAST(N'2018-09-27T12:15:30.953' AS DateTime), 1, 1, 250000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (98, CAST(N'2018-09-27T12:30:11.800' AS DateTime), CAST(N'2018-10-01T09:52:43.983' AS DateTime), 1, 1, 22000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (99, CAST(N'2018-09-28T23:18:50.197' AS DateTime), CAST(N'2018-10-01T09:42:53.047' AS DateTime), 7, 1, 102000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (100, CAST(N'2018-10-01T09:44:14.817' AS DateTime), CAST(N'2018-10-01T09:44:23.000' AS DateTime), 7, 1, 90000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (101, CAST(N'2018-10-01T09:45:45.343' AS DateTime), CAST(N'2018-10-01T09:45:50.913' AS DateTime), 8, 1, 88000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (102, CAST(N'2018-10-01T09:50:27.037' AS DateTime), CAST(N'2018-10-01T09:50:35.210' AS DateTime), 2, 1, 110000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (103, CAST(N'2018-10-01T09:56:25.087' AS DateTime), CAST(N'2018-10-01T09:59:29.483' AS DateTime), 6, 1, 66000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (104, CAST(N'2018-10-01T10:37:56.143' AS DateTime), CAST(N'2018-10-01T10:38:07.017' AS DateTime), 7, 1, 175000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (105, CAST(N'2018-10-04T10:19:09.850' AS DateTime), CAST(N'2018-10-04T10:36:49.707' AS DateTime), 8, 1, 200000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (106, CAST(N'2018-10-04T10:39:38.783' AS DateTime), CAST(N'2018-10-04T10:39:44.230' AS DateTime), 6, 1, 100000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (107, CAST(N'2018-10-04T10:47:13.420' AS DateTime), CAST(N'2018-10-04T10:47:19.790' AS DateTime), 9, 1, 100000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (108, CAST(N'2018-10-07T04:08:38.530' AS DateTime), CAST(N'2018-10-07T04:44:53.840' AS DateTime), 3, 1, 150000, N'staff1')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (109, CAST(N'2018-10-07T04:08:41.630' AS DateTime), CAST(N'2018-10-07T14:03:19.350' AS DateTime), 8, 1, 181000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (110, CAST(N'2018-10-07T04:08:45.853' AS DateTime), CAST(N'2018-10-07T04:45:10.503' AS DateTime), 5, 1, 80000, N'staff1')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (111, CAST(N'2018-10-07T04:08:48.220' AS DateTime), CAST(N'2018-10-08T08:33:31.737' AS DateTime), 11, 1, 100000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (112, CAST(N'2018-10-07T04:08:51.790' AS DateTime), CAST(N'2018-10-08T08:33:44.297' AS DateTime), 15, 1, 54000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (113, CAST(N'2018-10-07T04:08:54.710' AS DateTime), CAST(N'2018-10-08T08:33:07.207' AS DateTime), 4, 1, 103000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (114, CAST(N'2018-10-08T08:33:53.630' AS DateTime), CAST(N'2018-10-08T08:34:06.137' AS DateTime), 1, 1, 120000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (115, CAST(N'2018-10-08T08:34:10.410' AS DateTime), CAST(N'2018-10-08T08:34:16.303' AS DateTime), 6, 1, 20000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (116, CAST(N'2018-10-08T08:34:21.327' AS DateTime), CAST(N'2018-10-08T08:34:28.910' AS DateTime), 15, 1, 75000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (117, CAST(N'2018-10-08T08:34:37.573' AS DateTime), CAST(N'2018-10-08T08:34:51.177' AS DateTime), 6, 1, 278000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (118, CAST(N'2018-10-08T08:34:54.187' AS DateTime), CAST(N'2018-10-08T08:34:59.110' AS DateTime), 9, 1, 150000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (119, CAST(N'2018-10-08T08:35:03.517' AS DateTime), CAST(N'2018-10-08T08:35:18.440' AS DateTime), 11, 1, 261000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (120, CAST(N'2018-10-08T08:35:22.080' AS DateTime), CAST(N'2018-10-08T08:35:28.597' AS DateTime), 10, 1, 160000, N'admin')
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DateCheckOut], [idTable], [status], [totalPrice], [Cashier]) VALUES (121, CAST(N'2018-10-08T08:48:42.197' AS DateTime), NULL, 6, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (271, 89, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (272, 90, 21, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (273, 90, 22, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (274, 90, 23, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (275, 90, 24, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (276, 91, 13, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (277, 92, 21, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (278, 92, 23, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (279, 92, 24, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (280, 93, 21, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (281, 93, 39, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (282, 93, 40, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (283, 93, 31, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (284, 94, 21, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (285, 94, 25, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (287, 95, 3, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (288, 95, 5, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (289, 95, 4, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (290, 95, 2, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (291, 96, 22, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (292, 96, 23, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (293, 96, 24, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (294, 96, 13, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (295, 96, 15, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (296, 96, 14, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (297, 97, 21, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (298, 97, 23, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (299, 97, 22, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (300, 97, 24, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (301, 97, 25, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (302, 97, 26, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (303, 98, 21, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (304, 99, 21, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (306, 99, 22, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (307, 100, 6, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (308, 101, 21, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (309, 102, 21, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (310, 103, 21, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (314, 105, 31, 8)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (315, 106, 30, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (316, 107, 30, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (318, 109, 21, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (319, 109, 25, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (320, 109, 8, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (321, 110, 16, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (322, 111, 8, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (323, 111, 10, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (324, 111, 9, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (325, 112, 6, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (326, 113, 3, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (328, 109, 6, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (330, 114, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (331, 114, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (332, 114, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (333, 115, 40, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (334, 116, 39, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (335, 116, 42, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (336, 117, 16, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (337, 117, 28, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (338, 117, 15, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (339, 117, 3, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (340, 118, 30, 6)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (341, 119, 33, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (342, 119, 38, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (343, 119, 17, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (344, 119, 42, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (345, 119, 12, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (346, 119, 14, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (347, 119, 15, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (348, 119, 13, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (349, 120, 18, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (350, 120, 20, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (352, 121, 16, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (353, 121, 17, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (354, 121, 18, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (355, 121, 21, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (2, N'Phở bò', 1, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (3, N'Bánh canh', 1, 26000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (4, N'Bò né', 1, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (5, N'Bún cá', 1, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (6, N'Cà phê đá', 2, 18000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (7, N'Cà phê sữa', 2, 26000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (8, N'Cà phê trứng', 2, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (9, N'Cà phê Latte', 2, 24000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (10, N'Cà phê Espresso', 2, 26000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (11, N'Cà phê Cappuccino', 2, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (12, N'Trà sữa truyền thống', 3, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (13, N'Trà sữa Matcha', 3, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (14, N'Trà sữa Caramel', 3, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (15, N'Trà sữa Chocolate', 3, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (16, N'Sinh tố dâu', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (17, N'Sinh tố bơ', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (18, N'Sinh tố xoài', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (19, N'Sinh tố mít', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (20, N'Sinh tố sa bô', 4, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (21, N'Đá xay truyền thống', 5, 22000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (22, N'Đá xay Matcha', 5, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (23, N'Đá xay Chocolate', 5, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (24, N'Đá xay bạc hà', 5, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (25, N'Nước cam ép', 6, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (26, N'Nước bưởi ép', 6, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (27, N'Nước táo ép', 6, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (28, N'Nước ổi ép', 6, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (29, N'Nước mía ép', 6, 20000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (30, N'Machiato trà đen', 7, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (31, N'Machiato trà xanh', 7, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (32, N'Machiato Rasberry', 7, 25000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (33, N'7 Up', 8, 17000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (34, N'Pesi', 8, 17000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (35, N'Coca Cola', 8, 17000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (36, N'Fanta', 8, 17000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (37, N'Twister', 8, 17000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (38, N'Mountain Dew', 8, 17000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (39, N'Thuốc lá', 9, 15000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (40, N'Bật lửa 2', 10, 10000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (42, N'555', 9, 15000)
SET IDENTITY_INSERT [dbo].[Food] OFF
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'Điểm tâm')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'Cà phê')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'Trà sữa')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'Sinh tố')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'Đá xay')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (6, N'Nước ép')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (7, N'Machiato')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (8, N'Nước ngọt')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (9, N'Linh tinh ')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (10, N'Khác ')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn 01', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn 02', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Bàn 03', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Bàn 04', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Bàn 05', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Bàn 06', N'Có người')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Bàn 07', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (8, N'Bàn 08', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn 09', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn 10', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (11, N'Bàn 11', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (12, N'Bàn 12', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (13, N'Bàn 13', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (14, N'Bàn 14', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (15, N'Bàn 15', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (16, N'Bàn 16', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (17, N'Bàn 17', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (18, N'Bàn 18', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (19, N'Bàn 19', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (20, N'Bàn 20', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (21, N'Bàn 21', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (22, N'Bàn 22', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (23, N'Bàn 23', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (24, N'Bàn 24', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (25, N'Bàn 25', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (26, N'Bàn 26', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (27, N'Bàn 27', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (28, N'Bàn 28', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (29, N'Bàn 29', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (30, N'Bàn 30', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [name]    Script Date: 11/4/2018 14:12:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [name] ON [dbo].[TableFood]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Bàn chưa có tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([Cashier])
REFERENCES [dbo].[Account] ([UserName])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.TableFood
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0  -- status - int
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood AND idBill = @idBill
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login](@id nvarchar(100), @pass nvarchar(100))
AS
BEGIN
	SELECT * FROM Account WHERE Account.UserName = @id AND Account.PassWord = @pass
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Recipe]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Recipe](@idBill nvarchar(100))
AS
BEGIN
SELECT TableFood.name, Food.name, BillInfo.count, Food.price, BillInfo.count*Food.price, Account.DisplayName, Bill.totalPrice, Bill.DateCheckIn, Bill.DateCheckOut
FROM Bill, BillInfo, Food, TableFood, Account
WHERE
	Bill.id = BillInfo.idBill AND 
	BillInfo.idFood=Food.id AND 
	Bill.idTable = TableFood.id  AND
	Bill.Cashier = Account.UserName AND
	Bill.id = @idBill
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Report]    Script Date: 11/4/2018 14:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Report]
	(
	@dateFrom Datetime,
	@dateTo Datetime
	)
AS
	BEGIN
		SELECT c.name , SUM(b.count) , FORMAT(c.price, '#,### VNĐ'), FORMAT(SUM(b.count) * c.price, '#,### VNĐ')
		FROM Bill a, BillInfo b, Food c 
		WHERE a.id = b.idBill AND 
			b.idFood = c.id AND 
			DateCheckIn >= @dateFrom AND 
			DateCheckOut <= @dateTo
		GROUP BY c.name, c.price 
		ORDER BY c.name 
	END
GO
USE [master]
GO
ALTER DATABASE [Coffee] SET  READ_WRITE 
GO
