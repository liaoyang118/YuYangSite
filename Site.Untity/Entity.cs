using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using System.Web;
using System.Security.Cryptography;
using System.Reflection;
using System.ComponentModel;

namespace Site.Untity
{
    /// <summary>
    /// 此类，本来是 Web 公共组件 Site.Common，窗体引用不适用，需要更改
    /// </summary>
    public static class Entity
    {
        #region 加密部分

        #region MD5
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Str2Md5(string str)
        {

            MD5 md5 = MD5.Create();
            string pwd = string.Empty;
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }
        #endregion

        #endregion

        #region WCF部分

        #region 创建wcf通道
        /// <summary>
        ///创建wcf通道
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static T CreateChannel<T>(Site.Common.SiteEnum.SiteService serviceName, bool isBasicBindding = false)
        {
            string mapPath = @"./config/service.config";
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(mapPath, settings);

            doc.Load(reader);
            reader.Dispose();

            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;
            XmlNode node = null;
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].FirstChild.InnerText == serviceName.ToString())
                {
                    node = nodeList.Item(i);
                    break;
                }
            }
            string service = node.SelectSingleNode("serviceName").InnerText;
            string serviceUrl = node.SelectSingleNode("serviceUrl").InnerText;
            string securityMode = node.SelectSingleNode("SecurityMode").InnerText;
            string servicespace = node.SelectSingleNode("servicespace").InnerText;

            ChannelFactory<T> channelFac = null;
            if (isBasicBindding)
            {
                channelFac = new ChannelFactory<T>(CreateBasicBindding(service, BasicHttpSecurityMode.None, servicespace), CreateEndpoint(serviceUrl));
            }
            else
            {
                channelFac = new ChannelFactory<T>(CreateBindding(service, SecurityMode.None, servicespace), CreateEndpoint(serviceUrl));
            }

            //查看是否有 数据契约
            foreach (OperationDescription op in channelFac.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>() as DataContractSerializerOperationBehavior;
                if (dataContractBehavior != null)
                {
                    //制定数据契约 序列化的数量
                    dataContractBehavior.MaxItemsInObjectGraph = 0x100000;
                }
            }

            return channelFac.CreateChannel();

        }

        /// <summary>
        /// 创建 同名的多个 wcf通道 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static List<T> CreateChannelList<T>(Site.Common.SiteEnum.SiteService serviceName)
        {
            List<T> list = new List<T>();

            string mapPath = @"./config/service.config";
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(mapPath, settings);

            doc.Load(reader);
            reader.Dispose();

            XmlNodeList nodeList = doc.DocumentElement.ChildNodes;
            List<XmlNode> node = new List<XmlNode>();
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].FirstChild.InnerText == serviceName.ToString())
                {
                    node.Add(nodeList.Item(i));
                }
            }

            string service = string.Empty;
            string serviceUrl = string.Empty;
            string securityMode = string.Empty;
            string servicespace = string.Empty;
            foreach (XmlNode item in node)
            {
                service = item.SelectSingleNode("serviceName").InnerText;
                serviceUrl = item.SelectSingleNode("serviceUrl").InnerText;
                securityMode = item.SelectSingleNode("SecurityMode").InnerText;
                servicespace = item.SelectSingleNode("servicespace").InnerText;

                ChannelFactory<T> channelFac = new ChannelFactory<T>(CreateBindding(service, SecurityMode.None, servicespace), CreateEndpoint(serviceUrl));

                //查看是否有 数据契约
                foreach (OperationDescription op in channelFac.Endpoint.Contract.Operations)
                {
                    DataContractSerializerOperationBehavior dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>() as DataContractSerializerOperationBehavior;
                    if (dataContractBehavior != null)
                    {
                        //制定数据契约 序列化的数量
                        dataContractBehavior.MaxItemsInObjectGraph = 0x100000;
                    }
                }

                list.Add(channelFac.CreateChannel());
            }

            return list;
        }


        #endregion

        //缓存锁
        private static object lockObj = new object();


        #region 创建MSHttpBindding + CreateBindding(string serviceName, SecurityMode securityMode, string servicespace)
        /// <summary>
        /// 创建MSHttpBindding
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="securityMode"></param>
        /// <param name="servicespace"></param>
        /// <returns></returns>
        private static WSHttpBinding CreateBindding(string serviceName, SecurityMode securityMode, string servicespace)
        {
            string bindingName = servicespace + "," + securityMode.GetHashCode().ToString() + "," + serviceName.ToString();

            lock (lockObj)
            {
                WSHttpBinding ws = new WSHttpBinding();

                //基本配置
                ws.Security.Mode = securityMode;
                ws.Namespace = servicespace;

                ws.TransactionFlow = false;
                ws.ReliableSession.Enabled = false;
                ws.AllowCookies = false;
                //使用代理
                ws.BypassProxyOnLocal = false;

                ws.CloseTimeout = TimeSpan.FromMinutes(1);
                ws.OpenTimeout = TimeSpan.FromMinutes(1);
                ws.ReceiveTimeout = TimeSpan.FromMinutes(10);
                ws.SendTimeout = TimeSpan.FromMinutes(60);

                ws.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                ws.MaxBufferPoolSize = 10485760;
                ws.MaxReceivedMessageSize = int.MaxValue;

                ws.MessageEncoding = WSMessageEncoding.Text;
                ws.UseDefaultWebProxy = true;
                ws.TextEncoding = Encoding.UTF8;

                //XmlDictionaryReaderQuotas ,一定要引用 System.Runtime.Serialization，才有这些属性值
                //抵御某种类型的拒绝服务 (DoS) 攻击
                ws.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                ws.ReaderQuotas.MaxArrayLength = int.MaxValue;
                ws.ReaderQuotas.MaxDepth = 32;

                //传输级安全
                HttpTransportSecurity hts = ws.Security.Transport;
                hts.ClientCredentialType = HttpClientCredentialType.Windows;
                hts.ProxyCredentialType = HttpProxyCredentialType.None;
                hts.Realm = "";

                //消息级安全
                NonDualMessageSecurityOverHttp ndms = ws.Security.Message;
                ndms.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;
                ndms.ClientCredentialType = MessageCredentialType.Windows;
                ndms.EstablishSecurityContext = true;
                ndms.NegotiateServiceCredential = true;


                return ws;
            }
        }
        #endregion

        #region 创建BasicHttpBinding + CreateBasicBindding(string serviceName, BasicHttpSecurityMode securityMode, string servicespace)
        /// <summary>
        /// 创建BasicHttpBinding
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="securityMode"></param>
        /// <param name="servicespace"></param>
        /// <returns></returns>
        private static BasicHttpBinding CreateBasicBindding(string serviceName, BasicHttpSecurityMode securityMode, string servicespace)
        {
            string bindingName = servicespace + "," + securityMode.GetHashCode().ToString() + "," + serviceName.ToString();

            lock (lockObj)
            {
                BasicHttpBinding ws = new BasicHttpBinding();

                //基本配置
                ws.Security.Mode = securityMode;
                ws.Namespace = servicespace;

                ws.TransferMode = TransferMode.Streamed;
                ws.AllowCookies = false;
                //使用代理
                ws.BypassProxyOnLocal = false;

                ws.CloseTimeout = TimeSpan.FromMinutes(1);
                ws.OpenTimeout = TimeSpan.FromMinutes(1);
                ws.ReceiveTimeout = TimeSpan.FromMinutes(10);
                ws.SendTimeout = TimeSpan.FromMinutes(60);

                ws.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
                ws.MaxBufferPoolSize = 10485760;
                ws.MaxReceivedMessageSize = int.MaxValue;

                ws.MessageEncoding = WSMessageEncoding.Text;
                ws.UseDefaultWebProxy = true;
                ws.TextEncoding = Encoding.UTF8;

                //XmlDictionaryReaderQuotas ,一定要引用 System.Runtime.Serialization，才有这些属性值
                //抵御某种类型的拒绝服务 (DoS) 攻击
                ws.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                ws.ReaderQuotas.MaxArrayLength = int.MaxValue;
                ws.ReaderQuotas.MaxDepth = 32;

                //传输级安全
                HttpTransportSecurity hts = ws.Security.Transport;
                hts.ClientCredentialType = HttpClientCredentialType.None;
                hts.ProxyCredentialType = HttpProxyCredentialType.None;
                hts.Realm = "";

                //消息级安全
                BasicHttpMessageSecurity ndms = ws.Security.Message;
                ndms.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;


                return ws;
            }
        }



        #endregion


        #region 创建 终结点 + CreateEndpoint(string url)
        /// <summary>
        /// 创建 终结点
        /// </summary>
        /// <returns></returns>
        private static EndpointAddress CreateEndpoint(string url)
        {
            EndpointIdentity ei = EndpointIdentity.CreateDnsIdentity("localhost");
            EndpointAddress epa = new EndpointAddress(new Uri(url), ei, new AddressHeaderCollection());

            return epa;
        }
        #endregion

        #endregion

        #region 扩展方法部分



        #region 扩展方法 + string ToSafeString(this String str)
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSafeString(this String str)
        {
            return str.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("'", "");
        }
        #endregion

        /// <summary>
        /// 扩展方法 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringFullDate(this DateTime str)
        {
            return str.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回指定长度的元素，如何集合元素长度小于指定数，则返回集合的长度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int GetLength<T>(this List<T> list, int length)
        {
            if (list.Count > length)
            {
                return length;
            }
            else
            {
                return list.Count;
            }
        }


        #endregion

        #region 生成guid + string GenerateGUID(int length)
        /// <summary>
        /// 生成guid
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateGUID(int length = 8)
        {
            return Guid.NewGuid().ToString().Substring(0, length);
        }
        #endregion

        #region 常量

        /// <summary>
        /// 权限key
        /// </summary>
        public const string PERMISSIONKEY = "PremissionKey";

        public const string UserSessionKey = "UserInfo";

        #endregion

        #region 公用方法

        /// <summary>
        /// 获取枚举项的 Description 描述信息
        /// </summary>
        /// <param name="enumItemValue">枚举对应的数值</param>
        /// <typeparam name="T">枚举类</typeparam>
        /// <returns>Description信息</returns>
        public static string GetDescription<T>(int enumItemValue)
        {
            string name = Enum.GetName(typeof(T), enumItemValue);
            Site.Common.SiteEnum.SiteItemStatus enumItem = (Site.Common.SiteEnum.SiteItemStatus)Enum.Parse(typeof(T), name);
            FieldInfo fieldinfo = enumItem.GetType().GetField(name);

            object[] arr = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (arr.Length > 0)
            {
                return ((DescriptionAttribute)arr[0]).Description;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

    }
}
