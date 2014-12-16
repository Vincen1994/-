using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal
{
    public class dal_Help
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldKey">SID</param>
        /// <param name="fieldShow">要显示的字段</param>
        /// <param name="fieldOrder">排序  ‘字段’ asc</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页显示的多少条数据</param>
        /// <param name="recordCount">数据的总数</param>
        /// <returns></returns>
        public DataTable GetDataPager(string tableName, string fieldKey, string fieldShow, string fieldOrder, int pageIndex, int pageSize, string where1, ref int recordCount)
        {
            StringBuilder where = new StringBuilder();
            if (string.IsNullOrEmpty(where1))
            {

                where.AppendFormat(" 1=1");
            }
            else
            {
                where.AppendFormat(where1);
            }
            DataTable dt = SqlHelper.GetPagedList(tableName, fieldKey, pageIndex, pageSize, fieldShow, fieldOrder, where.ToString(), ref recordCount);
            return dt;
        }
    }
}
