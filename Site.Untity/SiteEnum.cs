using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Site.Untity
{
    public class SiteEnum
    {
        /// <summary>
        /// 小说分类
        /// </summary>
        public enum Cate
        {
            玄幻 = 1,
            都市 = 2,
            网游 = 3,
            修真 = 4,
            其他 = 5,
            科幻 = 6,
            恐怖 = 7
        }

        /// <summary>
        /// 小说章节获取是否到最后一章 状态
        /// </summary>
        public enum CompleteState
        {
            未完成 = 0,
            完成 = 1
        }

        /// <summary>
        /// 错误章节处理状态
        /// </summary>
        public enum DisposeStatus
        {
            未处理 = 0,
            已处理 = 1
        }


        #region 汽车

        public enum PriceUnti
        {
            美元 = 0,
            人民币 = 1,
            澳元 = 2
        }


        #endregion

        #region 视频
        public enum VideoStatus
        {
            无效 = 0,
            有效 = 1
        }


        #endregion
    }
}