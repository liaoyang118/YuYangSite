using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    /// <summary>
    /// 收货人信息
    /// </summary>
    public class shipping_info
    {
        /// <summary>
        /// 收货地址
        /// </summary>
        public address address { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
