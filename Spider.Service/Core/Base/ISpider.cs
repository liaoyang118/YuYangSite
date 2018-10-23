using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spider.Service.Model;

namespace Spider.Service
{
    public delegate void Complete(string iocName);

    public interface ISpider
    {
        event Complete SpiderRunComplete;

        void SpiderRun();

        void Stop();
    }
}
