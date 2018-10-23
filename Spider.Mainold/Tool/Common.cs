using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Spider.Main.Model;

namespace Spider.Main.Tool
{

    public delegate void ConsoleLog(string log);


    public class Common
    {        
        public static TaskList ReadConfig()
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(@".\Config\SpiderTask.xml");

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
