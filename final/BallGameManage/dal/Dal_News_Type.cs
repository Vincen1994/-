using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entity;

namespace Dal
{
    public class Dal_News_Type
    {
        /// <summary>
        /// 查出所有的新闻类型
        /// </summary>
        /// <returns></returns>
        public DataTable selectedNewsType() {
            string sql="select * from NewsType";
            var result=DBHelp.GetTable(sql);
            return result;
        }

        /// <summary>
        /// 分页 查出n条以内的数据
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public DataTable selectedNewsType(int number, int n)
        {
            string sql = "SELECT TOP " + n + " * FROM NewsType WHERE (news_type_id  not IN (SELECT TOP " + number + " news_type_id  FROM NewsType  ORDER BY news_type_id))ORDER BY news_type_id";
            var result = DBHelp.GetTable(sql);
            return result;
        }

        /// <summary>
        /// 根据ID查出新闻类型
        /// </summary>
        /// <returns></returns>
        public DataTable selectedNewstype(int id)
        {
            string sql = "select * from NewsType where news_type_id='" + id + "'";
            var dt = DBHelp.GetTable(sql);
            return dt;
        }
        /// <summary>
        /// 根据ID删除新闻类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int delectNewsType(int id) {
            string sql = "Delete from NewsType where news_type_id='"+id+"'";
            int result=DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        /// 添加新闻类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int addNewstype(News_type type) {
            string sql = "insert into NewsType (news_type_name,news_type_createTime,news_type_ParentID) values('"+ type.TypeName +"','"+type.Type_createTime+"','"+type.Type_ParentID+"')";
            int result = DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        /// 修改新闻类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateNewstype(News_type type)
        {
            string sql = "update NewsType set news_type_name='" + type.TypeName + "' where news_type_id='"+type.TypeID+"'";
            int result=DBHelp.DoSql(sql);
            return result;
        }

       
    }
}
