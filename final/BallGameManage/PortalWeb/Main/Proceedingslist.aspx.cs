using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using System.Text;
using Dal;

namespace BallGameManage.Main
{
    public partial class Proceedingslist : System.Web.UI.Page
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
                    case "one": this.HeadTitle.Text = "精彩片段"; break;
                    case "two": this.HeadTitle.Text = "绝杀时刻"; break;
                }
                Refresh();
            }
        }
        private void Refresh()
        {
            string where = " type='" + type + "'";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ImageList ");

            strSql.Append(" where " + where);
            strSql.Append("  order by  name desc ");

            DataSet table = DbHelperSQL.Query(strSql.ToString());
            this.ImageList.DataSource = Change(table.Tables[0]);
            this.ImageList.DataBind();
        }
        private DataTable Change(DataTable tab)
        {
            foreach (DataRow dr in tab.Rows)
            {
                if (bll.selectUrl(dr["sid"].ToString()) == "")
                {
                    dr["url"] = "../img/Default.jpg";
                }
                else
                {
                    dr["url"] = bll.selectUrl(dr["sid"].ToString());
                }
            }
            return tab;
        }
        protected void lnk_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName.Equals("select"))
            {
                string id = e.CommandArgument.ToString();
                Entity.entity_ImageList img = bll.GetModel(id);
                Response.Redirect("ImageShow.aspx?type=" + type );
            }
        }
    }
}