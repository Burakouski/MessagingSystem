USE [MessagingSystem]
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 01/05/2018 18:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[Registration]

@NameF varchar(100),
@NameI varchar(100),
@NameO varchar(100),
@Login varchar(max),
@Password varchar(max),
@Phone varchar(50),
@Birthday date,
@DateRegistration date

AS
/*
	Регистрация

	dbo.Registration 'Иванов', 'Иван', 'Иванович', 'dfs', '123', '93759', '19930204', '20180101'
	
*/
BEGIN


INSERT dbo.Users(NameF, NameI, NameO, Password, Login,
								Phone, Birthday, DateRegistration, DateLastOnline)

		Values(@NameF, @NameI, @NameO, @Password, @Login,
								@Phone, @Birthday, @DateRegistration, GETDATE())
		

END
