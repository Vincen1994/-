
using System;
namespace Entity
{
	/// <summary>
	/// entity_ScheduleDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_ScheduleDetail
	{
		public entity_ScheduleDetail()
		{}
		#region Model
		private string _sid;
		private string _homecourt;
		private string _homecourtname;
		private int? _homecourt_fraction;
		private string _away;
		private string _awayname;
		private int? _away_fraction;
		private int? _state;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private string _t_extend1;
		private string _t_extend2;
		private string _t_extend3;
        private DateTime _CreaterTime;

        public DateTime CreaterTime
        {
            get { return _CreaterTime; }
            set { _CreaterTime = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeCourt
		{
			set{ _homecourt=value;}
			get{return _homecourt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeCourtName
		{
			set{ _homecourtname=value;}
			get{return _homecourtname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? HomeCourt_Fraction
		{
			set{ _homecourt_fraction=value;}
			get{return _homecourt_fraction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string away
		{
			set{ _away=value;}
			get{return _away;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string awayName
		{
			set{ _awayname=value;}
			get{return _awayname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? away_Fraction
		{
			set{ _away_fraction=value;}
			get{return _away_fraction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}

        /// <summary>
        /// 字段转义：状态
        /// </summary>
        public System.String hh_State
        {
            get
            {
                switch (State.ToString())
                {
                    case "0": return "未开始";
                    case "1": return "比赛中";
                    case "2": return "已结束";
                    default: return "[" + State + "]";
                }

            }
            set { }
        }


		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string T_Extend1
		{
			set{ _t_extend1=value;}
			get{return _t_extend1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string T_Extend2
		{
			set{ _t_extend2=value;}
			get{return _t_extend2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string T_Extend3
		{
			set{ _t_extend3=value;}
			get{return _t_extend3;}
		}
		#endregion Model

	}
}

