USE [FamilyEvent]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [varchar](50) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatMessage]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMessage](
	[ChatID] [varchar](50) NOT NULL,
	[EventBookerID] [varchar](50) NOT NULL,
	[StaffID] [varchar](50) NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_ChatMessage] PRIMARY KEY CLUSTERED 
(
	[ChatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DateTimeLocation]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DateTimeLocation](
	[EventID] [varchar](50) NOT NULL,
	[RoomID] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_DateTimeLocation] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC,
	[RoomID] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Decoration]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Decoration](
	[DecorationID] [varchar](50) NOT NULL,
	[DecorationName] [nvarchar](50) NOT NULL,
	[DecorationPrice] [money] NOT NULL,
	[DecorationImage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Decoration] PRIMARY KEY CLUSTERED 
(
	[DecorationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DecorationProduct]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DecorationProduct](
	[DecorationID] [varchar](50) NOT NULL,
	[ProductID] [varchar](25) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_DecorationProduct] PRIMARY KEY CLUSTERED 
(
	[DecorationID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entertainment]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entertainment](
	[EntertainmentID] [varchar](25) NOT NULL,
	[Status] [bit] NOT NULL,
	[EntertainmentTotal] [money] NOT NULL,
 CONSTRAINT [PK_Entertainment] PRIMARY KEY CLUSTERED 
(
	[EntertainmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntertainmentProduct]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntertainmentProduct](
	[EntertainmentID] [varchar](25) NULL,
	[ProductID] [varchar](25) NOT NULL,
	[ShowID] [varchar](25) NULL,
	[GameID] [varchar](25) NULL,
	[EntertainmentProductPrice] [money] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_EntertainmentProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventID] [varchar](50) NOT NULL,
	[ScriptID] [varchar](25) NULL,
	[DecorationID] [varchar](50) NOT NULL,
	[EventTypeID] [varchar](50) NOT NULL,
	[MenuID] [varchar](50) NOT NULL,
	[EntertainmentID] [varchar](25) NOT NULL,
	[EventBookerID] [varchar](50) NOT NULL,
	[OrganizedPerson] [nvarchar](50) NULL,
	[StartDate] [date] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventBooker]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventBooker](
	[EventBookerID] [varchar](50) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[RegisterDate] [date] NULL,
	[Gender] [bit] NULL,
	[DateOfBirth] [date] NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_EventBooker] PRIMARY KEY CLUSTERED 
(
	[EventBookerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeID] [varchar](50) NOT NULL,
	[EventTypeName] [nvarchar](50) NOT NULL,
	[EventTypeImage] [nvarchar](max) NOT NULL,
	[EventTypeDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Family]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventBookerID] [varchar](50) NOT NULL,
	[MemberID] [nvarchar](50) NULL,
	[MemberName] [nvarchar](max) NOT NULL,
	[MemberPhone] [nvarchar](10) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DateOfBirth] [date] NULL,
	[Description] [nvarchar](max) NULL,
	[Relation] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Family] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventBookerID] [varchar](50) NOT NULL,
	[EventID] [varchar](50) NOT NULL,
	[Vote] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Date] [date] NOT NULL,
	[Reply] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[FoodID] [varchar](50) NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
	[Dish] [nvarchar](50) NOT NULL,
	[FoodPrice] [money] NOT NULL,
	[FoodDescription] [nvarchar](max) NULL,
	[FoodIngredient] [nvarchar](max) NULL,
	[FoodOrigin] [nvarchar](max) NULL,
	[CookingRecipe] [nvarchar](max) NULL,
	[FoodImage] [nvarchar](max) NOT NULL,
	[FoodTypeID] [varchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodType]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodType](
	[FoodTypeID] [varchar](50) NOT NULL,
	[FoodTypeName] [nvarchar](50) NOT NULL,
	[FoodTypeDetail] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FoodType] PRIMARY KEY CLUSTERED 
(
	[FoodTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameServices]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameServices](
	[GameID] [varchar](25) NOT NULL,
	[GameName] [nvarchar](50) NOT NULL,
	[GameServicePrice] [money] NOT NULL,
	[GameDetails] [nvarchar](max) NOT NULL,
	[GameRules] [nvarchar](max) NOT NULL,
	[GameReward] [nvarchar](50) NOT NULL,
	[Supplies] [nvarchar](50) NOT NULL,
	[GameImage] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [varchar](50) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[PriceTotal] [money] NOT NULL,
	[TableQuantity] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuProduct]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuProduct](
	[MenuID] [varchar](50) NOT NULL,
	[Product] [varchar](50) NOT NULL,
	[Quatity] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Type] [bit] NOT NULL,
 CONSTRAINT [PK_MenuProduct] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC,
	[Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [varchar](50) NULL,
	[NotificationContent] [nvarchar](100) NULL,
	[Date] [datetime] NULL,
	[Type] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participant]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant](
	[PhoneParticipant] [float] NOT NULL,
	[FullNameParticipant] [nvarchar](50) NOT NULL,
	[Relation] [nvarchar](50) NOT NULL,
	[EventID] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [varchar](50) NOT NULL,
	[EventID] [varchar](50) NOT NULL,
	[Amount] [money] NOT NULL,
	[PayContent] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [varchar](25) NOT NULL,
	[DecorationProductName] [nvarchar](50) NOT NULL,
	[ProductPrice] [money] NOT NULL,
	[ProductQuantity] [int] NOT NULL,
	[ProductDetails] [nvarchar](max) NOT NULL,
	[ProductImage] [nvarchar](max) NULL,
	[ProductSupplier] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomLocation]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomLocation](
	[RoomID] [varchar](50) NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[Parking] [nvarchar](50) NULL,
	[Capacity] [int] NOT NULL,
	[RoomImage] [nvarchar](max) NULL,
	[RoomDescription] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_RoomLocation] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Script]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Script](
	[id] [varchar](25) NOT NULL,
	[ScriptName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[ScriptContent] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Script] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShowService]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowService](
	[ShowID] [varchar](25) NOT NULL,
	[ShowPrice] [money] NOT NULL,
	[ShowServiceName] [nvarchar](50) NOT NULL,
	[Light] [nvarchar](50) NOT NULL,
	[Sound] [nvarchar](50) NOT NULL,
	[Singer] [nvarchar](50) NOT NULL,
	[ShowDescription] [nvarchar](max) NOT NULL,
	[ShowImage] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Show] PRIMARY KEY CLUSTERED 
(
	[ShowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verify]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verify](
	[VerifyID] [int] IDENTITY(1,1) NOT NULL,
	[VerifyCode] [nvarchar](50) NOT NULL,
	[EventID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Verify] PRIMARY KEY CLUSTERED 
(
	[VerifyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/18/2023 11:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[VoucherID] [varchar](50) NOT NULL,
	[VoucherName] [nvarchar](200) NOT NULL,
	[VoucherDiscount] [int] NOT NULL,
	[VoucherImage] [nvarchar](max) NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
	[EventID] [varchar](50) NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'18e16155-0706-434b-8d30-9', N'thinh123', N'admin@gmail.com', N'0961449382', N'1234', N'staff', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'1ab03b68-2b89-424c-b800-5', N'string', N'string', N'string', N'string', N'staff', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'1bfca16b-a6f6-41c0-b773-2', N'user124', N'nguyenvanb@gmail.com', N'0867860834', N'1234', N'staff', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'3cb00151-6fe8-4c00-adf2-7', N'Manh Cương', N'manhcuong@', N'0865561285', N'Manhcuongz1', N'staff', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'5', N'uoc1', N'uoc1@gmail.com', N'123456789', N'1', N'1', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'6', N'uoc12', N'uocnguyen123@gmail.com', N'1219809226', N'1', N'3', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'65bffbe8-68e2-49e8-a11d-7', N'user123', N'user123@gmail.com', N'0123456789', N'1234', N'staff', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'7', NULL, N'quyentran1@gmail.com', N'933787869', N'1', N'2', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'8', N'Thuong', N'haivv@gmail.com', N'+84384629954', N'1', N'eventBooker', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'AId142527c4-0c6a-4cec-a2', NULL, NULL, N'+840329475550', NULL, N'eventBooker', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'AId7116eba9-c067-48dd-bb', NULL, NULL, N'+84949771791', NULL, N'eventBooker', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'AId7e7a6161-c727-4372-83', NULL, NULL, N'+84378590716', NULL, N'eventBooker', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'AIdd0afc6ad-8a46-4bbd-81', NULL, NULL, N'+84865561285', NULL, N'eventBooker', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'b7aaa1dd-f49f-4280-86aa-a', N'nguyến', N'asa@gmail.com', N'3211232', N'1234', N'staff', 0)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'e20d6e21-0216-408b-b34c-0', N'Manh Cuong', N'manhcuong@', N'0865561285', N'Manhcuongz1', N'staff', 1)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'ef3aade7-9913-4b6a-8b53-7', N'nguyen van a', N'nguyenvana@gmail.com', N'0123456789', N'1234', N'staff', 0)
