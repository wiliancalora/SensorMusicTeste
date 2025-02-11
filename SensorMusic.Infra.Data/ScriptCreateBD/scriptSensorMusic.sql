USE [master]
GO
/****** Object:  Database [SensorMusic]    Script Date: 05/07/2020 11:32:20 ******/
CREATE DATABASE [SensorMusic]

USE [SensorMusic]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[IdProfile] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUser] [bigint] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[HomeTown] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[IdProfile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNote]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNote](
	[IdUser] [bigint] NOT NULL,
	[Note] [nvarchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPasswordRecovery]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswordRecovery](
	[Email] [nvarchar](150) NOT NULL,
	[Hash] [nvarchar](255) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserNote]  WITH CHECK ADD  CONSTRAINT [FK_UserNote_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[UserNote] CHECK CONSTRAINT [FK_UserNote_User]
GO
/****** Object:  StoredProcedure [dbo].[AddProfile]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddProfile]
	@idUser BIGINT = NULL,
	@name NVARCHAR(150) = NULL,
	@homeTown NVARCHAR(150) = NULL
AS
BEGIN
	INSERT INTO Profile (IdUser, Name, HomeTown)
		OUTPUT INSERTED.*
	VALUES (@idUser, @name, @homeTown)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@email NVARCHAR(150) = NULL,
	@password NVARCHAR(50) = NULL,
	@createDate DATETIME = NULL
AS
BEGIN
	INSERT INTO [User] (Email, [Password], CreateDate)
		OUTPUT INSERTED.*
	VALUES (@email, @password, @createDate)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserNote]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddUserNote]
	@idUser BIGINT = NULL,
	@note NVARCHAR(255) = NULL
AS
BEGIN
	INSERT INTO UserNote (IdUser, Note)
		OUTPUT INSERTED.*
	VALUES (@idUser, @note)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserPasswordRecovery]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserPasswordRecovery]
	@email NVARCHAR(150) = NULL,
	@hash NVARCHAR(255) = NULL,
	@createDate DATETIME = NULL
AS
BEGIN
	INSERT INTO UserPasswordRecovery (Email, [Hash], CreateDate)
		OUTPUT INSERTED.*
	VALUES (@email, @hash, @createDate)
END
GO
/****** Object:  StoredProcedure [dbo].[GetLogin]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLogin]
	@email NVARCHAR(150) = NULL,
	@password NVARCHAR(50) = NULL
AS
BEGIN
	SELECT * FROM [User] A INNER JOIN Profile B ON A.IdUser = B.IdUser
	WHERE A.Email = @email AND A.[Password] = @password
END
GO
/****** Object:  StoredProcedure [dbo].[GetProfileByIdUser]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetProfileByIdUser]
	@idUser BIGINT = NULL
AS
BEGIN
	SELECT * FROM Profile WHERE IdUser = @idUser
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetUserByEmail]
	@email NVARCHAR(150) = NULL
AS
BEGIN
	SELECT * FROM [User] WHERE Email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserPasswordRecoveryByEmail]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserPasswordRecoveryByEmail]
	@email NVARCHAR(150) = NULL	
AS
BEGIN
	SELECT * FROM UserPasswordRecovery WHERE Email = @email AND UpdateDate IS NOT NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserPasswordRecoveryByHash]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserPasswordRecoveryByHash]
	@hash NVARCHAR(150) = NULL	
AS
BEGIN
	SELECT * FROM UserPasswordRecovery WHERE [Hash] = @hash --AND UpdateDate IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@email NVARCHAR(150) = NULL,
	@password NVARCHAR(50) = NULL,
	@updateDate DATETIME = NULL
AS
BEGIN
	UPDATE [User] SET [Password] = @password , UpdateDate = @updateDate
	WHERE Email = @email
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserPasswordRecoveryByEmail]    Script Date: 05/07/2020 11:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUserPasswordRecoveryByEmail]
	@hash NVARCHAR(150) = NULL,
	@updateDate DATETIME = NULL
AS
BEGIN
	UPDATE UserPasswordRecovery SET UpdateDate = @updateDate 
	WHERE Hash = @hash AND UpdateDate IS NOT NULL
END
GO

