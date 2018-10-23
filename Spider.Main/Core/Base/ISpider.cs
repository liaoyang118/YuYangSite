using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Main.Core
{
    public interface ISpider
    {
        void SpiderRun();

        void Stop();
    }
}
