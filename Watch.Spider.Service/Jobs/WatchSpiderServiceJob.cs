using Quartz;
using System;
using System.ServiceProcess;

namespace Watch.Spider.Service.Jobs
{
    public class WatchSpiderServiceJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Site.Log.LogHelp.Info("执行重启任务");

            SentMail.SentMail sm = null;
            string content = string.Empty;
            try
            {
                string serviceName = "爬虫服务";
                //监控业务服务是否启动，未启动，自动重启
                if (IsServiceExisted(serviceName))
                {
                    if (ServiceStart(serviceName))
                    {
                        sm = new SentMail.SentMail();
                        sm.Init("爬虫守护进程", "爬虫服务宕机，守护进程重启该服务", "liao.yang118@163.com", content);
                        content = "重启服务成功！";
                    }
                }


                serviceName = "MongoDB";
                //监控业务服务是否启动，未启动，自动重启
                if (IsServiceExisted(serviceName))
                {
                    if (ServiceStart(serviceName))
                    {
                        sm = new SentMail.SentMail();
                        sm.Init("MongoDB守护进程", "MongoDB服务宕机，守护进程重启该服务", "liao.yang118@163.com", content);
                        content = "重启服务成功！";
                    }
                }
                Site.Log.LogHelp.Info(content);
            }
            catch (Exception ex)
            {
                content = "重启服务出错：" + ex.Message;

                Site.Log.LogHelp.Info(content);
            }
            finally
            {
                if (sm != null)
                {
                    string error;
                    sm.SentNetMail(out error);
                    Site.Log.LogHelp.Info("发送邮件错误：" + error);
                }
            }
        }

        //启动服务
        private bool ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    control.Start();
                    return true;
                }
            }
            return false;
        }

        //停止服务
        private bool ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                    return true;
                }
            }
            return false;
        }

        //判断服务是否存在
        private bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
