using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bll;

namespace BallGameManage.Main
{
    public partial class Economylist : System.Web.UI.Page
    {
        string pid = "";
        bll_ScheduleDetail bll = new bll_ScheduleDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["sid"] != null)
                {
                    pid = Request["sid"].ToString();
                
                }
            if (!IsPostBack)
            {
                
                pagelist_chang(null, null);

            }
        }
        protected void pagelist_chang(object sender, EventArgs e)
        {
         string where ="";
            int recordCount = 0;
            if (pid != "")
            {
                where = " T_Extend1='" + pid + "'";
            }
            else
            {
                where = " ";
            }
            string showfield = " * ";
            DataTable dataTable = bll.GetDataPager(pagelist.CurrentPageIndex - 1, pagelist.Pagesize, ref recordCount, where, showfield);
            this.Repeater.DataSource = dataTable;
            this.Repeater.DataBind();
            pagelist.RecordCount = recordCount;
        }
       
    }
}