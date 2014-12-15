
using System;
namespace Entity
{
	/// <summary>
	/// T_ScheduleMain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_ScheduleMain
	{
		public entity_ScheduleMain()
		{}
		#region Model
		private string _sid;
		private string _name;
        private DateTime _createrTime;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreaterTime
        {
            get { return _createrTime; }
            set { _createrTime = value; }
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

