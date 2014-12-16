using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Bll
{
    public class Bll_Administrator
    {
        Dal_Administrator dal_admin = new Dal_Administrator();

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool adminLogin(Administrator admin) {
            int count= dal_admin.adminLogin(admin);
            if(count==1){
                return true;
            }
            else
            {
                return false; 
            }
            
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool addAdmin(Administrator admin)
        {
            int result=dal_admin.addAdmin(admin);
            if (result == 1)
            {
                return true;
            }
            else {
                return false;
            }
            
        }

        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool VerifyAdminName(string name)
        {
            int result =dal_admin.VerifyAdminName(name);
            if (result == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// 把查出的所有管理员
        /// </summary>
        /// <returns></returns>
        DataTable dt = null;
        public DataTable CheckAll()
        {
            dt=dal_admin.CheckAll();
            return dt;
        }
        /// <summary>
        /// 分页 查出n以内的数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public DataTable CheckAll(int number, int n)
        {
            dt = dal_admin.CheckAll(number,n);
            return dt;
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string delectAdmin(int id)
        {
            if (!isSuperAdmin(id))
            {
                if (dal_admin.delectAdmin(id) != 1)
                {
                    return "删除失败";
                }
                else
                {
                    return "删除成功";
                }
            }
            else {
                return "无法删除超级管理员";
            }
            
            
        }

        /// <summary>
        /// 判断是否为超级管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool isSuperAdmin(int id) {
            if (dal_admin.isSuperAdmin(id) == 1)
            {
                return true;
            }
            else {
                return false; 
            }
              
        }


        /// <summary>
        /// 用id查出管理员的信息,再转成对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Administrator selectAdmin(int id) {
            Administrator admin = new Administrator();
            var admin_table = dal_admin.selectAdmin(id);
            foreach(DataRow dt in admin_table.Rows){
                admin.AdminId = Convert.ToInt16(dt["adminID"].ToString().Trim());
                admin.AdminName = dt["adminName"].ToString().Trim();
                admin.AdminPassword = dt["adminPassword"].ToString().Trim();
                admin.RealName = dt["RealName"].ToString().Trim();
                admin.CreatedTime = Convert.ToDateTime(dt["CreatedTime"].ToString().Trim());
            }
            return admin;
        }
        /// <summary>
        /// 用管理员帐号查出管理员信息
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public Administrator selectAdmin(string adminName)
        {
            Administrator admin = new Administrator();
            var admin_table = dal_admin.selectAdmin(adminName);
            foreach (DataRow dt in admin_table.Rows)
            {
                admin.AdminId = Convert.ToInt16(dt["adminID"].ToString().Trim());
                admin.AdminName = dt["adminName"].ToString().Trim();
                admin.AdminPassword = dt["adminPassword"].ToString().Trim();
                admin.RealName = dt["RealName"].ToString().Trim();
                admin.CreatedTime = Convert.ToDateTime(dt["CreatedTime"].ToString().Trim());
            }
            return admin;
        }



        /// <summary>
        /// 修改管理员信息(修改密码)
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool UpdateAdmin(Administrator admin)
        {
            int result=dal_admin.UpdateAdmin(admin);
            if (result == 1)
            {
                return true;
            }
            else {
                return false;
            }
            
        }


        /// <summary>
        /// 修改管理员信息(不修改密码)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="realName"></param>
        /// <returns></returns>
        public bool UpdateAdmin(int id, string realName)
        {
            int result = dal_admin.UpdateAdmin(id,realName);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 数据的条数
        /// </summary>
        /// <returns></returns>
        public int Quantity()
        {
            int result=dal_admin.Quantity();
            return result;
        }
    }
}
