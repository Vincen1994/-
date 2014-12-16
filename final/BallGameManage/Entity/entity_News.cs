using System;
namespace Entity
{
	/// <summary>
	/// News:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_News
	{
		#region Model
		private string _sid;
		private string _title;
		private string _content;
		private string _createtime;
		private string _type;
		private string _createpeople;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreatePeople
		{
			set{ _createpeople=value;}
			get{return _createpeople;}
		}
		#endregion Model

	}
}

