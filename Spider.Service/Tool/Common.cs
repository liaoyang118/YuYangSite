using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Spider.Service.Model;

namespace Spider.Service.Tool
{

    public delegate void ConsoleLog(string log);


    public class Common
    {
        /// <summary>
        /// 系统调用上传服务时，Windows服务所在配置文件的路径【Windows服务需要注意执行路径和安装路径】
        /// </summary>
        public static string UploadServiceConfigFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Config\\upload.config";

        public static TaskList ReadConfig()
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Config\SpiderTask.xml");

                using (StringReader sr = new StringReader(xd.InnerXml))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(TaskList));
                    return xmldes.Deserialize(sr) as TaskList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string FormatContent(string content)
        {
            //过滤a链接
            content = Regex.Replace(content, @"<[aA][^>]*>([\s\S]*?)</[aA]>", "");
            //过滤域名
            content = Regex.Replace(content, @"5858xs.com", "");
            content = Regex.Replace(content, @"小说网", "");
            //过滤html
            content = Regex.Replace(content, @"<font[^>]*>([ \W\s\S\w]*)</font>", "");
            content = content.Replace(@"</br>", "");
            content = content.Replace(@"&amp;", "");
            content = content.Replace(@"#12288", "");
            content = content.Replace(@"www", "");
            content = content.Replace(@".com", "");
            content = content.Replace(@".cn", "");

            //过滤 特殊字符
            content = Regex.Replace(content, @"[%~!@#$…%￥—+=]", "");

            return content;
        }
    }


}
