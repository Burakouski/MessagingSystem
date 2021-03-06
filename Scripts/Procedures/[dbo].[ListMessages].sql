USE [MessagingSystem]
GO
/****** Object:  StoredProcedure [dbo].[ListMessages]    Script Date: 01/05/2018 18:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[ListMessages]

@IdUserSender int,
@IdUserRecipient int,
@NumberMessages int

AS
/*
	список всех пользователей

exec	[dbo].[ListMessages] 1, 2, 50
exec	[dbo].[ListMessages] 2, 1, 50
	
*/
BEGIN

Select 
	m.IdMessage,
	IdUserSender,
	IdUserRecipient,
	'Text' = m.Message,
	'TypeMessage' = case 
						when IdUserSender = @IdUserRecipient
							then convert(bit, 0) -- received
						else convert(bit, 1)	-- sent				
					end,
	DateSend	--'DateSend' = CONVERT(varchar(100), DateSend, 104) + ' в' + CONVERT(varchar(100), DateSend, 108) 
	
	from dbo.MessagesV m
		join (select
				 'Position' = ROW_NUMBER() OVER(ORDER BY DateSend),
				 IdMessage	
				 from MessagesV m2
				 where m2.IdUserSender in (@IdUserSender, @IdUserRecipient)
				 and m2.IdUserRecipient in (@IdUserSender, @IdUserRecipient)
				) he
		on m.IdMessage = he.IdMessage
			
		where he.Position <= @NumberMessages
	order by m.DateSend desc		
END
