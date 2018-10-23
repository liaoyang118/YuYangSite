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
using Spider.Service.Interface;
using Spider.Service.Tool;

namespace Spider.Service
{
    /// <summary>
    /// 错误补偿任务
    /// </summary>
    public class Spider58_ErrorCompensate : ISpider
    {
        #region 变量

        /// <summary>
        /// 停止任务
        /// </summary>
        bool isStop = false;

        /// <summary>
        /// 主窗体引用
        /// </summary>
        IWriteContent main = null;

        /// <summary>
        /// 页容量
        /// </summary>
        int _pageCount = 1000;

        string LogTaskHead = "【错误章节补偿】";

        /// <summary>
        /// IocName
        /// </summary>
        private string IocName;

        /// <summary>
        /// 任务运行完毕 事件
        /// </summary>
        public event Complete SpiderRunComplete;

        #endregion

        public Spider58_ErrorCompensate(IWriteContent form, string iocName, int pageCount)
        {
            main = form;
            _pageCount = pageCount;
            IocName = iocName;
        }


        public void SpiderRun()
        {
            main.WriteSuccessContet(string.Format("{0}:任务开始。", LogTaskHead));

            int rowCount = 0, pageIndex = 1, totalPage = 1;
            ErrorChapterSearchInfo search = new ErrorChapterSearchInfo();
            search.DisposeStatus = (int)SiteEnum.DisposeStatus.未处理;
            search.MaxTryCounts = 3;

            GetListByPageIndex(pageIndex, search, out rowCount);
            totalPage = (int)Math.Ceiling(rowCount * 1.00 / _pageCount * 1.00);
            if (totalPage > 1)
            {
                for (pageIndex = 2; pageIndex <= totalPage; pageIndex++)
                {
                    if (!isStop)
                    {
                        GetListByPageIndex(pageIndex, search, out rowCount);
                    }
                    else
                    {
                        main.WriteNotifyContet(string.Format("{0}:退出任务成功。", LogTaskHead));
                        break;
                    }
                }
            }

            main.WriteNotifyContet(string.Format("{0}:任务结束。", LogTaskHead));

            //定时轮询
            if (!isStop)
            {
                Thread.Sleep(1000 * 60);
                main.WriteNotifyContet(string.Format("{0}:重启任务", LogTaskHead));
                //SpiderRun();

                if (SpiderRunComplete != null)
                {
                    SpiderRunComplete(IocName);
                }

            }
        }


        private void GetListByPageIndex(int pageIndex, ErrorChapterSearchInfo search, out int rowCount)
        {
            rowCount = 0;
            try
            {
                List<ErrorChapter> list = ErrorChapterService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, _pageCount, out rowCount).ToList();

                main.WriteSuccessContet(string.Format("{0}:开始处理第【{1}】页数据，共【{2}】条。", LogTaskHead, pageIndex, rowCount));
                foreach (ErrorChapter item in list)
                {
                    if (!isStop)
                    {
                        //获取章节
                        GetChapter(item);
                    }
                    else
                    {
                        main.WriteNotifyContet(string.Format("{0}:停止任务成功。", LogTaskHead));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                main.WriteErrorContet(string.Format("{0}:获取数据错误。【{1}】", LogTaskHead, ex.Message));
            }
        }

        private void GetChapter(ErrorChapter eInfo)
        {
            bool success = false;
            try
            {
                if (eInfo.C_C_Id <= 0)
                {
                    Fiction fInfo = FictionService.SelectObject(eInfo.F_Id);
                    if (fInfo == null)
                    {
                        main.WriteErrorContet(string.Format("{0}:小说【{1}】已不存在，Id【{2}】", LogTaskHead, eInfo.Title, eInfo.F_Id));

                        success = true;

                        return;
                    }
                    eInfo.C_C_Id = fInfo.C_C_ID;
                }

                ChapterList isExistInfo = null;
                //判断是否存在该章节
                isExistInfo = ChapterListService.Select(string.Format("where ChapterName=N'{0}' and F_ID={1}", eInfo.ChapterName, eInfo.F_Id), eInfo.C_C_Id).FirstOrDefault();
                if (isExistInfo == null)
                {
                    ChapterList info = new ChapterList();
                    info.F_ID = eInfo.F_Id;
                    info.UpdateTime = DateTime.Now;
                    info.ChapterName = eInfo.ChapterName;
                    string[] str = eInfo.Title.Split(new string[] { "章" }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length == 2)
                    {
                        info.ChapterIndex = string.Format("{0}章", str[0]);
                    }
                    else
                    {
                        info.ChapterIndex = string.Empty;
                    }
                    info.ChapterSort = UntityTool.GetIndexSort(info.ChapterIndex.Replace(" ", ""));

                    HttpClientHelp web = new HttpClientHelp();
                    string result = web.Get(eInfo.ChapterUrl);

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
                            main.WriteSuccessContet(string.Format("{0}:小说【{1}】,章节【{2}】内文数据成功！", LogTaskHead, eInfo.Title, eInfo.ChapterName));
                            info.ChapterContent = Common.FormatContent(contentMatch.Value);
                            //插入章节数据
                            int resultInt = ChapterListService.Insert(info, eInfo.C_C_Id);
                            if (resultInt > 0)
                            {
                                success = true;
                            }
                        }
                        else
                        {
                            main.WriteErrorContet(string.Format("{0}:小说【{1}】,章节【{2}】，未获取到内文数据", LogTaskHead, eInfo.Title, eInfo.ChapterName));
                            success = false;
                        }
                    }
                    else
                    {
                        main.WriteErrorContet(string.Format("{0}:未获取到小说【{1}】章节【{2}】内文Dom元素", LogTaskHead, eInfo.Title, eInfo.ChapterName));
                        success = false;
                    }
                }
                else
                {
                    main.WriteErrorContet(string.Format("{0}:小说【{1}】，章节【{2}】已存在，Id【{3}】", LogTaskHead, eInfo.Title, eInfo.ChapterName, eInfo.F_Id));
                    success = true;
                }
            }
            catch (Exception ex)
            {
                main.WriteErrorContet(string.Format("{0}:获取小说【{1}】章节【{2}】内文数据错误。【{3}】{4}", LogTaskHead, eInfo.Title, eInfo.ChapterName, eInfo.ChapterUrl, ex.Message));
                success = false;
            }
            finally
            {

                #region 更新补偿成功的章节状态和次数

                if (success)
                {
                    eInfo.DisposeStatus = (int)SiteEnum.DisposeStatus.已处理;
                    eInfo.RetryCount = 1;
                }
                else
                {
                    eInfo.DisposeStatus = (int)SiteEnum.DisposeStatus.未处理;
                    eInfo.RetryCount = eInfo.RetryCount + 1;
                }

                ErrorChapterService.Update(eInfo);
                #endregion
            }
        }

        public void Stop()
        {
            isStop = true;
        }

    }
}
