using System;
namespace Entity
{
	/// <summary>
	/// ImageList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class entity_ImageList
	{
		#region Model
		private string _sid;
		private string _name;
		private string _url;
		private string _bookname;
        private string _type;
        private string _pid;

        /// <summary>
        /// 父类ID
        /// </summary>
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        /// <summary>
        ///  图片类型
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        } 
		/// <summary>
		/// SID
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 图片名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 路径
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 相册名
		/// </summary>
		public string bookName
		{
			set{ _bookname=value;}
			get{return _bookname;}
		}
		#endregion Model

	}
}

