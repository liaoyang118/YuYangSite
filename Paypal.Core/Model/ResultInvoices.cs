using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core.Model
{
    public class ResultInvoices
    {
        public string id { get; set; }
        public string number { get; set; }
        public string template_id { get; set; }
        public string status { get; set; }
        public List<Urls> links { get; set; }

        public Urls GetUrls(RelType relType)
        {
            string type = string.Empty;
            switch (relType)
            {
                case RelType.当前:
                    type = "self";
                    break;
                case RelType.发送:
                    type = "send";
                    break;
                case RelType.替换:
                    type = "replace";
                    break;
                case RelType.删除:
                    type = "delete";
                    break;
                case RelType.付款预览:
                    type = "payer-view";
                    break;
                case RelType.商户预览:
                    type = "merchant-view";
                    break;
                default:
                    break;
            }

            if (links != null && links.Count > 0)
            {
                return links.Where(u => u.rel == type).FirstOrDefault();
            }
            return null;
        }
    }

    public class Urls
    {
        /// <summary>
        /// self send replace delete payer-view merchant-view
        /// </summary>
        public string rel { get; set; }

        public string href { get; set; }

        public string method { get; set; }
    }

    public enum RelType
    {
        当前 = 1,
        发送 = 2,
        替换 = 3,
        删除 = 4,
        付款预览 = 5,
        商户预览 = 6
    }

}
