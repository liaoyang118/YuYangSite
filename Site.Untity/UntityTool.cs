using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using Site.Service.UploadService;
using Site.Service.UploadService.UploadService;
using System.Runtime.Serialization.Json;

namespace Site.Untity
{
    public class UntityTool
    {
        static string domain = GetConfigValue("Domain");

        static UntityTool()
        {
            tenThousand.Add("一万", 10000);
            tenThousand.Add("二万", 20000);
            tenThousand.Add("三万", 30000);
            tenThousand.Add("四万", 40000);
            tenThousand.Add("五万", 50000);
            tenThousand.Add("六万", 60000);
            tenThousand.Add("七万", 70000);
            tenThousand.Add("八万", 80000);
            tenThousand.Add("九万", 90000);
            tenThousand.Add("十万", 100000);

            thousand.Add("一千", 1000);
            thousand.Add("二千", 2000);
            thousand.Add("三千", 3000);
            thousand.Add("四千", 4000);
            thousand.Add("五千", 5000);
            thousand.Add("六千", 6000);
            thousand.Add("七千", 7000);
            thousand.Add("八千", 8000);
            thousand.Add("九千", 9000);

            hundred.Add("一百", 100);
            hundred.Add("二百", 200);
            hundred.Add("两百", 200);
            hundred.Add("三百", 300);
            hundred.Add("四百", 400);
            hundred.Add("五百", 500);
            hundred.Add("六百", 600);
            hundred.Add("七百", 700);
            hundred.Add("八百", 800);
            hundred.Add("九百", 900);

            ten.Add("一十", 10);
            ten.Add("二十", 20);
            ten.Add("三十", 30);
            ten.Add("四十", 40);
            ten.Add("五十", 50);
            ten.Add("六十", 60);
            ten.Add("七十", 70);
            ten.Add("八十", 80);
            ten.Add("九十", 90);

            single.Add("一", 1);
            single.Add("二", 2);
            single.Add("三", 3);
            single.Add("四", 4);
            single.Add("五", 5);
            single.Add("六", 6);
            single.Add("七", 7);
            single.Add("八", 8);
            single.Add("九", 9);
            single.Add("十", 10);

            zero.Add("零一", 1);
            zero.Add("零二", 2);
            zero.Add("零三", 3);
            zero.Add("零四", 4);
            zero.Add("零五", 5);
            zero.Add("零六", 6);
            zero.Add("零七", 7);
            zero.Add("零八", 8);
            zero.Add("零九", 9);
        }

        public static string GetConfigValue(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                result = "";
            }

            return result;
        }

