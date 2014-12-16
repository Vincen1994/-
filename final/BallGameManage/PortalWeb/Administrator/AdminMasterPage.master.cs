using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace BallGameManage.Administrator
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["adminName"] == null)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未登录!');</script>");
                    ///////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('未登录!')", true);
                    Response.Redirect("login.aspx");
                }
                else
                {
                    entity_users admin = HttpContext.Current.Session["adminName"] as entity_users;
                    if (admin.sid.Equals("0000-0000-0000-0000"))
                    {
                        this.adminData.Visible = false;
                    }
                    this.lab_adminName.Text = admin.RealName;
                }
            }
            else
            {
                if (HttpContext.Current.Session["adminName"] == null)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未登录!');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('未登录!')", true);
                    Response.Redirect("login.aspx");
                }
                else
                {
                    //admin = HttpContext.Current.Session["adminName"] as Administrator;
                    //this.lab_adminName.Text = admin.AdminName;
                }
            }

        }
        protected void exit_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["adminName"] = null;
            Response.Redirect("login.aspx");
        }
        protected void adminData_Click(object sender, EventArgs e)
        {
            entity_users user = HttpContext.Current.Session["adminName"] as entity_users;
            Response.Redirect("UpdateAdmin.aspx?id=" + user.sid);
        }
    }
}