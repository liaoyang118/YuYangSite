using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Site.Untity.SiteEnum;

namespace Site.Untity
{
    public class HttpBase
    {
        //抓取远程图片，调用WCF存储在图片服务器
        public string CaptureRemoteImage(string imageUrl, out string error, string uploadConfigName = "XiaoShuoUpload")
        {
            error = string.Empty;
            string result = string.Empty;

            var request = HttpWebRequest.Create(imageUrl) as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    error = "Url returns " + response.StatusCode + ", " + response.StatusDescription;
                }
                if (response.ContentType.IndexOf("image") == -1)
                {
                    error = "Url is not an image";
                }

                List<string> urlResult = new List<string>();

                try
                {
                    var stream = response.GetResponseStream();
                    var reader = new BinaryReader(stream);
                    byte[] bytes;
                    using (var ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[4096];
                        int count;
                        while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            ms.Write(buffer, 0, count);
                        }
                        bytes = ms.ToArray();
                    }

                    //调用站点上传服务
                    urlResult = UntityTool.UploadImg(bytes, uploadConfigName, new List<string>() { "140*180" }, "jpg", "s");

                    if (urlResult.Count > 0)
                    {
                        result = urlResult[1];
                    }
                }
                catch (Exception e)
                {
                    error = "抓取错误：" + e.Message;
                }
            }
            return result;

        }


        /// <summary>
        /// 抓取远程视频，调用WCF存储在视频服务器
        /// </summary>
        /// <param name="vedioUrl"></param>
        /// <param name="error"></param>
        /// <param name="uploadConfigName"></param>
        /// <param name="action"></param>
        /// <returns>[0]视频地址，[1]视频截图地址 [2]...[3]... </returns>
        public List<string> CaptureRemoteVedio(string vedioUrl, out string error, string uploadConfigName = "VideoUpload", Action<string> action = null)
        {
            error = string.Empty;
            string result = string.Empty;

            var request = HttpWebRequest.Create(vedioUrl) as HttpWebRequest;


            request.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = @" Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36";
            request.ContentType = "application/octet-stream";


            List<string> urlResult = new List<string>();


            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    error = "Url returns " + response.StatusCode + ", " + response.StatusDescription;
                }
                if (response.ContentType.IndexOf("video") == -1)
                {
                    error = "Url is not an video";
                }


                try
                {
                    var stream = response.GetResponseStream();
                    byte[] bytes;
                    int totalCount = (int)response.ContentLength;
                    int offset = 0;


                    string currentMb = "0.00";
                    string totalMb = (totalCount * 1.00m / (1024 * 1024 * 1.00m)).ToString("#0.00");
                    if ((totalCount * 1.00m / (1024 * 1024 * 1.00m)) < 400.00m)
                    {
                        return new List<string>();
                    }
                    using (var ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[totalCount];
                        int count;
                        while (totalCount > 0)
                        {
                            count = stream.Read(buffer, offset, totalCount);
                            if (count == 0) break;

                            ms.Write(buffer, offset, count);

                            totalCount -= count;
                            offset += count;

                            currentMb = ((ms.Length * 1.00m) / (1024 * 1024 * 1.00m)).ToString("#0.00");

                            if (action != null)
                            {
                                action.Invoke(string.Format("{0}Mb/{1}Mb", currentMb, totalMb));
                            }
                        }
                        bytes = ms.ToArray();
                    }

                    //调用站点上传服务
                    List<string> videoAndImageSrc = UntityTool.UploadVideo(bytes, uploadConfigName, new List<string>() { "140*180" }, "mp4", "s", true);

                    urlResult.AddRange(videoAndImageSrc);

                }
                catch (Exception e)
                {
                    error = "抓取错误：" + e.Message;
                }
            }
            return urlResult;

        }

        /// <summary>
        /// 迅雷下载远程视频，将本地目录替换为网络目录
        /// </summary>
        /// <param name="vedioUrl"></param>
        /// <param name="error"></param>
        /// <param name="uploadConfigName"></param>
        /// <param name="action"></param>
        /// <returns>[0]视频地址，[1]视频截图地址 [2]...[3]... </returns>

        public List<string> CaptureRemoteVedioByThunder(string videoUrl, string videoName, int totalSecond, out string error, string uploadConfigName = "VideoUpload", Action<string, string> action = null)
        {
            error = string.Empty;
            List<string> urlResult = new List<string>();

            try
            {
                #region 01 ThunderComLib 下载，只能下载，不能直接获取到下载的任务信息

                //物理实际路径
                string thunderPath = UntityTool.GetConfigValue("ThunderDownLoadPath");
                string thumSize = UntityTool.GetConfigValue("ThumSize");//缩略图尺寸 355*200
                string yyyy = DateTime.Now.ToString("yyyy/MM/dd");
                string virtualWcfPath = string.Format("{0}{1}/", thunderPath, yyyy).Replace("/", "\\");

                //网络路径
                string saveFileName = UntityTool.Md5_32(videoName);
                string fileNameAndExt = string.Format("{0}.mp4", saveFileName);
                string domain = UntityTool.GetConfigValue("vDomain");


                ThunderComLib engine = new ThunderComLib();
                engine.AddTask(videoUrl, fileNameAndExt, virtualWcfPath); //格式 F:\迅雷下载\
                int waitSecond = 5;
                if (!Directory.Exists(virtualWcfPath))
                {
                    waitSecond = 15;
                }
                //系统等待5秒钟，初次任务创建任务时，比较慢
                System.Threading.Thread.Sleep(1000 * waitSecond);
                //查询任务
                VideoDownloadStatus status = VideoDownloadStatus.任务创建中;
                do
                {
                    System.Threading.Thread.Sleep(500);//防止主界面假死
                    status = engine.DetectorDownloadProgress(saveFileName, "mp4", virtualWcfPath, action);
                } while (status != VideoDownloadStatus.任务结束 && status != VideoDownloadStatus.任务中断);
                #endregion

                if (status == VideoDownloadStatus.任务结束)
                {
                    //生成截图
                    FFmpegTool tool = new FFmpegTool();
                    string sourcePath = virtualWcfPath + fileNameAndExt;
                    string configPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\\ffmpeg\\ffmpeg.exe";

                    //剪切
                    tool.ShearVideo(ref sourcePath, ".mp4", totalSecond, configPath);
                    //截图                
                    string thumSrc = tool.CatchImg(sourcePath, ".mp4", thumSize, totalSecond, configPath);
                    //试看截取
                    string minFileName = UntityTool.Md5_32(videoUrl) + ".mp4";
                    string minSrc = tool.ShearMinVideo(sourcePath, minFileName, totalSecond, 60, configPath);

                    //网络路径
                    string videoSrc = sourcePath.Replace(thunderPath, domain).Replace("\\", "/");
                    string imgSrc = thumSrc.Replace(thunderPath, domain).Replace("\\", "/");
                    string minVideoSrc = minSrc.Replace(thunderPath, domain).Replace("\\", "/");

                    //资源地址
                    urlResult.Add(videoSrc);
                    urlResult.Add(imgSrc);
                    urlResult.Add(minVideoSrc);

                    if (File.Exists(virtualWcfPath + fileNameAndExt))
                    {
                        File.Delete(virtualWcfPath + fileNameAndExt);
                    }

                }

            }
            catch (Exception e)
            {
                error = "抓取错误：" + e.Message;
            }

            return urlResult;

        }

    }

    public class HttpClientHelp : HttpBase
    {

        private string _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36";
        private string _acceptLanguage = "zh-CN,zh;q=0.8";
        private string _accept = "text/html, application/xhtml+xml, */*";
        private string _acceptEncoding = "gzip, deflate";
        private string _charset = "GB2312";

        public string UserAgent { set { ChangeHeaders("User-Agent", value); } }
        public string AcceptLanguage { set { ChangeHeaders("Accept-Language", value); } }
        public string Accept { set { ChangeHeaders("Accept", value); } }
        public string Cookie { get; set; }
        public string AcceptEncoding { set { ChangeHeaders("Accept-Encoding", value); } }
        public string ContentType { get; set; } = "application/x-www-form-urlencoded";
        public string Charset { set { ChangeHeaders("Accept-Charset", value); } }
        public string TagCode { get; set; }

        private void ChangeHeaders(string name, string newHeaders)
        {
            client.DefaultRequestHeaders.Remove(name);
            client.DefaultRequestHeaders.Add(name, newHeaders);
        }

        public void AddHeaders(string name, string values)
        {
            client.DefaultRequestHeaders.Add(name, values);
        }

        public void SetAuthorizationHead(string name, string password)
        {
            string str = string.Format("{0}:{1}", name, password);
            AuthenticationHeaderValue authValue = new AuthenticationHeaderValue("Basic", str.ToBase64(Encoding.UTF8));
            client.DefaultRequestHeaders.Authorization = authValue;
        }



        HttpClient client = null;
        //fiddler 代理
        bool IsProxy = bool.Parse(UntityTool.GetConfigValue("IsProxy"));
        public HttpClientHelp()
        {
            if (IsProxy)
            {
                client = new HttpClient(new HttpClientHandler()
                {
                    UseCookies = true,
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.GZip,
                    Proxy = new WebProxy("127.0.0.1", 8888),//8888 fiddler 端口
                    UseProxy = true
                });
            }
            else
            {
                client = new HttpClient(new HttpClientHandler()
                {
                    UseCookies = true,
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.GZip
                });
            }

            client.Timeout = TimeSpan.FromSeconds(180);
            client.DefaultRequestHeaders.Add("Accept", _accept);
            client.DefaultRequestHeaders.Add("Accept-Language", _acceptLanguage);
            client.DefaultRequestHeaders.Add("Accept-Encoding", _acceptEncoding);
            client.DefaultRequestHeaders.Add("User-Agent", _userAgent);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Accept-Charset", _charset);
        }


        #region HttpClient

        public string Get(string url, string postDataStr = "")
        {
            try
            {

                string content = string.Empty;

                HttpResponseMessage result = client.GetAsync(url + (postDataStr == "" ? "" : "?") + postDataStr).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //IIS可能会有静态压缩 gbk5 编码，统一转码为本地编码
                    byte[] srcBytes = result.Content.ReadAsByteArrayAsync().Result;
                    content = Encoding.Default.GetString(srcBytes);
                }
                return content;
            }
            catch (Exception ex)
            {
                throw new Exception("Http网络请求：" + ex.Message);
            }
        }

        /// <summary>
        /// post提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string Post(string url, Dictionary<string, string> dic)
        {
            try
            {
                string content = string.Empty;
                HttpContent requestContent = new FormUrlEncodedContent(dic);
                HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    content = result.Content.ReadAsStringAsync().Result;
                }
                return content;
            }
            catch (Exception ex)
            {
                throw new Exception("Http网络请求：" + ex.Message);
            }
        }

        /// <summary>
        /// 表单提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name=""></param>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public string Post(string url, string fileName, byte[] bytes)
        {
            try
            {
                string content = string.Empty;
                MultipartFormDataContent requestContent = new MultipartFormDataContent();
                requestContent.Add(CreateFileContent(bytes, fileName, "application/octet-stream"));
                HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    content = result.Content.ReadAsStringAsync().Result;
                }

                return content;
            }
            catch (Exception ex)
            {
                throw new Exception("Http网络请求：" + ex.Message);
            }
        }

        private HttpContent CreateFileContent(byte[] bytes, string fileName, string contentType)
        {
            //var fileContent = new ByteArrayContent(bytes);
            //fileContent.Headers.Clear();
            //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            //{
            //    Name = "\"media\"",//微信端上传文件固定是media,普通post为file
            //    FileName = "\"" + fileName + "\""
            //};
            //fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            var fileContent = new ByteArrayContent(bytes);
            fileContent.Headers.Clear();
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = "\"" + fileName + "\""
            }; // the extra quotes are key here
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return fileContent;
        }


        /// <summary>
        /// post body字符参数提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string Post(string url, string param, string bodyContentType = "application/x-www-form-urlencoded")
        {
            try
            {
                string content = string.Empty;
                HttpContent requestContent = new StringContent(param);
                requestContent.Headers.ContentType = new MediaTypeHeaderValue(bodyContentType);
                HttpResponseMessage result = client.PostAsync(url, requestContent).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    content = result.Content.ReadAsStringAsync().Result;
                }
                return content;
            }
            catch (Exception ex)
            {
                throw new Exception("Http网络请求：" + ex.Message);
            }
        }





        #endregion

    }

    public class WebRequestHelp : HttpBase
    {
        #region WebRequest


        /// <summary>
        /// WebRequest Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="bf"></param>
        /// <returns></returns>
        public string WebRequestPost(string url, string fileName, byte[] bf)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            //请求头部信息 
            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bf, 0, bf.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            string content = sr.ReadToEnd();
            return content;
        }

        /// <summary>
        /// WebRequest Get
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public string WebRequestHttpGet(string Url, string postDataStr = "", int retryCount = 1)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Timeout = 1000 * 40;//超时时间 40秒
                request.Accept = "text/html, application/xhtml+xml, image/jxr, */*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36";
                request.KeepAlive = true;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");


                string retString = string.Empty;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //超时重试3次
                if (response.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    retryCount++;
                    if (retryCount <= 3)
                    {
                        retString = WebRequestHttpGet(Url + string.Format("?r={0}", retryCount), postDataStr, retryCount);
                    }
                }
                else
                {
                    //Stream myResponseStream = response.GetResponseStream();
                    //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.Default);
                    //retString = myStreamReader.ReadToEnd();
                    //myStreamReader.Close();
                    //myResponseStream.Close();

                    retString = GetHtml(response);

                }
                return retString;
            }
            catch (Exception ex)
            {
                throw new Exception("Http网络请求：" + ex.Message);
            }
        }



        /// <summary>
        /// 解析响应报文内容
        /// </summary>
        /// <param name="webResponse"></param>
        /// <returns></returns>
        public string GetHtml(HttpWebResponse webResponse)
        {

            string htmlCode = string.Empty;
            //获取目标网站的编码格式
            string contentype = webResponse.Headers["Content-Type"];
            Regex regex = new Regex("charset\\s*=\\s*[\\W]?\\s*([\\w-]+)", RegexOptions.IgnoreCase);
            if (webResponse.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (var zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                    {

                        //匹配编码格式
                        if (regex.IsMatch(contentype))
                        {
                            Encoding ending = Encoding.GetEncoding(regex.Match(contentype).Groups[1].Value.Trim());
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, ending))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            else
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.Default))
                    {
                        htmlCode = sr.ReadToEnd();
                    }
                }
            }
            return htmlCode;
        }


        #endregion
    }
}
