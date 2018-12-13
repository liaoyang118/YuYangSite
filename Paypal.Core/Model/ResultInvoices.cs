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
    }

    public class Urls
    {
        public string rel { get; set; }

        public string href { get; set; }

        public string method { get; set; }
    }
}
