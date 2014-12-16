using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Dal;
using System.Data;
namespace Bll
{
    public class Bll_News
    {
        Dal_News dal_news = new Dal_News();
        News news = new News();
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool addNews(News news)
        {
           int result= dal_news.addNews(news);
           if (result == 1)
           {
               return true;
           }
           else {
               return false;
           }
        }

        /// <summary>
        /// 查出n条数据(作为分页)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public DataTable selectNews(int number, int n)
        {
            var result = dal_news.selectNews(number,n);
            return result;
        }
        /// <summary>
        /// 用ID查出新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News selectNews(int id) {
            News news = new News();
            var result = dal_news.selectNews(id);
            foreach(DataRow dr in result.Rows){
                news.NewsId = Convert.ToInt16(dr["News_id"].ToString());
                news.NewsTitle = dr["News_title"].ToString();
                news.NewsType = Convert.ToInt16(dr["News_type"].ToString());
                news.NewsContent = dr["News_content"].ToString();
                news.NewsAuthor = dr["News_author"].ToString();
                news.NewsSequence = Convert.ToInt16(dr["News_sequence"]);
                news.NewsImg = dr["News_img"].ToString();
                news.NewsBrowseCount = Convert.ToInt16( dr["News_browseCount"].ToString());
                news.NewsSource = dr["News_source"].ToString();
                news.NewsPublishTime = Convert.ToDateTime( dr["News_publishTime"]);
                news.NewsIsDisplay = Convert.ToBoolean( dr["News_isDisplay"]);
            }
            return news;
        }
        /// <summary>
        /// 查出所有数据的条数
        /// </summary>
        /// <returns></returns>
        public int selectNews()
        {
            var result = dal_news.selectNews();
            return result;
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool UpdateNews(News news)
        {
            if (dal_news.UpdateNews(news) == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 根据ID删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delNews(int id)
        {
            if (dal_news.delNews(id) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询排序最大的值
        /// </summary>
        /// <returns></returns>
        public int getMaxSequence()
        {
            int result = dal_news.getMaxSequence();
            return result;
        }
    }
}
