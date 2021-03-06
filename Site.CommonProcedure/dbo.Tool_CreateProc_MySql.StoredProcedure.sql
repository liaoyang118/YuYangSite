USE [Video]
GO
/****** Object:  StoredProcedure [dbo].[Tool_CreateProc_MySql]    Script Date: 2018/11/19 23:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Tool_CreateProc_MySql]
    @tableName VARCHAR(50),
    @createUser NVARCHAR(50) = ''
AS
DECLARE @name VARCHAR(20),
        @userType VARCHAR(5),
        @isIdentity BIT,
        @maxLength INT;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = @tableName)
BEGIN
    PRINT 'Not Find This Table';
    RETURN;
END;


DECLARE columnsCursor SCROLL CURSOR FOR
--查询表有哪些列
SELECT name,
       user_type_id,
       is_identity,
       max_length
FROM sys.columns
WHERE object_id = OBJECT_ID(@tableName);

--打开游标
OPEN columnsCursor;
--移动游标
FETCH NEXT FROM columnsCursor
INTO @name,
     @userType,
     @isIdentity,
     @maxLength;

----------------------------插入----------------------------------
PRINT ''
PRINT '/*****插入*****
*****CreateUser:' + @createUser + '*****' + '
*****CreateTime:' + CAST(GETDATE() AS VARCHAR(30)) + '*****/'
PRINT N'DELIMITER $$';
PRINT N'DROP PROCEDURE IF EXISTS `Proc_' + @tableName + '_Insert`$$
CREATE PROCEDURE `Proc_' + @tableName + '_Insert`';
PRINT N'('
DECLARE @columnType NVARCHAR(30),
        @argus VARCHAR(100),
        @outPutArgument VARCHAR(30);

WHILE @@FETCH_STATUS = 0
BEGIN
    --调用函数，得到数据类型
    SET @columnType = dbo.f_GetCSharpDataTypeBySqlUserType(@userType, @maxLength);
    IF (@isIdentity = 1)
    BEGIN
        SET @argus = 'out ' + @name + ' ' + @columnType;
        SET @outPutArgument = @name;
    END;
    ELSE
        SET @argus = 'in ' + @name + ' ' + @columnType;
    --移动游标,判断是否还有下一条
    FETCH NEXT FROM columnsCursor
    INTO @name,
         @userType,
         @isIdentity,
         @maxLength;
    IF (@@FETCH_STATUS = 0)
    BEGIN
        PRINT @argus + ',';
    END;
    ELSE
    BEGIN
        PRINT @argus;
    END;
END;

-------------------------
PRINT ') BEGIN';
PRINT 'insert into ' + @tableName + '(';
--移动游标,判断是否还有下一条
FETCH FIRST FROM columnsCursor
INTO @name,
     @userType,
     @isIdentity,
     @maxLength;

WHILE @@FETCH_STATUS = 0
BEGIN
    --调用函数，得到数据类型
    SET @columnType = dbo.f_GetCSharpDataTypeBySqlUserType(@userType, @maxLength);
    IF (@isIdentity = 1)
    BEGIN
        --移动游标,判断是否还有下一条
        FETCH RELATIVE 1
        FROM columnsCursor
        INTO @name,
             @userType,
             @isIdentity,
             @maxLength;
        CONTINUE;
    END;
    ELSE
    BEGIN
        SET @argus = @name;
    END;
    --移动游标,判断是否还有下一条
    FETCH RELATIVE 1
    FROM columnsCursor
    INTO @name,
         @userType,
         @isIdentity,
         @maxLength;
    IF (@@FETCH_STATUS = 0)
    BEGIN
        PRINT @argus + ',';
    END;
    ELSE
    BEGIN
        PRINT @argus;
    END;

END;



PRINT ')
values(';

--移动游标到第一条
FETCH FIRST FROM columnsCursor
INTO @name,
     @userType,
     @isIdentity,
     @maxLength;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF (@isIdentity = 1)
    BEGIN
        --移动游标,判断是否还有下一条
        FETCH RELATIVE 1
        FROM columnsCursor
        INTO @name,
             @userType,
             @isIdentity,
             @maxLength;
        CONTINUE;
    END;
    ELSE
    BEGIN
        SET @argus = @name;
    END;
    --移动游标,判断是否还有下一条
    FETCH RELATIVE 1
    FROM columnsCursor
    INTO @name,
         @userType,
         @isIdentity,
         @maxLength;
    IF (@@FETCH_STATUS = 0)
    BEGIN
        PRINT @argus + ',';
    END;
    ELSE
    BEGIN
        PRINT @argus;
    END;
END;
PRINT ');';
PRINT 'SET ' + @outPutArgument + '=@@IDENTITY;';
PRINT N'END$$'
PRINT N'DELIMITER ;'

-----------------------删除------------------------------
PRINT ''
PRINT '/*****删除*****
*****CreateUser:' + @createUser + '*****' + '
*****CreateTime:' + CAST(GETDATE() AS VARCHAR(30)) + '*****/'
PRINT N'DELIMITER $$';
PRINT N'DROP PROCEDURE IF EXISTS `Proc_' + @tableName + '_DeleteBy' + @outPutArgument+ '`$$
create PROCEDURE `Proc_' + @tableName + '_DeleteBy' + @outPutArgument+'`';
PRINT '('
PRINT 'IN ' + @outPutArgument + ' int
)';
PRINT 'BEGIN'
PRINT 'delete from ' + @tableName + ' where ' + @outPutArgument + '=' + '' + @outPutArgument+';';
PRINT 'END$$'
PRINT 'DELIMITER ;'

