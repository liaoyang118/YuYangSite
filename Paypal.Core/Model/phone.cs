using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    public class phone
    {
        /// <summary>
        /// 国家代码 001
        /// </summary>
        public string country_code { get; set; }

        /// <summary>
        /// 唯一号码
        /// </summary>
        public string national_number { get; set; }
    }
}
