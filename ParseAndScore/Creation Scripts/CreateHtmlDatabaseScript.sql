USE [master]
GO
/****** Object:  Database [HtmlDatabase]    Script Date: 7/20/18 8:16:09 PM ******/
CREATE DATABASE [HtmlDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HtmlDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HtmlDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HtmlDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HtmlDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HtmlDatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HtmlDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HtmlDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HtmlDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HtmlDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HtmlDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HtmlDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [HtmlDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HtmlDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HtmlDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HtmlDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HtmlDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HtmlDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HtmlDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HtmlDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HtmlDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HtmlDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HtmlDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HtmlDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HtmlDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HtmlDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HtmlDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HtmlDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HtmlDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HtmlDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HtmlDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [HtmlDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HtmlDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HtmlDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HtmlDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HtmlDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HtmlDatabase] SET QUERY_STORE = OFF
GO
USE [HtmlDatabase]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [HtmlDatabase]
GO
/****** Object:  UserDefinedTableType [dbo].[KVTable]    Script Date: 7/20/18 8:16:09 PM ******/
CREATE TYPE [dbo].[KVTable] AS TABLE(
	[K] [varchar](50) NULL,
	[V] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TagScoreTableType]    Script Date: 7/20/18 8:16:10 PM ******/
CREATE TYPE [dbo].[TagScoreTableType] AS TABLE(
	[Tag] [varchar](50) NULL,
	[Score] [int] NULL
)
GO
/****** Object:  Table [dbo].[PageInfoKV]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageInfoKV](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL,
	[Score] [int] NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK__PageInfo__3214EC07925256CC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PageInfoTable]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageInfoTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[ProcessingDate] [datetime2](7) NOT NULL,
	[AverageScore] [float] NOT NULL,
	[MinScore] [int] NOT NULL,
	[MaxScore] [int] NOT NULL,
	[TotalScore] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PageInfoKV]  WITH NOCHECK ADD  CONSTRAINT [FK_PageInfoKV_ToTable] FOREIGN KEY([ParentId])
REFERENCES [dbo].[PageInfoTable] ([Id])
GO
ALTER TABLE [dbo].[PageInfoKV] CHECK CONSTRAINT [FK_PageInfoKV_ToTable]
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllScoresFromDateRange]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetAllScoresFromDateRange] 
	-- Add the parameters for the stored procedure here
	@startDate datetime2,
	@endDate datetime2

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT 
		a.FileName
      ,a.ProcessingDate
      ,a.AverageScore
      ,a.MinScore
      ,a.MaxScore
      ,a.TotalScore,
	  a.Id,
	  b.Tag,
	  b.Score
  FROM [HtmlDatabase].[dbo].[PageInfoTable] as a
  LEFT JOIN [PageInfoKV] as b
  On a.Id = b.ParentId
  Where ( @startDate<= a.ProcessingDate and @endDate >= a.ProcessingDate)
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllScoresFromFile]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetAllScoresFromFile] 
	-- Add the parameters for the stored procedure here
	@FileName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT 
		a.FileName
      ,a.ProcessingDate
      ,a.AverageScore
      ,a.MinScore
      ,a.MaxScore
      ,a.TotalScore,
	  a.Id,
	  b.Tag,
	  b.Score
  FROM [HtmlDatabase].[dbo].[PageInfoTable] as a
  LEFT JOIN [PageInfoKV] as b
  On a.Id = b.ParentId
  Where @FileName = a.FileName
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllScoresInDatabase]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetAllScoresInDatabase] 
	-- Add the parameters for the stored procedure here
	--@FileName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT 
		a.FileName
      ,a.ProcessingDate
      ,a.AverageScore
      ,a.MinScore
      ,a.MaxScore
      ,a.TotalScore,
	  a.Id,
	  b.Tag,
	  b.Score
  FROM [HtmlDatabase].[dbo].[PageInfoTable] as a
  LEFT JOIN [PageInfoKV] as b
  On a.Id = b.ParentId
 -- Where @FileName = a.FileName
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateCommand]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateCommand] 
	-- Add the parameters for the stored procedure here

	@AverageScore float, 
	@FileName nvarchar(50),
	@MaxScore int , 
	@MinScore int, 
	@ProcessingDate datetime2,
	@TotalScore int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].PageInfoTable
           ([AverageScore]
           ,[FileName]
           ,[MaxScore]
           ,[MinScore]
           ,[ProcessingDate]
		   ,[TotalScore])
     VALUES
           (@AverageScore
           ,@FileName
           ,@MaxScore
           ,@MinScore
           ,@ProcessingDate
           ,@TotalScore)
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateCommandII]    Script Date: 7/20/18 8:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateCommandII] 
	-- Add the parameters for the stored procedure here

	@AverageScore float, 
	@FileName nvarchar(50),
	@MaxScore int , 
	@MinScore int, 
	@ProcessingDate datetime2,
	@TotalScore int,
	@HtmlKeyValueList TagScoreTableType READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @id int, @tempId int
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].PageInfoTable
           ([AverageScore]
           ,[FileName]
           ,[MaxScore]
           ,[MinScore]
           ,[ProcessingDate]
		   ,[TotalScore])
     VALUES
           (@AverageScore
           ,@FileName
           ,@MaxScore
           ,@MinScore  
           ,@ProcessingDate
           ,@TotalScore)



SET @id = SCOPE_IDENTITY() 


INSERT INTO PageInfoKV([Tag],[Score],[ParentId])
SELECT p.Tag, p.Score, @id
FROM @HtmlKeyValueList as p


END





GO
USE [master]
GO
ALTER DATABASE [HtmlDatabase] SET  READ_WRITE 
GO