        public static string Md5_32(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);

            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }

        public static string GetJsonByObject(Object obj)
        {
            //实例化DataContractJsonSerializer对象，需要待序列化的对象类型
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            //实例化一个内存流，用于存放序列化后的数据
            MemoryStream stream = new MemoryStream();
            //使用WriteObject序列化对象
            serializer.WriteObject(stream, obj);
            //写入内存流中
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            //通过UTF8格式转换为字符串
            return Encoding.UTF8.GetString(dataBytes);
        }


        public static object JsonResult(bool success, string message)
        {
            return new
            {
                success = success,
                message = new { text = message }
            };
        }

        /// <summary>
        /// XML 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(string xml, Encoding encoding) where T : new()
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(T));
                using (var ms = new MemoryStream(encoding.GetBytes(xml)))
                {
                    using (var sr = new StreamReader(ms, encoding))
                    {
                        return (T)mySerializer.Deserialize(sr);
                    }
                }
            }
            catch (Exception e)
            {
                return default(T);
            }

        }

        public static int GetTimeSpan()
        {
            //TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //return Convert.ToInt64(ts.TotalSeconds * 1000);

            int intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (int)(DateTime.Now - startTime).TotalSeconds;
            return intResult;
        }

        public static DateTime TimespanToDatetime(long timeStamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(timeStamp);
            return dt;
        }

        #region 小说生成链接


        /// <summary>
        /// 生成分类列表分页Dome
        /// </summary>
        /// <returns></returns>
        public static string CreateListPage(int interval, int pageSize, int pageIndex, int rowCount, string urlBase)
        {
            /*
             <ul class="pagination pagination-lg">
                    <li><a href="#">上一页</a></li>
                    <li class="active"><a href="#">1</a></li>
                    <li class="disabled"><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li><a href="#">下一页</a></li>
                </ul>
            */
            string result = string.Empty;

            string pageHtml = "<ul class=\"pagination pagination-lg\">{0}</ul>";
            string a_url = string.Empty;
            int totalPage = (int)Math.Ceiling(rowCount * 1.00 / pageSize * 1.00);
            if (totalPage > 1)
            {
                if (pageIndex != 1)
                {
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">首页</a></li>\r\n", GetListUrl(1, urlBase));
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">上一页</a></li>\r\n", GetListUrl(pageIndex - 1, urlBase));
                }
                //页码条中间的间隔
                int barInteval = interval;
                int defaulStart = 1, defaultEnd = barInteval;
                //生成页码条的 起始位置---间隔页位置
                if (pageIndex % barInteval == 0)
                {
                    defaulStart = pageIndex - barInteval + 1;
                    defaultEnd = pageIndex + barInteval;

                    if (defaultEnd > totalPage)
                    {
                        defaultEnd = totalPage;
                    }
                }
                //首页时
                else if (pageIndex == 1)
                {
                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex;
                        defaultEnd = pageIndex + barInteval - 1;
                    }
                    else
                    {
                        defaultEnd = totalPage;
                    }
                }
                //尾页时
                else if (pageIndex == totalPage)
                {

                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex - barInteval;
                        defaultEnd = totalPage;
                    }
                    else
                    {
                        defaulStart = 1;
                        defaultEnd = totalPage;
                    }
                }

                //中间页时
                else
                {
                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex - barInteval;
                        if (defaulStart < 0)
                        {
                            defaulStart = 1;
                        }
                        defaultEnd = pageIndex + barInteval - 1;
                    }
                    else
                    {
                        defaultEnd = totalPage;
                    }
                }


                //生成中间的页码条
                for (int i = defaulStart; i <= defaultEnd; i++)
                {
                    a_url += string.Format("<li class=\"{2}\"><a href=\"{0}\">{1}</a></li>\r\n", GetListUrl(i, urlBase), i, i == pageIndex ? "active" : "");
                }

                if (pageIndex != totalPage)
                {
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">下一页</a></li>\r\n", GetListUrl(pageIndex + 1, urlBase));
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">尾页</a></li>\r\n", GetListUrl(totalPage, urlBase));
                }

                result = string.Format(pageHtml, a_url);
            }

            return result;
        }

        private static string GetListUrl(int current, string url)
        {
            string result = string.Empty;
            if (url.Contains("?"))
            {
                result = url + "&page=" + current;
            }
            else
            {
                result = url + "?page=" + current;
            }

            return result;
        }

        /// <summary>
        /// 生成小说介绍页URL
        /// </summary>
        /// <param name="cateId"></param>
        /// <param name="fId"></param>
        /// <returns></returns>
        public static string GenerateIntroUrl(int fId)
        {
            return string.Format("http://{0}/Introduce/{1}.html", domain, fId);
        }

        /// <summary>
        /// 生成小说章节页URL
        /// </summary>
        /// <param name="fId"></param>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        public static string GenerateDetailUrl(int fId, int chapterId)
        {
            return string.Format("http://{0}/Detail/{1}/{2}.html", domain, fId, chapterId);
        }

        /// <summary>
        /// MongoDB 生成小说章节页URL
        /// </summary>
        /// <param name="fId"></param>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        public static string GenerateDetailUrl(int fId, string chapterId)
        {
            return string.Format("http://{0}/Detail/{1}/{2}.html", domain, fId, chapterId);
        }


        /// <summary>
        /// 生成小说列表页URL
        /// </summary>
        /// <param name="fId"></param>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        public static string GenerateListUrl(int cateId)
        {
            return string.Format("http://{0}/List/{1}.html", domain, cateId);
        }


        #region 字符串处理

        //万
        private static Dictionary<string, int> tenThousand = new Dictionary<string, int>();
        //千
        private static Dictionary<string, int> thousand = new Dictionary<string, int>();
        //百
        private static Dictionary<string, int> hundred = new Dictionary<string, int>();
        //十
        private static Dictionary<string, int> ten = new Dictionary<string, int>();
        //个
        private static Dictionary<string, int> single = new Dictionary<string, int>();
        //零
        private static Dictionary<string, int> zero = new Dictionary<string, int>();

        /// <summary>
        /// 根据章节序号字符串，获取物理对应的排序序号
        /// </summary>
        /// <param name="indexString"></param>
        /// <returns></returns>
        public static int GetIndexSort(string indexString)
        {
            int result = 0;
            Match m = Regex.Match(indexString, @"第([\d]+?)章|第([万千百十九八七六五四三二一零两]*?)章");
            if (!m.Success)
            {
                return result;
            }
            string _num = m.Value.Replace("第", "").Replace("章", "");
            if (!int.TryParse(_num, out result))
            {
                try
                {
                    foreach (KeyValuePair<string, int> item in tenThousand)
                    {
                        if (indexString.Contains(item.Key))
                        {
                            result += item.Value;
                            indexString = indexString.Replace(item.Key, "");
                            break;
                        }
                    }

                    foreach (KeyValuePair<string, int> item in thousand)
                    {
                        if (indexString.Contains(item.Key))
                        {
                            result += item.Value;
                            indexString = indexString.Replace(item.Key, "");
                            break;
                        }
                    }

                    foreach (KeyValuePair<string, int> item in hundred)
                    {
                        if (indexString.Contains(item.Key))
                        {
                            result += item.Value;
                            indexString = indexString.Replace(item.Key, "");
                            break;
                        }
                    }


                    foreach (KeyValuePair<string, int> item in ten)
                    {
                        if (indexString.Contains(item.Key))
                        {
                            result += item.Value;
                            indexString = indexString.Replace(item.Key, "");
                            break;
                        }
                    }

                    foreach (KeyValuePair<string, int> item in single)
                    {
                        if (indexString.Contains(item.Key))
                        {
                            result += item.Value;
                            indexString = indexString.Replace(item.Key, "");

                            //这里不做跳出，特殊处理，例如 十一
                            //break;
                        }
                    }

                    foreach (KeyValuePair<string, int> item in zero)
                    {
                        if (indexString.Contains(item.Key))
                        {
                            result += item.Value;
                            indexString = indexString.Replace(item.Key, "");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = -1;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取GUID 32位
        /// </summary>
        /// <returns></returns>
        public static string GetGUID()
        {
            return Guid.NewGuid().ToString().ToLower().Replace("-", "");
        }


        #endregion

        #endregion

        #region Video生成链接
        public static string CreateVideoListPage(int interval, int pageSize, int pageIndex, int rowCount, string urlBase)
        {
            /*
              <ul class="pagination">
                        <li>
                            <a href="#" aria-label="Previous">
                                <span aria-hidden="true">«</span>
                            </a>
                        </li>
                        <li><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li>
                            <a href="#" aria-label="Next">
                                <span aria-hidden="true">»</span>
                            </a>
                        </li>
                    </ul>
            */
            string result = string.Empty;

            string pageHtml = "<ul class=\"pagination\">{0}</ul>";
            string a_url = string.Empty;
            int totalPage = (int)Math.Ceiling(rowCount * 1.00 / pageSize * 1.00);
            if (totalPage > 1)
            {
                if (pageIndex != 1)
                {
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">首页</a></li>\r\n", GetListUrl(1, urlBase));
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\" aria-label=\"Previous\"><span aria-hidden=\"true\">«</span></a></li>\r\n", GetListUrl(pageIndex - 1, urlBase));
                }
                //页码条中间的间隔
                int barInteval = interval;
                int defaulStart = 1, defaultEnd = barInteval;
                //生成页码条的 起始位置---间隔页位置
                if (pageIndex % barInteval == 0)
                {
                    defaulStart = pageIndex - barInteval + 1;
                    defaultEnd = pageIndex + barInteval;

                    if (defaultEnd > totalPage)
                    {
                        defaultEnd = totalPage;
                    }
                }
                //首页时
                else if (pageIndex == 1)
                {
                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex;
                        defaultEnd = pageIndex + barInteval - 1;
                    }
                    else
                    {
                        defaultEnd = totalPage;
                    }
                }
                //尾页时
                else if (pageIndex == totalPage)
                {

                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex - barInteval;
                        defaultEnd = totalPage;
                    }
                    else
                    {
                        defaulStart = 1;
                        defaultEnd = totalPage;
                    }
                }

                //中间页时
                else
                {
                    //判断总页数是否 大于 页码间隔
                    if (totalPage > barInteval)
                    {
                        defaulStart = pageIndex - barInteval;
                        if (defaulStart < 0)
                        {
                            defaulStart = 1;
                        }
                        defaultEnd = pageIndex + barInteval - 1;
                    }
                    else
                    {
                        defaultEnd = totalPage;
                    }
                }


                //生成中间的页码条
                for (int i = defaulStart; i <= defaultEnd; i++)
                {
                    a_url += string.Format("<li class=\"{2}\"><a href=\"{0}\">{1}</a></li>\r\n", GetVideoListUrl(i, urlBase), i, i == pageIndex ? "active" : "");
                }

                if (pageIndex != totalPage)
                {
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\"  aria-label=\"Next\" ><span aria-hidden=\"true\">»</span></a></li>\r\n", GetVideoListUrl(pageIndex + 1, urlBase));
                    a_url += string.Format("<li class=\"hidden-xs\"><a href=\"{0}\">尾页</a></li>\r\n", GetVideoListUrl(totalPage, urlBase));
                }

                result = string.Format(pageHtml, a_url);
            }

            return result;
        }

        private static string GetVideoListUrl(int current, string url)
        {
            string result = string.Empty;
            if (url.Contains("?"))
            {
                result = url + "&page=" + current;
            }
            else
            {
                result = url + "?page=" + current;
            }

            return result;
        }

        /// <summary>
        /// 生成详情页URL
        /// </summary>
        /// <param name="c_id">分类</param>
        /// <param name="vid">唯一ID</param>
        /// <returns></returns>
        public static string GenerateVideoDetailUrl(int c_id, int vid)
        {
            return string.Format("http://{0}/Detail/{1}/{2}.html", domain, c_id, vid);
        }

        /// <summary>
        /// 生成试看地址
        /// </summary>
        /// <param name="c_id">分类</param>
        /// <param name="vid">唯一ID</param>
        /// <returns></returns>
        public static string GenerateVideoMinDetailUrl(int c_id, int vid)
        {
            return string.Format("http://{0}/Detail/Min/{1}/{2}.html", domain, c_id, vid);
        }

        #endregion

        #region 图片上传 WCF服务

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="imgDatas">二进制数据</param>
        /// <param name="configName">文件保存路径配置名称 WeiXinUpload </param>
        /// <param name="sizeConfig">缩略尺寸设置：尺寸设置 360*200（大）、200*200（小） 不使用水印图片</param>
        /// <param name="imgExt">扩展名</param>
        /// <param name="thumbModel">"s",整图缩放;"c",裁剪; 默认为裁剪</param>
        /// <returns>原图地址(0)和缩略图地址(1)</returns>
        public static List<string> UploadImg(byte[] imgDatas, string configName, List<string> sizeConfig, string imgExt, string thumbModel = "c")
        {
            IUploadService channel = Entity.CreateChannel<IUploadService>(Site.Common.SiteEnum.SiteService.UploadService);
            var result = channel.UploadImg(imgDatas, configName, sizeConfig, imgExt, thumbModel);
            (channel as IDisposable).Dispose();
            return result;
        }

        #endregion

        #region 视频上传 WCF服务
        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="videoDatas">二进制数据</param>
        /// <param name="configName">文件保存路径配置名称 WeiXinUpload </param>
        /// <param name="sizeConfig">缩略尺寸设置：尺寸设置 360*200（大）、200*200（小） 不使用水印图片</param>
        /// <param name="videoExt">扩展名</param>
        /// <param name="thumbModel">"s",整图缩放;"c",裁剪; 默认为裁剪</param>
        /// <returns>原图地址(0)和缩略图地址(1)</returns>
        public static List<string> UploadVideo(byte[] videoDatas, string configName, List<string> sizeConfig, string videoExt, string thumbModel = "c", bool isBasicBindding = false)
        {
            IUploadService channel = Entity.CreateChannel<IUploadService>(Site.Common.SiteEnum.SiteService.UploadService, isBasicBindding);
            var result = channel.UploadVideo(videoDatas, configName, sizeConfig, videoExt, thumbModel);
            (channel as IDisposable).Dispose();
            return result;
        }
        #endregion

        #region 读取文件

        /// <summary>
        /// 读取文件为文本
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <returns></returns>
        public static string ReadFile(string filePath)
        {
            string result = string.Empty;
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        #endregion

    }
}
