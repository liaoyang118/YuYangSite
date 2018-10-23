using Site.Untity;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static Site.Untity.SiteEnum;
using HtmlAgilityPack;

namespace Spider.Main.Core
{
    public class Spider591_Cate
    {

        #region 字段

        //当前线程 抓取的页码
        int _currentPage = 1;
        int _totalPage = 0;
        string _currentCateName;
        string _pageFormat;

        /// <summary>
        /// 并发页数
        /// </summary>
        int _PageNums;

        /// <summary>
        /// 并发小说数
        /// </summary>
        int _fictionNums;

        /// <summary>
        /// 并发章节数
        /// </summary>
        int _Nums;

        /// <summary>
        /// 更新增量，小说标识是已完成抓取状态的，做更新操作，只抓取最后指定数量的章节
        /// </summary>
        public int _UpdateGrowNums { get; set; }

        /// <summary>
        /// 是否停止当前任务
        /// </summary>
        bool isStop = false;

        /// <summary>
        /// 正在执行的页数任务
        /// </summary>
        List<Spider58_Cate_Fiction> fictionPageList = new List<Spider58_Cate_Fiction>();

        /// <summary>
        /// 主窗体引用
        /// </summary>
        private MainForm main;

        /// <summary>
        /// 网站域名
        /// </summary>
        private string Domain;

        /// <summary>
        /// 任务名称头
        /// </summary>
        string LogTaskHead = "【58小说网】爬虫任务";
        List<Thread> excuteThreads = new List<Thread>();

        List<Task> excuteTasks = new List<Task>();

        //当前任务序号锁
        object taskLock = new object();
        //当前任务完成状态锁
        object IsComplateLock = new object();
        bool IsComplete = false;

        /// <summary>
        /// 通知完成
        /// </summary>
        public event Notify Complete;


        /// <summary>
        /// html解析器
        /// </summary>
        HtmlDocument htmlDoc = null;

        #endregion

