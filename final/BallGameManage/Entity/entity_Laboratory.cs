
using System;
namespace Entity
{
	/// <summary>
	/// Laboratory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_Laboratory
	{
		
		#region Model
		private string _sid;
		private string _name;
		private string _code;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
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

