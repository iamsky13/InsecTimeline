create database insectimeline

USE [InsecTimeline]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 5/9/2018 9:57:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date_Eng] [datetime] NULL,
	[Date_Nep] [nvarchar](255) NULL,
 CONSTRAINT [PK__Events__3214EC27FDA7C6E4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timeline]    Script Date: 5/9/2018 9:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timeline](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventLink] [varchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageLink] [varchar](255) NULL,
	[title] [nvarchar](max) NULL,
	[EventRef_Id] [int] NULL,
 CONSTRAINT [PK__Timeline__3214EC0710A9B1F1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
