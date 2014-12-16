using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Dal
{
    public class Dal_Administrator
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
         public int adminLogin(Administrator admin) {
             string sql = "select count(*) from webHT_Admin where adminName='" + admin.AdminName + "' and adminPassword='" + admin.AdminPassword + "'";
            int count = DBHelp.CommandScalar(sql);
            return count;
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <returns></returns>
         public int addAdmin(Administrator admin)
         {
             string sql ="insert into webHT_Admin(adminName,adminPassword,RealName,CreatedTime) values('"+admin.AdminName+"','"+admin.AdminPassword+"','"+admin.RealName+"','"+admin.CreatedTime+"')";
             int result = DBHelp.DoSql(sql);
             return result;
         }

        /// <summary>
        /// 验证管理员是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public int VerifyAdminName(string name) {
             string sql = "select count(*) from webHT_Admin where adminName='"+name+"'";
             int result = DBHelp.CommandScalar(sql);
             return result;
         }

        /// <summary>
        /// 查出所有管理员
        /// </summary>
        /// <returns></returns>
         public DataTable CheckAll()
         { 
            string sql="select * from webHT_Admin";
            var result = DBHelp.GetTable(sql);
            return result;
         }
        /// <summary>
         /// 分页 查出n条以内的数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <returns></returns>
         public DataTable CheckAll(int number, int n)
         {
             string sql = "SELECT TOP " + n + " * FROM webHT_Admin WHERE (adminID  not IN (SELECT TOP " + number + " adminID  FROM webHT_Admin  ORDER BY adminID))ORDER BY adminID";
             var result = DBHelp.GetTable(sql);
             return result;
         }

        /// <summary>
        ///  删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public int delectAdmin(int id) {
             string sql = "delete from webHT_Admin where adminId='"+id+"'";
             int result = DBHelp.DoSql(sql);
             return result;
         }
        /// <summary>
        /// 判断是否为超级管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public int isSuperAdmin(int id) {
             string sql = "select count(*) from webHT_Admin where adminId='" + id + "'and role=1";
             int result = DBHelp.CommandScalar(sql);
             return result;
         }
        
        /// <summary>
        /// 用id查出一个管理员的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public DataTable selectAdmin(int id) {
            string sql = "select * from webHT_Admin where adminID='"+id+"'";
            var result=DBHelp.GetTable(sql);
            return result;
         }
        /// <summary>
        /// 用帐号查出管理员信息
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
         public DataTable selectAdmin(string adminName) {
             string sql = "select * from webHT_Admin where adminName='" + adminName + "'";
            var result=DBHelp.GetTable(sql);
            return result;
         }

        /// <summary>
        /// 修改管理员信息(修改密码)
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int UpdateAdmin(Administrator admin){
            string sql = "update webHT_Admin set adminPassword='" + admin.AdminPassword + "',RealName='"+admin.RealName+"'  where adminID='" + admin.AdminId + "'";
            int result = DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        ///  修改管理员信息 (不修改密码)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="realName"></param>
        /// <returns></returns>
        public int UpdateAdmin(int id,string realName){
            string sql = "update webHT_Admin set RealName='" + realName + "'  where adminID='" + id + "'";
            int result = DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        /// 数据的条数
        /// </summary>
        /// <returns></returns>
        public int Quantity()
        {
            string sql = "select count(*) from webHT_Admin";
            int result= DBHelp.CommandScalar(sql) ;
            return result;
        }
    }
}
