USE [AvansDatabase]
GO
/****** Object:  Table [dbo].[Advance]    Script Date: 19.12.2023 17:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdvanceAmount] [money] NULL,
	[AdvanceDescription] [nvarchar](max) NULL,
	[ProjectID] [int] NULL,
	[DesiredDate] [datetime] NULL,
	[StatusID] [int] NULL,
	[RequestDate] [datetime] NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_Advance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceHistory]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusID] [int] NULL,
	[AdvanceID] [int] NULL,
	[TransactorID] [int] NULL,
	[ApprovedAmount] [money] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_AdvanceHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[AuthorizationID] [int] IDENTITY(1,1) NOT NULL,
	[AuthroizationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[AuthorizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessUnit]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessUnitName] [nvarchar](50) NULL,
	[BusinessUnitDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[BusinessUnitID] [int] NULL,
	[TitleID] [int] NULL,
	[UpperEmployeeID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeProject]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProject](
	[EmployeeID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Page]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [nvarchar](50) NULL,
	[Path] [nvarchar](50) NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeterminedPaymentDate] [datetime] NULL,
	[FinanceManagerID] [int] NULL,
	[AdvanceID] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[ProjectDescription] [nvarchar](max) NULL,
	[EndDate] [datetime] NULL,
	[StartingDate] [datetime] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptNo] [nvarchar](50) NULL,
	[isRefundReceipt] [bit] NULL,
	[AdvanceID] [int] NULL,
	[Date] [datetime] NULL,
	[AccountantID] [int] NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rule]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaxAmount] [money] NULL,
	[MinAmount] [money] NULL,
	[Date] [datetime] NULL,
	[TitleID] [int] NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
	[TitleId] [int] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Title]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Title](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TitleName] [nvarchar](50) NULL,
	[TitleDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Title] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TitleAuthorization]    Script Date: 19.12.2023 17:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TitleAuthorization](
	[TitleID] [int] NOT NULL,
	[AuthorizationID] [int] NOT NULL,
	[PageID] [int] NOT NULL,
 CONSTRAINT [PK_TitleAuthorization] PRIMARY KEY CLUSTERED 
(
	[TitleID] ASC,
	[AuthorizationID] ASC,
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Advance] ON 

INSERT [dbo].[Advance] ([ID], [AdvanceAmount], [AdvanceDescription], [ProjectID], [DesiredDate], [StatusID], [RequestDate], [EmployeeID]) VALUES (9, 15000.0000, N'Proje', 4, CAST(N'2023-12-25T00:00:00.000' AS DateTime), 201, CAST(N'2023-12-16T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Advance] ([ID], [AdvanceAmount], [AdvanceDescription], [ProjectID], [DesiredDate], [StatusID], [RequestDate], [EmployeeID]) VALUES (10, 9000.0000, N'Proje öncelikli avansı', 3, CAST(N'2023-12-30T00:00:00.000' AS DateTime), 201, CAST(N'2023-12-17T00:00:00.000' AS DateTime), 30)
SET IDENTITY_INSERT [dbo].[Advance] OFF
SET IDENTITY_INSERT [dbo].[AdvanceHistory] ON 

INSERT [dbo].[AdvanceHistory] ([ID], [StatusID], [AdvanceID], [TransactorID], [ApprovedAmount], [Date]) VALUES (33, 201, 9, 22, 0.0000, CAST(N'2023-12-19T00:00:00.000' AS DateTime))
INSERT [dbo].[AdvanceHistory] ([ID], [StatusID], [AdvanceID], [TransactorID], [ApprovedAmount], [Date]) VALUES (34, 201, 10, 30, 0.0000, CAST(N'2023-12-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[AdvanceHistory] OFF
SET IDENTITY_INSERT [dbo].[Authorization] ON 

INSERT [dbo].[Authorization] ([AuthorizationID], [AuthroizationName]) VALUES (1, N'Create')
INSERT [dbo].[Authorization] ([AuthorizationID], [AuthroizationName]) VALUES (2, N'Select')
INSERT [dbo].[Authorization] ([AuthorizationID], [AuthroizationName]) VALUES (3, N'Update')
INSERT [dbo].[Authorization] ([AuthorizationID], [AuthroizationName]) VALUES (4, N'Delete')
SET IDENTITY_INSERT [dbo].[Authorization] OFF
SET IDENTITY_INSERT [dbo].[BusinessUnit] ON 

INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (4, N'Yazılım', N'Tech ekibi')
INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (5, N'Muhasebe', N'Finansal işlemler')
INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (6, N'İnsan Kaynakları', N'Çalışan memnuniyeti')
INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (7, N'Teknik Destek', N'Yardım')
INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (8, N'İdari İşler', N'İdari')
INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (9, N'Danışma', N'Yardım')
INSERT [dbo].[BusinessUnit] ([ID], [BusinessUnitName], [BusinessUnitDescription]) VALUES (10, N'Analiz', N'Analistler')
SET IDENTITY_INSERT [dbo].[BusinessUnit] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (22, N'Serdar', N'Aziz', N'5546', N'serdar@mail.com', 0x90D2E9135A25E2E75EFBDAFE679799FBA74B1D52B659A8B33488D94C04B94F9D962178C3863770B71DC217B5D0CD658E80249F5BB4075C628F2701C8C2F98839, 0x407D06F02AC30791D0C2F3DFC3717D56A566DC0887C16065584CD1913177451ED73F51F93C246A5D40167AF5F60D55D93D0E50094452FA1BAC102FF19D1D957AA67925612601F3BFAA346915E2DC9850FD17C7DC705E655697F8956C59E785E50B9921499B0C88B00F8760D690214CBA11376EBFF61A10E5D527084E662C8977, 6, 1, 27)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (24, N'Bilge', N'Kağan', N'555', N'bilge@mail.com', 0x09D5A9671D9950C7F22E54B6BA44B81007FAE911E3FDFE079099B8BF6BA48C27E29A658D6CE5D81F6173F8F3A3427AC0EF221CA03348F5FD9D752E0200756E5C, 0x80945BA5C8A66BE792350AA3A2583A8A3423DC42114A310A46E88667DB765BBA3226CCDD763F78CF13E502C98B115F61004DEB539AAD3EBB21C07643182DACB8C1CE295D47800432BAC3A1FA4BE52C29CD5E77565F28A2D2E46710D61BED957051BE5240DE6CC8ACC375FA9C3B117B9060F76C6AB6026492969B7B031D467F9E, 6, 5, 0)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (25, N'Furkan', N'Gökırmak', N'2542', N'furkan@mail.com', 0xAE58B63AA0AFBD6CD30FE98ADDD972F1669A0CCE298D06D63E02B950C3C74A51CF423D4A1176745B3BECC869A0C5ADAFA281214E5BA2F08B0C61849D1F2C3E86, 0x2CAAB72C655718FF1ABF35D9D7D49609B91A9004FB1BD0DD43638D1CB0093FAEDD6622BBFAE0642D2B14442DDFB610869F67BA90ABEFF405DCF0648021AF07E85AB028CC1C808BA3C9680FADD3672028D459A30DF0666079707C19D55D1C6E1A30C86DEF9546AC476C28DAA68A7071010A4F37318DA798AFCD2FC7DACB0842EC, 6, 4, 24)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (26, N'Fatih', N'Çatal', N'2154', N'fatih@mail.com', 0xD0024B5845C269A0B1DFC07C8A00AE32F3A644F86D60DF4296D722B85BA63A3EC02C1F4702EC701DC508AA6DE59D0B7D04BAEECCD0450E42C4AA494E3A0B51AF, 0x587E53567CD7C6B75A0521D4C47E5F3C87827798CF1817B927AFFC4A091C07D1485C8B72B2DA957FDBFC059DBA9B26F2D503552864BD4CCEAADCEDD443920BCA063A8F35EDE34FA379BFB17F5B14C8DC874FB0D3F609D4FF30B33A230FC093164EF293561AAF07CAC8092D14A2A682E2223490AB47637459A7B3C477779CCA7F, 6, 3, 25)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (27, N'Turan', N'Kaya', N'521', N'turan@mail.com', 0x2B640E9A02C4947CE52355877CB829408DEC79BFB8884AD748C698D7F971B681E1FBF23E7C4200C2290064C5260A5CC67F1552A675825DC5C91A62500F3D67A8, 0x765F7A6145CA151DD1AEE7AD4E9C31357FF2E73B328D8D15F4CA780CEA9D0505E7B2379CB7F0301865F01EB161344E4ABC06253FCA0C042728152966534A27BF0388FA15A927B6E4997DFDDEADD28F160F07F80FD98944BB37E22E84D814BB619A3D9F938525553B1476EC6DB3EA54A0AAB3890DC74B1AC2FC07E7A9787A3331, 6, 2, 26)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (28, N'İhsan', N'Kuzu', N'212', N'ihsan@mail.com', 0x0E047197A5731649FE6B7005BE20464C8FDFA99DF63F252E20841EE109F8767023AA293B5617911FE6FBC7DFD68DFAC48217C5A28329FC18BE086BAEF9E34C9D, 0x90E4D944B8BAB87B78217B91F773801BDE5F0180E14221C042D97A7DECAFD524C12B6EE1F05112E5EE39D629CC3B5C2461A3B9ADB37DDFA5FF60750DF8561CE53AC1AE73DD8928A3E8ACF14BF70E46BC1C1ADABFD0EC356AF75367ECC8D0FF366924F4246564EB847C9141F27BFDA0881F06CF9C2FC4E43E145C2E832127660A, 6, 6, 24)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (29, N'Deniz', N'Aslan', N'123', N'deniz@mail.com', 0x51C114DDBAFF086A1A85B53407E8B2B9AF8E7BEAB8D018EF100694781C54BB222D869F6A5D7D10BE48BF261EFFF60443D547BF9F3FD13BABF99277A9C2D086BE, 0xC09B5A0DE0F8934573603416B7BF11060BCC36675AF38B5CF3BCBAFCB348D57530927535EC13C6C4C48D42FBDEE83D37CE2020DB28FB3E756004168EF1C8D6A22B0EF320B1FDDE8F911246D2EF465A0E56962D41C2BAA3C9122D1C4D6D15C21E1028A7EB957F0D155AB925ECD6ABC097BF4230213A1051D07E4A39F016C412D2, 6, 7, 28)
INSERT [dbo].[Employee] ([ID], [Name], [Surname], [PhoneNumber], [Email], [PasswordHash], [PasswordSalt], [BusinessUnitID], [TitleID], [UpperEmployeeID]) VALUES (30, N'Hakan', N'Peker', N'123', N'hakan@mail.com', 0x6318083F835FBDC7405C09BE1713267406E0375452BF0E8A4B4929CE65D06A453D7B6B92BA0ACD27D75C99660F1ACC455A3BC0DA29471943662D8E860598B8D8, 0xEC20BD574A3BB9DE888C6299C0C99842CE5D549185F320152BE48F9B35AB577AF83ADCF3B8AF7284DDA25F7B2DBE76BC5EFC1064BBB133DF3E6ED55AC16DEA609A68B19861616BC3866CA25C11196CE509CA1A694F6AC8FCFD95DE6215FCA7E991DEB05F6055698BF4B62ECCB3B04A0F92EF2C40364880C917DA511D92D572E9, 6, 1, 27)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Page] ON 

INSERT [dbo].[Page] ([PageID], [PageName], [Path]) VALUES (2, N'Avans Talep Sayfası', N'/avanstalep')
INSERT [dbo].[Page] ([PageID], [PageName], [Path]) VALUES (3, N'Avans Onay', N'/avansonay')
INSERT [dbo].[Page] ([PageID], [PageName], [Path]) VALUES (4, N'Avans Geri ödeme', N'/avansgeriodeme')
INSERT [dbo].[Page] ([PageID], [PageName], [Path]) VALUES (5, N'Avans Makbuz', N'/avansmakbuz')
INSERT [dbo].[Page] ([PageID], [PageName], [Path]) VALUES (6, N'Avans Finans Müdürü Ekranı', N'/avansfinansmudur')
SET IDENTITY_INSERT [dbo].[Page] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ID], [ProjectName], [ProjectDescription], [EndDate], [StartingDate]) VALUES (3, N'Turkcell Varlık Zimmet Projesi', N'Bu projede varlıkların zimmete atanma durumları kontrol edilir.', CAST(N'2023-12-12T00:00:00.000' AS DateTime), CAST(N'2022-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ID], [ProjectName], [ProjectDescription], [EndDate], [StartingDate]) VALUES (4, N'Avans Projesi', N'Proje avans yönetimi gerçekleştirir', CAST(N'2022-11-24T00:00:00.000' AS DateTime), CAST(N'2019-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ID], [ProjectName], [ProjectDescription], [EndDate], [StartingDate]) VALUES (5, N'Fineksus FM projesi', N'FM Tech', CAST(N'2022-05-20T00:00:00.000' AS DateTime), CAST(N'2020-05-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ID], [ProjectName], [ProjectDescription], [EndDate], [StartingDate]) VALUES (6, N'Bilge Adam .NET Dönüşümü', N'Enes yapacak dönüşümü 2 tane log kullansın', CAST(N'2019-10-12T00:00:00.000' AS DateTime), CAST(N'2017-10-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Rule] ON 

INSERT [dbo].[Rule] ([ID], [MaxAmount], [MinAmount], [Date], [TitleID]) VALUES (1, 1000.0000, 0.0000, CAST(N'2023-12-11T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Rule] ([ID], [MaxAmount], [MinAmount], [Date], [TitleID]) VALUES (2, 5000.0000, 1001.0000, CAST(N'2023-12-11T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Rule] ([ID], [MaxAmount], [MinAmount], [Date], [TitleID]) VALUES (3, 10000.0000, 5001.0000, CAST(N'2023-12-11T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Rule] ([ID], [MaxAmount], [MinAmount], [Date], [TitleID]) VALUES (4, 10000000.0000, 10001.0000, CAST(N'2023-12-11T00:00:00.000' AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[Rule] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (101, N'Bekliyor', NULL)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (102, N'Onaylandı', NULL)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (103, N'Reddedildi', NULL)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (201, N'TalepOluşturuldu', 1)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (202, N'BM Onayladı', 2)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (203, N'DirektörOnayladı', 3)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (204, N'GMYOnaylandı', 4)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (205, N'GMOnayladı', 5)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (206, N'FM Tarih Belirledi', 6)
INSERT [dbo].[Status] ([ID], [StatusName], [TitleId]) VALUES (207, N'Muhasebeci Avansı Ödedi', 7)
SET IDENTITY_INSERT [dbo].[Status] OFF
SET IDENTITY_INSERT [dbo].[Title] ON 

INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (1, N'İşçi', N'İşci')
INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (2, N'Birim Müdürü ', N'BM')
INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (3, N'Direktör', N'DİREKTÖR')
INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (4, N'Genel Müdür Yardımcısı', N'GMY')
INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (5, N'Genel Müdür', N'GM')
INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (6, N'Finans Müdürü ', N'FM')
INSERT [dbo].[Title] ([ID], [TitleName], [TitleDescription]) VALUES (7, N'Muhasebeci', N'Muhasebe')
SET IDENTITY_INSERT [dbo].[Title] OFF
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 1, 2)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 1, 3)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 2, 2)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 2, 3)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 3, 2)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 3, 3)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 4, 2)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (1, 4, 3)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (2, 1, 4)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (2, 2, 4)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (2, 3, 4)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (2, 4, 4)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (3, 1, 5)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (3, 2, 5)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (3, 3, 5)
INSERT [dbo].[TitleAuthorization] ([TitleID], [AuthorizationID], [PageID]) VALUES (3, 4, 5)
ALTER TABLE [dbo].[Advance]  WITH CHECK ADD  CONSTRAINT [FK_Advance_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Advance] CHECK CONSTRAINT [FK_Advance_Employee]
GO
ALTER TABLE [dbo].[Advance]  WITH CHECK ADD  CONSTRAINT [FK_Advance_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ID])
GO
ALTER TABLE [dbo].[Advance] CHECK CONSTRAINT [FK_Advance_Project]
GO
ALTER TABLE [dbo].[Advance]  WITH CHECK ADD  CONSTRAINT [FK_Advance_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Advance] CHECK CONSTRAINT [FK_Advance_Status]
GO
ALTER TABLE [dbo].[AdvanceHistory]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceHistory_Advance] FOREIGN KEY([AdvanceID])
REFERENCES [dbo].[Advance] ([ID])
GO
ALTER TABLE [dbo].[AdvanceHistory] CHECK CONSTRAINT [FK_AdvanceHistory_Advance]
GO
ALTER TABLE [dbo].[AdvanceHistory]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceHistory_Employee] FOREIGN KEY([TransactorID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[AdvanceHistory] CHECK CONSTRAINT [FK_AdvanceHistory_Employee]
GO
ALTER TABLE [dbo].[AdvanceHistory]  WITH CHECK ADD  CONSTRAINT [FK_AdvanceHistory_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[AdvanceHistory] CHECK CONSTRAINT [FK_AdvanceHistory_Status]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_BusinessUnit] FOREIGN KEY([BusinessUnitID])
REFERENCES [dbo].[BusinessUnit] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_BusinessUnit]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Title]
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Employee]
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ID])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Project]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Advance] FOREIGN KEY([AdvanceID])
REFERENCES [dbo].[Advance] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Advance]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Employee] FOREIGN KEY([FinanceManagerID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Employee]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Advance] FOREIGN KEY([AdvanceID])
REFERENCES [dbo].[Advance] ([ID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Advance]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Employee] FOREIGN KEY([AccountantID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Employee]
GO
ALTER TABLE [dbo].[Rule]  WITH CHECK ADD  CONSTRAINT [FK_Rule_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[Rule] CHECK CONSTRAINT [FK_Rule_Title]
GO
ALTER TABLE [dbo].[Status]  WITH CHECK ADD  CONSTRAINT [FK_Status_Title] FOREIGN KEY([TitleId])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[Status] CHECK CONSTRAINT [FK_Status_Title]
GO
ALTER TABLE [dbo].[TitleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_TitleAuthorization_Authorization] FOREIGN KEY([AuthorizationID])
REFERENCES [dbo].[Authorization] ([AuthorizationID])
GO
ALTER TABLE [dbo].[TitleAuthorization] CHECK CONSTRAINT [FK_TitleAuthorization_Authorization]
GO
ALTER TABLE [dbo].[TitleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_TitleAuthorization_Page] FOREIGN KEY([PageID])
REFERENCES [dbo].[Page] ([PageID])
GO
ALTER TABLE [dbo].[TitleAuthorization] CHECK CONSTRAINT [FK_TitleAuthorization_Page]
GO
ALTER TABLE [dbo].[TitleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_TitleAuthorization_Title] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Title] ([ID])
GO
ALTER TABLE [dbo].[TitleAuthorization] CHECK CONSTRAINT [FK_TitleAuthorization_Title]
GO
