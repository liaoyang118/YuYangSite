using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Data;

namespace DataAccess.Base
{
    /// <summary>
    /// 所有id属性 默认为表中的主键
    /// </summary>
    /// <typeparam name="T">操作对象</typeparam>
    public abstract class AccessBase<T> where T : class
    {
        //抽象属性
        protected abstract string ConnectionStr { get; set; }
        protected abstract string DataTableName { get; set; }

        public abstract int Insert(T obj);

        public abstract int Delete(int id);

        public abstract int Update(T obj);

        public abstract T SelectObject(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <returns></returns>
        public abstract IList<T> Select(string whereStr);

        /// <summary>
        /// 分页查询，注意需要数据库有该存储过程 Proc_SelectPageBase
        /// </summary>
        /// <param name="cloumns">格式：*、name,age,num</param>
        /// <param name="order">格式:ID DESC、ID ASC、name,age desc</param>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public abstract IList<T> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="batchSize">一次性插入的量</param>
        public int SqlBulkCopyBatchInsert(IList list, int batchSize = 100000)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(ConnectionStr, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        DataTable sourceDataTable = ToDataTableTow(list);
                        sqlBulkCopy.DestinationTableName = DataTableName;
                        sqlBulkCopy.BatchSize = batchSize;
                        for (int i = 0; i < sourceDataTable.Columns.Count; i++)
                        {
                            sqlBulkCopy.ColumnMappings.Add(sourceDataTable.Columns[i].ColumnName, sourceDataTable.Columns[i].ColumnName);
                        }
                        sqlBulkCopy.WriteToServer(sourceDataTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("批量插入数据库：" + ex.Message);
                    }
                    return batchSize;
                }
            }
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private DataTable ToDataTableTow(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                foreach (object t in list)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(t, null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
    }
}