-----------------------修改------------------------------
PRINT ''
PRINT '/*****修改*****
*****CreateUser:' + @createUser + '*****' + '
*****CreateTime:' + CAST(GETDATE() AS VARCHAR(30)) + '*****/'
PRINT N'DELIMITER $$';
PRINT N'DROP PROCEDURE IF EXISTS `Proc_' + @tableName + '_UpdateBy' + @outPutArgument + '`$$
CREATE PROCEDURE `Proc_' + @tableName + '_UpdateBy' + @outPutArgument+'`(';

--移动游标到第一条
FETCH FIRST FROM columnsCursor
INTO @name,
     @userType,
     @isIdentity,
     @maxLength;

WHILE @@FETCH_STATUS = 0
BEGIN
    --调用函数，得到数据类型
    SET @columnType = dbo.f_GetCSharpDataTypeBySqlUserType(@userType, @maxLength);
    --IF(@isIdentity=1)
    --BEGIN
    ----SET @argus=''
    --SET @outPutArgument=@name
    ----移动游标,判断是否还有下一条
    --FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
    --CONTINUE
    --END
    --ELSE
    SET @argus = 'in ' + @name + ' ' + @columnType;
    --移动游标,判断是否还有下一条
    FETCH RELATIVE 1
    FROM columnsCursor
    INTO @name,
         @userType,
         @isIdentity,
         @maxLength;
    IF (@@FETCH_STATUS = 0)
    BEGIN
        PRINT @argus + ',';
    END;
    ELSE
    BEGIN
        PRINT @argus;
    END;
END;
PRINT ') Begin';
PRINT 'update ' + @tableName + ' SET ';

--移动游标到第一条
FETCH FIRST FROM columnsCursor
INTO @name,
     @userType,
     @isIdentity,
     @maxLength;
DECLARE @VALUES VARCHAR(50);
WHILE @@FETCH_STATUS = 0
BEGIN
    IF (@isIdentity = 1)
    BEGIN
        --移动游标,判断是否还有下一条
        FETCH RELATIVE 1
        FROM columnsCursor
        INTO @name,
             @userType,
             @isIdentity,
             @maxLength;
        CONTINUE;
    END;
    ELSE
        SET @VALUES = @name + '='  + @name;
    --移动游标,判断是否还有下一条
    FETCH RELATIVE 1
    FROM columnsCursor
    INTO @name,
         @userType,
         @isIdentity,
         @maxLength;
    IF (@@FETCH_STATUS = 0)
    BEGIN
        PRINT @VALUES + ',';
    END;
    ELSE
    BEGIN
        PRINT @VALUES;
    END;
END;
PRINT ' where ' + @outPutArgument + '=' + @outPutArgument+';';
PRINT 'END$$'
PRINT 'DELIMITER ;'

-----------------------查询------------------------------
PRINT ''
PRINT '/*****查询*****
*****CreateUser:' + @createUser + '*****' + '
*****CreateTime:' + CAST(GETDATE() AS VARCHAR(30)) + '*****/'
PRINT N'DELIMITER $$';
PRINT N'DROP PROCEDURE IF EXISTS `Proc_' + @tableName + '_SelectBy' + @outPutArgument + '`$$
create PROCEDURE `Proc_' + @tableName + '_SelectBy' + @outPutArgument+'`';
PRINT '('
PRINT 'in ' + @outPutArgument + ' int';
PRINT ')
BEGIN
select * FROM ' + @tableName + ' WHERE ' + @outPutArgument + '='  + @outPutArgument+';';
PRINT 'END$$'
PRINT 'DELIMITER ;'

----------------------- where查询---------------------------------------
PRINT ''
PRINT '/*****查询*****
*****CreateUser:' + @createUser + '*****' + '
*****CreateTime:' + CAST(GETDATE() AS VARCHAR(30)) + '*****/'
PRINT N'DELIMITER $$';
PRINT N'DROP PROCEDURE IF EXISTS `Proc_' + @tableName + '_SelectList`$$
create PROCEDURE `Proc_' + @tableName + '_SelectList`(';
PRINT 'whereStr nvarchar(1000)';
PRINT ')
BEGIN
SET @sqlStr=CONCAT(''SELECT * FROM ' + @tableName + ' '',whereStr);
PREPARE stmt FROM @sqlStr;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;'
PRINT 'END$$'
PRINT 'DELIMITER ;'

-----------------------分页查询------------------------------
PRINT ''
PRINT '/*****查询*****
*****CreateUser:' + @createUser + '*****' + '
*****CreateTime:' + CAST(GETDATE() AS VARCHAR(30)) + '*****/'
PRINT N'DELIMITER $$';
PRINT N'DROP PROCEDURE IF EXISTS `Proc_' + @tableName + '_SelectPage'+ '`$$
create PROCEDURE `Proc_' + @tableName + '_SelectPage`(';
PRINT 'out rowCount INT,
in cloumns VARCHAR(200),
in pageIndex INT,
in pageSize INT,
in orderBy VARCHAR(20),
in whereStr VARCHAR(500)
)';
PRINT 'BEGIN'
PRINT 'declare startIndex int;'
PRINT 'set startIndex=(pageIndex-1)*pageSize;'
PRINT 'set @sqlStr=CONCAT(''SELECT * FROM `'+@tableName+'`'',whereStr,''LIMIT '',startIndex,'','',pageSize);'
PRINT '
PREPARE stmt FROM @sqlStr;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;'
PRINT 'END$$
DELIMITER ;'

--关闭游标
CLOSE columnsCursor;
--释放游标
DEALLOCATE columnsCursor;








GO