        #region 01 开启线程获取该分类下的分页列表数据


        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="domain"></param>
        /// <param name="logTaskHead"></param>
        /// <param name="pageFormat"></param>
        /// <param name="cateName"></param>
        /// <param name="totalPage"></param>
        /// <param name="isContinueCompensateChapter">
        /// 是否继续补全已经存在的小说的章节数据
        /// true:判断章节是否存在，存在则不插入子表
        /// false：直接插入子表，如不清空数据会造成重复，一般初次启动时设置为false；中途停止任务后重启任务设置为true
        /// </param>
        public Spider591_Cate(MainForm form, string domain, string logTaskHead, string pageFormat, string cateName, int totalPage, int pageNums, int fictionNums, int nums, int UpdateGrowNums)
        {
            main = form;
            Domain = domain;
            LogTaskHead = logTaskHead;
            _currentCateName = cateName;
            _pageFormat = pageFormat;
            _totalPage = totalPage;
            _PageNums = pageNums;
            _fictionNums = fictionNums;
            _Nums = nums;
            _UpdateGrowNums = UpdateGrowNums;



            htmlDoc = new HtmlDocument();
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        public void StopTask()
        {
            isStop = true;
            //TODO:通知下家停止,待优化方案
        }

        //开始线程
        public void GetFictionByPage()
        {
            #region Thread线程模式

            ////同时抓取的页数
            //int totalThreads = 5;
            //Thread t = null;
            //for (int i = 0; i < totalThreads; i++)
            //{
            //    t = new Thread(new ParameterizedThreadStart(PageThreadRun));
            //    t.IsBackground = true;
            //    t.Name = string.Format("页线程{0}", _currentPage);
            //    t.Start(_currentPage);
            //    excuteThreads.Add(t);

            //    //延时
            //    Thread.Sleep(20);

            //    //页码+1
            //    _currentPage++;
            //}

            ////人工设置优先级，强制执行完后在开启新线程，弊端是必须同时开启固定数量的线程
            //foreach (Thread item in excuteThreads)
            //{
            //    item.Join();
            //}
            ////必须前面的线程全部执行完毕后才会执行下面代码
            ////定时轮询 监控线程
            //WatchThreadByTimer();

            ////循环轮询 监控线程
            ////WatchThreadByWhile(); 
            #endregion

            #region Task 异步模式

            //同时抓取的页数
            int totalThreads = _PageNums;
            for (int i = 0; i < totalThreads; i++)
            {
                excuteTasks.Add(CreateNewTask(_currentPage));
                //页码+1
                _currentPage++;
            }

            Task task = new Task(() =>
            {
                while (true)
                {
                    if (!isStop)
                    {
                        Thread.Sleep(1000 * 5);
                        if (_currentPage < _totalPage)
                        {
                            for (int i = 0; i < excuteTasks.Count; i++)
                            {
                                if (excuteTasks[i].IsCompleted)
                                {
                                    excuteTasks[i] = CreateNewTask(_currentPage);
                                    //页码+1
                                    _currentPage++;
                                }
                            }
                        }
                        else
                        {
                            if (excuteTasks.Where(t => t.IsCompleted == true).Count() == excuteTasks.Count)
                            {
                                main.WriteNotifyLog(string.Format("{0}:分类【{1}】，获取完毕", LogTaskHead, _currentCateName, _currentPage), true);
                                //通知此分类已完成
                                Complete();
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            });
            task.Start();

            #endregion
        }

        private Task CreateNewTask(int currentPage)
        {
            //Task 多线程测试
            Task task = new Task(
                () =>
                {
                    //线程处理方法
                    PageThreadRun(currentPage);
                }
            );
            task.Start();
            //task.ContinueWith((t) =>
            //{
            //    if (currentPage <= _totalPage)
            //    {
            //        //当前任务执行完毕，再开新任务
            //        t = CreateNewTask(_currentPage);
            //        lock (taskLock)
            //        {
            //            //页码+1
            //            _currentPage++;
            //        }
            //    }
            //    else
            //    {
            //        if (!IsComplete)
            //        {
            //            lock (IsComplateLock)
            //            {
            //                IsComplete = true;
            //            }
            //            main.WriteNotifyLog(string.Format("{0}:分类【{1}】，第【{2}】页获取完毕", LogTaskHead, _currentCateName, _currentPage));
            //        }
            //    }
            //});
            return task;
        }

        //线程获取当前页的数据
        private void PageThreadRun(object obj)
        {
            List<KeyValuePair<VideoInfo, string>> watingGetCarsList = new List<KeyValuePair<VideoInfo, string>>();

            int pageIndex = (int)obj;
            try
            {
                string pageUrl = string.Format(_pageFormat, pageIndex);
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(pageUrl);

                //获取数据列表

                if (!string.IsNullOrEmpty(result))
                {
                    htmlDoc.LoadHtml(result);
                    HtmlNodeCollection items = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"videoCategory\"]/li");

                    if (items != null && items.Count > 0)
                    {
                        main.WriteSuccessLog(string.Format("{0}:分类【{1}】,获取第【{2}】页数据,共【{3}】条", LogTaskHead, _currentCateName, pageIndex, items.Count));

                        string title, detailUrl;
                        string times;

                        foreach (HtmlNode item in items)
                        {
                            detailUrl = Domain + item.SelectSingleNode("child::div[1]/div[1]/div[2]/a[1]").Attributes["href"].Value;
                            title = item.SelectSingleNode("child::div[1]/div[3]/span[1]/a[1]").InnerText;
                            times = item.SelectSingleNode("child::div[1]/div[1]/div[2]/div[1]/var[@class=\"duration\"]").InnerText;

                            //小说对象
                            VideoInfo vInfo = new VideoInfo();
                            vInfo.Title = title;


                            watingGetCarsList.Add(new KeyValuePair<VideoInfo, string>(vInfo, detailUrl));
                        }
                    }
                    else
                    {
                        main.WriteErrorLog(string.Format("{0}:分类【{1}】,未获取到第【{2}】页数据【{3}】", LogTaskHead, _currentCateName, pageIndex, pageUrl));
                    }
                }
                else
                {
                    main.WriteErrorLog(string.Format("{0}:未获取到分页Dom元素【{1}】", LogTaskHead, pageUrl));
                }
                if (watingGetCarsList.Count > 0)
                {
                    //获取视频
                    Spider591_Cate_Detail scf = new Spider591_Cate_Detail(main, Domain, LogTaskHead, watingGetCarsList, _currentCateName, _Nums, _fictionNums, pageIndex, _UpdateGrowNums);
                    scf.GetFictionByPage();
                }



            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:分类【{1}】,获取第【{2}】页数据出错，详情：【{3}】", LogTaskHead, _currentCateName, pageIndex, ex.Message));
            }
        }

        //获取分类
        private int GetCateId(string cateName)
        {
            int cateId = 0;
            switch (cateName)
            {
                case "武侠修真":
                    cateId = (int)SiteEnum.Cate.修真;
                    break;
                case "玄幻魔法":
                    cateId = (int)SiteEnum.Cate.玄幻;
                    break;
                case "都市言情":
                    cateId = (int)SiteEnum.Cate.都市;
                    break;
                case "网游动漫":
                    cateId = (int)SiteEnum.Cate.网游;
                    break;
                case "其他":
                    cateId = (int)SiteEnum.Cate.其他;
                    break;
                case "科幻小说":
                    cateId = (int)SiteEnum.Cate.科幻;
                    break;
                case "恐怖灵异":
                    cateId = (int)SiteEnum.Cate.恐怖;
                    break;
                default:
                    cateId = (int)SiteEnum.Cate.其他;
                    break;
            }
            return cateId;
        }

        //轮询监控线程
        private void WatchThreadByTimer()
        {
            if (excuteTasks.Count > 0)
            {
                System.Timers.Timer aTimer = new System.Timers.Timer();
                //到时间的时候执行事件  
                aTimer.Elapsed += new ElapsedEventHandler(Watch);
                aTimer.Interval = 1000 * 5;
                aTimer.AutoReset = true;//执行一次 false，一直执行true  
                aTimer.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件 
            }
        }
        //轮询监控线程
        private void Watch(object source, System.Timers.ElapsedEventArgs e)
        {
            #region Thread轮询【无效】
            //if (_totalPage < _currentPage)
            //{
            //    if (excuteThreads.Where(t => t.IsAlive == false).Count() == excuteThreads.Count)
            //    {
            //        //该分类任务执行完毕
            //        main.WriteErrorLog(string.Format("{0}:分类【{1}】,执行完毕。", LogTaskHead, _currentCateName));
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < excuteThreads.Count; i++)
            //    {
            //        if (!excuteThreads[i].IsAlive)
            //        {
            //            main.WriteNotifyLog(string.Format("{0}:分类【{1}】，页【{2}】,【{3}】终止。", LogTaskHead, _currentCateName, _currentPage, excuteThreads[i].Name));

            //            //结束旧线程
            //            excuteThreads[i].Abort();

            //            //开启新线程
            //            excuteThreads[i] = new Thread(new ParameterizedThreadStart(PageThreadRun));
            //            excuteThreads[i].IsBackground = true;
            //            excuteThreads[i].Name = string.Format("页线程{0}", _currentPage);
            //            excuteThreads[i].Start(_currentPage);

            //            //页码+1
            //            _currentPage++;
            //        }
            //    }

            //    //人工设置优先级，强制执行完后在开启新线程，弊端是必须同时开启固定数量的线程
            //    foreach (Thread item in excuteThreads)
            //    {
            //        item.Join();
            //    }
            //    WatchThreadByTimer();
            //} 
            #endregion

            #region Task轮询

            if (_currentPage < _totalPage)
            {
                for (int i = 0; i < excuteTasks.Count; i++)
                {
                    if (excuteTasks[i].IsCompleted)
                    {
                        excuteTasks[i] = CreateNewTask(_currentPage);
                        //页码+1
                        _currentPage++;
                    }
                }
            }
            else
            {
                if (!IsComplete)
                {
                    IsComplete = true;
                    main.WriteNotifyLog(string.Format("{0}:分类【{1}】，第【{2}】页获取完毕", LogTaskHead, _currentCateName, _currentPage));
                }
            }

            #endregion
        }

        //死循环监控
        private void WatchThreadByWhile()
        {
            while (true)
            {
                if (_totalPage < _currentPage)
                {
                    if (excuteThreads.Where(thread => thread.IsAlive == false).Count() == excuteThreads.Count)
                    {
                        //该分类任务执行完毕
                        main.WriteErrorLog(string.Format("{0}:分类【{1}】,执行完毕。", LogTaskHead, _currentCateName));
                        //终止循环
                        break;
                    }
                }
                else
                {
                    for (int i = 0; i < excuteThreads.Count; i++)
                    {
                        if (!excuteThreads[i].IsAlive)
                        {
                            //结束旧线程
                            main.WriteNotifyLog(string.Format("{0}:分类【{1}】,线程【{2}】执行完毕，终止。", LogTaskHead, _currentCateName, excuteThreads[i].Name));
                            excuteThreads[i].Abort();

                            //开启新线程
                            excuteThreads[i] = new Thread(new ParameterizedThreadStart(PageThreadRun));
                            excuteThreads[i].IsBackground = true;
                            excuteThreads[i].Name = string.Format("页线程{0}", _currentPage);
                            excuteThreads[i].Start(_currentPage);

                            //页码+1
                            _currentPage++;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
