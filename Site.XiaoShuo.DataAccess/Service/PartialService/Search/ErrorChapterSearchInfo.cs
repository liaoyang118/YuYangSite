using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.XiaoShuo.DataAccess.Service.PartialService.Search
{
    public class ErrorChapterSearchInfo
    {
        public string OrderBy = "Id";

        public int? F_Id { get; set; }

        public int? C_C_ID { set; get; }
        public int? DisposeStatus { set; get; }

        public int? MaxTryCounts { get; set; }

        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (F_Id != null)
            {
                where.Add(string.Format("F_Id = {0}", F_Id));
            }

            if (C_C_ID != null)
            {
                where.Add(string.Format("C_C_ID = {0}", C_C_ID.Value));
            }

            if (DisposeStatus != null)
            {
                where.Add(string.Format("DisposeStatus = {0}", DisposeStatus));
            }

            if (MaxTryCounts != null)
            {
                where.Add(string.Format("RetryCount <= {0}", MaxTryCounts));
            }

            if (where.Count > 0)
            {
                return string.Format(" where {0}", string.Join(" and ", where.ToList()));
            }
            else
            {
                return string.Empty;
            }
        }


    }
}
