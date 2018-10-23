using Site.Untity;
using Site.Cars.DataAccess.Model;
using Site.Cars.DataAccess.Service;
using Spider.Main.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using HtmlAgilityPack;

namespace Spider.Main.Core
{
    public class SpiderCars_Cate_Detail
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
        List<KeyValuePair<Mongo_CarsInfo, string>> _watingGetFictionList = new List<KeyValuePair<Mongo_CarsInfo, string>>();

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
        /// </param>
        public SpiderCars_Cate_Detail(MainForm form, string domain, string logTaskHead, List<KeyValuePair<Mongo_CarsInfo, string>> watingInsertList, string cateName, int nums, int fictionNums, int currentPage, int UpdateGrowNums)
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

            htmlDoc = new HtmlDocument();
        }

        //开始线程
        public void GetFictionByPage()
        {
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

            return task;
        }


        //线程获取当前页的数据
        private void FictionThreadRun(object obj)
        {
            int fictionIndex = (int)obj;
            try
            {
                if (fictionIndex < _watingGetFictionList.Count)
                {
                    Mongo_CarsInfo fInfo = _watingGetFictionList[fictionIndex].Key;
                    try
                    {
                        string fictionUrl = _watingGetFictionList[fictionIndex].Value;
                        //获取封面和插入信息
                        string fId = GetCoverImage(fInfo, fictionUrl);
                    }
                    catch (Exception ex)
                    {
                        main.WriteErrorLog(string.Format("{0}:分类【{1}】,获取第【{2}】页数据，车辆【{3}】出错，详情：【{3}】", LogTaskHead, _currentCateName, _currentPage, fInfo.FullName, ex.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:分类【{1}】,获取车辆出错，可能是索引超出。当前索引【{2}】，总长度：【{3}】:详情：【{4}】", LogTaskHead, _currentCateName, fictionIndex, _watingGetFictionList.Count, ex.Message));
            }
        }

        /// <summary>
        /// 获取封面和章节列表
        /// </summary>
        /// <param name="fInfo"></param>
        /// <param name="fictionUrl"></param>
        /// <returns></returns>
        private string GetCoverImage(Mongo_CarsInfo fInfo, string fictionUrl)
        {
            string identityId = string.Empty;

            try
            {
                //判断是否存在
                bool isExist = false;
                Mongo_CarsInfo isExistInfo = Mongo_CarsInfoService.Select(u => u.FullName == fInfo.FullName).FirstOrDefault();
                if (isExistInfo != null)
                {
                    isExist = true;
                    fInfo = isExistInfo;
                }

                main.WriteSuccessLog(string.Format("{0}:分类【{1}】,车辆【{2}】获取封面地址：【{3}】", LogTaskHead, _currentCateName, fInfo.FullName, fictionUrl));
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(fictionUrl);
                //获取小说主页
                if (!string.IsNullOrEmpty(result))
                {
                    htmlDoc.LoadHtml(result);
                    HtmlNode item = htmlDoc.DocumentNode.SelectSingleNode("/html/body/main/article/section[2]/div/div/div[1]/img");

                    if (item != null)
                    {
                        string imageSrc;
                        //提取图片路径,此处特殊处理，https
                        imageSrc = Domain.Replace("http", "https") + item.Attributes["src"].Value;

                        main.WriteSuccessLog(string.Format("{0}:分类【{1}】,车辆【{2}】获取封面,封面地址：【{3}】", LogTaskHead, _currentCateName, fInfo.FullName, imageSrc));
                        if (!isExist)
                        {
                            #region 下载网络图片到本地，生成本地路径
                            string error;
                            string coverImageSrc = web.CaptureRemoteImage(imageSrc, out error,"CarsUpload");
                            if (string.IsNullOrEmpty(coverImageSrc))
                            {
                                main.WriteErrorLog(string.Format("{0}:分类【{1}】,车辆【{2}】获取封面出错：【{3}】", LogTaskHead, _currentCateName, fInfo.FullName, error));
                            }
                            else
                            {
                                fInfo.CarsCoverSrc = coverImageSrc;
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        main.WriteErrorLog(string.Format("{0}:分类【{1}】,车辆【{2}】,未匹配到封面元素。", LogTaskHead, _currentCateName, fInfo.FullName));
                    }

                    if (isExist)
                    {
                        identityId = fInfo.Id.ToString();
                    }
                    else
                    {
                        //插入小说
                        identityId = Mongo_CarsInfoService.Insert(fInfo);
                    }
                }
                else
                {
                    main.WriteErrorLog(string.Format("{0}:未获取到获取小说主页Dom元素", LogTaskHead));
                }

            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:分类【{1}】,车辆【{2}】获取封面出错：【{3}】", LogTaskHead, _currentCateName, fInfo.FullName, ex.Message));
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
