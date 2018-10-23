using Site.Untity;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;
using Spider.Service.Interface;
using Spider.Service.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using MongoDB.Driver;

namespace Spider.Service
{
    /// <summary>
    /// 获取小说章节列表
    /// </summary>
    public class Spider58_Cate_Fiction_Chapter
    {
        #region 字段
        //执行线程
        List<Thread> excuteThreads = new List<Thread>();

        List<Task> excuteTasks = new List<Task>();

        //待插入数据
        List<Mongo_ChapterList> watingInsertList = new List<Mongo_ChapterList>();

        //待插入锁
        object insertLock = new object();

        //当前任务序号锁
        //object taskLock = new object();
        //当前任务完成状态锁
        //object IsComplateLock = new object();
        bool IsComplete = false;

        /// <summary>
        /// 等待获取内容的章节列表 key:章节名称，value:章节内文Url
        /// </summary>
        List<KeyValuePair<string, string>> waitGetContentList = new List<KeyValuePair<string, string>>();

        string _currentCateName;
        int _currentCateId;

        /// <summary>
        /// 主窗体引用
        /// </summary>
        private IWriteContent main;

        /// <summary>
        /// 网站域名
        /// </summary>
        private string Domain;

        /// <summary>
        /// 小说名称
        /// </summary>
        private string _title;

        /// <summary>
        /// 任务名称头
        /// </summary>
        string LogTaskHead = "【58小说网】爬虫任务";

        /// <summary>
        /// 当前章节元素序号
        /// </summary>
        int _currentIndex = 0;

        /// <summary>
        /// 小说ID
        /// </summary>
        int _fid = -1;

        /// <summary>
        /// 线程轮询监控
        /// </summary>
        System.Timers.Timer aTimer = null;

        /// <summary>
        /// 当前小说对象
        /// </summary>
        Fiction _fInfo;

        /// <summary>
        /// 并发章节数
        /// </summary>
        int _nums;

        /// <summary>
        /// 更新增量，小说标识是已完成抓取状态的，做更新操作，只抓取最后指定数量的章节
        /// </summary>
        public int _UpdateGrowNums { get; set; }

        /// <summary>
        /// 当前获取的小说页码
        /// </summary>
        int _currentPage;

        #endregion

        public Spider58_Cate_Fiction_Chapter(IWriteContent form, string domain, string logTaskHead, string cateName, int fid, Fiction fInfo, int nums, int currentPage, int UpdateGrowNums)
        {
            main = form;
            Domain = domain;
            LogTaskHead = logTaskHead;
            _currentCateName = cateName;
            _currentCateId = fInfo.C_C_ID;
            _title = fInfo.Title;
            _fid = fid;
            _fInfo = fInfo;
            _nums = nums;
            _currentPage = currentPage;
            _UpdateGrowNums = UpdateGrowNums;
        }

        /// <summary>
        /// 多线程 获取小说章节 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fid"></param>
        /// <param name="fictionListUrl"></param>
        public void GetFictionCharterList(string fictionListUrl)
        {
            main.WriteSuccessContet("章节列表页：" + fictionListUrl);
            try
            {
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(fictionListUrl);

                //获取小说章节列表
                if (!string.IsNullOrEmpty(result))
                {
                    Regex reg = new Regex(@"<table [^>/]*?class=[""]*t[""]*[^>/]*>([\s\S]*?)<\/table>");
                    string pagesDiv = reg.Match(result).Value;

                    //匹配tr
                    MatchCollection mList = Regex.Matches(pagesDiv, @"<tr>[\s\S]*?<\/tr>");
                    if (mList.Count > 0)
                    {
                        main.WriteSuccessContet(string.Format("{0}:分类【{1}】,获取【{2}】小说，章节列表数据", LogTaskHead, _currentCateName, _title));
                        //跳过第一条
                        MatchCollection tdMatchList;
                        Match m;
                        string chapterUrl, chapterTitle;
                        //第一行，全部为插入的广告，跳过链接
                        for (int i = 2; i < mList.Count; i++)
                        {
                            //提取章节名称 格式 第1章 传承
                            tdMatchList = Regex.Matches(mList[i].Value, @"<td>[\s\S]*?<\/td>");
                            //做首章节判断
                            for (int j = 0; j < tdMatchList.Count; j++)
                            {
                                m = Regex.Match(tdMatchList[j].Value, @"<a href=[""]?(?<url>(.*?))[""]?>(?<title>(.*?))<\/a>");
                                chapterUrl = fictionListUrl.Replace("index.html", m.Groups["url"].Value);
                                chapterTitle = m.Groups["title"].Value;
                                if (!string.IsNullOrEmpty(chapterTitle))
                                {
                                    //待获取章节列表
                                    waitGetContentList.Add(new KeyValuePair<string, string>(chapterTitle, chapterUrl));
                                }

                            }
                        }
                    }
                    else
                    {
                        main.WriteSuccessContet(string.Format("{0}:分类【{1}】,小说【{2}】，未获取到章节列表", LogTaskHead, _currentCateName, _title));
                    }
                }
                else
                {
                    main.WriteErrorContet(string.Format("{0}:分类【{1}】,未获取到小说【{2}】章节列表Dom元素", LogTaskHead, _currentCateName, _title));
                }
                //判断是否是已完成抓取状态，如果是，只取最后的增量章节
                if (_fInfo.CompleteState == (int)SiteEnum.CompleteState.完成)
                {
                    if (waitGetContentList.Count > _UpdateGrowNums)
                    {
                        waitGetContentList = waitGetContentList.Skip(waitGetContentList.Count - _UpdateGrowNums).ToList();
                    }
                }

                //开始抓取章节
                ThreadStart();
            }
            catch (Exception ex)
            {
                main.WriteErrorContet(string.Format("{0}:分类【{1}】,获取小说【{2}】章节列表错误【{3}】", LogTaskHead, _currentCateName, _title, ex.Message));
            }

        }

