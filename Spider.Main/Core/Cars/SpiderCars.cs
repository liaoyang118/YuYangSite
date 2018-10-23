using Site.Untity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace Spider.Main.Core
{
    public class SpiderCars : ISpider
    {
        #region 字段

        /// <summary>
        /// 主窗体引用
        /// </summary>
        private MainForm main;

        /// <summary>
        /// 网站域名
        /// </summary>
        private string Domain = "http://www.cars.com";//cars

        /// <summary>
        /// 任务名称头
        /// </summary>
        const string LogTaskHead = "【Cars】爬虫任务";

        /// <summary>
        /// 分类 url 字典
        /// </summary>
        Dictionary<string, string> urlDic = new Dictionary<string, string>();

        /// <summary>
        /// 正在执行的分类任务
        /// </summary>
        List<SpiderCars_Cate> cateList = new List<SpiderCars_Cate>();

        /// <summary>
        /// 执行完成的分类数量
        /// </summary>
        int SuccessCateCount = 0;

        /// <summary>
        /// 并发页数
        /// </summary>
        public int _PageNums { get; set; }

        /// <summary>
        /// 并发项目 数
        /// </summary>
        int _fictionNums;

        /// <summary>
        /// 并发详情页 数
        /// </summary>
        public int _Nums { get; set; }

        /// <summary>
        /// 更新增量
        /// </summary>
        public int _UpdateGrowNums { get; set; }

        /// <summary>
        /// 是否停止当前任务
        /// </summary>
        bool isStop = false;

        #endregion

        #region 构造函数
        /// <summary>
        /// IOC 构造函数
        /// </summary>
        /// <param name="form"></param>
        public SpiderCars(MainForm form, int PageNums = 1, int FictionNums = 5, int Nums = 5, int UpdateGrowNums = 20)
        {
            main = form;
            _PageNums = PageNums;
            _fictionNums = FictionNums;
            _Nums = Nums;
            _UpdateGrowNums = UpdateGrowNums;

            main.WriteSuccessLog(string.Format("{0}:开始", LogTaskHead));
        }
        #endregion

        #region 01 SpiderRun() + 核心执行方法
        /// <summary>
        /// 核心执行方法
        /// </summary>
        public void SpiderRun()
        {
            //获取信息分类URL
            GetCateUrl();
            //获取分类列表
            GetCateList();
        }
        #endregion

        #region 02 GetCateUrl() - 获取分类 Url
        /// <summary>
        /// 获取分类 Url
        /// </summary>
        private void GetCateUrl()
        {
            try
            {
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(Domain + "?v=" + UntityTool.GetTimeStamp());
                if (!string.IsNullOrEmpty(result))
                {
                    #region 正则表达式
                    Regex reg = new Regex(@"<ul [^>/]*?class=""b69JQ""[^>/]*>(.*?)<\/ul>");
                    string urls = reg.Match(result).Value;

                    //匹配li标签
                    MatchCollection mList = Regex.Matches(urls, @"<li[^>/]*>(.*?)<\/li>");
                    if (mList.Count == 11)
                    {
                        //跳过CPO 广告分类
                        Match cateMatch;
                        string cateName;
                        string url;
                        for (int i = 0; i < 11; i++)
                        {
                            //提取分类名称和路径URL
                            cateMatch = Regex.Match(mList[i].Value, @"<a\b[^>]+\bhref=""(?<url>([^""]*))""[^>]*>(?<CateName>([\s\S]*?))</a>");
                            url = cateMatch.Groups["url"].Value;
                            if (url.ToLower().Contains("cpo"))
                            {
                                continue;
                            }
                            cateMatch = Regex.Match(cateMatch.Groups["CateName"].Value, @"<span [^>/]*?>(?<name>(.*?))<\/span>");
                            cateName = cateMatch.Groups["name"].Value;
                            main.WriteSuccessLog(string.Format("{0}:分类【{1}】,Url【{2}】", LogTaskHead, cateName, Domain + url));

                            urlDic[cateName] = Domain + url;
                        }
                    }
                    else
                    {
                        main.WriteErrorLog(string.Format("{0}:未获取到分类Li", LogTaskHead));
                    }
                    #endregion
                }
                else
                {
                    main.WriteErrorLog(string.Format("{0}:未获取到分类Div", LogTaskHead));
                }
            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:错误【{1}】", LogTaskHead, ex.Message));
            }
        }
        #endregion

        #region 03 GetCateList() - 获取分类列表
        /// <summary>
        /// 获取分类小说列表
        /// </summary>
        private void GetCateList()
        {
            foreach (KeyValuePair<string, string> item in urlDic)
            {
                GetListByCate(item.Key, item.Value);
            }
        }
        #endregion



        #region 04 获取该分类下分页列表 + void GetListByCate(string cateName, string cateUrl)

        private void GetListByCate(string cateName, string cateUrl)
        {
            try
            {
                HttpClientHelp web = new HttpClientHelp();
                string result = web.Get(cateUrl);
                //获取该分类下列表 总页数
                if (!string.IsNullOrEmpty(result))
                {
                    //获取所有车型的页面链接
                    Regex reg = new Regex(@"<div [^>/]*?class=[""]*allmodels[""]*[^>/]*>([\s\S]*?)<\/div>");
                    string allDiv = reg.Match(result).Value;
                    Match allMatch = Regex.Match(allDiv, @"<a\b[^>]+\bhref=""(?<url>([^""]*))""[^>]*>(?<totalPage>([\s\S]*?))</a>");
                    string allUrl = allMatch.Groups["url"].Value.ToString();

                    result = web.Get(Domain + allUrl);
                    if (!string.IsNullOrEmpty(result))
                    {
                        reg = new Regex(@"<div [^>/]*?class=[""]*page-numbers[""]*[^>/]*>([\s\S]*?)<\/div>");
                        string pagesDiv = reg.Match(result).Value;

                        //匹配分页标签
                        MatchCollection mList = Regex.Matches(pagesDiv, @"<a\b[^>]+\bhref=""(?<url>([^""]*))""[^>]*>(?<totalPage>([\s\S]*?))</a>");
                        if (mList.Count > 0)
                        {
                            int totalPage = mList[mList.Count - 1].Groups["totalPage"].Value.ToInt32(0);
                            string pageUrl = mList[mList.Count - 1].Groups["url"].Value;// /research/search/?catId=440&rn=377&rpp=13
                            //替换 rn
                            pageUrl = Domain + Regex.Replace(pageUrl, @"rn=[\d]+", "rn={0}");
                            pageUrl = HttpUtility.HtmlDecode(pageUrl);

                            main.WriteSuccessLog(string.Format("{0}:分类【{1}】,总页数【{2}】", LogTaskHead, cateName, totalPage));
                            //开始获取分类下列表数据
                            SpiderCars_Cate cateSpider = new SpiderCars_Cate(main, Domain, LogTaskHead, pageUrl, cateName, totalPage, _PageNums, _fictionNums, _Nums, _UpdateGrowNums);
                            cateSpider.Complete += new Notify(NotifyComplete);
                            cateList.Add(cateSpider);
                            cateSpider.GetFictionByPage();
                        }
                        else
                        {
                            main.WriteErrorLog(string.Format("{0}:分类【{1}】,未获取到分页页数", LogTaskHead, cateName));
                        }
                    }
                    else
                    {
                        main.WriteErrorLog(string.Format("{0}:未获取到所有车型的分页Dom元素", LogTaskHead));
                    }
                }
                else
                {
                    main.WriteErrorLog(string.Format("{0}:未获取到分页Dom元素", LogTaskHead));
                }
            }
            catch (Exception ex)
            {
                main.WriteErrorLog(string.Format("{0}:获取分类列表数据错误，{1}", LogTaskHead, ex.Message));
            }
        }


        #endregion



        #region 05 停止任务
        /// <summary>
        /// 停止任务
        /// </summary>
        public void Stop()
        {
            isStop = true;
            foreach (SpiderCars_Cate item in cateList)
            {
                item.StopTask();
            }
        }
        #endregion

        #region 06 轮询执行任务

        /// <summary>
        /// 通知任务完成
        /// </summary>
        public void NotifyComplete()
        {
            SuccessCateCount++;
            if (SuccessCateCount == cateList.Count && !isStop)
            {
                main.WriteNotifyLog(string.Format("{0}:重启任务", LogTaskHead), true);
                //重启任务
                //循环启动，不释放内存，会导致内存崩溃
                //cateList.Clear();
                //SuccessCateCount = 0;
                //GetCateFictionList();

                //让当前线程回收，重新从外面启动新的实例
                main.ResetTask("Cars");
            }
        }


        #endregion


    }
}
