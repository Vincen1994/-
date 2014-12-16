using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using Bll;
using Entity;

namespace BallGameManage.Administrator
{
    public partial class selectdAdmin : System.Web.UI.Page
    {
        private bll_users bll = new bll_users();
        string IsTrue = "false";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["adminName"] == null)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未登录');</script>");
                    ////// ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('未登录!')", true);
                    Response.Redirect("login.aspx");
                }
                entity_users user = HttpContext.Current.Session["adminName"] as entity_users;
                if (user.sid.Equals("1111-1111-1111-1111"))
                {
                    IsTrue = "true";
                }
                pagelist_chang(null, null);
            }
        }
        protected void Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            entity_users user = HttpContext.Current.Session["adminName"] as entity_users;
            if (!user.sid.Equals("1111-1111-1111-1111"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('对不起，您没有权限删除用户');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('对不起，您没有权限删除用户')", true);
                return;
            }
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
        /// <summary>
        /// 批量删除
        /// </summary>
        public void batchDelete()
        {
            entity_users user = HttpContext.Current.Session["adminName"] as entity_users;
            if (!user.sid.Equals("1111-1111-1111-1111"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('对不起，您没有权限删除用户');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('对不起，您没有权限删除用户')", true);
                return;
            }
            for (int i = 0; i < Repeater.Items.Count; i++)
            {
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)Repeater.Items[i].FindControl("checkbox");
                string id = ckb.Value;
                if (ckb.Checked == true)
                {
                    if (id.Equals("1111-1111-1111-1111"))
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('无权限删除超级管理员');</script>");
                        //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('无权限删除超级管理员')", true)
                        continue;
                    }
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
                }
            }
            pagelist_chang(null, null);
        }
        protected void batchDelete_Click(object sender, ImageClickEventArgs e)
        {
            batchDelete();
        }
        protected void lk_btn_batchDelete_Click(object sender, EventArgs e)
        {
            batchDelete();
        }
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
    }
}