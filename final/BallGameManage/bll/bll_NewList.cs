
using System;
using System.Data;
using System.Collections.Generic;
using Dal;
using Entity;
namespace Bll
{
	/// <summary>
	/// News
	/// </summary>
	public partial class bll_NewList
	{
        private dal_NewList dal = new dal_NewList();
        dal_Help help = new dal_Help();


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页显示的多少条数据</param>
        /// <param name="recordCount">数据的总数</param>
        /// <returns></returns>
        public DataTable GetDataPager(int pageIndex, int pageSize, ref int recordCount, string where, string fieldShow)
        {
            string tableName = "News";
            string fieldKey = "sid";
            string fieldOrder = "";
            fieldOrder = "CreateTime desc";
            return help.GetDataPager(tableName, fieldKey, fieldShow, fieldOrder, pageIndex, pageSize, where,
                                        ref recordCount);
        }

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(entity_News model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(entity_News model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sid)
		{
			
			return dal.Delete(sid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			return dal.DeleteList(sidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public entity_News GetModel(string sid)
		{
			
			return dal.GetModel(sid);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public entity_News GetEntity(string type)
        {

            return dal.GetEntity(type);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<entity_News> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<entity_News> DataTableToList(DataTable dt)
		{
            List<entity_News> modelList = new List<entity_News>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                entity_News model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
	}
}

