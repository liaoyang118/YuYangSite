using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderAgentLib;
using System.IO;
using static Site.Untity.SiteEnum;

namespace Site.Untity
{
    /// <summary>
    /// 迅雷下载Com组件,只能添加任务下载，不能获取到其它任务信息
    /// </summary>
    public class ThunderComLib
    {
        AgentClass agent = null;

        DateTime? taskBeginTime = null;
        DateTime? taskEndTime = null;
        DateTime? taskExcuteTime = null;
        decimal totalMb = 0.00m;

        public ThunderComLib()
        {
            agent = new AgentClass();
        }


        /// <summary>
        /// 添加下载任务
        /// </summary>
        /// <param name="pURL">目标URL</param>
        /// <param name="pFileName">另存名称</param>
        /// <param name="pPath">存储目录</param>
        /// <param name="pComments">下载注释</param>
        /// <param name="pReferURL">引用页URL</param>
        /// <param name="nStartMode">开始模式，0手工开始，1立即开始，默认为-1，表示由迅雷处理</param>
        /// <param name="nOnlyFromOrigin">是否只从原始URL下载，1只从原始URL下载，0多资源下载，默认为0</param>
        /// <param name="nOriginThreadCount">原始地址下载线程数，范围1-10，默认为-1，表示由迅雷处理</param>
        public void AddTask(string pURL, string pFileName, string pPath, string pComments = "", string pReferURL = "", int nStartMode = 1, int nOnlyFromOrigin = 0, int nOriginThreadCount = 5)
        {
            /*
                运行的时候会弹出窗口，工具》配置》高级》通过IE右键菜单“使用迅雷下载”添加任务，将这项去掉;
             */
            agent.AddTask(pURL, pFileName, pPath, pComments, pReferURL, nStartMode, nOnlyFromOrigin, nOriginThreadCount);

            //提交任务
            agent.CommitTasks2(1);
        }

        /// <summary>
        /// 取消所有 AddTask 添加的任务
        /// </summary>
        public void CancelTasks()
        {
            /*
             注意：如果AddTask添加的任务没有被提交没有被取消（调用CancelTasks），则Agent对象析构时会阻塞，所以调用者不应该残留一些没有被提交或者取消的任务，以避免脚本执行者停止响应。
             */
            agent.CancelTasks();
        }

        /// <summary>
        /// 获取任务信息[暂时无法获取属性信息]
        /// </summary>
        /// <param name="pURL">任务下载地址</param>
        /// <param name="pFileName">任务下载文件名称</param>
        /// <param name="callback">信息反馈</param>
        [Obsolete]
        public Dictionary<string, string> GetTaskInfo(string pURL, Action<string> callback = null)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            /*
             返回值

            “Exists”	”true”存在，”false”不存在

            “Path”		存储目录，最后带反斜线"，例：C:"TDDownload"

            “FileName”	文件名称

            “FileSize”	文件大小，以字节为单位，0表示大小未知

            “CompletedSize”	已下载大小，以字节为单位

            “Percent”	下载进度，带1位小数，例：70.0

            “Status”	任务状态，有以下6种状态 
			            “running”： 运行状态 
			            “stopped”： 停止状态 
			            “failed”： 失败状态 
			            “success”： 成功状态 
			            “creatingfile”：正在创建数据文件 
			            “connecting”： 正在连接            
             
             
             */
            string Exists = agent.GetTaskInfo(pURL, "Exists");
            string Path = agent.GetTaskInfo(pURL, "Path");
            string FileName = agent.GetTaskInfo(pURL, "FileName");
            string FileSize = agent.GetTaskInfo(pURL, "FileSize");
            string CompletedSize = agent.GetTaskInfo(pURL, "CompletedSize");
            string Percent = agent.GetTaskInfo(pURL, "Percent");
            string Status = agent.GetTaskInfo(pURL, "Status");

            dic["Exists"] = Exists;
            dic["Path"] = Path;
            dic["FileName"] = FileName;
            dic["FileSize"] = FileSize;
            dic["CompletedSize"] = CompletedSize;
            dic["Percent"] = Percent;
            dic["Status"] = Status;

            return dic;
        }

        [Obsolete]
        public List<string> Test(string name)
        {
            List<string> list = new List<string>();
            list.Add(agent.GetInfo(name));

            return list;
        }


        /// <summary>
        /// 监控下载进度
        /// </summary>
        /// <param name="fileName">保存的文件名称</param>
        /// <param name="fileExt">文件的后缀，不带.</param>
        /// <param name="filePath">保存文件的文件夹绝对路径</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public VideoDownloadStatus DetectorDownloadProgress(string fileName, string fileExt, string filePath, Action<string, string> action)
        {

            VideoDownloadStatus downLoadSuccess = VideoDownloadStatus.任务执行中;
            string detectorFilePath = string.Empty;


            if (Directory.Exists(filePath))
            {
                string fullName = string.Format("{0}{1}.{2}", filePath, fileName, fileExt);
                string tdFileName = string.Format("{0}.xltd", fullName);



                if (File.Exists(fullName))
                {
                    //已经下载完毕
                    downLoadSuccess = VideoDownloadStatus.任务结束;
                    detectorFilePath = fullName;
                }
                else
                {
                    if (File.Exists(tdFileName))
                    {
                        detectorFilePath = tdFileName;
                        //下载中
                        downLoadSuccess = VideoDownloadStatus.任务执行中;

                        if (taskExcuteTime == null)
                        {
                            taskExcuteTime = DateTime.Now;
                        }

                        if (totalMb > 0)
                        {
                            int seconds = (int)((totalMb * 1024) / 50);//总大小，按照50Kb/s 时间估算
                            if (DateTime.Now.AddSeconds(-seconds) > taskExcuteTime)
                            {
                                //长时间未下载完毕，自动放弃该任务
                                downLoadSuccess = VideoDownloadStatus.任务中断;
                            }
                        }
                    }
                    else
                    {
                        if (taskBeginTime == null)
                        {
                            taskBeginTime = DateTime.Now;
                        }
                        taskEndTime = DateTime.Now;

                        if (taskEndTime.Value.AddSeconds(-60) > taskBeginTime)
                        {
                            //下载任务还未创建成功
                            downLoadSuccess = VideoDownloadStatus.任务中断;
                        }
                        else
                        {
                            downLoadSuccess = VideoDownloadStatus.任务创建中;
                        }

                    }
                }
            }
            else
            {
                downLoadSuccess = VideoDownloadStatus.任务中断;
            }

            if (!string.IsNullOrEmpty(detectorFilePath) && totalMb == 0)
            {
                using (FileStream fs = new FileStream(detectorFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    totalMb = (fs.Length * 1.00m) / (1024 * 1024 * 1.00m);
                }
            }

            action.Invoke(string.Format("{0}Mb", totalMb.ToString("#0.00")), downLoadSuccess.ToString());


            return downLoadSuccess;
        }


    }
}
