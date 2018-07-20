CREATE TABLE [dbo].[PageInfoTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FileName] NVARCHAR(50) NOT NULL, 
    [ProcessingDate] DATETIME2 NOT NULL, 
    [AverageScore] FLOAT NOT NULL, 
    [MinScore] INT NOT NULL, 
    [MaxScore] INT NOT NULL, 
    [TotalScore] INT NOT NULL 
)
