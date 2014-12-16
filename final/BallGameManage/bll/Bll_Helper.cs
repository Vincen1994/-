using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dal;

namespace Bll
{
    public class Bll_Helper
    {
        /// <summary>
        /// 获取Title
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTitle(string type)
        {
            string title = "";
            switch (type)
            {
                case "jc": title = "章程"; break;
                case "jj": title = "简介"; break;
                case "hyjj": title = "行业简介"; break;
                case "jgnsjg": title = "机关内设机构"; break;
                case "ldcy": title = "领导成员"; break;
                case "hwxx": title = "会务信息"; break;
                case "lxxnjysj": title = "理想信念教育实践"; break;
                case "zcfg": title = "政策法规"; break;
                case "hyhwxx": title = "商会会务信息"; break;
                case "qyfc": title = "企业风采"; break;
                case "fsy": title = "访商英"; break;
                case "jjxx": title = "经济信息"; break;
                case "gg": title = "公告"; break;
                case "zpp": title = "展品牌"; break;
                default: title = ""; break;
            }
            return title;
        }

        public DataSet getData(string SQL)
        {
            DataSet ds = null;
            ds=DbHelperSQL.Query(SQL);
            return ds;
        }
    }
}
