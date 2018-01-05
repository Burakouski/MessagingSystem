USE [MessagingSystem]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 01/05/2018 18:52:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[NameF] [varchar](100) NOT NULL,
	[NameI] [varchar](100) NOT NULL,
	[NameO] [varchar](100) NULL,
	[Birthday] [date] NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[DateRegistration] [date] NOT NULL,
	[Login] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Photo] [image] NULL,
	[DateLastOnline] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


