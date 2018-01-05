USE [MessagingSystem]
GO
/****** Object:  StoredProcedure [dbo].[Check_Login]    Script Date: 01/05/2018 18:50:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Check_Login]

@Login varchar(max),
@Password varchar(max)	

AS
BEGIN

	select IdUser
		from Users u
	where u.Login = @Login and u.Password = @Password
END
