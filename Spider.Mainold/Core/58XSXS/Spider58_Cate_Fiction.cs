using Site.Untity;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;
using Spider.Main.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Spider.Main.Core
{
    public class Spider58_Cate_Fiction
    {

        #region 字段

        //当前线程 抓取的小说序号
        int _currentFictionIndex = 0;
        int _totalPage = 0;
        string _currentCateName;
        string _pageFormat;
        //当前页
        int _currentPage;

        //待获取小说数据
        List<KeyValuePair<Fiction, string>> _watingGetFictionList = new List<KeyValuePair<Fiction, string>>();

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
        //object taskLock = new object();
        //当前任务完成状态锁
        //object IsComplateLock = new object();
        bool IsComplete = false;

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
        /// </param>
        public Spider58_Cate_Fiction(MainForm form, string domain, string logTaskHead, List<KeyValuePair<Fiction, string>> watingInsertList, string cateName, int nums, int fictionNums, int currentPage, int UpdateGrowNums)
        {
            main = form;
            Domain = domain;
            LogTaskHead = logTaskHead;
            _currentCateName = cateName;
            _watingGetFictionList = watingInsertList;
            _Nums = nums;
            _fictionNums = fictionNums;
            _currentPage = currentPage;
            _UpdateGrowNums = UpdateGrowNums;
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

            //同时抓取的小说数
            int totalThreads = _fictionNums;
            for (int i = 0; i < totalThreads; i++)
            {
                excuteTasks.Add(CreateNewTask(i));
                //小说序号+1
                _currentFictionIndex++;
            }
            while (true)
            {
                Thread.Sleep(1000 * 5);
                if (_currentFictionIndex < _watingGetFictionList.Count)
                {
                    for (int i = 0; i < excuteTasks.Count; i++)
                    {
                        if (excuteTasks[i].IsCompleted)
                        {
                            excuteTasks[i] = CreateNewTask(_currentFictionIndex);
                            //页码+1
                            _currentFictionIndex++;
                        }
                    }
                }
                else
                {
                    if (!IsComplete)
                    {
                        IsComplete = true;
                        main.WriteNotifyLog(string.Format("{0}:分类【{1}】，第【{2}】页小说列表获取完毕", LogTaskHead, _currentCateName, _currentPage), true);
                    }
                    break;
                }
            }

            #endregion

        }

        private Task CreateNewTask(int currentIndex)
        {
            //Task 多线程测试
            Task task = new Task(
                () =>
                {
                    //线程处理方法
                    FictionThreadRun(currentIndex);
                }
            );
            task.Start();
            //task.ContinueWith((t) =>
            //{
            //    if (currentIndex < _watingGetFictionList.Count)
            //    {
            //        //当前任务执行完毕，再开新任务
            //       t= CreateNewTask(_currentFictionIndex);
            //        lock (taskLock)
            //        {
            //            //小说序号+1
            //            _currentFictionIndex++;
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
            //            main.WriteNotifyLog(string.Format("{0}:分类【{1}】，第【{2}】页小说列表获取完毕", LogTaskHead, _currentCateName, _currentPage));
            //        }
            //    }
            //});
            return task;
        }


        //线程获取当前页的数据
        private void FictionThreadRun(object obj)
        {
            int fictionIndex = (int)obj;
            try
            {
                Fiction fInfo = _watingGetFictionList[fictionIndex].Key;
                try
                {
                    string fictionUrl = _watingGetFictionList[fictionIndex].Value;
                    //获取封面和章节列表
                    int fId = GetCoverImage(fInfo, fictionUrl);
                }
                catch (Exception ex)
                {
                    main.WriteErrorLog(string.Format("{0}:分类【{1}】,获取第【{2}】页数据，小说【{3}】出错，详情：【{3}】", LogTaskHead, _currentCateName, _currentPage, fInfo.Title, ex.Message));
                }
            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:分类【{1}】,获取小说出错，可能是索引超出。当前索引【{2}】，总长度：【{3}】:详情：【{4}】", LogTaskHead, _currentCateName, fictionIndex, _watingGetFictionList.Count, ex.Message));
            }
        }

        /// <summary>
        /// 获取封面和章节列表
        /// </summary>
        /// <param name="fInfo"></param>
        /// <param name="fictionUrl"></param>
        /// <returns></returns>
        private int GetCoverImage(Fiction fInfo, string fictionUrl)
        {
            int identityId = -1;

            try
            {
                //判断是否存在该小说
                bool isExist = false;
                Fiction isExistInfo = FictionService.Select(string.Format("where Title=N'{0}' and Author=N'{1}'", fInfo.Title, fInfo.Author)).FirstOrDefault();
                if (isExistInfo != null)
                {
                    isExist = true;
                    fInfo = isExistInfo;
                }

                main.WriteSuccessLog(string.Format("{0}:分类【{1}】,小说【{2}】获取封面,主页地址：【{3}】", LogTaskHead, _currentCateName, fInfo.Title, fictionUrl));
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(fictionUrl);
                //获取小说主页
                if (!string.IsNullOrEmpty(result))
                {
                    Regex reg = new Regex(@"<div [^>/]*?id=[""]*info_content[""]*[^>/]*>([\s\S]*?)<\/div>");
                    string contentDiv = reg.Match(result).Value;

                    //匹配image标签
                    Match match = Regex.Match(contentDiv, @"<img[\s]+src[\s]*=[\s]*((['""](?<src>[^'""]*)[\'""])|(?<src>[^\s]*))");
                    if (match.Success)
                    {
                        string imageSrc;
                        //提取图片路径
                        imageSrc = match.Groups["src"].Value;

                        main.WriteSuccessLog(string.Format("{0}:分类【{1}】,小说【{2}】获取封面,封面地址：【{3}】", LogTaskHead, _currentCateName, fInfo.Title, imageSrc));
                        if (!isExist)
                        {
                            #region 下载网络图片到本地，生成本地路径
                            string error;
                            string coverImageSrc = web.CaptureRemoteImage(imageSrc, out error);
                            if (string.IsNullOrEmpty(coverImageSrc))
                            {
                                main.WriteErrorLog(string.Format("{0}:分类【{1}】,小说【{2}】获取封面出错：【{3}】", LogTaskHead, _currentCateName, fInfo.Title, error));
                            }
                            else
                            {
                                fInfo.CoverImage = coverImageSrc;
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        main.WriteErrorLog(string.Format("{0}:分类【{1}】,小说【{2}】,未匹配到封面元素。", LogTaskHead, _currentCateName, fInfo.Title));
                    }

                    //匹配内容简介
                    if (string.IsNullOrEmpty(fInfo.Intro))
                    {
                        match = Regex.Match(contentDiv, @"<br (/)?>(&nbsp;)*[“]*[\s\S]+联系站长!!!<br (/)?>");
                        if (match.Success)
                        {
                            //提取图片路径
                            string introContent = Common.FormatContent(match.Value);
                            fInfo.Intro = introContent;
                        }
                        else
                        {
                            main.WriteErrorLog(string.Format("{0}:分类【{1}】,小说【{2}】,未匹配到内容简介。", LogTaskHead, _currentCateName, fInfo.Title));
                        }
                    }

                    if (isExist)
                    {
                        identityId = fInfo.Id;
                    }
                    else
                    {
                        //插入小说
                        identityId = FictionService.Insert(fInfo);
                    }

                    //开始获取章节列表
                    if (identityId > 0)
                    {
                        string listUrl;
                        Match Listmatch = Regex.Match(result, @"<div [^>/]*?class=[""]*info_c[""]*[^>/]*>([\s\S]*?)<\/div>");
                        if (Listmatch.Success)
                        {
                            //获取li标签
                            MatchCollection mList = Regex.Matches(Listmatch.Value, @"<li>(.*?)<\/li>");
                            //只取第一个 li
                            Match aMatch = Regex.Match(mList[0].Value, @"<a href=[""]?(?<url>(.*))[""]?\s(.*?)[^>/]*>(?<title>(.*?))<\/a>");
                            if (aMatch.Success)
                            {
                                listUrl = Domain + aMatch.Groups["url"].Value;

                                //获取小说章节列表和详细内容
                                Spider58_Cate_Fiction_Chapter scc = new Spider58_Cate_Fiction_Chapter(main, Domain, LogTaskHead, _currentCateName, identityId, fInfo, _Nums, _currentPage, _UpdateGrowNums);
                                scc.GetFictionCharterList(listUrl);

                            }
                            else
                            {
                                main.WriteErrorLog(string.Format("{0}:分类【{1}】,小说【{2}】,未匹配到列表页面地址", LogTaskHead, _currentCateName, fInfo.Title));
                            }

                        }
                        else
                        {
                            main.WriteErrorLog(string.Format("{0}:分类【{1}】,小说【{2}】,未匹配到页面列表元素。", LogTaskHead, _currentCateName, fInfo.Title));
                        }
                    }
                }
                else
                {
                    main.WriteErrorLog(string.Format("{0}:未获取到获取小说主页Dom元素", LogTaskHead));
                }

            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:分类【{1}】,小说【{2}】获取封面出错：【{3}】", LogTaskHead, _currentCateName, fInfo.Title, ex.Message));
            }
            return identityId;
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
            //if (_totalPage < _currentFictionIndex)
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
            //            main.WriteNotifyLog(string.Format("{0}:分类【{1}】，页【{2}】,【{3}】终止。", LogTaskHead, _currentCateName, _currentFictionIndex, excuteThreads[i].Name));

            //            //结束旧线程
            //            excuteThreads[i].Abort();

            //            //开启新线程
            //            excuteThreads[i] = new Thread(new ParameterizedThreadStart(FictionThreadRun));
            //            excuteThreads[i].IsBackground = true;
            //            excuteThreads[i].Name = string.Format("页线程{0}", _currentFictionIndex);
            //            excuteThreads[i].Start(_currentFictionIndex);

            //            //页码+1
            //            _currentFictionIndex++;
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

            if (_currentFictionIndex < _watingGetFictionList.Count)
            {
                for (int i = 0; i < excuteTasks.Count; i++)
                {
                    if (excuteTasks[i].IsCompleted)
                    {
                        excuteTasks[i] = CreateNewTask(_currentFictionIndex);
                        //页码+1
                        _currentFictionIndex++;
                    }
                }
            }
            else
            {
                if (!IsComplete)
                {
                    IsComplete = true;
                    main.WriteNotifyLog(string.Format("{0}:分类【{1}】，第【{2}】页小说列表获取完毕", LogTaskHead, _currentCateName, _currentPage));
                }
            }

            #endregion
        }


        //死循环监控
        private void WatchThreadByWhile()
        {
            while (true)
            {
                if (_totalPage < _currentFictionIndex)
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
                            excuteThreads[i] = new Thread(new ParameterizedThreadStart(FictionThreadRun));
                            excuteThreads[i].IsBackground = true;
                            excuteThreads[i].Name = string.Format("页线程{0}", _currentFictionIndex);
                            excuteThreads[i].Start(_currentFictionIndex);

                            //页码+1
                            _currentFictionIndex++;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
