using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;

namespace Site.XiaoShuo.DataAccess.Base
{
    /// <summary>
    /// MySql 分表对应的数据库操作
    /// </summary>
    /// <typeparam name="T">操作对象</typeparam>
    public abstract class MySql_AccessBasePartial<T> where T : class
    {

        MySqlConnection connection = null;
        public MySqlCommand Command = null;

        public void GetCommand(string sql)
        {
            if (connection == null)
            {
                connection = new MySqlConnection(ConnectionStr);
            }
            if (Command == null)
            {
                Command = new MySqlCommand(sql, connection);
            }
        }

        public void DisposeCommand()
        {
            if (Command != null)
            {
                Command.Dispose();
            }
        }

        public void DisposeConnection()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }


        //抽象属性
        protected abstract string ConnectionStr { get; set; }

        /// <summary>
        /// 分表格式：表名_T_{index}
        /// </summary>
        protected abstract string DataTableNameFormat { get; set; }

        public abstract int Insert(T obj, int tableIndex);

        public abstract int Delete(int id, int tableIndex);

        public abstract int Update(T obj, int tableIndex);

        public abstract T SelectObject(int id, int tableIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <returns></returns>
        public abstract IList<T> Select(string whereStr, int tableIndex);

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
        public abstract IList<T> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, int tableIndex, out int rowCount);


        public abstract int BatchInsert(IList<T> list, int tableIndex);

    }
}
