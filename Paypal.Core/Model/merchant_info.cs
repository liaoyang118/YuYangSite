using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    /// <summary>
    /// 发票方（商家）
    /// </summary>
    public class merchant_info
    {
        /// <summary>
        /// 商户邮箱
        /// </summary>
        public string email { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string business_name { get; set; }

        /// <summary>
        /// 商家联系电话
        /// </summary>
        public phone phone { get; set; }

        /// <summary>
        /// 商家地址
        /// </summary>
        public address address { get; set; }
        
    }
}
