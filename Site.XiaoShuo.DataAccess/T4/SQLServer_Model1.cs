

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.XiaoShuo.DataAccess.Model
{

	[Serializable]
	public partial class ChapterList
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region F_ID
		private int _F_ID;
       
        /// <summary>
        /// 
        /// </summary>        
        public int F_ID 
		{ 
			get { return _F_ID; } 
			set { _F_ID = value; } 
		
		}
		#endregion
		
		#region ChapterName
		private string _ChapterName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ChapterName 
		{ 
			get { return _ChapterName; } 
			set { _ChapterName = value; } 
		
		}
		#endregion
		
		#region ChapterIndex
		private string _ChapterIndex;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ChapterIndex 
		{ 
			get { return _ChapterIndex; } 
			set { _ChapterIndex = value; } 
		
		}
		#endregion
		
		#region ChapterContent
		private string _ChapterContent;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ChapterContent 
		{ 
			get { return _ChapterContent; } 
			set { _ChapterContent = value; } 
		
		}
		#endregion
		
		#region UpdateTime
		private DateTime _UpdateTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime UpdateTime 
		{ 
			get { return _UpdateTime; } 
			set { _UpdateTime = value; } 
		
		}
		#endregion
		
		#region ChapterSort
		private int _ChapterSort;
       
        /// <summary>
        /// 
        /// </summary>        
        public int ChapterSort 
		{ 
			get { return _ChapterSort; } 
			set { _ChapterSort = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class ChapterVisits
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region IP
		private string _IP;
       
        /// <summary>
        /// 
        /// </summary>        
        public string IP 
		{ 
			get { return _IP; } 
			set { _IP = value; } 
		
		}
		#endregion
		
		#region OS
		private string _OS;
       
        /// <summary>
        /// 
        /// </summary>        
        public string OS 
		{ 
			get { return _OS; } 
			set { _OS = value; } 
		
		}
		#endregion
		
		#region Browser
		private string _Browser;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Browser 
		{ 
			get { return _Browser; } 
			set { _Browser = value; } 
		
		}
		#endregion
		
		#region Url
		private string _Url;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Url 
		{ 
			get { return _Url; } 
			set { _Url = value; } 
		
		}
		#endregion
		
		#region Time
		private DateTime _Time;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime Time 
		{ 
			get { return _Time; } 
			set { _Time = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class ContentCate
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region CateName
		private string _CateName;
       
        /// <summary>
        /// 小说分类名称
        /// </summary>        
        public string CateName 
		{ 
			get { return _CateName; } 
			set { _CateName = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class ErrorChapter
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region F_Id
		private int _F_Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int F_Id 
		{ 
			get { return _F_Id; } 
			set { _F_Id = value; } 
		
		}
		#endregion
		
		#region Title
		private string _Title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Title 
		{ 
			get { return _Title; } 
			set { _Title = value; } 
		
		}
		#endregion
		
		#region ChapterName
		private string _ChapterName;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ChapterName 
		{ 
			get { return _ChapterName; } 
			set { _ChapterName = value; } 
		
		}
		#endregion
		
		#region ChapterUrl
		private string _ChapterUrl;
       
        /// <summary>
        /// 章节地址
        /// </summary>        
        public string ChapterUrl 
		{ 
			get { return _ChapterUrl; } 
			set { _ChapterUrl = value; } 
		
		}
		#endregion
		
		#region ExceptionMessage
		private string _ExceptionMessage;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ExceptionMessage 
		{ 
			get { return _ExceptionMessage; } 
			set { _ExceptionMessage = value; } 
		
		}
		#endregion
		
		#region DisposeStatus
		private int _DisposeStatus;
       
        /// <summary>
        /// 状态，0未处理，1已处理
        /// </summary>        
        public int DisposeStatus 
		{ 
			get { return _DisposeStatus; } 
			set { _DisposeStatus = value; } 
		
		}
		#endregion
		
		#region C_C_Id
		private int _C_C_Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int C_C_Id 
		{ 
			get { return _C_C_Id; } 
			set { _C_C_Id = value; } 
		
		}
		#endregion
		
		#region RetryCount
		private int _RetryCount;
       
        /// <summary>
        /// 尝试获取次数
        /// </summary>        
        public int RetryCount 
		{ 
			get { return _RetryCount; } 
			set { _RetryCount = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Fiction
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region Title
		private string _Title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Title 
		{ 
			get { return _Title; } 
			set { _Title = value; } 
		
		}
		#endregion
		
		#region Author
		private string _Author;
       
        /// <summary>
        /// 
        /// </summary>        
        public string Author 
		{ 
			get { return _Author; } 
			set { _Author = value; } 
		
		}
		#endregion
		
		#region Intro
		private string _Intro;
       
        /// <summary>
        /// 小说简介
        /// </summary>        
        public string Intro 
		{ 
			get { return _Intro; } 
			set { _Intro = value; } 
		
		}
		#endregion
		
		#region CoverImage
		private string _CoverImage;
       
        /// <summary>
        /// 小说封面
        /// </summary>        
        public string CoverImage 
		{ 
			get { return _CoverImage; } 
			set { _CoverImage = value; } 
		
		}
		#endregion
		
		#region C_C_ID
		private int _C_C_ID;
       
        /// <summary>
        /// 分类ID
        /// </summary>        
        public int C_C_ID 
		{ 
			get { return _C_C_ID; } 
			set { _C_C_ID = value; } 
		
		}
		#endregion
		
		#region LastUpdateChapter
		private string _LastUpdateChapter;
       
        /// <summary>
        /// 最新章节
        /// </summary>        
        public string LastUpdateChapter 
		{ 
			get { return _LastUpdateChapter; } 
			set { _LastUpdateChapter = value; } 
		
		}
		#endregion
		
		#region LastUpdateTime
		private DateTime _LastUpdateTime;
       
        /// <summary>
        /// 最后更新时间
        /// </summary>        
        public DateTime LastUpdateTime 
		{ 
			get { return _LastUpdateTime; } 
			set { _LastUpdateTime = value; } 
		
		}
		#endregion
		
		#region CompleteState
		private int _CompleteState;
       
        /// <summary>
        /// 是否已经获取完毕所有章节，如果是就直接获取更新章节
        /// </summary>        
        public int CompleteState 
		{ 
			get { return _CompleteState; } 
			set { _CompleteState = value; } 
		
		}
		#endregion
		
		#region LastChapterId
		private string _LastChapterId;
       
        /// <summary>
        /// 
        /// </summary>        
        public string LastChapterId 
		{ 
			get { return _LastChapterId; } 
			set { _LastChapterId = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class FictionVisits
    {
        
		#region Id
		private int _Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Id 
		{ 
			get { return _Id; } 
			set { _Id = value; } 
		
		}
		#endregion
		
		#region F_Id
		private int _F_Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int F_Id 
		{ 
			get { return _F_Id; } 
			set { _F_Id = value; } 
		
		}
		#endregion
		
		#region Visits
		private int _Visits;
       
        /// <summary>
        /// 
        /// </summary>        
        public int Visits 
		{ 
			get { return _Visits; } 
			set { _Visits = value; } 
		
		}
		#endregion
		
		#region C_Id
		private int _C_Id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int C_Id 
		{ 
			get { return _C_Id; } 
			set { _C_Id = value; } 
		
		}
		#endregion
		
    }
	
}