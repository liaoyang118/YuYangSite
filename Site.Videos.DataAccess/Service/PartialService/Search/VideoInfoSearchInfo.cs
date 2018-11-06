using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Videos.DataAccess.Service.PartialService.Search
{
    public class VideoInfoSearchInfo
    {
        public string OrderBy = "v_createTime desc";
        

        public int? v_c_id { get; set; }


        public string ToWhereString()
        {
            List<string> where = new List<string>();
            
            if (v_c_id != null)
            {
                where.Add(string.Format("v_c_id={0}", v_c_id));
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
