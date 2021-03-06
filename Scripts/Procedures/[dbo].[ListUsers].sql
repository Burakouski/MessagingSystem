USE [MessagingSystem]
GO
/****** Object:  StoredProcedure [dbo].[ListUsers]    Script Date: 01/05/2018 18:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[ListUsers]
@IdCurrentUser int,
@SearchStr varchar(max)

AS
/*
	список всех пользователей

	dbo.ListUsers 1, null
	
*/
BEGIN

Select 
		u.IdUser,
		u.NameF,
		u.NameI,
		u.NameO,
		u.Birthday,
		u.DateRegistration,
		u.Photo,
		u.Phone,
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
		

	From dbo.Users u
where (NameF + ' ' + NameI + ' ' + NameO like '%' + @SearchStr + '%' or @SearchStr is null)
	and u.IdUser != @IdCurrentUser

END
