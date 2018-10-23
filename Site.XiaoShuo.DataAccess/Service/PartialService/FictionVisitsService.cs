using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.XiaoShuo.DataAccess.Access;
using Site.XiaoShuo.DataAccess.Model;

namespace Site.XiaoShuo.DataAccess.Service
{
    public partial class FictionVisitsService
    {
        public static IList<FictionVisits> SelectPageExcuteSql(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
        {
            using (var access = new FictionVisitsAccess())
            {
                return access.SelectPageExcuteSql(cloumns, order, whereStr, pageIndex, pageSize, out rowCount);
            }
        }
    }
}
