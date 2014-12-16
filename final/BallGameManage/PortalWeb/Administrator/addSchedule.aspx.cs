using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Entity;
namespace BallGameManage.Administrator
{
    public partial class addSchedule : System.Web.UI.Page
    {
        string type = "";
        string SID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["type"].ToString();
            if (!IsPostBack)
            {
                databind(type);
            }
        }

        private void databind(string type)
        {
            switch (type)
            {
                case "add": this.lab_type.Text = "添加";
                    tbx_Name.Text = "";
                    break;
                case "update": this.lab_type.Text = "修改";
                    ViewState["SID"] = Request["sid"].ToString();
                    tbx_Name.Text = bll.GetModel(ViewState["SID"].ToString()).Name;
                    break;
            }
        }
        bll_ScheduleMain bll = new bll_ScheduleMain();
        protected void Submit_Click(object sender, EventArgs e)
        {
            entity_ScheduleMain model = null;
            if (type == "add")
            {
                 model = new entity_ScheduleMain();
                model.SID = Guid.NewGuid().ToString();
                model.Name = this.tbx_Name.Text;
                model.CreaterTime = DateTime.Now;
                if (bll.Add(model))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功!');</script>");
                    Response.Redirect("ScheduleList.aspx?mm=" + new Random().Next(), true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加失败!');</script>");
                }
            }
            if (type == "update")
            {
                model = bll.GetModel(ViewState["SID"].ToString());
                model.Name = this.tbx_Name.Text;
                if (bll.Update(model))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功!');</script>");
                    Response.Redirect("ScheduleList.aspx?mm=" + new Random().Next(), true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改失败!');</script>");
                }
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            databind(type);
        }
    }
}