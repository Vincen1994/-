using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bll;

namespace BallGameManage.Main
{
    public partial class NewList : System.Web.UI.Page
    {
        string type = "";
        bll_NewList bll = new bll_NewList();
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
            this.Repeater.DataSource = UpDateTitle(dataTable);
            this.Repeater.DataBind();
            pagelist.RecordCount = recordCount;
        }
        private DataTable UpDateTitle(DataTable tab)
        {
            foreach (DataRow dr in tab.Rows)
            {
                dr["CreateTime"] = Common.StringHelp.updateStr(dr["CreateTime"].ToString());
            }
            return tab;
        }
    }
}