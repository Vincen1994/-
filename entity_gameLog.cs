
using System;
namespace Entity
{
	/// <summary>
	/// gameLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_gameLog
	{
        public entity_gameLog()
		{}
		#region Model
		private string _sid;
		private int? _score;
		private string _teamid;
		private string _teamname;
		private DateTime? _createtime;
		private string _pid;
		private string _expand1;
		private string _expand2;
		private string _expand3;
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
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeamID
		{
			set{ _teamid=value;}
			get{return _teamid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeamName
		{
			set{ _teamname=value;}
			get{return _teamname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Expand1
		{
			set{ _expand1=value;}
			get{return _expand1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Expand2
		{
			set{ _expand2=value;}
			get{return _expand2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Expand3
		{
			set{ _expand3=value;}
			get{return _expand3;}
		}
		#endregion Model

	}
}

