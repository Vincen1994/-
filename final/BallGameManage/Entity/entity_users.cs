using System;
namespace Entity
{
	/// <summary>
	/// users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_users
	{
		#region Model
		private string _sid;
		private string _userid;
		private string _password;
        private string _RealName;

        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        private DateTime _CreatedTime;

        public DateTime CreatedTime
        {
            get { return _CreatedTime; }
            set { _CreatedTime = value; }
        } 
		/// <summary>
		/// 
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		#endregion Model

	}
}

