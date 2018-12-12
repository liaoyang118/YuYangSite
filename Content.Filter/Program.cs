using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Site.Untity;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;
using Site.XiaoShuo.DataAccess.Service.PartialService.Search;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using Site.Videos.DataAccess.Service.PartialService.Search;

namespace Content.Filter
{
    delegate void StopTask();

    interface ITest
    {
        void Log();
    }

    class TestALog : ITest
    {
        public void Log()
        {
            Console.WriteLine("Alog");
        }
    }

    class TestBLog : ITest
    {
        public void Log()
        {
            Console.WriteLine("Blog");
        }
    }

    class Program
    {

        static List<Task> list = new List<Task>();
        static int curInt = 0;
        static int total = 1000000;
        static bool IsComplete = false;
        static object objLock = new object();
        static object obj2Lock = new object();

        /// <summary>
        /// 停止任务事件
        /// </summary>
        static event StopTask StopTaskEvent;

        static void Main(string[] args)
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    CreateNewTask(i);
            //    curInt++;
            //}
            //ITest ta = new TestALog();
            //StopTaskEvent += new StopTask(ta.Log);
            //ITest tb = new TestBLog();
            //StopTaskEvent += new StopTask(tb.Log);

            //Delegate[] delegateList = StopTaskEvent.GetInvocationList();

            //foreach (Delegate item in delegateList)
            //{
            //    Console.WriteLine(item.Method.DeclaringType.ToString());
            //    Console.WriteLine(item.Target.GetType().ToString());
            //}

            //Console.WriteLine("......");

            #region 转移数据

            //Console.WriteLine("任务开始");
            //Console.WriteLine("请输入需要处理的分类ID：");
            //string c_id = Console.ReadLine();

            //int rowCount = 0, pageIndex = 1, totalPage = 1, _pageCount = 1000;
            //FictionSearchInfo search = new FictionSearchInfo();
            //search.C_C_ID = int.Parse(c_id);

            //GetListByPageIndex(pageIndex, search, out rowCount);
            //totalPage = (int)Math.Ceiling(rowCount * 1.00 / _pageCount * 1.00);
            //if (totalPage > 1)
            //{
            //    for (pageIndex = 2; pageIndex <= totalPage; pageIndex++)
            //    {
            //        GetListByPageIndex(pageIndex, search, out rowCount);
            //        Thread.Sleep(1000 * 2);
            //    }
            //}

            //var oo = new Mongo_ChapterList() { ChapterContent = "sdf", ChapterIndex = "fds", ChapterName = "test" };
            //Mongo_ChapterListService.Insert(oo, 1);
            //Console.WriteLine(oo.Id.ToString());

            //Console.WriteLine("任务结束");


            #endregion

            #region WCF测试

            //try
            //{
            //    HttpClientHelp web = new HttpClientHelp();
            //    string error;

            //    string imageSrc = "http://localhost:8900/mp4/test4.mp4";
            //    //string coverImageSrc = web.CaptureRemoteVedio(imageSrc, out error);

            //    List<string> videoServerSrc = web.CaptureRemoteVedio(imageSrc, out error, "VideoUpload", percent =>
            //    {
            //        Console.WriteLine(string.Format("进度【{0}】", percent));
            //    });

            //    Console.WriteLine(error);

            //    Console.WriteLine(videoServerSrc[0]);
            //    Console.WriteLine(videoServerSrc[1]);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion

            #region MySql测试

            //try
            //{
            //    MySql_VideoCate cate = new MySql_VideoCate();
            //    cate.c_name = "test";

            //    int result = MySql_VideoCateService.Insert(cate);

            //    if (result > 0)
            //    {
            //        Console.WriteLine("插入成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("插入失败");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("出错了：" + ex.Message);
            //}

            #endregion

            #region paypal测试

            Paypal.Core.Paypal paypal = new Paypal.Core.Paypal();
            paypal.IsSandBox = true;
            string result = paypal.GetCurrentToken();
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("获取错误");
            }
            #endregion


