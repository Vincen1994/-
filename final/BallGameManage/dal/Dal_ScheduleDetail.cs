
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Entity;
namespace Dal
{
	/// <summary>
	/// 数据访问类:Dal_ScheduleDetail
	/// </summary>
	public partial class Dal_ScheduleDetail
	{
		public Dal_ScheduleDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from T_ScheduleDetail");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(entity_ScheduleDetail model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into T_ScheduleDetail(");
			strSql.Append("SID,HomeCourt,HomeCourtName,HomeCourt_Fraction,away,awayName,away_Fraction,State,StartTime,EndTime,T_Extend1,T_Extend2,T_Extend3)");
			strSql.Append(" values (");
            strSql.Append("@SID,@HomeCourt,@HomeCourtName,@HomeCourt_Fraction,@away,@awayName,@away_Fraction,@State,@StartTime,@EndTime,@T_Extend1,@T_Extend2,@T_Extend3,@CreaterTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeCourt", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeCourtName", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeCourt_Fraction", SqlDbType.Int,4),
					new SqlParameter("@away", SqlDbType.NVarChar,50),
					new SqlParameter("@awayName", SqlDbType.NVarChar,50),
					new SqlParameter("@away_Fraction", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@T_Extend1", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Extend2", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Extend3", SqlDbType.NVarChar,50),
					new SqlParameter("@CreaterTime", SqlDbType.DateTime)
                                        };
			parameters[0].Value = model.SID;
			parameters[1].Value = model.HomeCourt;
			parameters[2].Value = model.HomeCourtName;
			parameters[3].Value = model.HomeCourt_Fraction;
			parameters[4].Value = model.away;
			parameters[5].Value = model.awayName;
			parameters[6].Value = model.away_Fraction;
			parameters[7].Value = model.State;
			parameters[8].Value = model.StartTime;
			parameters[9].Value = model.EndTime;
			parameters[10].Value = model.T_Extend1;
			parameters[11].Value = model.T_Extend2;
			parameters[12].Value = model.T_Extend3;
			parameters[13].Value = model.CreaterTime;

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
        public bool Update(entity_ScheduleDetail model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update T_ScheduleDetail set ");
			strSql.Append("HomeCourt=@HomeCourt,");
			strSql.Append("HomeCourtName=@HomeCourtName,");
			strSql.Append("HomeCourt_Fraction=@HomeCourt_Fraction,");
			strSql.Append("away=@away,");
			strSql.Append("awayName=@awayName,");
			strSql.Append("away_Fraction=@away_Fraction,");
			strSql.Append("State=@State,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("T_Extend1=@T_Extend1,");
			strSql.Append("T_Extend2=@T_Extend2,");
			strSql.Append("T_Extend3=@T_Extend3");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@HomeCourt", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeCourtName", SqlDbType.NVarChar,50),
					new SqlParameter("@HomeCourt_Fraction", SqlDbType.Int,4),
					new SqlParameter("@away", SqlDbType.NVarChar,50),
					new SqlParameter("@awayName", SqlDbType.NVarChar,50),
					new SqlParameter("@away_Fraction", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@T_Extend1", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Extend2", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Extend3", SqlDbType.NVarChar,50),
					new SqlParameter("@SID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.HomeCourt;
			parameters[1].Value = model.HomeCourtName;
			parameters[2].Value = model.HomeCourt_Fraction;
			parameters[3].Value = model.away;
			parameters[4].Value = model.awayName;
			parameters[5].Value = model.away_Fraction;
			parameters[6].Value = model.State;
			parameters[7].Value = model.StartTime;
			parameters[8].Value = model.EndTime;
			parameters[9].Value = model.T_Extend1;
			parameters[10].Value = model.T_Extend2;
			parameters[11].Value = model.T_Extend3;
			parameters[12].Value = model.SID;

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
            strSql.Append("delete from T_ScheduleDetail ");
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
            strSql.Append("delete from T_ScheduleDetail ");
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
        public entity_ScheduleDetail GetModel(string SID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 * from T_ScheduleDetail ");
			strSql.Append(" where SID=@SID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SID;

            entity_ScheduleDetail model = new entity_ScheduleDetail();
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
        public entity_ScheduleDetail DataRowToModel(DataRow row)
		{
            entity_ScheduleDetail model = new entity_ScheduleDetail();
			if (row != null)
			{
				if(row["SID"]!=null)
				{
					model.SID=row["SID"].ToString();
				}
				if(row["HomeCourt"]!=null)
				{
					model.HomeCourt=row["HomeCourt"].ToString();
				}
				if(row["HomeCourtName"]!=null)
				{
					model.HomeCourtName=row["HomeCourtName"].ToString();
				}
				if(row["HomeCourt_Fraction"]!=null && row["HomeCourt_Fraction"].ToString()!="")
				{
					model.HomeCourt_Fraction=int.Parse(row["HomeCourt_Fraction"].ToString());
				}
				if(row["away"]!=null)
				{
					model.away=row["away"].ToString();
				}
				if(row["awayName"]!=null)
				{
					model.awayName=row["awayName"].ToString();
				}
				if(row["away_Fraction"]!=null && row["away_Fraction"].ToString()!="")
				{
					model.away_Fraction=int.Parse(row["away_Fraction"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["StartTime"]!=null && row["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(row["StartTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["T_Extend1"]!=null)
				{
					model.T_Extend1=row["T_Extend1"].ToString();
				}
				if(row["T_Extend2"]!=null)
				{
					model.T_Extend2=row["T_Extend2"].ToString();
				}
				if(row["T_Extend3"]!=null)
				{
					model.T_Extend3=row["T_Extend3"].ToString();
                }
                if (row["CreaterTime"] != null)
                {
                    model.CreaterTime =DateTime.Parse( row["CreaterTime"].ToString());
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
			strSql.Append("select * ");
            strSql.Append(" FROM T_ScheduleDetail ");
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
			strSql.Append(" * ");
            strSql.Append(" FROM T_ScheduleDetail ");
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
            strSql.Append("select count(1) FROM T_ScheduleDetail ");
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
            strSql.Append(")AS Row, T.*  from T_ScheduleDetail T ");
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
			parameters[0].Value = "Dal_ScheduleDetail";
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

