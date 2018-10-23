using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Site.XiaoShuo.DataAccess.Base
{
    /// <summary>
    /// MongoDB 分表对应的数据库操作
    /// MongoDB插入会自动产生一个ObjectId唯一键
    /// </summary>
    /// <typeparam name="T">操作对象</typeparam>
    public abstract class Mongo_AccessBasePartial<T> where T : class
    {

        MongoClient client = null;
        public IMongoDatabase Database = null;

        public void GetDatabase(string databaseName)
        {
            if (client == null)
            {
                client = new MongoClient(ConnectionStr);
            }
            if (Database == null)
            {
                Database = client.GetDatabase(databaseName);
            }
        }

        //抽象属性
        protected abstract string ConnectionStr { get; set; }

        /// <summary>
        /// 分表格式：表名_T_{index}
        /// </summary>
        protected abstract string DataTableNameFormat { get; set; }

        public abstract string Insert(T obj, int tableIndex);

        public abstract int Delete(Expression<Func<T, bool>> filter, int tableIndex);

        public abstract int Update(Expression<Func<T, bool>> filter, T obj, int tableIndex);

        public abstract T SelectObject(Expression<Func<T, bool>> filter, int tableIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IList<T> Select(Expression<Func<T, bool>> filter, int tableIndex);

        public abstract IList<T> Select(Expression<Func<T, bool>> filter, SortDefinition<T> order, int tableIndex);


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="order"></param>
        /// <param name="filter">格式： where 条件</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tableIndex"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public abstract IList<T> SelectPage(SortDefinition<T> order, Expression<Func<T, bool>> filter, int pageIndex, int pageSize, int tableIndex, out int rowCount);


        public abstract void BatchInsert(IList<T> list, int tableIndex);

    }
}
