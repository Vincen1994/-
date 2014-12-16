using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using System.Data;
using Entity;

namespace Dal
{
    public class Dal_News
    {
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int addNews(News news){
            string sql = "insert into News_detailedList (News_title,News_type,News_content,News_author,News_createTime,News_lastModified,News_img,News_source,News_publishTime) values('"+news.NewsTitle+"','"+news.NewsType+"','"+news.NewsContent+"','"+news.NewsAuthor+"','"+news.NewsCreateTime+"','"+news.NewsLastModified+"','"+news.NewsImg+"','"+news.NewsSource+"','"+news.NewsPublishTime+"')";
            int result = DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        /// 查出n条数据(作为分页)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public DataTable selectNews(int number, int n)
        {
            string sql = "SELECT TOP " + n + " * FROM News_detailedList WHERE (News_id  not IN (SELECT TOP " + number + " News_id  FROM News_detailedList  ORDER BY News_id))ORDER BY News_id";
            var result = DBHelp.GetTable(sql);
            return result;
        }
        /// <summary>
        /// 查出所有数据的条数
        /// </summary>
        /// <returns></returns>
        public int selectNews() {
            string sql = "select count(*) from News_detailedList";
            var result = DBHelp.CommandScalar(sql);
            return result;
        }
        /// <summary>
        /// 用ID查出新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable selectNews(int id)
        {
            string sql = "select * from News_detailedList where News_id='"+id+"'";
            var result = DBHelp.GetTable(sql);
            return result;
        }
        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int UpdateNews(News news) {
            string sql = "update News_detailedList set News_title='"+news.NewsTitle+"',News_type='"+news.NewsType+"',News_content='"+news.NewsContent+"',News_sequence='"+news.NewsSequence+"',News_author='"+news.NewsAuthor+"',News_lastModified='"+news.NewsLastModified+"',News_img='"+news.NewsImg+"',News_browseCount='"+news.NewsBrowseCount+"',News_source='"+news.NewsSource+"',News_publishTime='"+news.NewsPublishTime+"',News_isDisplay='"+news.NewsIsDisplay+"' where News_id='"+news.NewsId+"'";
            int result = DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        /// 根据ID删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int delNews(int id) {
            string sql = "Delete from News_detailedList where News_id='" + id + "'";
            int result = DBHelp.DoSql(sql);
            return result;
        }

        /// <summary>
        /// 查询排序最大的项的值
        /// </summary>
        /// <returns></returns>
        public int getMaxSequence() {
            string sql = "select max(News_sequence) from News_detailedList";
            int result = DBHelp.CommandScalar(sql);
            return result;
        }
    }
}
