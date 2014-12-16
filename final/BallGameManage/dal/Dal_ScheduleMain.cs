﻿
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Entity;
namespace Dal
{
    /// <summary>
    /// 数据访问类:T_ScheduleMain
    /// </summary>
    public partial class Dal_ScheduleMain
    {
        public Dal_ScheduleMain()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_ScheduleMain");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(entity_ScheduleMain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_ScheduleMain(");
            strSql.Append("SID,Name,CreaterTime)");
            strSql.Append(" values (");
            strSql.Append("@SID,@Name,@CreaterTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
            new SqlParameter("@CreaterTime", SqlDbType.DateTime)};
            parameters[0].Value = model.SID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CreaterTime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(entity_ScheduleMain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_ScheduleMain set ");
            strSql.Append("Name=@Name");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@SID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.SID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_ScheduleMain ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string SIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_ScheduleMain ");
            strSql.Append(" where SID in (" + SIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public entity_ScheduleMain GetModel(string SID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SID,Name,CreaterTime from T_ScheduleMain ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SID;

            entity_ScheduleMain model = new entity_ScheduleMain();
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
        public entity_ScheduleMain DataRowToModel(DataRow row)
        {
            entity_ScheduleMain model = new entity_ScheduleMain();
            if (row != null)
            {
                if (row["SID"] != null)
                {
                    model.SID = row["SID"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["CreaterTime"] != null)
                {
                    model.CreaterTime = DateTime.Parse(row["CreaterTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SID,Name,CreaterTime ");
            strSql.Append(" FROM T_ScheduleMain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SID,Name,CreaterTime ");
            strSql.Append(" FROM T_ScheduleMain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_ScheduleMain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.SID desc");
            }
            strSql.Append(")AS Row, T.*  from T_ScheduleMain T ");
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
            parameters[0].Value = "T_ScheduleMain";
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

