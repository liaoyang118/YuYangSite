using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Spider.Service.Core;

namespace Spider.Service
{
    public partial class SpiderService : ServiceBase
    {
        MainStart main = null;

        public SpiderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(1000 * 20);
            main = new MainStart();
            main.Start();
        }

        protected override void OnStop()
        {
            main.write.WriteNotifyContet("服务停止");
        }
    }
}
