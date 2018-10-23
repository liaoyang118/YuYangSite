

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Videos.DataAccess.Model
{

	[Serializable]
	public partial class AdvertisingInfo
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
		
		#region a_id
		private string _a_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string a_id 
		{ 
			get { return _a_id; } 
			set { _a_id = value; } 
		
		}
		#endregion
		
		#region a_name
		private string _a_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string a_name 
		{ 
			get { return _a_name; } 
			set { _a_name = value; } 
		
		}
		#endregion
		
		#region a_type
		private int? _a_type;
       
        /// <summary>
        /// 图片、视频
        /// </summary>        
        public int? a_type 
		{ 
			get { return _a_type; } 
			set { _a_type = value; } 
		
		}
		#endregion
		
		#region a_src
		private string _a_src;
       
        /// <summary>
        /// 
        /// </summary>        
        public string a_src 
		{ 
			get { return _a_src; } 
			set { _a_src = value; } 
		
		}
		#endregion
		
		#region a_second
		private int? _a_second;
       
        /// <summary>
        /// 秒
        /// </summary>        
        public int? a_second 
		{ 
			get { return _a_second; } 
			set { _a_second = value; } 
		
		}
		#endregion
		
		#region a_status
		private int? _a_status;
       
        /// <summary>
        /// 0 无效 1 有效
        /// </summary>        
        public int? a_status 
		{ 
			get { return _a_status; } 
			set { _a_status = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class ComboInfo
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
		
		#region c_id
		private string _c_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_id 
		{ 
			get { return _c_id; } 
			set { _c_id = value; } 
		
		}
		#endregion
		
		#region c_title
		private string _c_title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_title 
		{ 
			get { return _c_title; } 
			set { _c_title = value; } 
		
		}
		#endregion
		
		#region c_intro
		private string _c_intro;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_intro 
		{ 
			get { return _c_intro; } 
			set { _c_intro = value; } 
		
		}
		#endregion
		
		#region c_num
		private int? _c_num;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? c_num 
		{ 
			get { return _c_num; } 
			set { _c_num = value; } 
		
		}
		#endregion
		
		#region c_days
		private int? _c_days;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? c_days 
		{ 
			get { return _c_days; } 
			set { _c_days = value; } 
		
		}
		#endregion
		
		#region c_status
		private int? _c_status;
       
        /// <summary>
        /// 0 无效 1 生效
        /// </summary>        
        public int? c_status 
		{ 
			get { return _c_status; } 
			set { _c_status = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class NoticeInfo
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
		
		#region n_id
		private string _n_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string n_id 
		{ 
			get { return _n_id; } 
			set { _n_id = value; } 
		
		}
		#endregion
		
		#region n_title
		private string _n_title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string n_title 
		{ 
			get { return _n_title; } 
			set { _n_title = value; } 
		
		}
		#endregion
		
		#region n_content
		private string _n_content;
       
        /// <summary>
        /// 
        /// </summary>        
        public string n_content 
		{ 
			get { return _n_content; } 
			set { _n_content = value; } 
		
		}
		#endregion
		
		#region n_beginTime
		private DateTime? _n_beginTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? n_beginTime 
		{ 
			get { return _n_beginTime; } 
			set { _n_beginTime = value; } 
		
		}
		#endregion
		
		#region n_endTime
		private DateTime? _n_endTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? n_endTime 
		{ 
			get { return _n_endTime; } 
			set { _n_endTime = value; } 
		
		}
		#endregion
		
		#region n_status
		private int? _n_status;
       
        /// <summary>
        /// 0 无效 1 有效
        /// </summary>        
        public int? n_status 
		{ 
			get { return _n_status; } 
			set { _n_status = value; } 
		
		}
		#endregion
		
		#region n_createTime
		private DateTime? _n_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? n_createTime 
		{ 
			get { return _n_createTime; } 
			set { _n_createTime = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class RechargeRecoder
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
		
		#region r_id
		private string _r_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_id 
		{ 
			get { return _r_id; } 
			set { _r_id = value; } 
		
		}
		#endregion
		
		#region r_u_id
		private string _r_u_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_u_id 
		{ 
			get { return _r_u_id; } 
			set { _r_u_id = value; } 
		
		}
		#endregion
		
		#region r_c_id
		private string _r_c_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_c_id 
		{ 
			get { return _r_c_id; } 
			set { _r_c_id = value; } 
		
		}
		#endregion
		
		#region r_c_title
		private string _r_c_title;
       
        /// <summary>
        /// 
        /// </summary>        
        public string r_c_title 
		{ 
			get { return _r_c_title; } 
			set { _r_c_title = value; } 
		
		}
		#endregion
		
		#region r_money
		private decimal? _r_money;
       
        /// <summary>
        /// 
        /// </summary>        
        public decimal? r_money 
		{ 
			get { return _r_money; } 
			set { _r_money = value; } 
		
		}
		#endregion
		
		#region r_c_days
		private int? _r_c_days;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? r_c_days 
		{ 
			get { return _r_c_days; } 
			set { _r_c_days = value; } 
		
		}
		#endregion
		
		#region r_createTime
		private DateTime? _r_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? r_createTime 
		{ 
			get { return _r_createTime; } 
			set { _r_createTime = value; } 
		
		}
		#endregion
		
		#region r_u_expriseTime
		private DateTime? _r_u_expriseTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? r_u_expriseTime 
		{ 
			get { return _r_u_expriseTime; } 
			set { _r_u_expriseTime = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class UserInfo
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
		
		#region 唯一Id
		private string _唯一Id;
       
        /// <summary>
        /// 唯一Id
        /// </summary>        
        public string 唯一Id 
		{ 
			get { return _唯一Id; } 
			set { _唯一Id = value; } 
		
		}
		#endregion
		
		#region u_name
		private string _u_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_name 
		{ 
			get { return _u_name; } 
			set { _u_name = value; } 
		
		}
		#endregion
		
		#region u_pwd
		private string _u_pwd;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_pwd 
		{ 
			get { return _u_pwd; } 
			set { _u_pwd = value; } 
		
		}
		#endregion
		
		#region u_level
		private int? _u_level;
       
        /// <summary>
        /// 0普通用户；1 周用户 ；2 月用户；3 年用户
        /// </summary>        
        public int? u_level 
		{ 
			get { return _u_level; } 
			set { _u_level = value; } 
		
		}
		#endregion
		
		#region u_expriseTime
		private DateTime? _u_expriseTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? u_expriseTime 
		{ 
			get { return _u_expriseTime; } 
			set { _u_expriseTime = value; } 
		
		}
		#endregion
		
		#region u_regTime
		private DateTime? _u_regTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? u_regTime 
		{ 
			get { return _u_regTime; } 
			set { _u_regTime = value; } 
		
		}
		#endregion
		
		#region u_status
		private int? _u_status;
       
        /// <summary>
        /// 0 无效；1 正常
        /// </summary>        
        public int? u_status 
		{ 
			get { return _u_status; } 
			set { _u_status = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class UserVisitsInfo
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
		
		#region u_id
		private string _u_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string u_id 
		{ 
			get { return _u_id; } 
			set { _u_id = value; } 
		
		}
		#endregion
		
		#region v_id
		private string _v_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_id 
		{ 
			get { return _v_id; } 
			set { _v_id = value; } 
		
		}
		#endregion
		
		#region v_ip
		private string _v_ip;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_ip 
		{ 
			get { return _v_ip; } 
			set { _v_ip = value; } 
		
		}
		#endregion
		
		#region platform
		private string _platform;
       
        /// <summary>
        /// 
        /// </summary>        
        public string platform 
		{ 
			get { return _platform; } 
			set { _platform = value; } 
		
		}
		#endregion
		
		#region v_url
		private string _v_url;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_url 
		{ 
			get { return _v_url; } 
			set { _v_url = value; } 
		
		}
		#endregion
		
		#region v_time
		private DateTime? _v_time;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? v_time 
		{ 
			get { return _v_time; } 
			set { _v_time = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class VideoCate
    {
        
		#region c_id
		private int _c_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int c_id 
		{ 
			get { return _c_id; } 
			set { _c_id = value; } 
		
		}
		#endregion
		
		#region c_name
		private string _c_name;
       
        /// <summary>
        /// 
        /// </summary>        
        public string c_name 
		{ 
			get { return _c_name; } 
			set { _c_name = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class VideoInfo
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
		
		#region v_id
		private string _v_id;
       
        /// <summary>
        /// 唯一Id
        /// </summary>        
        public string v_id 
		{ 
			get { return _v_id; } 
			set { _v_id = value; } 
		
		}
		#endregion
		
		#region v_c_id
		private int? _v_c_id;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? v_c_id 
		{ 
			get { return _v_c_id; } 
			set { _v_c_id = value; } 
		
		}
		#endregion
		
		#region v_c_name
		private string _v_c_name;
       
        /// <summary>
        /// 分类名称
        /// </summary>        
        public string v_c_name 
		{ 
			get { return _v_c_name; } 
			set { _v_c_name = value; } 
		
		}
		#endregion
		
		#region v_titile
		private string _v_titile;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_titile 
		{ 
			get { return _v_titile; } 
			set { _v_titile = value; } 
		
		}
		#endregion
		
		#region v_intro
		private string _v_intro;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_intro 
		{ 
			get { return _v_intro; } 
			set { _v_intro = value; } 
		
		}
		#endregion
		
		#region v_coverImgSrc
		private string _v_coverImgSrc;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_coverImgSrc 
		{ 
			get { return _v_coverImgSrc; } 
			set { _v_coverImgSrc = value; } 
		
		}
		#endregion
		
		#region v_playSrc
		private string _v_playSrc;
       
        /// <summary>
        /// 
        /// </summary>        
        public string v_playSrc 
		{ 
			get { return _v_playSrc; } 
			set { _v_playSrc = value; } 
		
		}
		#endregion
		
		#region v_timeLength
		private string _v_timeLength;
       
        /// <summary>
        /// HH:mm:ss
        /// </summary>        
        public string v_timeLength 
		{ 
			get { return _v_timeLength; } 
			set { _v_timeLength = value; } 
		
		}
		#endregion
		
		#region v_createTime
		private DateTime? _v_createTime;
       
        /// <summary>
        /// 
        /// </summary>        
        public DateTime? v_createTime 
		{ 
			get { return _v_createTime; } 
			set { _v_createTime = value; } 
		
		}
		#endregion
		
		#region v_status
		private int? _v_status;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? v_status 
		{ 
			get { return _v_status; } 
			set { _v_status = value; } 
		
		}
		#endregion
		
    }
	
}