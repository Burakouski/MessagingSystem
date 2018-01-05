USE [MessagingSystem]
GO
/****** Object:  StoredProcedure [dbo].[ReadMessage]    Script Date: 01/05/2018 18:49:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ReadMessage]

@IdMessage int

AS
/*
	список всех пользователей

	[dbo].[ReadMessage] 2
	
*/
BEGIN

select IdMessage,
		IdUserSender,
		IdUserRecipient,
		'Text' = Message,
		DateSend
		
from dbo.MessagesV
	where IdMessage = @IdMessage

END