            Console.ReadKey();
        }


        private static void GetListByPageIndex(int pageIndex, FictionSearchInfo search, out int rowCount)
        {
            Console.WriteLine("处理第{0}页", pageIndex);
            rowCount = 0;
            try
            {
                Thread.Sleep(1000 * 2);
                List<Fiction> list = FictionService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, 1000, out rowCount).ToList();

                List<Mongo_Fiction> fInfos = new List<Mongo_Fiction>();

                foreach (Fiction item in list)
                {
                    Mongo_Fiction modbInfo = new Mongo_Fiction();
                    //modbInfo.Id = item.Id;
                    modbInfo.Author = item.Author;
                    modbInfo.CompleteState = item.CompleteState;
                    modbInfo.CoverImage = item.CoverImage;
                    modbInfo.C_C_ID = item.C_C_ID;
                    modbInfo.Intro = item.Intro;
                    modbInfo.LastChapterId = item.LastChapterId;
                    modbInfo.LastUpdateChapter = item.LastUpdateChapter;
                    modbInfo.LastUpdateTime = item.LastUpdateTime;
                    modbInfo.Title = item.Title;
                    fInfos.Add(modbInfo);

                    if (fInfos.Count > 0 && fInfos.Count % 50 == 0)
                    {
                        Mongo_FictionService.BatchInsert(fInfos);
                        Console.WriteLine("插入MongoDB成功【{0}】条数据！", fInfos.Count);
                        fInfos.Clear();
                    }
                }
                //插入尾数
                if (fInfos.Count > 0)
                {
                    Mongo_FictionService.BatchInsert(fInfos);
                    Console.WriteLine("插入MongoDB成功【{0}】条数据！", fInfos.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错了。。" + ex.Message);
            }
        }

        /// <summary>
        /// 转移数据到monogdb
        /// </summary>
        /// <param name="tableIndex"></param>
        /// <param name="fid"></param>
        private static void InsertMongoDB(Fiction item, List<Mongo_Fiction> fInfos)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("插入MongoDB错误:" + ex.Message);
            }
        }


        //处理章节名称
        private static void GetChapter(int tableIndex, int fid)
        {
            bool success = false;
            try
            {
                IList<ChapterList> list = ChapterListService.Select(string.Format("where ChapterIndex='' and F_ID={0}", fid), tableIndex);
                string[] str = null;
                foreach (ChapterList item in list)
                {
                    Console.WriteLine("正在处理章节{0}", item.ChapterName);
                    //处理章节名称
                    str = item.ChapterName.Split(new string[] { "章" }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length == 2)
                    {
                        item.ChapterIndex = string.Format("{0}章", str[0]);
                    }
                    else
                    {
                        item.ChapterIndex = "";
                    }
                    item.ChapterName = Regex.Replace(item.ChapterName, "[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", "");
                    item.ChapterSort = UntityTool.GetIndexSort(item.ChapterIndex.Replace(" ", ""));

                    ChapterListService.Update(item, tableIndex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("修正章节排序出错了。。。。。" + ex.Message);
            }
        }


        static void CreateNewTask(int i)
        {
            //Task 多线程测试
            Task task = new Task(
                () =>
                {
                    Console.WriteLine("Task处理" + i);
                }
            );
            task.Start();
            list.Add(task);
            task.ContinueWith((t) =>
            {
                if (curInt < total)
                {
                    //当前线程执行完毕，再开新线程
                    CreateNewTask(curInt);
                    lock (objLock)
                    {
                        curInt++;
                    }
                    Console.WriteLine("Task处理完毕" + i);
                }
                else
                {
                    if (!IsComplete)
                    {
                        lock (obj2Lock)
                        {
                            IsComplete = true;
                        }
                        Console.WriteLine("只执行一次：任务完成了。" + i);
                    }
                }

            });

        }


        public static void Notify()
        {
            Console.WriteLine("single");
        }

        public static void NotifyAll()
        {
            Console.WriteLine("all");
        }
    }
}

