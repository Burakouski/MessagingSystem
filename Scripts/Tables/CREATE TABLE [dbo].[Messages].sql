USE [MessagingSystem]
GO

/****** Object:  Table [dbo].[Messages]    Script Date: 01/05/2018 18:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Messages](
	[IdMessage] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[DateSend] [datetime2](7) NULL,
	[IdUserSender] [int] NOT NULL,
	[IdUserRecipient] [int] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[IdMessage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_DateSend]  DEFAULT (getdate()) FOR [DateSend]
GO


