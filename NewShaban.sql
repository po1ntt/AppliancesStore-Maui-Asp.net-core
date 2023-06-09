USE [master]
GO
/****** Object:  Database [AppliancesStore]    Script Date: 23.06.2023 11:05:50 ******/
CREATE DATABASE [AppliancesStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AppliancesStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AppliancesStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AppliancesStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AppliancesStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AppliancesStore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AppliancesStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AppliancesStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AppliancesStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AppliancesStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AppliancesStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AppliancesStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [AppliancesStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AppliancesStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AppliancesStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AppliancesStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AppliancesStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AppliancesStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AppliancesStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AppliancesStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AppliancesStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AppliancesStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AppliancesStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AppliancesStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AppliancesStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AppliancesStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AppliancesStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AppliancesStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AppliancesStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AppliancesStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AppliancesStore] SET  MULTI_USER 
GO
ALTER DATABASE [AppliancesStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AppliancesStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AppliancesStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AppliancesStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AppliancesStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AppliancesStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AppliancesStore] SET QUERY_STORE = ON
GO
ALTER DATABASE [AppliancesStore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AppliancesStore]
GO
/****** Object:  Table [dbo].[Adreses]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adreses](
	[id_adress] [int] IDENTITY(1,1) NOT NULL,
	[adress] [nvarchar](max) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Adreses] PRIMARY KEY CLUSTERED 
(
	[id_adress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[id_basket] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[user_Id] [int] NULL,
	[countProduct] [int] NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[id_basket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[id_brand] [int] IDENTITY(1,1) NOT NULL,
	[nameBrand] [nvarchar](max) NULL,
	[logoBrand] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[id_brand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id_category] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[id_favorites] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[id_favorites] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderedProducts]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderedProducts](
	[id_orderedProducts] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[order_id] [int] NULL,
	[CountProduct] [int] NULL,
 CONSTRAINT [PK_OrderedProducts] PRIMARY KEY CLUSTERED 
(
	[id_orderedProducts] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id_order] [int] IDENTITY(1,1) NOT NULL,
	[orderNumber] [nvarchar](max) NULL,
	[dateOrderBegin] [nvarchar](max) NULL,
	[dateOrderEnd] [nvarchar](max) NULL,
	[status_id] [int] NULL,
	[user_id] [int] NULL,
	[paymentMethod_id] [int] NULL,
	[comment] [nvarchar](max) NULL,
	[FirstNameReceiver] [nvarchar](max) NULL,
	[SecondNameReceiver] [nvarchar](max) NULL,
	[PatronymicReceiver] [nvarchar](max) NULL,
	[AdressReceiver] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id_order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id_paymentMethod] [int] IDENTITY(1,1) NOT NULL,
	[paymentMethod] [nvarchar](max) NULL,
 CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[id_paymentMethod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](max) NULL,
	[productDescription] [nvarchar](max) NULL,
	[productCategory_id] [int] NULL,
	[productBrand_id] [int] NULL,
	[productImage] [nvarchar](max) NULL,
	[productPrice] [float] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[id_reviews] [int] NOT NULL,
	[product_id] [int] NULL,
	[user_id] [int] NULL,
	[review] [nvarchar](max) NULL,
	[grade] [float] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[id_reviews] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_role] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id_status] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[id_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.06.2023 11:05:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[gender] [nvarchar](max) NULL,
	[firstName] [nvarchar](max) NULL,
	[secondName] [nvarchar](max) NULL,
	[patronymic] [nvarchar](max) NULL,
	[login] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (5, N'LifeSmart', N'https://i.ibb.co/YW1YyVK/Life-Smart.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (6, N'Timson', N'https://i.ibb.co/VWLtqRK/Timson.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (7, N'Tuya-Smart', N'https://i.ibb.co/bsT7bPV/Tuya-Smart.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (8, N'Winia', N'https://i.ibb.co/cbRfYg0/winia.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (9, N'Uniel', N'https://i.ibb.co/9wPy91k/Uniel.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (10, N'Aceline', N'https://i.ibb.co/WVmTRxC/Aceline.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (11, N'Babyono', N'https://i.ibb.co/s2pJcvq/babyono.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (12, N'Dexp', N'https://i.ibb.co/wsVDvZ5/dexp.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (13, N'Digma', N'https://i.ibb.co/CbMtQFT/digma.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (14, N'Ekf', N'https://i.ibb.co/5T7jSnS/Ekf.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (15, N'Enever', N'https://i.ibb.co/K52fvKz/eneever.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (16, N'Fenix Present', N'https://i.ibb.co/Mf8N4vH/fenixpresent.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (17, N'Flama', N'https://i.ibb.co/HT08bnJ/Flama.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (18, N'Galaxy', N'https://i.ibb.co/vv9Lt0H/Galaxy.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (19, N'GoodHelper', N'https://i.ibb.co/k8FXvQx/goodhelperlogobrand.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (20, N'HomeStar', N'https://i.ibb.co/02H3v7y/homestar.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (21, N'Leben', N'https://i.ibb.co/R2RR0Ty/Lebent.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (22, N'Lumme', N'https://i.ibb.co/nk2JYGj/Lumme.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (23, N'Nord-Frost', N'https://i.ibb.co/gRqTwcF/Nord-Frost.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (24, N'Saratov', N'https://i.ibb.co/6Nr3G6T/saratov.jpg')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (25, N'Sibling', N'https://i.ibb.co/tPnjRpZ/Sibling.png')
INSERT [dbo].[Brand] ([id_brand], [nameBrand], [logoBrand]) VALUES (26, N'Tcl', N'https://i.ibb.co/5xDZK60/tcl.png')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id_category], [name], [logo]) VALUES (5, N'Плиты', N'https://i.ibb.co/mtqv6Sb/pligdfsglogo.jpg')
INSERT [dbo].[Category] ([id_category], [name], [logo]) VALUES (6, N'Прочее', N'https://i.ibb.co/X8W9X40/prochee.jpg')
INSERT [dbo].[Category] ([id_category], [name], [logo]) VALUES (7, N'Умный дом', N'https://i.ibb.co/6BCWjCW/smartdom.jpg')
INSERT [dbo].[Category] ([id_category], [name], [logo]) VALUES (8, N'Часы', N'https://i.ibb.co/YPfYgTc/clock.jpg')
INSERT [dbo].[Category] ([id_category], [name], [logo]) VALUES (9, N'Холодильники', N'https://i.ibb.co/vxXtQNh/holodilniki.png')
INSERT [dbo].[Category] ([id_category], [name], [logo]) VALUES (10, N'Нарезка и смешивание', N'https://i.ibb.co/YyDXKQm/narezkasmeshivanie.jpg')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Favorites] ON 

INSERT [dbo].[Favorites] ([id_favorites], [product_id], [user_id]) VALUES (53, 16, 1)
INSERT [dbo].[Favorites] ([id_favorites], [product_id], [user_id]) VALUES (56, 17, 1)
INSERT [dbo].[Favorites] ([id_favorites], [product_id], [user_id]) VALUES (68, 19, 1)
SET IDENTITY_INSERT [dbo].[Favorites] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderedProducts] ON 

INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (2, 16, 7, 1)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (3, 6, 7, 1)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (4, 7, 7, 1)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (5, 24, 7, 3)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (6, 16, 8, 1)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (7, 6, 8, 1)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (8, 7, 8, 1)
INSERT [dbo].[OrderedProducts] ([id_orderedProducts], [product_id], [order_id], [CountProduct]) VALUES (9, 24, 8, 3)
SET IDENTITY_INSERT [dbo].[OrderedProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id_order], [orderNumber], [dateOrderBegin], [dateOrderEnd], [status_id], [user_id], [paymentMethod_id], [comment], [FirstNameReceiver], [SecondNameReceiver], [PatronymicReceiver], [AdressReceiver]) VALUES (7, N'996492', N'22.06.2023', N'23.06.2023', 4, 1, 2, N'bhhbhh', N'fhvgg', N'ghgvhh', N'chhvh', N'gyhvh')
INSERT [dbo].[Orders] ([id_order], [orderNumber], [dateOrderBegin], [dateOrderEnd], [status_id], [user_id], [paymentMethod_id], [comment], [FirstNameReceiver], [SecondNameReceiver], [PatronymicReceiver], [AdressReceiver]) VALUES (8, N'916078', N'23.06.2023', NULL, 1, 1, 1, N'дом', N'Никита', N'Шаханов', N'Дмитриевич', N'Г. Покров ул Ленина 11')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 

INSERT [dbo].[PaymentMethod] ([id_paymentMethod], [paymentMethod]) VALUES (1, N'Оплата наличными')
INSERT [dbo].[PaymentMethod] ([id_paymentMethod], [paymentMethod]) VALUES (2, N'Оплата банковской картой')
SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (6, N'Пульт управления LifeSmart LS069WH
', N'управление-со смартфона, питание-батарейка, до 100 м, радиоканал', 7, 5, N'https://i.ibb.co/YP4dW5n/pult-Upravlenie-Life-Smart.png', 500)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (7, N'Умная розетка Sibling Powerswitch-W-W
', N'16 А, 220 В, 3.5 кВт, Wi-Fi, помощник-Алиса', 7, 25, N'https://i.ibb.co/Zxqsj82/Sibling-Powerswitch.webp', 600)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (8, N'Умная светодиодная лампа EKF Connect 8W WIFI RGBW E27
', N'Wi-Fi, E27, 8 Вт, 806 лм, 2700 К, 6500 К, 220-240 В / 50-60 Гц', 7, 14, N'https://i.ibb.co/pKcdxGJ/EKFConnect.webp', 700)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (9, N'IP-камера Digma DiVision 201
', N'1280x720, 15 кадр./сек, CMOS, 1 Мп, Wi-Fi, ночная съемка, датчик движения', 7, 13, N'https://i.ibb.co/1dmnrqc/digma-DIVision201.webp', 3000)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (10, N'Умный дверной замок Nayun Smart Door Lock
', N'Wi-Fi, экосистема-TuyaSmart', 7, 7, N'https://i.ibb.co/b6stbG3/smart-Dvernoy-Zamok.webp', 2000)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (11, N'Блендер GoodHelper HB-412 белый
', N'Блендер Goodhelper HB-412 мощностью 280 Вт оптимален для домашнего использования. Двигатель рассчитан на продолжительную бесперебойную работу и имеет защиту от перегрузки. ', 10, 19, N'https://i.ibb.co/8c7F63y/Good-Helper.webp', 3000)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (12, N'Блендер Galaxy GL2105 белый
', N'Блендер Galaxy GL2105 с погружной насадкой позволяет быстро измельчать и смешивать в однородную массу различные продукты. Он изготовлен в прочном пластиковом корпусе и оснащен одним скоростным режимом с простым управлением одной кнопкой. ', 10, 18, N'https://i.ibb.co/DwJyynN/Galaxy-GL2105.webp', 2000)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (13, N'Блендер Homestar HS-2016 белый
', N'лендер погружной HOMESTAR HS-2016 действует с мощностью 300 Вт при наличии одной скорости. При производстве погружной части прибора использовался прочный и безопасный для здоровья пластик.', 10, 20, N'https://i.ibb.co/SBTN5hs/Homestar-HS-2016.webp', 2500)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (14, N'Блендер LEBEN 269-002 белый
', N'Погружной блендер LEBEN 269-002 предназначен для легкого измельчения, взбивания и смешивания различных продуктов до однородной массы. ', 10, 21, N'https://i.ibb.co/x2nPXzK/LEBEN-269-002.webp', 2600)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (15, N'Блендер LUMME LU-1835 красный
', N'Ручной блендер со съемной насадкой и лезвиями из пищевой нержавеющей стали удобен в использовании и идеально подходит для приготовления детского питания, овощных пюре, супов-пюре, майонеза, соусов, коктейлей. ', 10, 22, N'https://i.ibb.co/VJs9Xvs/LUMMELU-1835.webp', 2634.33)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (16, N'Стерилизатор Timson TO-01-111
', N'Стерилизатор Timson TO-01-111 станет полезным помощником для молодой мамы, которая сможет носить его всегда с собой. Прибор в пластиковом корпусе зеленого цвета вмещает в себя одну бутылочку, которую простерилизует за 6 минут.', 6, 6, N'https://i.ibb.co/SK1tKSS/Timson-TO-01-111.webp', 242.33)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (17, N'Подогреватель бутылочек Babyono 199
', N'Подогреватель бутылочек Babyono 199 незаменим для использования во время длительной дороги или путешествия, ведь его функционирование осуществляется посредством автомобильного прикуривателя. Выполнен в виде компактной сумки,', 6, 11, N'https://i.ibb.co/GFzMyBm/FLAMACE3208-B.webp', 24155.23)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (18, N'Электрическая плита FLAMA CE 3208 B коричневый
', N'Электрическая плита FLAMA CE 3208 B со стильным коричневым корпусом оснащена двумя мощными конфорками и вместительной духовкой. За эмалированной варочной панелью легко ухаживать, ', 5, 17, N'https://i.ibb.co/FwW6dHp/FLAMACE3208-B.webp', 232.32)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (19, N'Плита компактная электрическая Aceline INC-1400 черный

', N'Плита компактная электрическая Aceline INC-1400 при мощности 1400 Вт обладает одной индукционной конфоркой диаметром 17.5 см. ', 5, 10, N'https://i.ibb.co/1sgVxbB/Aceline-INC-1400.webp', 2134312.32)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (20, N'Плита компактная электрическая Skyline DP-45B черный
', N'Плита компактная электрическая Skyline DP-45B представлена в необычном округлом дизайне с варочной панелью из стеклокерамики немаркого черного цвета. ', 5, 15, N'https://i.ibb.co/Qbn36gf/Skyline-DP-45-B.webp', 15999)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (21, N'Микроволновая печь DEXP MS-71 черный
', N'Микроволновая печь DEXP MS-71 обладает всеми необходимыми для такого типа устройств функциями и возможностями, и при этом не усложнена лишними и редко используемыми. ', 5, 12, N'https://i.ibb.co/yFSWSjt/DEXPMS-71.webp', 5888)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (22, N'Микроволновая печь Winia KOR-6617WW белый
', N'Микроволновая печь Winia KOR-6617WW обладает традиционным корпусом белого цвета. Простая в обращении модель позволяет быстро разогревать и размораживать пищу. ', 5, 8, N'https://i.ibb.co/0C9F8Dw/KOR-6617-WW.webp', 3999)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (23, N'Холодильник компактный DEXP TF050D белый
', N'Холодильник DEXP TF050D в белом корпусе является идеальной моделью для дачи, офиса или гостиничного номера. Объем холодильной камеры представленной модели составляет 43 литра. ', 9, 12, N'https://i.ibb.co/jwb6Z4J/DEXPTF050-D.webp', 8999)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (24, N'Холодильник компактный TCL TR-41CZ серебристый
', N'Холодильник компактный TCL TR-41CZ со стильным серебристым корпусом подходит для одиночного проживания. Камера оснащена одной металлической полочкой и двумя лотками в дверце. ', 9, 26, N'https://i.ibb.co/KzJf5xw/TCLTR41-CZ.webp', 9213)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (25, N'Холодильник компактный DEXP RF-SD050RMA/W белый
', N'Холодильник компактный DEXP RF-SD050RMA/W вместительностью 47 л оптимально дополнит офис или дачу. Прибор не имеет морозильной камеры. Камера состоит из 2 полок и балкончиков в дверце. ', 9, 12, N'https://i.ibb.co/CHbhJBk/RF-SD050-RMAW.webp', 10000)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (26, N'Холодильник компактный Саратов 452 белый
', N'Холодильник Саратов 452 представляет собой бытовое устройство, предназначенное для замораживания продуктов питания или хранения их в охлажденном состоянии.', 9, 24, N'https://i.ibb.co/F5mGjYw/saratov452white.webp', 12300)
INSERT [dbo].[Products] ([id_product], [productName], [productDescription], [productCategory_id], [productBrand_id], [productImage], [productPrice]) VALUES (27, N'Холодильник с морозильником Nordfrost NRT 143 332 серебристый
', N'Холодильник полноразмерный с морозильником NORDFROST NRT 143 332 − двухкамерный прибор с размерами корпуса 123.5x57.4x62.5 см. ', 9, 23, N'https://i.ibb.co/x7DktTK/Nordfrost-NRT-143-332.webp', 14999)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([id_status], [status]) VALUES (1, N'Принят')
INSERT [dbo].[Status] ([id_status], [status]) VALUES (2, N'Собран')
INSERT [dbo].[Status] ([id_status], [status]) VALUES (3, N'Курьер в пути')
INSERT [dbo].[Status] ([id_status], [status]) VALUES (4, N'Доставлен')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_user], [gender], [firstName], [secondName], [patronymic], [login], [password], [role_id]) VALUES (1, N'М', N'Тимур', N'Толстов', N'Артемьевич', N'1', N'1', NULL)
INSERT [dbo].[Users] ([id_user], [gender], [firstName], [secondName], [patronymic], [login], [password], [role_id]) VALUES (2, N'-', N'-', N'-', N'-', N'sdagsadg', N'gsadgdsa', NULL)
INSERT [dbo].[Users] ([id_user], [gender], [firstName], [secondName], [patronymic], [login], [password], [role_id]) VALUES (3, NULL, NULL, NULL, NULL, N'test', N'test', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Adreses]  WITH CHECK ADD  CONSTRAINT [FK_Adreses_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Adreses] CHECK CONSTRAINT [FK_Adreses_Users]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id_product])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Products]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Users] FOREIGN KEY([user_Id])
REFERENCES [dbo].[Users] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Users]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id_product])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Products]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id_user])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Users]
GO
ALTER TABLE [dbo].[OrderedProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderedProducts_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id_order])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderedProducts] CHECK CONSTRAINT [FK_OrderedProducts_Orders]
GO
ALTER TABLE [dbo].[OrderedProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderedProducts_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id_product])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderedProducts] CHECK CONSTRAINT [FK_OrderedProducts_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentMethod] FOREIGN KEY([paymentMethod_id])
REFERENCES [dbo].[PaymentMethod] ([id_paymentMethod])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentMethod]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id_status])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Status]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brand] FOREIGN KEY([productBrand_id])
REFERENCES [dbo].[Brand] ([id_brand])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brand]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([productCategory_id])
REFERENCES [dbo].[Category] ([id_category])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id_product])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[Roles] ([id_role])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [AppliancesStore] SET  READ_WRITE 
GO
