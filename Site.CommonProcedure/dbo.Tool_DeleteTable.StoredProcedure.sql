USE [Video]
GO
/****** Object:  StoredProcedure [dbo].[Tool_DeleteTable]    Script Date: 2018/11/19 23:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Tool_DeleteTable]
AS
BEGIN
	DECLARE @tableName VARCHAR(100),@sql NVARCHAR(500)
	DECLARE tableCursor CURSOR FOR
	SELECT [name] FROM sys.objects WHERE [type]='U' AND [type_desc]='USER_TABLE'

	OPEN tableCursor
	FETCH NEXT FROM tableCursor INTO @tableName

	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @sql=N'drop table '+@tableName
		EXEC sp_executesql @sql

		FETCH NEXT FROM tableCursor INTO @tableName
    END

	CLOSE tableCursor
	DEALLOCATE tableCursor

END
GO
