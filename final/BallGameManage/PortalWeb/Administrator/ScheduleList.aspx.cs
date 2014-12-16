using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace BallGameManage.Administrator
{
    public partial class ScheduleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pagelist_chang(null, null);

            }

        }

        Bll.bll_ScheduleMain bll = new Bll.bll_ScheduleMain();
        protected void pagelist_chang(object sender, EventArgs e)
        {
            int recordCount = 0;
            string where = "";
            string showfield = " * ";
            DataTable dataTable = bll.GetDataPager(pagelist.CurrentPageIndex - 1, pagelist.Pagesize, ref recordCount, where, showfield);
            this.Repeater.DataSource = dataTable;
            this.Repeater.DataBind();
            pagelist.RecordCount = recordCount;
        }
        protected void btn_addLike_Click(object sender, EventArgs e)
        {
            Response.Redirect("addSchedule.aspx?type=add");
        }
        protected void Repeater_ItemCommand_nimei(object source, RepeaterCommandEventArgs e)
        {
            string id = ((ImageButton)e.Item.FindControl("Delete")).CommandArgument.ToString();
            if (e.CommandName == "Delete")
            {
                string news = "";
                bool IsTrue = bll.Delete(id);
                if (IsTrue)
                {
                    news = "删除成功";
                }
                else
                {
                    news = "删除失败";
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + news + "');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('" + news + "')", true);
                pagelist_chang(null, null);
            }
        }
    }
}