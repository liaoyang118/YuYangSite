
------ɾ���ظ�����
GO
DECLARE @Id INT ,
    @C_Id INT;
DECLARE columnsCursor SCROLL CURSOR
FOR
    --��ѯ�ظ�Id�ͷ���Id
SELECT  Id ,
        C_C_ID
FROM    dbo.Fiction
WHERE   Id NOT IN ( SELECT  MAX(Id) AS MaxId
                    FROM    dbo.Fiction
                    GROUP BY Title ,
                            Author );

--���α�
OPEN columnsCursor;
--�ƶ��α�
FETCH NEXT FROM columnsCursor INTO @Id, @C_Id;
DECLARE @sql NVARCHAR(1000);
WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRANSACTION trandelete;
        DECLARE @tran_error INT;
        SET @tran_error = 0;
        BEGIN TRY
	--ɾ��С˵
            SET @sql = N'DELETE dbo.Fiction WHERE Id= '
                + CAST(@Id AS NVARCHAR(10));
            EXEC sp_executesql @sql;
            SET @tran_error = @tran_error + @@error;
	--ɾ��С˵�½�
            SET @sql = N'DELETE  ChapterList_T_' + CAST(@C_Id AS NVARCHAR(10))
                + N' where F_ID=' + CAST(@Id AS NVARCHAR(10));
            EXEC sp_executesql @sql;
            SET @tran_error = @tran_error + @@error;
        END TRY
        BEGIN CATCH  
            PRINT '�����쳣�������ţ�' + CONVERT(VARCHAR, ERROR_NUMBER()) + '�� ������Ϣ��'
                + ERROR_MESSAGE();  
            SET @tran_error = @tran_error + 1;
        END CATCH;
        IF ( @tran_error > 0 )
            BEGIN
        --ִ�г����ع�����
                ROLLBACK TRAN;
                PRINT 'ɾ���ظ�ʧ�ܣ��ع�ɾ��';
            END;
        ELSE
            BEGIN
        --û���쳣���ύ����
                COMMIT TRAN;
                PRINT 'ɾ���ظ��ɹ�';
            END;

--�ƶ��α�,�ж��Ƿ�����һ��
        FETCH NEXT FROM columnsCursor INTO @Id, @C_Id;
    END;
--�ر��α�
CLOSE columnsCursor;
--�ͷ��α�
DEALLOCATE columnsCursor;