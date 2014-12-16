using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Dal
{
    public class DBHelp
    {
        private static SqlConnection conn = null;
        private static SqlCommand comm = null;
        private static DataSet ds = null;
        private static SqlDataAdapter sda = null;
        private static SqlDataReader sdr = null;

        private static string connString = System.Configuration.ConfigurationSettings.AppSettings["connectionString"]; 


        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connString);
            }
            conn.Open();//打开连接
            return conn;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public static void CloseConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Command执行ExecuteScalar方法返回第一行第一列单元格的结果
        /// </summary>
        /// <param name="sql">要执行的Sql语句</param>
        /// <returns></returns>
        public static int CommandScalar(string sql)
        {
            try
            {
                comm = new SqlCommand(sql, GetConnection());
                int count = (int)comm.ExecuteScalar();
                CloseConnection();
                return count;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                CloseConnection();
                throw e;
            }
            finally
            {
                CloseConnection();
            }

        }

        /// <summary>
        /// Command执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的Sql语句</param>
        /// <returns></returns>
        public static int DoSql(string sql)
        {
            try
            {
                comm = new SqlCommand(sql, GetConnection());
                int result = comm.ExecuteNonQuery();
                CloseConnection();
                return result;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                CloseConnection();
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// 获取相应的DataTable
        /// </summary>
        /// <param name="sql">要执行的Sql语句</param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            try
            {
                ds = new DataSet();
                sda = new SqlDataAdapter(sql, GetConnection());
                sda.Fill(ds);
                return ds.Tables[0];
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                CloseConnection();
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        ///  Command执行ExecuteReader方法返回一个SqlDataReader对象
        ///   Command执行sql语句进行查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader CommandReader(string sql)
        {
           
            try
            {
                comm = new SqlCommand(sql, GetConnection());
                SqlDataReader sdr = comm.ExecuteReader();
                return sdr;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                CloseConnection();
                throw e;
            }
            finally
            {
                CloseConnection();
                
            }

        }
    }
}
