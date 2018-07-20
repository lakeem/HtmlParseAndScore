CREATE TABLE [dbo].[PageInfoKV]
(
	[KvId] INT NOT NULL PRIMARY KEY, 
    [Key] NVARCHAR(50) NOT NULL, 
    [Value] INT NOT NULL, 
    CONSTRAINT [FK_PageInfoKV_ToTable] FOREIGN KEY (KvId) REFERENCES PageInfoTable (Id)

)