        //开始线程
        public void ThreadStart()
        {
            #region Task 异步模式

            //同时抓取的章节数
            int totalThreads = _nums;
            for (int i = 0; i < totalThreads; i++)
            {
                excuteTasks.Add(CreateNewTask(i));
                //章节序号+1
                _currentIndex++;//为了索引和序号一致
            }

            while (true)
            {
                Thread.Sleep(1000 * 5);
                if (_currentIndex < waitGetContentList.Count)
                {
                    for (int i = 0; i < excuteTasks.Count; i++)
                    {
                        if (excuteTasks[i].IsCompleted)
                        {
                            if (_currentIndex < waitGetContentList.Count)
                            {
                                excuteTasks[i] = CreateNewTask(_currentIndex);
                                //页码+1
                                _currentIndex++;
                            }
                        }
                    }
                }
                else
                {
                    try
                    {

                        if (excuteTasks.Where(t => t.IsCompleted == true).Count() == excuteTasks.Count)
                        {
                            if (watingInsertList.Count > 0)
                            {
                                try
                                {
                                    Mongo_ChapterListService.BatchInsert(watingInsertList, _currentCateId);
                                    watingInsertList.Clear();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }

                        main.WriteNotifyContet(string.Format("{0}:分类【{1}】,小说【{2}】，章节获取完毕", LogTaskHead, _currentCateName, _title));
                        //更新当前小说的状态
                        Mongo_ChapterList lastcInfo = Mongo_ChapterListService.Select(u => u.F_ID == _fInfo.Id, Builders<Mongo_ChapterList>.Sort.Descending("ChapterSort").Descending("UpdateTime"), _currentCateId).FirstOrDefault();

                        _fInfo.CompleteState = (int)SiteEnum.CompleteState.完成;
                        _fInfo.LastUpdateTime = DateTime.Now;
                        _fInfo.LastUpdateChapter = lastcInfo.ChapterName;
                        _fInfo.LastChapterId = lastcInfo.Id.ToString();

                        FictionService.Update(_fInfo);

                    }
                    catch (Exception ex)
                    {
                        main.WriteErrorContet(string.Format("{0}:分类【{1}】,小说【{2}】，章节获取完毕,插入尾章节时错误:{3}", LogTaskHead, _currentCateName, _title, ex.Message));
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
                    ContentThreadRun(currentIndex);
                }
            );
            task.Start();

            return task;
        }

        //线程获取当前章节的内文数据
        private void ContentThreadRun(object obj)
        {
            int _index = (int)obj;

            try
            {
                if (waitGetContentList.Count <= 0)
                {
                    return;
                }

                KeyValuePair<string, string> item = waitGetContentList[_index];
                string chapterTitle = item.Key;
                string chapterUrl = item.Value;
                //获取章节内容
                main.WriteSuccessContet(string.Format("{0}:分类【{1}】,第【{4}】页，小说【{2}】，开始获取章节【{3}】数据", LogTaskHead, _currentCateName, _title, chapterTitle, _currentPage));

                Mongo_ChapterList clInfo = new Mongo_ChapterList();
                clInfo.F_ID = _fid;
                clInfo.UpdateTime = DateTime.Now;
                string[] str = chapterTitle.Split(new string[] { "章" }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length == 2)
                {
                    clInfo.ChapterIndex = string.Format("{0}章", str[0]);
                }
                else
                {
                    clInfo.ChapterIndex = "";
                }
                clInfo.ChapterName = Regex.Replace(chapterTitle, "[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", "");
                clInfo.ChapterSort = UntityTool.GetIndexSort(clInfo.ChapterIndex.Replace(" ", ""));

                //判断是否存在该章节
                Mongo_ChapterList isExistInfo = Mongo_ChapterListService.Select(u => u.ChapterName == clInfo.ChapterName && u.F_ID == clInfo.F_ID, _currentCateId).FirstOrDefault();
                if (isExistInfo == null)
                {
                    //获取内容
                    GetChapter(clInfo, chapterUrl, _title);
                }
                else
                {
                    main.WriteNotifyContet(string.Format("{0}:分类【{1}】,小说【{2}】，章节【{3}】已存在", LogTaskHead, _currentCateName, _title, chapterTitle));
                }

            }
            catch (Exception ex)
            {
                main.WriteErrorContet(string.Format("{0}:分类【{1}】,小说【{4}】，总长度【{5}】，获取章节列表序号【{2}】元素出错，详情：【{3}】", LogTaskHead, _currentCateName, _index, ex.Message + ex.InnerException == null ? "" : ex.Message + ex.InnerException.Message, _title, waitGetContentList.Count));
            }

        }

        //获取章节内容
        private void GetChapter(Mongo_ChapterList info, string chapterUrl, string title)
        {
            try
            {
                //去除url特殊字符
                chapterUrl = Regex.Replace(chapterUrl.Trim(new char[] { ' ' }), "[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？•`·、。，；;\"‘’'“”-]", "");
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(chapterUrl);

                //获取小说章节内文
                if (!string.IsNullOrEmpty(result))
                {
                    Regex reg = new Regex(@"<div [^>/]*?Id=[""]*content[""]*[^>/]*>([\s\S]*)<\/div>");
                    string contentDiv = reg.Match(result).Value;

                    //匹配br
                    Match contentMatch = Regex.Match(contentDiv, @"<(/)?br>(&nbsp;)+[“]*[\s\S]+<(/)?br>");
                    info.ChapterContent = "内容正在处理中，请稍后再来......";
                    if (contentMatch.Success)
                    {
                        main.WriteSuccessContet(string.Format("{0}:分类【{1}】,获取【{2}】小说，章节【{3}】内文数据成功！", LogTaskHead, _currentCateName, title, string.Format("{0}-{1}", info.ChapterIndex, info.ChapterName)));
                        info.ChapterContent = Common.FormatContent(contentMatch.Value);

                        //批量插入数据库
                        watingInsertList.Add(info);
                        if (watingInsertList.Count % 50 == 0)
                        {
                            main.WriteNotifyContet(string.Format("{0}:分类【{1}】,【{2}】小说，批量插入【{3}】条章节数据", LogTaskHead, _currentCateName, title, watingInsertList.Count));
                            try
                            {
                                Mongo_ChapterListService.BatchInsert(watingInsertList, _currentCateId);
                                watingInsertList.Clear();
                            }
                            catch (Exception ex)
                            {
                                main.WriteErrorContet(string.Format("{0}:分类【{1}】,【{2}】小说，批量插入章节失败。", LogTaskHead, _currentCateName, title, watingInsertList.Count));
                            }
                        }
                    }
                    else
                    {
                        main.WriteErrorContet(string.Format("{0}:分类【{1}】,小说【{2}】，【{3}】未获取到内文数据", LogTaskHead, _currentCateName, title, string.Format("{0} {1}", info.ChapterIndex, info.ChapterName)));
                    }
                }
                else
                {
                    main.WriteErrorContet(string.Format("{0}:分类【{1}】,未获取到小说【{2}】章节【{3}】内文Dom元素", LogTaskHead, _currentCateName, title, string.Format("{0} {1}", info.ChapterIndex, info.ChapterName)));
                }


            }
            catch (Exception ex)
            {
                main.WriteErrorContet(string.Format("{0}:分类【{1}】,获取小说【{2}】章节【{5}】内文数据错误。【{4}】{3}", LogTaskHead, _currentCateName, title, ex.Message, chapterUrl, string.Format("{0} {1}", info.ChapterIndex, info.ChapterName)));

                #region 记录获取出错的章节
                ErrorChapter error = new ErrorChapter();
                error.ChapterName = info.ChapterName;
                error.ChapterUrl = chapterUrl;
                error.ExceptionMessage = ex.Message;
                error.F_Id = info.F_ID;
                error.Title = title;
                error.C_C_Id = _currentCateId;
                error.DisposeStatus = (int)SiteEnum.DisposeStatus.未处理;
                error.RetryCount = 0;

                ErrorChapterService.Insert(error);
                #endregion
            }
        }


        #region 无效
        /**
        //轮询监控线程
        private void WatchThreadByTimer()
        {
            if (excuteTasks.Count > 0)
            {
                aTimer = new System.Timers.Timer();
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
            //if (waitGetContentList.Count < _currentIndex)
            //{
            //    if (excuteThreads.Where(t => t.IsAlive == false).Count() == excuteThreads.Count)
            //    {
            //        //该分类任务执行完毕
            //        main.WriteErrorContet(string.Format("{0}:分类【{1}】小说【{2}】章节全部获取完毕。", LogTaskHead, _currentCateName, _title));
            //        lock (insertLock)
            //        {
            //            //最后批量插入尾数
            //            if (watingInsertList.Count > 0)
            //            {
            //                int successCount = ChapterListService.SqlBulkCopyBatchInsert(watingInsertList, _currentCateId, watingInsertList.Count);
            //                if (successCount > 0)
            //                {
            //                    watingInsertList.Clear();
            //                }
            //            }
            //        }
            //        //停止该计时器
            //        aTimer.Close();
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < excuteThreads.Count; i++)
            //    {
            //        if (!excuteThreads[i].IsAlive)
            //        {
            //            //结束旧线程
            //            //该小说章节全部获取完毕
            //            main.WriteNotifyContet(string.Format("{0}:分类【{1}】小说【{2}】,【{3}】终止。", LogTaskHead, _currentCateName, _title, excuteThreads[i].Name));
            //            excuteThreads[i].Abort();

            //            //开启新线程
            //            excuteThreads[i] = new Thread(new ParameterizedThreadStart(ContentThreadRun));
            //            excuteThreads[i].IsBackground = true;
            //            excuteThreads[i].Name = string.Format("章节线程{0}", _currentIndex);
            //            excuteThreads[i].Start(_currentIndex);

            //            //章节序号+1
            //            _currentIndex++;
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

            #region Task轮询【无效，线程会一直增长】

            if (_currentIndex < waitGetContentList.Count)
            {
                for (int i = 0; i < excuteTasks.Count; i++)
                {
                    if (excuteTasks[i].IsCompleted)
                    {
                        excuteTasks[i] = CreateNewTask(_currentIndex);
                        //页码+1
                        _currentIndex++;
                    }
                }
            }
            else
            {
                if (!IsComplete)
                {
                    IsComplete = true;
                    main.WriteNotifyContet(string.Format("{0}:分类【{1}】,小说【{2}】，章节获取完毕", LogTaskHead, _currentCateName, _title));
                    //更新当前小说的状态
                    _fInfo.CompleteState = (int)SiteEnum.CompleteState.完成;
                    FictionService.Update(_fInfo);
                }
                //关闭该计时器
                aTimer.Close();
            }

            #endregion
        }

        //死循环监控
        private void WatchThreadByWhile()
        {
            while (true)
            {
                if (waitGetContentList.Count < _currentIndex)
                {
                    if (excuteThreads.Where(thread => thread.IsAlive == false).Count() == excuteThreads.Count)
                    {
                        //该小说章节全部获取完毕
                        main.WriteErrorContet(string.Format("{0}:分类【{1}】小说【{2}】章节全部获取完毕。", LogTaskHead, _currentCateName, _title));

                        lock (insertLock)
                        {
                            //最后批量插入尾数
                            if (watingInsertList.Count > 0)
                            {
                                int successCount = ChapterListService.SqlBulkCopyBatchInsert(watingInsertList, _currentCateId, watingInsertList.Count);
                                if (successCount > 0)
                                {
                                    watingInsertList.Clear();
                                }
                            }
                        }
                        //最后获取完毕后，更新最新章节
                        FictionService.GetLastUpdateChapter(_fid, _currentCateId);


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
                            //该小说章节全部获取完毕
                            main.WriteNotifyContet(string.Format("{0}:分类【{1}】小说【{2}】,【{3}】终止。", LogTaskHead, _currentCateName, _title, excuteThreads[i].Name));
                            excuteThreads[i].Abort();

                            //开启新线程
                            excuteThreads[i] = new Thread(new ParameterizedThreadStart(ContentThreadRun));
                            excuteThreads[i].IsBackground = true;
                            excuteThreads[i].Name = string.Format("章节线程{0}", _currentIndex);
                            excuteThreads[i].Start(_currentIndex);

                            //章节序号+1
                            _currentIndex++;
                        }
                    }
                }
            }
        }
    **/
        #endregion

    }
}
