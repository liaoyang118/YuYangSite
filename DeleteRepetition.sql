
------删除重复数据
GO
DECLARE @Id INT ,
    @C_Id INT;
DECLARE columnsCursor SCROLL CURSOR
FOR
    --查询重复Id和分类Id
SELECT  Id ,
        C_C_ID
FROM    dbo.Fiction
WHERE   Id NOT IN ( SELECT  MAX(Id) AS MaxId
                    FROM    dbo.Fiction
                    GROUP BY Title ,
                            Author );

--打开游标
OPEN columnsCursor;
--移动游标
FETCH NEXT FROM columnsCursor INTO @Id, @C_Id;
DECLARE @sql NVARCHAR(1000);
WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRANSACTION trandelete;
        DECLARE @tran_error INT;
        SET @tran_error = 0;
        BEGIN TRY
	--删除小说
            SET @sql = N'DELETE dbo.Fiction WHERE Id= '
                + CAST(@Id AS NVARCHAR(10));
            EXEC sp_executesql @sql;
            SET @tran_error = @tran_error + @@error;
	--删除小说章节
            SET @sql = N'DELETE  ChapterList_T_' + CAST(@C_Id AS NVARCHAR(10))
                + N' where F_ID=' + CAST(@Id AS NVARCHAR(10));
            EXEC sp_executesql @sql;
            SET @tran_error = @tran_error + @@error;
        END TRY
        BEGIN CATCH  
            PRINT '出现异常，错误编号：' + CONVERT(VARCHAR, ERROR_NUMBER()) + '， 错误消息：'
                + ERROR_MESSAGE();  
            SET @tran_error = @tran_error + 1;
        END CATCH;
        IF ( @tran_error > 0 )
            BEGIN
        --执行出错，回滚事务
                ROLLBACK TRAN;
                PRINT '删除重复失败，回滚删除';
            END;
        ELSE
            BEGIN
        --没有异常，提交事务
                COMMIT TRAN;
                PRINT '删除重复成功';
            END;

--移动游标,判断是否还有下一条
        FETCH NEXT FROM columnsCursor INTO @Id, @C_Id;
    END;
--关闭游标
CLOSE columnsCursor;
--释放游标
DEALLOCATE columnsCursor;