INSERT [dbo].[Account] ([AccountID], [Username], [Email], [Phone], [Password], [Role], [Status]) VALUES (N'f77b7ab5-6d3b-40c6-8bd2-4', N'nguyenthinh123', N'abc@gmail.com', N'032322122', N'1234', N'staff', 1)
GO
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId0147a93b-bf08-4b5d-', N'RId993031ba-1fc6-42c1-9000-420f372744ab', CAST(N'2023-04-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId0db38fea-9228-4939-', N'RId993031ba-1fc6-42c1-9000-420f372744ab', CAST(N'2023-04-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId2138444d-9cc0-4992-', N'RId352508ae-20db-4cc5-b', CAST(N'2023-04-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId22369e86-5223-4e39-', N'RId993031ba-1fc6-42c1-9000-420f372744ab', CAST(N'2023-04-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId2b151cd5-cd8a-4885-', N'RId993031ba-1fc6-42c1-9000-420f372744ab', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId6061c876-f8ae-465e-', N'RId127f266c-3d97-4246-b', CAST(N'2023-04-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId64f0d70e-faee-4ae6-', N'RId993031ba-1fc6-42c1-9000-420f372744ab', CAST(N'2023-04-29T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVId74dfbe84-ad1b-4536-', N'RId993031ba-1fc6-42c1-9000-420f372744ab', CAST(N'2023-04-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVIdc3e4b988-374b-4120-', N'RId127f266c-3d97-4246-b', CAST(N'2023-04-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVIdd27bd92c-cfec-4893-', N'RId352508ae-20db-4cc5-b', CAST(N'2023-04-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVIdd5094edc-9da0-4d6f-', N'RId127f266c-3d97-4246-b', CAST(N'2023-04-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DateTimeLocation] ([EventID], [RoomID], [Date], [Status]) VALUES (N'EVIddb797278-b5e2-447a-', N'RIdbd0d6df5-7a74-46b9-a', CAST(N'2023-04-15T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'1', N'Vật Dụng chi tiết', 0.0000, N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/canhac.jpg?alt=media&token=d201604c-25ad-4151-b875-16b6249ace5c')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'2', N'Đồ dùng chuyên dụng', 0.0000, N'https://banghe123.com/wp-content/uploads/2020/12/thue-ban-ghe-chen-dia-1-450x285.jpg')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'3', N'Quần áo', 10000000.0000, N'https://file.hstatic.net/200000017614/file/trang_phuc_quan_ao_le_mung_tho_cu_ong_cu_ba_495aec1535d94c809c565cbf920fba1d.jpg')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'5', N'Đồ dùng trang trí', 0.0000, N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fjoyfood.com.vn%2Fdo-dung-1-lan-cho-cac-bua-tiec-cuoi-nam-tai-van-phong-cong-ty-.html&psig=AOvVaw30mLhOTpPVTuh3LypP6SSE&ust=1676623144403000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCIiy8InSmf0CFQAAAAAdAAAAABAJ')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID09aae8c4-cef6-4852', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID0e076b4d-868c-4ccb', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID10562910-a2e2-4dee', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID19a83ad6-921b-486e', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID30b5d6d6-3c95-4d63', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID37333275-9b0c-4a57', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID39bf8230-6f51-460a', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID3b24857a-d630-4b3a', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID3c4cfd85-1816-409d', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID5039e37a-18a5-4210', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID560637b3-ad7d-40b9', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID6735e32d-7ec6-4742', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID6be2e964-0bbb-4bf6', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID81e97e03-ca05-448f', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID82d996cf-2d90-46c2', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID8d71ed11-00a6-47cd', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID8ed72fb7-bfa6-4dff', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoID93061291-e6d9-4bb9', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDad35db4e-a300-4023', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDb75871d8-b099-477e', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDbdf5ff90-bf94-439e', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDd331d448-39db-4e2d', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDd62b7baa-9ed8-46e0', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDd936cd0d-deee-460a', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDe26864cb-d1d6-48dc', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DecoIDf92ac05d-342b-4c98', N'decorationName', 0.0000, N'null')
INSERT [dbo].[Decoration] ([DecorationID], [DecorationName], [DecorationPrice], [DecorationImage]) VALUES (N'DID4943fad9-6938-4964-8', N'string', 0.0000, N'string')
GO
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'1', N'1', 200, 50000.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'2', N'2', 150, 15000.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'3', N'3', 20, 500000.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'5', N'4', 100, 20000.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID09aae8c4-cef6-4852', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID0e076b4d-868c-4ccb', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID10562910-a2e2-4dee', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID19a83ad6-921b-486e', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID30b5d6d6-3c95-4d63', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID39bf8230-6f51-460a', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID3b24857a-d630-4b3a', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID3c4cfd85-1816-409d', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID5039e37a-18a5-4210', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID560637b3-ad7d-40b9', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID6735e32d-7ec6-4742', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID6be2e964-0bbb-4bf6', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID81e97e03-ca05-448f', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID82d996cf-2d90-46c2', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID8d71ed11-00a6-47cd', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID8ed72fb7-bfa6-4dff', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoID93061291-e6d9-4bb9', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDad35db4e-a300-4023', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDb75871d8-b099-477e', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDbdf5ff90-bf94-439e', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDd331d448-39db-4e2d', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDd62b7baa-9ed8-46e0', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDe26864cb-d1d6-48dc', N'1', 1, 0.0000)
INSERT [dbo].[DecorationProduct] ([DecorationID], [ProductID], [Quantity], [Price]) VALUES (N'DecoIDf92ac05d-342b-4c98', N'1', 1, 0.0000)
GO
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'1', 1, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'2', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'EId:1fdfff2e-d5d7-4917-9', 1, 100000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'EId:d8869b7a-d727-4a82-9', 0, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID1743605b-62ce-40af-a', 1, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID26f75eee-2466-4327-a', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID2d089af3-c732-4b81-8', 1, 100000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID2e63016e-6dbe-47bb-9', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID30fd6d91-f1bc-474d-a', 1, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID33a185af-f777-4217-8', 1, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID3f012f02-b399-447e-9', 1, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID4c00c3ec-e864-4393-8', 1, 0.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETID93b7d28d-cdea-4fa0-9', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETIDa4071b15-acde-499a-9', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETIDa8db4451-c2a0-41c8-a', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETIDaecbc337-83ff-49df-a', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETIDbbbf1b6b-8c14-40e3-8', 1, 200000.0000)
INSERT [dbo].[Entertainment] ([EntertainmentID], [Status], [EntertainmentTotal]) VALUES (N'ETIDe0cb9ca7-c17a-4636-b', 1, 200000.0000)
GO
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'1', N'3', N'1', N'1', N'2', N'2', N'5', N'My Son', CAST(N'2023-02-16' AS Date), 27100000.0000, CAST(N'2023-02-16' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'2', N'1', N'1', N'1', N'1', N'1', N'5', N'My Family', CAST(N'2023-03-02' AS Date), 30000000.0000, CAST(N'2023-03-02' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'3', N'4', N'3', N'1', N'1', N'1', N'7', N'Father & Mother', CAST(N'2023-03-24' AS Date), 22000000.0000, CAST(N'2023-03-24' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'5', N'3', N'3', N'3', N'2', N'1', N'5', N'Family', CAST(N'2023-03-25' AS Date), 26900000.0000, CAST(N'2023-03-26' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'6', N'3', N'3', N'3', N'2', N'1', N'7', N'My Son', CAST(N'2023-03-30' AS Date), 15000000.0000, CAST(N'2023-03-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'8', N'3', N'2', N'2', N'2', N'1', N'7', N'My Father', CAST(N'2023-02-16' AS Date), 1234560.0000, CAST(N'2023-02-16' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId0147a93b-bf08-4b5d-', N'SId0c7d7b0a-f429-4578-8', N'DecoIDbdf5ff90-bf94-439e', N'1', N'MenuID12e279b4-6d33-42b1', N'ETID33a185af-f777-4217-8', N'8', N'organizedPeople', CAST(N'2023-04-14' AS Date), 0.0000, CAST(N'2023-04-29' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId0db38fea-9228-4939-', N'SId0c7d7b0a-f429-4578-8', N'DecoID10562910-a2e2-4dee', N'1', N'MenuIDa44fb293-2259-4bbb', N'ETID1743605b-62ce-40af-a', N'8', N'organizedPeople', CAST(N'2023-04-14' AS Date), 0.0000, CAST(N'2023-04-29' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId20d3ca6c-fab3-46f2-', N'SId0c7d7b0a-f429-4578-8', N'DecoID3c4cfd85-1816-409d', N'1', N'MenuIDf4d7dcb8-cbb4-475c', N'ETID2e63016e-6dbe-47bb-9', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 224000.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId2138444d-9cc0-4992-', N'SId0c7d7b0a-f429-4578-8', N'DecoID30b5d6d6-3c95-4d63', N'2', N'MenuIDc6f1d40c-1f86-4467', N'ETIDa8db4451-c2a0-41c8-a', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 236000.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId22369e86-5223-4e39-', N'SId0c7d7b0a-f429-4578-8', N'DecoIDd331d448-39db-4e2d', N'3', N'MenuIDc3297aa2-b495-4589', N'ETID26f75eee-2466-4327-a', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 224000.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId2b151cd5-cd8a-4885-', N'SId0c7d7b0a-f429-4578-8', N'DecoID3b24857a-d630-4b3a', N'1', N'MenuIDac527696-6e7c-4572', N'ETID3f012f02-b399-447e-9', N'8', N'organizedPeople', CAST(N'2023-04-14' AS Date), 0.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId3685d5cb-a463-4363-8', N'1', N'1', N'1', N'1', N'1', N'7', N'My Family', CAST(N'2023-04-03' AS Date), 22000000.0000, CAST(N'2023-04-03' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId5689a660-b13b-4c28-a', N'1', N'1', N'1', N'2', N'1', N'7', N'Family', CAST(N'2023-04-03' AS Date), 10000000.0000, CAST(N'2023-04-03' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId6061c876-f8ae-465e-', N'SId0c7d7b0a-f429-4578-8', N'DecoIDad35db4e-a300-4023', N'1', N'MenuID65eb1f1e-9c09-45ca', N'ETIDe0cb9ca7-c17a-4636-b', N'8', N'organizedPeople', CAST(N'2023-04-14' AS Date), 583998.0000, CAST(N'2023-04-29' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId64f0d70e-faee-4ae6-', N'1', N'1', N'1', N'1', N'1', N'7', N'a', CAST(N'2023-04-11' AS Date), 22000000.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId686dd0a0-83d9-43e6-', N'1', N'1', N'1', N'1', N'1', N'5', N'str  ing', CAST(N'2023-04-06' AS Date), 10000000.0000, CAST(N'2023-04-21' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVId74dfbe84-ad1b-4536-', N'SId0c7d7b0a-f429-4578-8', N'DecoID560637b3-ad7d-40b9', N'1', N'MenuIDf7c24970-d257-4cf4', N'ETIDa4071b15-acde-499a-9', N'8', N'organizedPeople', CAST(N'2023-04-14' AS Date), 583998.0000, CAST(N'2023-04-29' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVIdb4fe033f-22c5-459f-', N'SId0c7d7b0a-f429-4578-8', N'DecoID37333275-9b0c-4a57', N'1', N'MenuIDfa06178f-14e4-429b', N'ETID4c00c3ec-e864-4393-8', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 0.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVIdc0b50536-0843-476d-', N'SId0c7d7b0a-f429-4578-8', N'DecoIDd936cd0d-deee-460a', N'1', N'MenuID34564722-dcb5-4237', N'ETID2d089af3-c732-4b81-8', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 124000.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVIdc3e4b988-374b-4120-', N'SId0c7d7b0a-f429-4578-8', N'DecoIDd62b7baa-9ed8-46e0', N'2', N'MenuID50db210d-4f67-4a10', N'ETID93b7d28d-cdea-4fa0-9', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 224000.0000, CAST(N'2023-04-30' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVIdd27bd92c-cfec-4893-', N'SId0c7d7b0a-f429-4578-8', N'DecoID8d71ed11-00a6-47cd', N'1', N'MenuID76bc17fb-14df-4e26', N'ETID30fd6d91-f1bc-474d-a', N'8', N'organizedPeople', CAST(N'2023-04-14' AS Date), 0.0000, CAST(N'2023-04-29' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVIdd5094edc-9da0-4d6f-', N'SId0c7d7b0a-f429-4578-8', N'DecoID93061291-e6d9-4bb9', N'2', N'MenuID2c79514e-ebd5-4f87', N'ETIDaecbc337-83ff-49df-a', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 224000.0000, CAST(N'2023-05-01' AS Date), 1)
INSERT [dbo].[Event] ([EventID], [ScriptID], [DecorationID], [EventTypeID], [MenuID], [EntertainmentID], [EventBookerID], [OrganizedPerson], [StartDate], [TotalPrice], [EndDate], [Status]) VALUES (N'EVIddb797278-b5e2-447a-', N'SId0c7d7b0a-f429-4578-8', N'DecoID09aae8c4-cef6-4852', N'1', N'MenuID3095adb8-aaad-475b', N'ETIDbbbf1b6b-8c14-40e3-8', N'8', N'organizedPeople', CAST(N'2023-04-15' AS Date), 224000.0000, CAST(N'2023-04-30' AS Date), 1)
GO
INSERT [dbo].[EventBooker] ([EventBookerID], [Fullname], [Email], [Phone], [Address], [RegisterDate], [Gender], [DateOfBirth], [Image], [Status]) VALUES (N'5', N'mvdj', N'uoc123@gmail.com', N'0933757561', N'string', NULL, 1, CAST(N'2023-04-05' AS Date), N'string', 1)
INSERT [dbo].[EventBooker] ([EventBookerID], [Fullname], [Email], [Phone], [Address], [RegisterDate], [Gender], [DateOfBirth], [Image], [Status]) VALUES (N'7', N'Trần Văn Quyền', N'quyen1234@gmail.com', N'0982123698', N'258 Lê Văn Việt, Phường Long Thạnh Mỹ, TP.Thủ Đức', NULL, 1, CAST(N'2023-04-05' AS Date), N'https://www.facebook.com/photo/?fbid=3328969510696823&set=a.1402224653371328&__tn__=%3C', 1)
INSERT [dbo].[EventBooker] ([EventBookerID], [Fullname], [Email], [Phone], [Address], [RegisterDate], [Gender], [DateOfBirth], [Image], [Status]) VALUES (N'8', N'Phạm Thị Thương', N'haivv@gmail.com', N'+84384629954', N'123 Quận 9', NULL, 1, CAST(N'2000-08-17' AS Date), N'https://scontent.fsgn5-3.fna.fbcdn.net/v/t39.30808-6/279367915_2109918329185720_9199987224835987791_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=i_ZIRtiNfaEAX_DNgwj&_nc_ht=scontent.fsgn5-3.fna&oh=00_AfCJz0Yhahl3QeNHsspcGM5A1WvqrBCKRC_iEOXurJZuYw&oe=6436CF98', 1)
INSERT [dbo].[EventBooker] ([EventBookerID], [Fullname], [Email], [Phone], [Address], [RegisterDate], [Gender], [DateOfBirth], [Image], [Status]) VALUES (N'AIdd0afc6ad-8a46-4bbd-81', N'quyenmt', N'quyen', N'+84865561285', N'striaaaaang', CAST(N'2023-04-12' AS Date), 1, CAST(N'2023-04-05' AS Date), N'striaaang', 1)
GO
INSERT [dbo].[EventType] ([EventTypeID], [EventTypeName], [EventTypeImage], [EventTypeDescription]) VALUES (N'1', N'Thôi Nôi', N'data:image/jpeg;base64,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', N'Mừng tiệc thôi nôi')
INSERT [dbo].[EventType] ([EventTypeID], [EventTypeName], [EventTypeImage], [EventTypeDescription]) VALUES (N'2', N'Sinh Nhật', N'data:image/jpeg;base64,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', N'Tiệc sinh nhật mừng bé được 2 tuổi')
INSERT [dbo].[EventType] ([EventTypeID], [EventTypeName], [EventTypeImage], [EventTypeDescription]) VALUES (N'3', N'Mừng Thượng Thọ', N'https://sites.google.com/site/ojovietnam/_/rsrc/1429397733998/cam-nang-cuoc-song/tuyen-tap-bai-van-cung-khan-co-truyen/bai-van-cung-khan-ngay-le-thuong-tho/van%20khan%20thuong%20tho%20www.OJO.vn.jpg', N'Tiệc mừng đại thọ cho những người lớn tuổi.')
INSERT [dbo].[EventType] ([EventTypeID], [EventTypeName], [EventTypeImage], [EventTypeDescription]) VALUES (N'4', N'Tiệc Đoàn Viên', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.nhahangquangon.com%2Fnha-hang-to-chuc-tiec-hop-mat-doan-vien-ben-gia-dinh-mua-trung-thu%2F&psig=AOvVaw1wX1EotFM5rXceordr8_m4&ust=1676624016715000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCOifxKnVmf0CFQAAAAAdAAAAABAE', N'Tiệc đàon viên được tổ chức dành cho 1 vài thành viên xa nhà lâu ngày')
INSERT [dbo].[EventType] ([EventTypeID], [EventTypeName], [EventTypeImage], [EventTypeDescription]) VALUES (N'ETIde2d28e03-d22e-481e-', N'555', N'stri555ng', N'st5555ring')
GO
SET IDENTITY_INSERT [dbo].[Family] ON 

INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (1, N'5', NULL, N'str11111ing', N'1234567890', 1, CAST(N'2023-04-05' AS Date), N'st1111ring', N'str1111ing', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (2, N'5', N'5', N'aaaaa', N'123456789', 1, CAST(N'2023-04-03' AS Date), N'aaaa', N'striaaang', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (3, N'5', N'5', N'str1111111111ing', N'1234', 1, CAST(N'2023-04-03' AS Date), N'str1111111111ing', N'stri111111111ng', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (4, N'5', NULL, N'Đồ AN', N'0933693986', 1, CAST(N'2023-04-05' AS Date), N'thành viên mới trong gia đình', N'cháu', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (5, N'5', NULL, N'ABCD', N'0423213232', 1, CAST(N'2023-04-05' AS Date), N'thành viên', N'cháu', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (6, N'5', NULL, N'dsadds', N'string', 1, CAST(N'2023-04-05' AS Date), N'string', N'string', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (7, N'7', NULL, N'fansaaks', N'hwige', 1, CAST(N'2023-04-05' AS Date), N'qgw', N'con', 1)
INSERT [dbo].[Family] ([id], [EventBookerID], [MemberID], [MemberName], [MemberPhone], [Gender], [DateOfBirth], [Description], [Relation], [Status]) VALUES (8, N'7', NULL, N'abc', N'0432432323', 0, CAST(N'2023-04-05' AS Date), N'323121', N'432', 1)
SET IDENTITY_INSERT [dbo].[Family] OFF
GO
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'1', N'Chả Giò Cuộn Tôm', N'Đồ chiên', 179999.0000, N'Chả giò tôm là món ăn quen thuộc luôn có mặt trong mâm cỗ đãi khách khứa, nhất là vào ngày Tết. Chả giò giòn rụm, vị tôm ngọt quyện với thịt đậm đà khiến món ăn thêm thú vị.', N'tôm, thịt, trứng gà, cà rốt, nắm mèo,...', N'Nó bắt nguồn từ châu á và Chả giò tôm là món ăn quen thuộc luôn có mặt trong mâm cỗ đãi khách khứa, nhất là vào ngày Tết', N'nấu', N'https://cdn.tgdd.vn/Files/2020/01/16/1231776/cach-lam-cha-gio-tom-thit-thom-ngon-gion-lau-don-gian-tai-nha-202202241337289905.jpg', N'1', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'14', N'Gà luộc', N'Món Luộc', 200000.0000, N'Món gà luộc gắn liền với mọi người trong các bữa tiệc lớn', N'gà, muối, nước sôi,....', N'Đây là món ăn gắn liền với mọi ngườ', N'luộc gà', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/e1894cc842da12b03b2cdf223250799d_Thumb_-crop083_G%C3%A0_lu%E1%BB%99c_l%C3%A1_chanh_944_531.jpg?alt=media&token=b07661cd-3aad-4d24-bf7a-4c6da7c4aa06', N'2', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'2', N'Gỏi Ngó Sen', N'Món Gỏi', 45000.0000, N'Gỏi ngó sen tôm thịt là món gỏi phổ biến trong các bữa tiệc, được nhiều người yêu thích bởi hương vị thanh ngọt của tôm, thịt, giòn giòn chua chua của rau củ. Cùng vào bếp với Điện máy XANH học ngay cách làm món gỏi thơm ngon đơn giản tại nhà mà ai cũng thực hiện được nhé!', N'Tôm sú, Thịt Ba chỉ, ngó sen, cà rốt, hành tây, đậu phộng, rau răm, nước mắm, muối,....', N'Nó có nguồn gốc từ châu á. Đây là món ăn hấp dẫn và mang nhiều nét văn hóa của châu á', NULL, N'https://cdn.tgdd.vn/Files/2020/05/25/1258272/cach-lam-goi-ngo-sen-tom-thit-gion-ngon-don-gian-t.png', N'1', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'20', N'Gà luộc', N'Món Luộc', 200000.0000, N'Món gà luộc gắn liền với mọi người trong các bữa tiệc lớn', N'gà, muối, nước sôi,....', N'Đây là món ăn gắn liền với mọi ngườ', N'luộc gà', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/e1894cc842da12b03b2cdf223250799d_Thumb_-crop083_G%C3%A0_lu%E1%BB%99c_l%C3%A1_chanh_944_531.jpg?alt=media&token=b9dc657a-ac26-4b39-b4c1-2b460afe90e8', N'3', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'23', N'Súp Nghêu', N'Món Soup', 12344.0000, N'Trong các món ăn ngon, nổi tiếng ở Mỹ bạn không thể không nhắc tới món súp nghêu.  Món súp được chế biến một cách vô cùng đặc biệt và cẩn thận. Ở Mỹ có nhiều loại súp khác nhau. Nhưng đặc biệt nhất là loại súp có tên gọi Massachuset. Bạn có thể tự làm món ăn này với các nguyên liệu như thịt lợn muối, nghêu, khoai tây, hành tây, gia vị. Nhưng có một nguyên tắc bất thành văn là khi nấu món ngon này. Bạn nhất định không được cho cà chua vào nấu cùng nghêu.', N'Nghêu, thịt lợn muối, khoai tây, hành tây', N'nổi tiếng ở Mỹ bạn không thể không nhắc tới món súp nghêu', N'stringdsfdsd', N'https://vanhoagiaoduc.com.vn/wp-content/uploads/2021/04/am-thuc-noi-tieng-nhat-chau-my-ban-nen-thu-mot-lan-trong-doi-clam-chowder-00-1024x576-1.jpg', N'2', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'24', N'Coxinhas', N'Món Chiên', 100000.0000, N'Nhắc đến 59 món ngon châu Mỹ, không hề bỏ lỡ món Coxinhas – món ăn có hình giọt nước của Brazil. Với những nguyên vật liệu chính là thịt gà, hánh tây, trứng, cà rốt và gia vị. Bánh coxinhas có lớp vỏ giòn và nhân thơm, mềm ', N'thảo dược Guasa, thịt gà, khoai tây,kem chua,....', N' Món ăn có hình giọt nước của Brazil là một món ăn độc đáo và ngon', NULL, N'https://ximgo.com/upload/2020/06/24/118911_original.jpg', N'2', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'25', N'Caesar salad', N'Salad', 50000.0000, N'Nhắc tới món ăn châu âu thì không thể thiếu  không thể thiếu salad ', N'xà lách, phô mai, thịt xông khói', N'Món ăn này bắt nguồn từ châu âu', NULL, N'https://cdn.tgdd.vn/2021/06/content/a2-800x450-1.jpg', N'3', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'26', N'Bò Hầm Rau Củ', N'Món Hầm', 210000.0000, N'Mang hương vị của nhà hàng hạng sang về nhà bạn với món bò hầm rau củ kiểu Pháp độc đáo này thôi nào.', N'cà rốt, nấm, linh chi trắng, thịt bò, khoai tây', N'Điểm nhấn của món bò hầm rau củ này chính là phần nước sốt, vị ngọt của nước sốt chính là sự kết hợp hài hòa của vị ngọt từ thịt bò và ngọt thanh từ các loại rau củ như cà rốt, nấm linh chi trắng, khoai tây, hành tây,... nấu cùng.', NULL, N'https://cdn.tgdd.vn/2021/06/content/a6-800x450-1.jpg', N'3', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'27', N'Cá hồi sốt chanh dây', N'sốt', 260000.0000, N'Cá hồi sốt chanh dây là món ăn vừa thơm ngon, vừa đầy dinh dưỡng. Phần thịt cá hồi áp chảo vàng thơm, pha thêm chút màu xanh tươi của măng tây và bông cải, màu đỏ của cà chua, cà rốt, màu vàng của khoai tây.', N'mỳ, cà chua, thịt cá hồi', N'Cá hồi sốt chanh dây là món ăn vừa thơm ngon, vừa đầy dinh dưỡng. Phần thịt cá hồi áp chảo vàng thơm, pha thêm chút màu xanh tươi của măng tây và bông cải, màu đỏ của cà chua, cà rốt, màu vàng của khoai tây.', NULL, N'https://cdn.tgdd.vn/2021/06/content/a7-800x450-1.jpg', N'3', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'3', N'Gà luộc', N'Món Luộc', 200000.0000, N'Món gà luộc là món ăn quen thuộc của người dân châu á trong những bữa tiệc', N'gà, muối, nước sôi, củ hành,...', N'Nó là món ăn gắn liền với mọi người', NULL, N'https://www.google.com/imgres?imgurl=https%3A%2F%2Fdanviet.mediacdn.vn%2F296231569849192448%2F2022%2F1%2F5%2F2403934595972026447777088179741936280533947n-16413609296771577835143.jpg&imgrefurl=https%3A%2F%2Fdanviet.vn%2Fluoc-ga-da-vang-uom-hap-dan-chi-can-dung-thu-nuoc-nay-20220105124932906.htm&tbnid=NAPfGjMFNwLuHM&vet=12ahUKEwi3jJKk3Zn9AhXQL7cAHVs9BPoQMygGegUIARDRAQ..i&docid=i_VnqJ6tBU12vM&w=960&h=960&q=g%C3%A0%20lu%E1%BB%99c&ved=2ahUKEwi3jJKk3Zn9AhXQL7cAHVs9BPoQMygGegUIARDRAQ', N'1', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID180dd741-63f8-4599-a', N'Cá hồi sốt chanh dây 2', N'Món Luộc', -212.0000, N'dsadkadsnsd', N'dshdsajdai', N'shdsdhadi', N'niahdada', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/%E1%BA%A2nh%20ch%E1%BB%A5p%20m%C3%A0n%20h%C3%ACnh%202023-03-02%20212752.png?alt=media&token=b137fc3c-562f-495a-b77d-077fdb0192aa', N'2', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID20efd4dd-f56c-4ddf-8', N'string', N'string', 0.0000, N'string', N'string', N'string', N'string', N'string', N'FTIdd02f8f3b-4b82-4013-', 0)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID26166947-0b58-4b66-b', N'string', N'string', 0.0000, N'string', N'string', N'string', N'string', N'string', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID26909d03-3cc8-4072-b', N'Nước Yến', N'Nước giải khát', 1000.0000, N'Nước yến ngân nhĩ: có chứa thành phần dinh dưỡng cân bằng, được chế biến có chứa tổ yến thật kết hợp với đường phèn để tạo ra sản phẩm thơm ngon và có lợi cho sức khỏe.', N'string', N'string', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/yenjpeg.jpeg?alt=media&token=a63a2967-423b-4579-bf8b-0e7d0f39d964', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID3bfb8371-a649-4816-a', N'Bia Tiger', N'Thức uống có cồn', 18000.0000, N'Tiger Beer là thương hiệu bia của Singapore ra mắt lần đầu tiên vào năm 1932. Hiện được sản xuất bởi Heineken Châu Á Thái Bình Dương, tiền thân là Nhà máy bia Châu Á Thái Bình Dương. Công ty là liên doanh giữa Heineken N.V. và công ty thực phẩm và đồ uống đa quốc gia của Singapore Fraser and Neave', N'Nước, đại mạch, lúa mì (3,4 %), ngũ cốc, hoa bia, vỏ cam, hạt rau mùi, chất ổn định (Pectin táo), hương cam giống tự nhiên và men.', N'Singapo', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/tiger.jpeg?alt=media&token=b6b66d62-3f7e-4aa7-b99c-3b5d345f6ced', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID511f9e22-8772-43b0-8', N'7-up', N'Nước uống có gas', 13000.0000, N'7UP là một nhãn hiệu đồ uống nhẹ vị chanh xanh-chanh vàng không chứa caffein. Bản quyền nhãn hiệu thuộc về Dr Pepper Snapple Group của Mỹ và PepsiCo ở bên ngoài nước Mỹ. Logo 7Up bao gồm một chấm đỏ nằm giữa 7 và up', N'hương vị, tinh bột và phụ gia thực phẩm', N'Mỹ', N'hong có vì nhập hàng', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/7up.jpeg?alt=media&token=5a6b88e5-1ddd-483f-8498-0f6fa9ee2af4', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID65522717-5615-4051-9', N'Cá hồi sốt chanh dây', N'Món Luộc', 1111000.0000, N'abc', N'abc', N'abc', N'abc', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/%E1%BA%A2nh%20ch%E1%BB%A5p%20m%C3%A0n%20h%C3%ACnh%202023-03-02%20212752.png?alt=media&token=ea03ce2c-8ed3-479b-8219-6018b046057e', N'2', 0)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID8fe41ab1-a6be-4879-8', N'Rượu Trắng', N'Thức uống có cồn', 70000.0000, N'Vodka là một loại đồ uống có cồn được chưng cất có nguồn gốc từ Ba Lan và Nga, bao gồm chủ yếu là nước và ethanol nhưng đôi khi có dấu vết của tạp chất và hương liệu', N' khoai tây và ngũ cốc, lúa mạch, lúa mì, ngô có thành phần chủ yếu là nước + ethanol', N'Ba Lan và Nga', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/ruou.jpeg?alt=media&token=0af2b373-75c3-497b-beec-fa689579cc34', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FID964fbef6-5291-4775-a', N'Heineken', N'string', 23000.0000, N'Heineken Lager, hay đơn giản là Heineken, là loại bia nhẹ có nồng độ cồn 5% được sản xuất bởi công ty sản xuất bia Hà Lan Heineken N.V. Bia Heineken được bán trong chai màu xanh lá cây có ngôi sao màu đỏ.', N'string', N'Pháp', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/bia-heineken.jpg?alt=media&token=e4d50889-1475-4263-86bb-2207a2d56218', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FIDcd5d01a4-a962-43e4-9', N'abc', N'string', 1098.0000, N'stringdsad', N'string', N'string', N'string', N'string', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FIDd3f26629-4113-46c8-b', N'Bia Sài Gòn', N'Thức Uống Có Cồn', 18000.0000, N'Tổng Công ty Cổ phần Bia - Rượu - Nước giải khát Sài Gòn, tên giao dịch SABECO, là một doanh nghiệp cổ phần tại Việt Nam. Mặc dù là công ty cổ phần nhưng Nhà nước vẫn nắm gần 90% vốn điều lệ doanh nghiệp này và Bộ Công Thương đóng vai trò là người đại diện phần vốn Nhà nước tại Sabeco', N'Nước, malt đại mạch, ngũ cốc, hoa bia', N'Việt Nam', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/saigon.jpg?alt=media&token=30a31e19-027f-49b3-a5d2-42b62e087f81', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FIDd51db787-464d-48df-a', N'Pepsi', N'Nước Uống có Gas', 12000.0000, N'Pepsi một đồ uống giải khát có gas, lần đầu tiên được sản xuất bởi Caleb Bradham. Ban đầu, Ông pha chế ra một loại nước uống dễ hấp thụ làm từ nước cacbonat, đường, vani và một ít dầu ăn dưới tên Nước uống của Brad năm 1892', N' Nước bão hòa CO2, đường, chất tạo chua, axit citric, hương cola tổng hợp, chất tạo màu, caramen', N'Mỹ', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/peopsi.webp?alt=media&token=78de012c-d34d-4592-b300-77c56ea1ad9b', N'FTIdd02f8f3b-4b82-4013-', 1)
INSERT [dbo].[Food] ([FoodID], [FoodName], [Dish], [FoodPrice], [FoodDescription], [FoodIngredient], [FoodOrigin], [CookingRecipe], [FoodImage], [FoodTypeID], [Status]) VALUES (N'FIDefc75e3e-cb8d-4373-b', N'Cá hồi sốt chanh dây', N'string', 213210.0000, N'e3333', N'string', N'string', N'string', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/%E1%BA%A2nh%20ch%E1%BB%A5p%20m%C3%A0n%20h%C3%ACnh%202023-03-02%20212752.png?alt=media&token=79b78b4f-2551-40d8-a507-4529bc9ef066', N'FTIdd02f8f3b-4b82-4013-', 1)
GO
INSERT [dbo].[FoodType] ([FoodTypeID], [FoodTypeName], [FoodTypeDetail]) VALUES (N'1', N'Châu Á', N'các món ăn nổi tiếng được tuyển chọn từ thực đơn tại Châu Á')
INSERT [dbo].[FoodType] ([FoodTypeID], [FoodTypeName], [FoodTypeDetail]) VALUES (N'2', N'Châu Mỹ', N'Các món ăn ngon, nổi tiếng được tuyển chọn từ thực đơn tại Châu Mỹ.')
INSERT [dbo].[FoodType] ([FoodTypeID], [FoodTypeName], [FoodTypeDetail]) VALUES (N'3', N'Châu Âu', N'Món ngon, nổi tiếng được tuyển chọn từ thực đơn tại Châu Âu')
INSERT [dbo].[FoodType] ([FoodTypeID], [FoodTypeName], [FoodTypeDetail]) VALUES (N'4', N'Châu Phi', N'các món ăn đến từ châu phi đa phần là món khô và dễ ăn')
INSERT [dbo].[FoodType] ([FoodTypeID], [FoodTypeName], [FoodTypeDetail]) VALUES (N'FTIdd02f8f3b-4b82-4013-', N'nước uống', N'các loại đồ uống thơm ngon sẽ được phục vụ theo yêu cầu của quý khách')
GO
INSERT [dbo].[GameServices] ([GameID], [GameName], [GameServicePrice], [GameDetails], [GameRules], [GameReward], [Supplies], [GameImage], [Status]) VALUES (N'1', N'Oẵn Tù Tì', 0.0000, N'Trò chơi nhân gian', N'Người chơi ra kéo búa bao tùy ý trong 3 tiếng điếm', N'3 phần thưởng dành cho thứ tự nhất,nhì và ba', N'Nhà Hàng', N'https://st.gamevui.com/images/image/2020/11/23/oan-tu-ti-640.jpg', 1)
INSERT [dbo].[GameServices] ([GameID], [GameName], [GameServicePrice], [GameDetails], [GameRules], [GameReward], [Supplies], [GameImage], [Status]) VALUES (N'3', N'Đuổi hình bắt chữ', 0.0000, N'Trò chơi nhân gian', N'Người chơi nhìn hình ảnh đoán nội dung', N'3 phần thưởng dành cho thứ tự nhất,nhì và ba', N'Nhà Hàng', N'https://gpbanmethuot.net/uploads/news/2021_04/game-130421d.jpg', 1)
INSERT [dbo].[GameServices] ([GameID], [GameName], [GameServicePrice], [GameDetails], [GameRules], [GameReward], [Supplies], [GameImage], [Status]) VALUES (N'4', N'Qủa bóng ma thuật', 0.0000, N'Trò chơi nhân gian', N'thành viên BTC sẽ chuẩn bị các phần quà và đánh số tương ứng. Sau đó ghi các nhiệm vụ và số của các phần quà vào mảnh giấy nhỏ, bỏ ngẫu nhiên vào các quả bóng bay. Mỗi quả bóng sẽ chứa 1 thẻ nhiệm vụ cùng 1 phần quà.', N'Các phần quà tương ứng nhiệm vụ', N'Nhà Hàng', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/bong.jpeg?alt=media&token=09777417-d5b4-4136-9d3d-755c7caab4f7', 1)
INSERT [dbo].[GameServices] ([GameID], [GameName], [GameServicePrice], [GameDetails], [GameRules], [GameReward], [Supplies], [GameImage], [Status]) VALUES (N'6', N'Giọng Hát Vàng', 0.0000, N'Trò chơi random', N'chọn ngẫu nhiên 5 người chơi', N'1 phần quà giá trị', N'Nhà Hàng', N'data:image/png;base64,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', 1)
GO
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'1', N'Menu Thôi Nôi', 1, 12000000.0000, 9)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'2', N'Menu Sinh Nhật', 1, 16900000.0000, 8)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID0b4b2523-5884-4714', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID12e279b4-6d33-42b1', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID16b498ae-f75b-417e', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID1763fd50-3add-4027', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID29e545cd-3dcd-438d', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID2c79514e-ebd5-4f87', N'menuName', 1, 12000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID3095adb8-aaad-475b', N'menuName', 1, 12000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID34564722-dcb5-4237', N'menuName', 1, 12000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID4e0df99b-0417-4405', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID50db210d-4f67-4a10', N'menuName', 1, 12000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID5c3d72dc-8f56-4f1f', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID5c765fc2-d440-4af4', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID62c899b5-c606-4e4c', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID6380b42b-72ca-4fe1', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID65eb1f1e-9c09-45ca', N'menuName', 1, 191999.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID754011ca-4271-4ba2', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuID76bc17fb-14df-4e26', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDa1f45dec-42a1-4f5f', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDa44fb293-2259-4bbb', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDac527696-6e7c-4572', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDc3297aa2-b495-4589', N'menuName', 1, 12000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDc33a99f3-ea4a-4578', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDc35a6e7d-2660-4cb8', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDc42cb669-8132-4662', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDc51860b8-38fb-4bed', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDc6f1d40c-1f86-4467', N'menuName', 1, 18000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDce75eab8-5cab-4016', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDd37faea6-d99f-45eb', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDdbdf3397-d269-45ce', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDdfe427d0-9cb6-4f7b', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDe00ba339-9991-4111', N'menuName', 1, 191999.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDe6ed20fd-ce78-45c7', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDead08914-b254-46b2', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDf4123751-03f9-404f', N'menuName', 1, 0.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDf4d7dcb8-cbb4-475c', N'menuName', 1, 12000.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDf7c24970-d257-4cf4', N'menuName', 1, 191999.0000, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Status], [PriceTotal], [TableQuantity]) VALUES (N'MenuIDfa06178f-14e4-429b', N'menuName', 1, 0.0000, 0)
GO
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'1', N'1', 2, 1000000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'1', N'2', 2, 2000000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'1', N'3', 2, 3000000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'2', N'1', 3, 1000000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'2', N'14', 2, 2000000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'2', N'2', 3, 3000000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'2', N'3', 3, 300000.0000, 1)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID0b4b2523-5884-4714', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID12e279b4-6d33-42b1', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID12e279b4-6d33-42b1', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID16b498ae-f75b-417e', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID16b498ae-f75b-417e', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID1763fd50-3add-4027', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID29e545cd-3dcd-438d', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID29e545cd-3dcd-438d', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID2c79514e-ebd5-4f87', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID3095adb8-aaad-475b', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID34564722-dcb5-4237', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID4e0df99b-0417-4405', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID50db210d-4f67-4a10', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID5c3d72dc-8f56-4f1f', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID5c3d72dc-8f56-4f1f', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID5c765fc2-d440-4af4', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID5c765fc2-d440-4af4', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID62c899b5-c606-4e4c', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID62c899b5-c606-4e4c', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID6380b42b-72ca-4fe1', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID6380b42b-72ca-4fe1', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID65eb1f1e-9c09-45ca', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID65eb1f1e-9c09-45ca', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID754011ca-4271-4ba2', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID76bc17fb-14df-4e26', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuID76bc17fb-14df-4e26', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDa1f45dec-42a1-4f5f', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDa44fb293-2259-4bbb', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDa44fb293-2259-4bbb', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDac527696-6e7c-4572', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDac527696-6e7c-4572', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc3297aa2-b495-4589', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc33a99f3-ea4a-4578', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc33a99f3-ea4a-4578', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc35a6e7d-2660-4cb8', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc35a6e7d-2660-4cb8', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc51860b8-38fb-4bed', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc51860b8-38fb-4bed', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDc6f1d40c-1f86-4467', N'FIDd3f26629-4113-46c8-b', 1, 18000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDce75eab8-5cab-4016', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDd37faea6-d99f-45eb', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDd37faea6-d99f-45eb', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDdbdf3397-d269-45ce', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDdfe427d0-9cb6-4f7b', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDdfe427d0-9cb6-4f7b', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDe00ba339-9991-4111', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDe00ba339-9991-4111', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDe6ed20fd-ce78-45c7', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDead08914-b254-46b2', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDf4d7dcb8-cbb4-475c', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDf7c24970-d257-4cf4', N'1', 1, 179999.0000, 0)
INSERT [dbo].[MenuProduct] ([MenuID], [Product], [Quatity], [Price], [Type]) VALUES (N'MenuIDf7c24970-d257-4cf4', N'FID511f9e22-8772-43b0-8', 1, 12000.0000, 0)
GO
INSERT [dbo].[Payment] ([PaymentID], [EventID], [Amount], [PayContent], [Date], [Status]) VALUES (N'1', N'1', 27100000.0000, N'thanh toán sự kiện #1', CAST(N'2023-04-15T15:44:47.183' AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentID], [EventID], [Amount], [PayContent], [Date], [Status]) VALUES (N'2', N'2', 30000000.0000, N'thanh toán sự kiện #2', CAST(N'2023-04-15T15:10:19.940' AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentID], [EventID], [Amount], [PayContent], [Date], [Status]) VALUES (N'EVId22369e86-5223-4e39-', N'EVId22369e86-5223-4e39-', 12000.0000, N'thanh toán sự kiện #EVId22369e86-5223-4e39-', CAST(N'2023-04-15T07:59:15.773' AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentID], [EventID], [Amount], [PayContent], [Date], [Status]) VALUES (N'EVId74dfbe84-ad1b-4536-', N'EVId74dfbe84-ad1b-4536-', 583998.0000, N'thanh toán sự kiện #EVId74dfbe84-ad1b-4536-', CAST(N'2023-04-14T23:53:32.930' AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentID], [EventID], [Amount], [PayContent], [Date], [Status]) VALUES (N'EVIdd5094edc-9da0-4d6f-', N'EVIdd5094edc-9da0-4d6f-', 12000.0000, N'thanh toán sự kiện #EVIdd5094edc-9da0-4d6f-', CAST(N'2023-04-15T10:10:27.330' AS DateTime), 1)
INSERT [dbo].[Payment] ([PaymentID], [EventID], [Amount], [PayContent], [Date], [Status]) VALUES (N'EVIddb797278-b5e2-447a-', N'EVIddb797278-b5e2-447a-', 12000.0000, N'thanh toán sự kiện #EVIddb797278-b5e2-447a-', CAST(N'2023-04-15T09:28:26.790' AS DateTime), 1)
GO
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'1', N'Đèn', 0.0000, 50, N'Đèn Flash', N'https://www.google.com/url?sa=i&url=http%3A%2F%2Fphukienmayanhdslr.com%2Fden-flash-godox-ad100pro-godox-ad100-pro-100w&psig=AOvVaw35gvIGZXqHaqYzEp-C7KvG&ust=1676612499006000&source=images&cd=vfe&ved=2ahUKEwjyhdq0qpn9AhW9W2wGHdCsDNcQjRx6BAgAEAo', N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'12', N'Máy Lạnh', 0.0000, 40, N'Máy lạnh công suất lớn', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fmaylanhgiasi.net%2Fcong-suat%2F-4-ngua-4-hp-7.html&psig=AOvVaw1anFwPXbNG9Prve2hv5x75&ust=1676616925749000&source=images&cd=vfe&ved=2ahUKEwjT_cTzupn9AhXKErcAHc2CAy4QjRx6BAgAEAo', N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'13', N'Banner', 0.0000, 10, N'Banner giúp cho bữa tiệc thêm sinh động', NULL, N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'2', N'Micro', 0.0000, 10, N'Micro chuyên dụng', N'https://baochauelec.com/cdn1/images/202006/goods_img/micro-shure-sm58--lc-G1593-1591070245259.jpg', N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'3', N'Đạo Cụ Chuyên Dụng', 0.0000, 100, N'Các đồ vật chuyên dụng', NULL, N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'4', N'Hoa trang trí', 0.0000, 100, N'Hoa chuyên dụng thường trang trí cho các sự kiện thích hợp', N'https://handydecor.com.vn/wp-content/uploads/2020/05/trang-tri-sinh-nhat-cho-be-tong-xanh-4.jpg', N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'5', N'Ghế', 0.0000, 1500, N'Ghế Ngồi cho khách', N'https://hoaphatgiasi.vn/wp-content/uploads/2019/08/Gh%E1%BA%BF-b%C3%A0n-%C4%83n-ga720tn.jpg', N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'6', N'bàn', 0.0000, 1000, N'Bàn cho khách ngồi', N'https://kalina.com.vn/wp-content/uploads/2019/07/goi-y-cach-sap-xep-cho-ngoi-hop-ly-trong-dam-cuoi-1.jpg', N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'8', N'Quần,áo', 0.0000, 35, N'Lễ Phục phù hợp', NULL, N'Nhà Hàng', 1)
INSERT [dbo].[Product] ([ProductID], [DecorationProductName], [ProductPrice], [ProductQuantity], [ProductDetails], [ProductImage], [ProductSupplier], [Status]) VALUES (N'9', N'Gìay', 0.0000, 20, N'Giay đạo cụ', NULL, N'Nhà Hàng', 1)
GO
INSERT [dbo].[RoomLocation] ([RoomID], [RoomName], [Parking], [Capacity], [RoomImage], [RoomDescription], [Status]) VALUES (N'RId127f266c-3d97-4246-b', N'Phòng Hoa Hồng', N'500', 200, N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/PeonyRoom.jpg?alt=media&token=4eeded44-8717-4e8c-b34c-0eda03ad5175', N'Căn phòng này được lấy ý tưởng và thiết kế theo hình dáng hoa hồng. Nó thích hợp được sử dụng dành cho các sự kiện dành cho gia đình mới lập,.....', 1)
INSERT [dbo].[RoomLocation] ([RoomID], [RoomName], [Parking], [Capacity], [RoomImage], [RoomDescription], [Status]) VALUES (N'RId352508ae-20db-4cc5-b', N'111', N'111', 0, N'111', N'111', 1)
INSERT [dbo].[RoomLocation] ([RoomID], [RoomName], [Parking], [Capacity], [RoomImage], [RoomDescription], [Status]) VALUES (N'RId993031ba-1fc6-42c1-9000-420f372744ab', N'Phòng hoa Quỳnh', N'500', 600, N'string', N'string', 1)
INSERT [dbo].[RoomLocation] ([RoomID], [RoomName], [Parking], [Capacity], [RoomImage], [RoomDescription], [Status]) VALUES (N'RIdbd0d6df5-7a74-46b9-a', N'Phòng Hoa Hướng Dương', N'400', 300, N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/Ph%C3%B2ng%20Hoa%20H%C6%B0%E1%BB%9Bng%20D%C6%B0%C6%A1ng.jpg?alt=media&token=5e8a7bfd-46b9-41f1-bd47-2a7f7c00ab5d', N'Căn phòng này được lấy ý tưởng và thiết kế theo hình dáng hoa hướng dương. Nó thích hợp được sử dụng dành cho các sự kiện về thôi nôi, sinh nhật,.....', 1)
GO
INSERT [dbo].[Script] ([id], [ScriptName], [Status], [ScriptContent]) VALUES (N'1', N'strin', 1, N'string')
INSERT [dbo].[Script] ([id], [ScriptName], [Status], [ScriptContent]) VALUES (N'3', N'Tiệc Đại Thọ Cụ Ông Lê Ánh Dương ', 1, N'Đại gia đình và con cháu cùng tổ chức tiệc đại thọ cho cụ ông.')
INSERT [dbo].[Script] ([id], [ScriptName], [Status], [ScriptContent]) VALUES (N'4', N'Tiệc Thôi Nôi Bé Hải Tú ', 1, N'Tiệc Thôi nôi chúc mừng bé Hải Tú tròn 1 tuổi')
INSERT [dbo].[Script] ([id], [ScriptName], [Status], [ScriptContent]) VALUES (N'SId0c7d7b0a-f429-4578-8', N'Tiệc', 1, N'Đây là script tiệc')
GO
INSERT [dbo].[ShowService] ([ShowID], [ShowPrice], [ShowServiceName], [Light], [Sound], [Singer], [ShowDescription], [ShowImage], [Status]) VALUES (N'2', 500000.0000, N'string', N'6 đèn flash', N'6 đạo cụ ', N'Đan trường, Cẩm Ly, Thủy Tiên', N'', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fvideohive.net%2Fitem%2Fmusic-show%2F13932551&psig=AOvVaw3Q-2eq6w7VHaCxveiZ6XLt&ust=1676609016940000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCLi4lbmdmf0CFQAAAAAdAAAAABAZ', 1)
INSERT [dbo].[ShowService] ([ShowID], [ShowPrice], [ShowServiceName], [Light], [Sound], [Singer], [ShowDescription], [ShowImage], [Status]) VALUES (N'5', 650000.0000, N'Ca Nhạc, Diễn kịch', N'6 Đèn Flash', N'Đạo cụ chuyên dụng', N'Nhóm Nhạc Five six, Nhóm Kịch Funny Day', N'Có nhiều năm kinh nghiệm biễu diễn cũng như ca hát', N'https://firebasestorage.googleapis.com/v0/b/family-event.appspot.com/o/banNhac.jpg?alt=media&token=e317acb4-370d-4b2b-85d2-cbee5e421553', 1)
INSERT [dbo].[ShowService] ([ShowID], [ShowPrice], [ShowServiceName], [Light], [Sound], [Singer], [ShowDescription], [ShowImage], [Status]) VALUES (N'6', 550000.0000, N'MC, Ca Sỹ,', N'đèn flash, khói', N'', N'Đàm Vĩnh Hưng, Khắc Việt, Mỹ Tâm, Mc.Trấn Thành', N'Đây là những Ca Sỹ và Mc nổi tiếng thường được nhiều người hâm mộ yêu quý', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fphukiensankhau.com%2Fcach-thiet-ke-den-san-khau-sao-cho-hieu-qua&psig=AOvVaw3S53-q6TFKFBhJn8TDB-sf&ust=1676609743398000&source=images&cd=vfe&ved=2ahUKEwjZhN2SoJn9AhVeDLcAHcNfDXkQjRx6BAgAEAo', 1)
INSERT [dbo].[ShowService] ([ShowID], [ShowPrice], [ShowServiceName], [Light], [Sound], [Singer], [ShowDescription], [ShowImage], [Status]) VALUES (N'7', 450000.0000, N'MC,Ca sỹ', N'Đèn Flash', N'đàn ghi-ta', N'Ngô Kiến Huy', N'Tiệc mục hứa hẹn mang đến nhiều điều hấp dẫn', N'https://ely.com.vn/wp-content/uploads/2020/09/san-khau-cuoi-rooftop.jpg', 1)
GO
SET IDENTITY_INSERT [dbo].[Verify] ON 

INSERT [dbo].[Verify] ([VerifyID], [VerifyCode], [EventID]) VALUES (1, N'EVId64f0d70e-faee-4ae6-7', N'EVId64f0d70e-faee-4ae6-')
SET IDENTITY_INSERT [dbo].[Verify] OFF
GO
ALTER TABLE [dbo].[ChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatMessage_EventBooker] FOREIGN KEY([EventBookerID])
REFERENCES [dbo].[EventBooker] ([EventBookerID])
GO
ALTER TABLE [dbo].[ChatMessage] CHECK CONSTRAINT [FK_ChatMessage_EventBooker]
GO
ALTER TABLE [dbo].[DateTimeLocation]  WITH CHECK ADD  CONSTRAINT [FK_DateTimeLocation_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[DateTimeLocation] CHECK CONSTRAINT [FK_DateTimeLocation_Event]
GO
ALTER TABLE [dbo].[DateTimeLocation]  WITH CHECK ADD  CONSTRAINT [FK_DateTimeLocation_RoomLocation] FOREIGN KEY([RoomID])
REFERENCES [dbo].[RoomLocation] ([RoomID])
GO
ALTER TABLE [dbo].[DateTimeLocation] CHECK CONSTRAINT [FK_DateTimeLocation_RoomLocation]
GO
ALTER TABLE [dbo].[DecorationProduct]  WITH CHECK ADD  CONSTRAINT [FK_DecorationProduct_Decoration] FOREIGN KEY([DecorationID])
REFERENCES [dbo].[Decoration] ([DecorationID])
GO
ALTER TABLE [dbo].[DecorationProduct] CHECK CONSTRAINT [FK_DecorationProduct_Decoration]
GO
ALTER TABLE [dbo].[DecorationProduct]  WITH CHECK ADD  CONSTRAINT [FK_DecorationProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[DecorationProduct] CHECK CONSTRAINT [FK_DecorationProduct_Product]
GO
ALTER TABLE [dbo].[EntertainmentProduct]  WITH CHECK ADD  CONSTRAINT [FK_EntertainmentProduct_Entertainment] FOREIGN KEY([EntertainmentID])
REFERENCES [dbo].[Entertainment] ([EntertainmentID])
GO
ALTER TABLE [dbo].[EntertainmentProduct] CHECK CONSTRAINT [FK_EntertainmentProduct_Entertainment]
GO
ALTER TABLE [dbo].[EntertainmentProduct]  WITH CHECK ADD  CONSTRAINT [FK_EntertainmentProduct_Game] FOREIGN KEY([GameID])
REFERENCES [dbo].[GameServices] ([GameID])
GO
ALTER TABLE [dbo].[EntertainmentProduct] CHECK CONSTRAINT [FK_EntertainmentProduct_Game]
GO
ALTER TABLE [dbo].[EntertainmentProduct]  WITH CHECK ADD  CONSTRAINT [FK_EntertainmentShow_Show] FOREIGN KEY([ShowID])
REFERENCES [dbo].[ShowService] ([ShowID])
GO
ALTER TABLE [dbo].[EntertainmentProduct] CHECK CONSTRAINT [FK_EntertainmentShow_Show]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Decoration] FOREIGN KEY([DecorationID])
REFERENCES [dbo].[Decoration] ([DecorationID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Decoration]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Entertainment] FOREIGN KEY([EntertainmentID])
REFERENCES [dbo].[Entertainment] ([EntertainmentID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Entertainment]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventBooker] FOREIGN KEY([EventBookerID])
REFERENCES [dbo].[EventBooker] ([EventBookerID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventBooker]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventType] ([EventTypeID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Menu]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Script] FOREIGN KEY([ScriptID])
REFERENCES [dbo].[Script] ([id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Script]
GO
ALTER TABLE [dbo].[EventBooker]  WITH CHECK ADD  CONSTRAINT [FK_EventBooker_Account] FOREIGN KEY([EventBookerID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[EventBooker] CHECK CONSTRAINT [FK_EventBooker_Account]
GO
ALTER TABLE [dbo].[Family]  WITH CHECK ADD  CONSTRAINT [FK_Family_EventBooker] FOREIGN KEY([EventBookerID])
REFERENCES [dbo].[EventBooker] ([EventBookerID])
GO
ALTER TABLE [dbo].[Family] CHECK CONSTRAINT [FK_Family_EventBooker]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Event]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_EventBooker] FOREIGN KEY([EventBookerID])
REFERENCES [dbo].[EventBooker] ([EventBookerID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_EventBooker]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_FoodType] FOREIGN KEY([FoodTypeID])
REFERENCES [dbo].[FoodType] ([FoodTypeID])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_FoodType]
GO
ALTER TABLE [dbo].[MenuProduct]  WITH CHECK ADD  CONSTRAINT [FK_MenuFood_Food] FOREIGN KEY([Product])
REFERENCES [dbo].[Food] ([FoodID])
GO
ALTER TABLE [dbo].[MenuProduct] CHECK CONSTRAINT [FK_MenuFood_Food]
GO
ALTER TABLE [dbo].[MenuProduct]  WITH CHECK ADD  CONSTRAINT [FK_MenuProduct_Menu1] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[MenuProduct] CHECK CONSTRAINT [FK_MenuProduct_Menu1]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Event]
GO
ALTER TABLE [dbo].[Participant]  WITH CHECK ADD  CONSTRAINT [FK_Participant_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[Participant] CHECK CONSTRAINT [FK_Participant_Event]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Event]
GO
ALTER TABLE [dbo].[Verify]  WITH CHECK ADD  CONSTRAINT [FK_Verify_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[Verify] CHECK CONSTRAINT [FK_Verify_Event]
GO
ALTER TABLE [dbo].[Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Voucher_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[Voucher] CHECK CONSTRAINT [FK_Voucher_Event]
GO
