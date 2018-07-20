USE [HtmlDatabase]
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateCommandII]    Script Date: 7/19/18 2:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[uspUpdateCommandII] 
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
--SET @tempId = ( SELECT * FROM dbo.[PageInfoTable] as t Where t.Id = @id) 


--INSERT INTO PageInfoKV(ParentId)
--VALUES (@id)


INSERT INTO PageInfoKV([Tag],[Score],[ParentId])
SELECT p.Tag, p.Score, @id
FROM @HtmlKeyValueList as p



--UPDATE PageInfoKV
--SET [Tag] =ph.[Tag], [Score] = ph.[Score], [ParentId] = @id
--FROM PageInfoKV JOIN @HtmlKeyValueList as ph
--ON PageInfoKV.ParentId = @id




END





