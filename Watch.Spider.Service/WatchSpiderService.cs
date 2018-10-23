using Quartz.Impl;
using System.ServiceProcess;
using Quartz;

namespace Watch.Spider.Service
{
    public partial class WatchSpiderService : ServiceBase
    {
        public WatchSpiderService()
        {
            InitializeComponent();
        }


        StdSchedulerFactory sf = null;
        IScheduler sc = null;
        protected override void OnStart(string[] args)
        {
            sf = new StdSchedulerFactory();
            sc = sf.GetScheduler();
            sc.Start();

        }

        protected override void OnStop()
        {
            sc.Shutdown();
        }
    }
}
