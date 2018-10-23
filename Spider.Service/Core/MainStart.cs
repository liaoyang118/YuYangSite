using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Spider.Service.Communicant;
using Spider.Service.Interface;
using Spider.Service.Model;
using Spider.Service.Tool;
using Unity;
using Unity.Resolution;

namespace Spider.Service.Core
{
    public class MainStart
    {
        #region 全局变量

        /// <summary>
        /// IOC容器
        /// </summary>
        IUnityContainer container = null;

        /// <summary>
        /// 任务通知者
        /// </summary>
        MainController controller = null;

        /// <summary>
        /// 日志输出
        /// </summary>
        public IWriteContent write;

        /// <summary>
        /// 开启的任务列表
        /// key ioc名称
        /// value 任务
        /// </summary>
        Dictionary<string, ISpider> dic = new Dictionary<string, ISpider>();

        #endregion

        #region 00 构造函数

        public MainStart()
        {
            try
            {
                //获得容器对象
                container = UnityHelper.GetIUnityContainer();
                //实例化任务通知者
                controller = new MainController();
                //日志输出
                write = container.Resolve<IWriteContent>();

                Start();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 01 开启任务 + void Start()
        public void Start()
        {
            try
            {
                TaskList info = Common.ReadConfig();
                foreach (TaskInfo item in info.TaskInfos)
                {
                    //开始 任务线程
                    Thread t = new Thread(StartSpider);
                    t.IsBackground = true;
                    t.Start(item);
                }
            }
            catch (Exception ex)
            {
                write.WriteErrorContet(ex.Message);
            }
        }
        #endregion

        #region 02 启动任务对象 - void StartSpider(object obj)
        private void StartSpider(object obj)
        {
            TaskInfo info = (TaskInfo)obj;
            try
            {
                ISpider spider = IOC_GetInstance(container, info);

                //任务加入列表
                dic[info.IocName] = spider;
                //加入通知者
                controller.StopTaskEvent += new StopTask(spider.Stop);

                //设置完成事件
                spider.SpiderRunComplete += Handle_SpiderRunComplete;
                //设置完成事件
                spider.SpiderRun();
            }
            catch (Exception ex)
            {
                write.WriteErrorContet(ex.Message);
            }
        }
        #endregion

        #region 03 获取IOC对象 - ISpider IOC_GetInstance(IUnityContainer container, TaskInfo info)
        /// <summary>
        /// 获取IOC对象
        /// </summary>
        /// <param name="container"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private ISpider IOC_GetInstance(IUnityContainer container, TaskInfo info)
        {
            //指定命名解析对象
            ISpider handle = null;

            //58小说网抓取任务
            if (info.IocName == "5858XS")
            {
                handle = container.Resolve<ISpider>(info.IocName, new ParameterOverrides{
                {"form", write},
                {"PageNums", info.PageNums},
                {"FictionNums", info.FictionNums},
                {"Nums", info.Nums},
                {"UpdateGrowNums", info.UpdateGrowNums},
                {"iocName", info.IocName}

                });

            }
            else if (info.IocName == "5858XS_Error")//获取错误章节任务
            {
                handle = container.Resolve<ISpider>(info.IocName, new ParameterOverrides{
                {"form", write},
                {"iocName", info.IocName},
                {"pageCount", 1000}
                });
            }
            return handle;
        }

        #endregion

        #region 04 完成事件 - void Handle_SpiderRunComplete(string iocName)

        private void Handle_SpiderRunComplete(string iocName)
        {
            try
            {
                TaskList info = Common.ReadConfig();
                foreach (TaskInfo item in info.TaskInfos)
                {
                    if (item.IocName.ToLower() == iocName.ToLower())
                    {
                        //开始 任务线程
                        Thread t = new Thread(StartSpider);
                        t.IsBackground = true;
                        t.Start(item);

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                write.WriteErrorContet(ex.Message);
            }
        }

        #endregion

    }
}
