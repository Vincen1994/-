using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;

namespace BallGameManage.Main
{
    public partial class Memberlist : System.Web.UI.Page
    {
        bll_ScheduleMain bll = new bll_ScheduleMain();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pagelist_chang(null, null);
            }
        }
        protected void pagelist_chang(object sender, EventArgs e)
        {
            int recordCount = 0;
            string where = " ";
            string showfield = " * ";
            DataTable dataTable = bll.GetDataPager(pagelist.CurrentPageIndex - 1, pagelist.Pagesize, ref recordCount, where, showfield);
            this.Repeater.DataSource = dataTable;
            this.Repeater.DataBind();
            pagelist.RecordCount = recordCount;
        }
    }
}