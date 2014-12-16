using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Entity;
namespace Dal
{
	/// <summary>
	/// 数据访问类:users
	/// </summary>
	public partial class dal_users
	{
		#region  BasicMethod

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int adminLogin(entity_users admin)
        {
            string sql = "select count(*) from dbo.users where userID='"+admin.userID+"' and PassWord='"+admin.PassWord+"'";
            int count = Convert.ToInt32( DbHelperSQL.GetSingle(sql));
            return count;
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from users ");
            strSql.Append(" where " + where);

			return DbHelperSQL.Exists(strSql.ToString());
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(entity_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into users(");
            strSql.Append("sid,userID,PassWord,RealName,CreatedTime)");
			strSql.Append(" values (");
            strSql.Append("@sid,@userID,@PassWord,@RealName,@CreatedTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@userID", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
                    new SqlParameter("@RealName",SqlDbType.NVarChar,50),
                    new SqlParameter("@CreatedTime",SqlDbType.DateTime)
                                        };
			parameters[0].Value = model.sid;
			parameters[1].Value = model.userID;
			parameters[2].Value = model.PassWord;
            parameters[3].Value = model.RealName;
            parameters[4].Value = DateTime.Now.ToString();

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
        public bool Update(entity_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update users set ");
			strSql.Append("userID=@userID,");
			strSql.Append("PassWord=@PassWord,");
            strSql.Append("RealName=@RealName");
			strSql.Append(" where sid=@sid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@RealName",SqlDbType.NVarChar,50)};
			parameters[0].Value = model.userID;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.sid;
            parameters[3].Value = model.RealName;

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
			strSql.Append("delete from users ");
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
			strSql.Append("delete from users ");
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
        public entity_users GetModel(string sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from users ");
			strSql.Append(" where sid=@sid ");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50)			};
			parameters[0].Value = sid;

            entity_users model = new entity_users();
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
        public entity_users GetEntity(string userID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from users ");
            strSql.Append(" where userID=@userID ");
            SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = userID;

            entity_users model = new entity_users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public entity_users DataRowToModel(DataRow row)
		{
            entity_users model = new entity_users();
			if (row != null)
			{
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["userID"]!=null)
				{
					model.userID=row["userID"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["CreatedTime"] != null)
                {
                    model.CreatedTime = Convert.ToDateTime( row["CreatedTime"].ToString());
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
			strSql.Append("select sid,userID,PassWord ");
			strSql.Append(" FROM users ");
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
			strSql.Append(" sid,userID,PassWord ");
			strSql.Append(" FROM users ");
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
			strSql.Append("select count(1) FROM users ");
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
			strSql.Append(")AS Row, T.*  from users T ");
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
			parameters[0].Value = "users";
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

