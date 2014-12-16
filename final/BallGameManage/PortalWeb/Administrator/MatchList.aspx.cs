using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace BallGameManage.Administrator
{
    public partial class MatchList : System.Web.UI.Page
    {
        string PID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            PID = Request["sid"];
            if (!IsPostBack)
            {
                pagelist_chang(null, null);
            }
        }



        Bll.bll_ScheduleDetail bll = new Bll.bll_ScheduleDetail();
        protected void pagelist_chang(object sender, EventArgs e)
        {
            int recordCount = 0;
            string where = " T_Extend1='" + PID+"'";
            string showfield = " * ";
            DataTable dataTable = bll.GetDataPager(pagelist.CurrentPageIndex - 1, pagelist.Pagesize, ref recordCount, where, showfield);
            this.Repeater.DataSource =Change( dataTable);
            this.Repeater.DataBind();
            pagelist.RecordCount = recordCount;
        }
        protected void btn_addLike_Click(object sender, EventArgs e)
        {
            Response.Redirect("addMatch.aspx?type=add&pid=" + PID);
        }
        protected void Repeater_ItemCommand_nimei(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
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
            if (e.CommandName == "Edit")
            {
                if (bll.GetModel(id).State>0) {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('此比赛无法修改');</script>");
                    return;
                }
                Response.Redirect("addMatch.aspx?type=update&sid=" + id,true);
            } if (e.CommandName == "ball")
            {
                if (bll.GetModel(id).State > 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('此比赛无法开始');</script>");
                    return;
                }
                Response.Redirect("Matching.aspx?sid=" + id, true);
            }
        }

        private DataTable Change(DataTable tab)
        {
            tab.Columns.Add("hh_State");
            foreach (DataRow dr in tab.Rows)
            {
                switch (dr["State"].ToString())
               {
                   case "0": dr["hh_State"] = "未开始"; break;
                   case "1": dr["hh_State"] = "比赛中"; break;
                   case "2": dr["hh_State"] = "已结束"; break;
               }
                
            }
            return tab;
        }
    }
}