using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;

namespace BallGameManage.Main
{
    public partial class Lawlist : System.Web.UI.Page
    {
        string type = "";
        bll_ImageList bll = new bll_ImageList();
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["type"];
            if (!IsPostBack)
            {
                switch (type)
                {
                    case "zcfg": this.HeadTitle.Text = "政策法规"; break;
                }
                pagelist_chang();
            }
        }


        protected void pagelist_chang()
        {
            string where = "type='zcfg'";
            DataSet dataTable = bll.GetList(where);
            this.Repeater.DataSource = dataTable.Tables[0];
            this.Repeater.DataBind();
        }
    }
}