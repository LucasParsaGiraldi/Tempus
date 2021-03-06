USE [Tempus]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/08/2021 11:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cliente_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[CPF] [varchar](max) NOT NULL,
	[Data_Nascimento] [date] NULL,
	[Data_Cadastro] [date] NULL,
	[Renda_Familiar] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Cliente_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Cliente_ID], [Nome], [CPF], [Data_Nascimento], [Data_Cadastro], [Renda_Familiar]) VALUES (1, N'Lucas Henrique Giraldi', N'781.665.980-60', CAST(N'2002-03-15' AS Date), CAST(N'2021-08-24' AS Date), CAST(200 AS Decimal(18, 0)))
INSERT [dbo].[Cliente] ([Cliente_ID], [Nome], [CPF], [Data_Nascimento], [Data_Cadastro], [Renda_Familiar]) VALUES (3, N'Cliente 2', N'622.768.040-09', CAST(N'2021-08-24' AS Date), CAST(N'2021-08-24' AS Date), CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[Cliente] ([Cliente_ID], [Nome], [CPF], [Data_Nascimento], [Data_Cadastro], [Renda_Familiar]) VALUES (4, N'Cliente 3', N'120.025.021-1', CAST(N'2002-08-25' AS Date), CAST(N'2021-08-24' AS Date), CAST(3700 AS Decimal(18, 0)))
INSERT [dbo].[Cliente] ([Cliente_ID], [Nome], [CPF], [Data_Nascimento], [Data_Cadastro], [Renda_Familiar]) VALUES (5, N'Cliente 4', N'120.022.033-21', CAST(N'2002-03-12' AS Date), CAST(N'2021-07-19' AS Date), CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[Cliente] ([Cliente_ID], [Nome], [CPF], [Data_Nascimento], [Data_Cadastro], [Renda_Familiar]) VALUES (6, N'cliente 5', N'358.921.430-90', CAST(N'1993-01-25' AS Date), CAST(N'2021-08-25' AS Date), CAST(10000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
