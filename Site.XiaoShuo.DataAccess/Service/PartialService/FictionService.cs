using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.XiaoShuo.DataAccess.Access;
using Site.XiaoShuo.DataAccess.Model;

namespace Site.XiaoShuo.DataAccess.Service
{
    public partial class FictionService
    {
        public static IList<Fiction> SelectPageExcuteSql(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
        {
            using (var access = new FictionAccess())
            {
                return access.SelectPageExcuteSql(cloumns, order, whereStr, pageIndex, pageSize, out rowCount);
            }
        }

        public static int GetLastUpdateChapter(int fid, int cateId)
        {
            using (var access = new FictionAccess())
            {
                return access.GetLastUpdateChapter(fid, cateId);
            }
        }

    }
}
