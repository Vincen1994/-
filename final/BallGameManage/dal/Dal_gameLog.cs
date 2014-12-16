
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Entity;
namespace Dal
{
	/// <summary>
	/// 数据访问类:gameLog
	/// </summary>
	public partial class Dal_gameLog
	{
		public Dal_gameLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gameLog");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(entity_gameLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into gameLog(");
			strSql.Append("SID,Score,TeamID,TeamName,CreateTime,PID,Expand1,Expand2,Expand3)");
			strSql.Append(" values (");
			strSql.Append("@SID,@Score,@TeamID,@TeamName,@CreateTime,@PID,@Expand1,@Expand2,@Expand3)");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@TeamID", SqlDbType.NVarChar,50),
					new SqlParameter("@TeamName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@PID", SqlDbType.NVarChar,50),
					new SqlParameter("@Expand1", SqlDbType.NVarChar,50),
					new SqlParameter("@Expand2", SqlDbType.NVarChar,50),
					new SqlParameter("@Expand3", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SID;
			parameters[1].Value = model.Score;
			parameters[2].Value = model.TeamID;
			parameters[3].Value = model.TeamName;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.PID;
			parameters[6].Value = model.Expand1;
			parameters[7].Value = model.Expand2;
			parameters[8].Value = model.Expand3;

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
        public bool Update(entity_gameLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gameLog set ");
			strSql.Append("Score=@Score,");
			strSql.Append("TeamID=@TeamID,");
			strSql.Append("TeamName=@TeamName,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("PID=@PID,");
			strSql.Append("Expand1=@Expand1,");
			strSql.Append("Expand2=@Expand2,");
			strSql.Append("Expand3=@Expand3");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@TeamID", SqlDbType.NVarChar,50),
					new SqlParameter("@TeamName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@PID", SqlDbType.NVarChar,50),
					new SqlParameter("@Expand1", SqlDbType.NVarChar,50),
					new SqlParameter("@Expand2", SqlDbType.NVarChar,50),
					new SqlParameter("@Expand3", SqlDbType.NVarChar,50),
					new SqlParameter("@SID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Score;
			parameters[1].Value = model.TeamID;
			parameters[2].Value = model.TeamName;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.PID;
			parameters[5].Value = model.Expand1;
			parameters[6].Value = model.Expand2;
			parameters[7].Value = model.Expand3;
			parameters[8].Value = model.SID;

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
		public bool Delete(string SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gameLog ");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SID;

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
		public bool DeleteList(string SIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gameLog ");
			strSql.Append(" where SID in ("+SIDlist + ")  ");
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
        public entity_gameLog GetModel(string SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SID,Score,TeamID,TeamName,CreateTime,PID,Expand1,Expand2,Expand3 from gameLog ");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SID;

            entity_gameLog model = new entity_gameLog();
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
        public entity_gameLog DataRowToModel(DataRow row)
		{
            entity_gameLog model = new entity_gameLog();
			if (row != null)
			{
				if(row["SID"]!=null)
				{
					model.SID=row["SID"].ToString();
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=int.Parse(row["Score"].ToString());
				}
				if(row["TeamID"]!=null)
				{
					model.TeamID=row["TeamID"].ToString();
				}
				if(row["TeamName"]!=null)
				{
					model.TeamName=row["TeamName"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["PID"]!=null)
				{
					model.PID=row["PID"].ToString();
				}
				if(row["Expand1"]!=null)
				{
					model.Expand1=row["Expand1"].ToString();
				}
				if(row["Expand2"]!=null)
				{
					model.Expand2=row["Expand2"].ToString();
				}
				if(row["Expand3"]!=null)
				{
					model.Expand3=row["Expand3"].ToString();
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
			strSql.Append("select SID,Score,TeamID,TeamName,CreateTime,PID,Expand1,Expand2,Expand3 ");
			strSql.Append(" FROM gameLog ");
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
			strSql.Append(" SID,Score,TeamID,TeamName,CreateTime,PID,Expand1,Expand2,Expand3 ");
			strSql.Append(" FROM gameLog ");
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
			strSql.Append("select count(1) FROM gameLog ");
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
				strSql.Append("order by T.SID desc");
			}
			strSql.Append(")AS Row, T.*  from gameLog T ");
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
			parameters[0].Value = "gameLog";
			parameters[1].Value = "SID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

