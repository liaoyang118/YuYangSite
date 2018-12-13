using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    /// <summary>
    /// 商品
    /// </summary>
    public class item
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public unit_price unit_price { get; set; }


        public tax tax { get; set; }
    }

    /// <summary>
    /// 单价
    /// </summary>
    public class unit_price
    {
        /// <summary>
        /// 币种 USD
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public Decimal value { get; set; }
    }

    /// <summary>
    /// 税率
    /// </summary>
    public class tax
    {
        /// <summary>
        /// 名称 Tax
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 百分比
        /// </summary>
        public double percent { get; set; }

    }

    /// <summary>
    /// 折扣
    /// </summary>
    public class discount
    {
        /// <summary>
        /// 百分比
        /// </summary>
        public double percent { get; set; }
    }

    /// <summary>
    /// 运费
    /// </summary>
    public class shipping_cost
    {
        public amount amount { get; set; }
    }

    public class amount : unit_price
    {

    }

}
