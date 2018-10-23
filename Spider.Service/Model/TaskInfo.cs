using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Spider.Service.Model
{
    [Serializable]
    public class TaskInfo
    {
        public string TaskName { get; set; }
        public int IsStart { get; set; }
        public int IsCompensate { get; set; }
        public string IocName { get; set; }
        public string LastUpdateTime { get; set; }
        public int PageNums { get; set; }
        public int FictionNums { get; set; }
        public int Nums { get; set; }
        public int UpdateGrowNums { get; set; }


        int _predictThreadNums;
        /// <summary>
        /// 预估总并发线程数
        /// </summary>
        public int PredictThreadNums
        {
            get { return PageNums * 8 * FictionNums * Nums; }
            set
            {
                _predictThreadNums = value;
            }
        }

    }

    /// <summary>
    /// 任务配置信息模型
    /// </summary>
    [Serializable]
    public class TaskList
    {
        public List<TaskInfo> TaskInfos { get; set; }
    }
}
