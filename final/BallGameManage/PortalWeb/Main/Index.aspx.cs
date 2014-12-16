using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BallGameManage.Main
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getHYDT();
                getGonggao();
            }
        }
        public string href = "";

    
        private void getHYDT()
        {
            string SQL = "  select TOP 8 * from [T_ScheduleDetail] where State=0 order by [CreaterTime] desc";
            DataSet ds = Dal.DbHelperSQL.Query(SQL);
            if (ds == null || ds.Tables[0] == null)
            {
                return;
            }

            this.Repeater_ss.DataSource = ds.Tables[0];
            this.Repeater_ss.DataBind();
        }
    
        private void getGonggao()
        {
            string SQL = "  select TOP 8 *  from [News] order by [CreateTime] desc";
            DataSet ds = Dal.DbHelperSQL.Query(SQL);
            if (ds == null || ds.Tables[0] == null)
            {
                return;
            }
            this.Repeater_gg.DataSource = ds.Tables[0];
            this.Repeater_gg.DataBind();
        }
     
        private DataTable UpDateTitle(DataTable tab)
        {
            foreach (DataRow dr in tab.Rows)
            {
                dr["title"] = CUT(dr["title"].ToString());
            }
            return tab;
        }
        private string CUT(string title)
        {
            if (title.Length > 8)
            {
                title = title.Substring(0, 8);
                title += "...";
            }
            return title;
        }
        private DataTable UpTitle(DataTable tab)
        {
            foreach (DataRow dr in tab.Rows)
            {
                dr["title"] = CU(dr["title"].ToString());
            }
            return tab;
        }
        private string CU(string title)
        {
            if (title.Length > 14)
            {
                title = title.Substring(0, 14);
                title += "...";
            }
            return title;
        }
        private DataTable UpnewsTitle(DataTable tab)
        {
            foreach (DataRow dr in tab.Rows)
            {
                dr["title"] = C(dr["title"].ToString());
                dr["CreateTime"] = Common.StringHelp.updateStr(dr["CreateTime"].ToString());
            }
            return tab;
        }
        private string C(string title)
        {
            if (title.Length > 28)
            {
                title = title.Substring(0, 28);
                title += "...";
            }
            return title;
        }
    }
}