USE [MessagingSystem]
GO
/****** Object:  StoredProcedure [dbo].[UserRead]    Script Date: 01/05/2018 18:38:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UserRead]

@IdUser int

AS
/*
	Регистрация
	dbo.Registration 'Иванов', 'Иван', 'Иванович', '123', '93759', '19930204', getdate()
*/
BEGIN
	select 
		u.IdUser,
		u.NameF,
		u.NameI,
		u.NameO,
		u.Password,
		u.Phone,
		u.Birthday,
		u.DateRegistration,
		'Online' = case
				when (DATEADD(minute, 1, u.DateLastOnline) > GETDATE())
					then 'Online'
				else 'Был в сети ' + CONVERT(varchar(100), u.DateLastOnline, 104) + ' в ' + CONVERT(varchar(100), u.DateLastOnline, 108)  
			end,
		'Online2' = case
						when (DATEADD(minute, 1, u.DateLastOnline) > GETDATE())
							then 'Online'
						else 'OffLine'
					end
		
	from dbo.Users u
		where IdUser = @IdUser
		

END
