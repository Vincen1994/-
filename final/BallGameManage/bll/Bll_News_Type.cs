using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dal;
using Entity;

namespace Bll
{
    public class Bll_News_Type
    {
        Dal_News_Type newsType = new Dal_News_Type();

        /// <summary>
        /// 查出所有的新闻类型
        /// </summary>
        /// <returns></returns>
        public DataTable selectedNewsType()
        {
            var result=newsType.selectedNewsType();
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
            var result=newsType.selectedNewsType(number,n);
            return result;
        }

        /// <summary>
        /// 根据Id删除新闻类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string delectNewsType(int id)
        {
            if (newsType.delectNewsType(id) == 1)
            {
                return "删除成功";
            }
            else {
                return "删除失败";
            }
        }

        /// <summary>
        /// 添加新闻类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool  addNewstype(News_type type)
        {
            if (newsType.addNewstype(type) == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 修改新闻类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool UpdateNewstype(News_type type)
        {
            if (newsType.UpdateNewstype(type) == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }


        /// <summary>
        /// 根据ID查出新闻类型(并以对象返回)
        /// </summary>
        /// <returns></returns>
        public News_type selectedNewstype(int id)
        {
            News_type type = new News_type();
            DataTable dt= newsType.selectedNewstype(id);
            foreach(DataRow d in dt.Rows){
                type.TypeID = Convert.ToInt16(d["news_type_id"].ToString().Trim());
                type.TypeName = d["news_type_name"].ToString().Trim();
                type.Type_createTime = Convert.ToDateTime(d["news_type_createTime"].ToString().Trim());
                type.Type_ParentID = Convert.ToInt16(d["news_type_ParentID"].ToString().Trim());
                type.Type_sequence = Convert.ToInt16(d["news_type_sequence"].ToString().Trim());
                type.Type_count = Convert.ToInt16(d["news_type_count"].ToString().Trim());               
            }
            return type;
        }
    }
}
