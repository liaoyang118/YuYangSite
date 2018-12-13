using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    /// <summary>
    /// 发票收件人账单信息
    /// </summary>
    public class billing_info
    {
        /// <summary>
        /// 收件人邮箱
        /// </summary>
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
