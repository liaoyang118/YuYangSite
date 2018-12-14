using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    /// <summary>
    /// 账单body
    /// </summary>
    public class InvoiceBody
    {
        /// <summary>
        /// 商户信息
        /// </summary>
        public merchant_info merchant_info { get; set; }

        /// <summary>
        /// 收件人信息（账单接收人）
        /// </summary>
        public List<billing_info> billing_info { get; set; }

        /// <summary>
        /// 收货人信息
        /// </summary>
        public shipping_info shipping_info { get; set; }


        /// <summary>
        /// 商品
        /// </summary>
        public List<item> items { get; set; }


        /// <summary>
        /// 运费
        /// </summary>
        public shipping_cost shipping_cost { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public discount discount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }

        /// <summary>
        /// 条款和条件（30天后过期）
        /// </summary>
        public string terms { get; set; }
    }
}
