using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Entity;

namespace Dal
{
	/// <summary>
	/// 数据访问类:LikeList
	/// </summary>
	public partial class dal_LikeList
	{
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LikeList");
			strSql.Append(" where sid=@sid ");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = sid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(entity_LikeList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LikeList(");
			strSql.Append("sid,likeName,url,type)");
			strSql.Append(" values (");
			strSql.Append("@sid,@likeName,@url,@type)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@likeName", SqlDbType.NVarChar,200),
					new SqlParameter("@url", SqlDbType.NVarChar,200),
					new SqlParameter("@type", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.likeName;
			parameters[2].Value = model.url;
			parameters[3].Value = model.type;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(entity_LikeList model,string sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LikeList set ");
            strSql.Append("sid=@sid,");
            strSql.Append("likeName=@likeName,");
			strSql.Append("url=@url,");
			strSql.Append("type=@type");
			strSql.Append(" where sid='"+sid+"'" );
			SqlParameter[] parameters = {
					new SqlParameter("@likeName", SqlDbType.NVarChar,200),
					new SqlParameter("@url", SqlDbType.NVarChar,200),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.likeName;
			parameters[1].Value = model.url;
			parameters[2].Value = model.type;
			parameters[3].Value = model.sid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LikeList ");
			strSql.Append(" where sid=@sid ");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = sid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LikeList ");
			strSql.Append(" where sid in ("+sidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public entity_LikeList GetModel(string sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,likeName,url,type from LikeList ");
			strSql.Append(" where sid=@sid ");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = sid;

            entity_LikeList model = new entity_LikeList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public entity_LikeList DataRowToModel(DataRow row)
		{
            entity_LikeList model = new entity_LikeList();
			if (row != null)
			{
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["likeName"]!=null)
				{
					model.likeName=row["likeName"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sid,likeName,url,type ");
			strSql.Append(" FROM LikeList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" sid,likeName,url,type ");
			strSql.Append(" FROM LikeList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM LikeList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.sid desc");
			}
			strSql.Append(")AS Row, T.*  from LikeList T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "LikeList";
			parameters[1].Value = "sid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
	}
}

