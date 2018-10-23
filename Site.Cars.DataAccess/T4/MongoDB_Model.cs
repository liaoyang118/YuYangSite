

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Site.Cars.DataAccess.Model
{

	[Serializable]
	public partial class Mongo_CarsCate
    {
		#region
		/// <summary>
        /// Monogdb 自带唯一ID
        /// </summary>
		public ObjectId Id{get;set;}

		#endregion


        
		#region CateName
		private string _CateName;
       
        /// <summary>
        /// 分类名称
        /// </summary>        
        public string CateName 
		{ 
			get { return _CateName; } 
			set { _CateName = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Mongo_CarsInfo
    {
		#region
		/// <summary>
        /// Monogdb 自带唯一ID
        /// </summary>
		public ObjectId Id{get;set;}

		#endregion


        
		#region FullName
		private string _FullName;
       
        /// <summary>
        /// 国外全称
        /// </summary>        
        public string FullName 
		{ 
			get { return _FullName; } 
			set { _FullName = value; } 
		
		}
		#endregion
		
		#region FullNameCN
		private string _FullNameCN;
       
        /// <summary>
        /// 国内全称
        /// </summary>        
        public string FullNameCN 
		{ 
			get { return _FullNameCN; } 
			set { _FullNameCN = value; } 
		
		}
		#endregion
		
		#region Price
		private decimal? _Price;
       
        /// <summary>
        /// 国外价格
        /// </summary>        
        public decimal? Price 
		{ 
			get { return _Price; } 
			set { _Price = value; } 
		
		}
		#endregion
		
		#region PriceUnti
		private string _PriceUnti;
       
        /// <summary>
        /// 国外价格标示：美元、澳元、人民币...
        /// </summary>        
        public string PriceUnti 
		{ 
			get { return _PriceUnti; } 
			set { _PriceUnti = value; } 
		
		}
		#endregion
		
		#region Used
		private bool? _Used;
       
        /// <summary>
        /// 是否新车
        /// </summary>        
        public bool? Used 
		{ 
			get { return _Used; } 
			set { _Used = value; } 
		
		}
		#endregion
		
		#region Kilometres
		private int? _Kilometres;
       
        /// <summary>
        /// 
        /// </summary>        
        public int? Kilometres 
		{ 
			get { return _Kilometres; } 
			set { _Kilometres = value; } 
		
		}
		#endregion
		
		#region Colour
		private string _Colour;
       
        /// <summary>
        /// 颜色
        /// </summary>        
        public string Colour 
		{ 
			get { return _Colour; } 
			set { _Colour = value; } 
		
		}
		#endregion
		
		#region Transmission
		private string _Transmission;
       
        /// <summary>
        /// 7速运动自动双离合器
        /// </summary>        
        public string Transmission 
		{ 
			get { return _Transmission; } 
			set { _Transmission = value; } 
		
		}
		#endregion
		
		#region Body
		private string _Body;
       
        /// <summary>
        /// 2门2座
        /// </summary>        
        public string Body 
		{ 
			get { return _Body; } 
			set { _Body = value; } 
		
		}
		#endregion
		
		#region BodyType
		private string _BodyType;
       
        /// <summary>
        /// convertible 敞篷车
        /// </summary>        
        public string BodyType 
		{ 
			get { return _BodyType; } 
			set { _BodyType = value; } 
		
		}
		#endregion
		
		#region DriveType
		private string _DriveType;
       
        /// <summary>
        /// 后轮驱动
        /// </summary>        
        public string DriveType 
		{ 
			get { return _DriveType; } 
			set { _DriveType = value; } 
		
		}
		#endregion
		
		#region Engine
		private string _Engine;
       
        /// <summary>
        /// 6缸汽油吸入2.9L
        /// </summary>        
        public string Engine 
		{ 
			get { return _Engine; } 
			set { _Engine = value; } 
		
		}
		#endregion
		
		#region ReleaseDate
		private string _ReleaseDate;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ReleaseDate 
		{ 
			get { return _ReleaseDate; } 
			set { _ReleaseDate = value; } 
		
		}
		#endregion
		
		#region BuildDate
		private string _BuildDate;
       
        /// <summary>
        /// 
        /// </summary>        
        public string BuildDate 
		{ 
			get { return _BuildDate; } 
			set { _BuildDate = value; } 
		
		}
		#endregion
		
		#region ComplianceDate
		private string _ComplianceDate;
       
        /// <summary>
        /// 
        /// </summary>        
        public string ComplianceDate 
		{ 
			get { return _ComplianceDate; } 
			set { _ComplianceDate = value; } 
		
		}
		#endregion
		
		#region FuelEconomyCombined
		private string _FuelEconomyCombined;
       
        /// <summary>
        /// 
        /// </summary>        
        public string FuelEconomyCombined 
		{ 
			get { return _FuelEconomyCombined; } 
			set { _FuelEconomyCombined = value; } 
		
		}
		#endregion
		
		#region TransmissionType
		private string _TransmissionType;
       
        /// <summary>
        /// 自动
        /// </summary>        
        public string TransmissionType 
		{ 
			get { return _TransmissionType; } 
			set { _TransmissionType = value; } 
		
		}
		#endregion
		
		#region AreaId
		private string _AreaId;
       
        /// <summary>
        /// 所属国家Id
        /// </summary>        
        public string AreaId 
		{ 
			get { return _AreaId; } 
			set { _AreaId = value; } 
		
		}
		#endregion
		
		#region CarsCateId
		private string _CarsCateId;
       
        /// <summary>
        /// 汽车分类Id
        /// </summary>        
        public string CarsCateId 
		{ 
			get { return _CarsCateId; } 
			set { _CarsCateId = value; } 
		
		}
		#endregion
		
		#region CarsCoverSrc
		private string _CarsCoverSrc;
       
        /// <summary>
        /// 汽车封面地址
        /// </summary>        
        public string CarsCoverSrc 
		{ 
			get { return _CarsCoverSrc; } 
			set { _CarsCoverSrc = value; } 
		
		}
		#endregion
		
    }
	[Serializable]
	public partial class Mongo_Worlds
    {
		#region
		/// <summary>
        /// Monogdb 自带唯一ID
        /// </summary>
		public ObjectId Id{get;set;}

		#endregion


        
		#region AreaId
		private int? _AreaId;
       
        /// <summary>
        /// 大陆板块
        /// </summary>        
        public int? AreaId 
		{ 
			get { return _AreaId; } 
			set { _AreaId = value; } 
		
		}
		#endregion
		
		#region ParentId
		private int? _ParentId;
       
        /// <summary>
        /// 国家所属板块ID,板块ID默认为0
        /// </summary>        
        public int? ParentId 
		{ 
			get { return _ParentId; } 
			set { _ParentId = value; } 
		
		}
		#endregion
		
		#region Name
		private string _Name;
       
        /// <summary>
        /// 名称
        /// </summary>        
        public string Name 
		{ 
			get { return _Name; } 
			set { _Name = value; } 
		
		}
		#endregion
		
    }
	
}