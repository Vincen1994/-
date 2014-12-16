using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Bll;

namespace BallGameManage.Administrator
{
    public partial class addMatch : System.Web.UI.Page
    {
        string type = "";
        string pid = "";
        string sid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["type"];
            if (Request["pid"] != null)
            {
                pid = Request["pid"].ToString();
            }
            if (Request["sid"] != null)
            {
                sid = Request["sid"].ToString();
            }
            if (!IsPostBack)
            {
                DDL_DataBind();
            }
        }

        Bll.bll_Laboratory laboratory = new Bll.bll_Laboratory();
        private void DDL_DataBind()
        {
            this.ddl_zhudui.DataSource = laboratory.GetAllList();
            ddl_zhudui.DataTextField = "name";
            ddl_zhudui.DataValueField = "sid";
            this.ddl_zhudui.DataBind();
            this.ddl_kedui.DataSource = laboratory.GetAllList();
            ddl_kedui.DataTextField = "name";
            ddl_kedui.DataValueField = "sid";
            this.ddl_kedui.DataBind();
        }

        bll_ScheduleDetail ScheduleDetail = new bll_ScheduleDetail();
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (this.ddl_zhudui.SelectedValue == this.ddl_kedui.SelectedValue)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('主队跟客队不能选择同一个实验室');</script>");
                return;
            }
            if (this.CreateTime.Value == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('开始时间不能空');</script>");
                return;
            }
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            bool Success = false;
            if (type == "add")
            {
                entity.SID = Guid.NewGuid().ToString();
                entity.T_Extend1 = pid;
                entity.HomeCourt = this.ddl_zhudui.SelectedValue;
                entity.HomeCourtName = this.ddl_zhudui.Text ;
                entity.away = this.ddl_kedui.SelectedValue;
                entity.awayName = this.ddl_kedui.Text;
                entity.StartTime =DateTime.Parse( this.CreateTime.Value);
                entity.CreaterTime = DateTime.Now;
                Success = ScheduleDetail.Add(entity);
                if (Success)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功');</script>");
                    Response.Redirect("MatchList.aspx?mm=" + new Random().Next() + "&sid=" + entity.T_Extend1);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加失败');</script>");
                }
            }
            if (type == "update")
            {
                entity = ScheduleDetail.GetModel(sid);
                entity.HomeCourt = this.ddl_zhudui.SelectedValue;
                entity.HomeCourtName = this.ddl_zhudui.Text;
                entity.away = this.ddl_kedui.SelectedValue;
                entity.awayName = this.ddl_kedui.Text;
                entity.StartTime = DateTime.Parse(this.CreateTime.Value);
                Success = ScheduleDetail.Update(entity);
                if (Success)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功');</script>");
                    Response.Redirect("MatchList.aspx?mm=" + new Random().Next() + "&sid=" + entity.T_Extend1);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改失败');</script>");
                }
            }
        }
    }
}