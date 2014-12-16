using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Entity;

namespace BallGameManage.Administrator
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["adminName"] = null;
        }

        private bll_users bll = new bll_users();

        protected void user_submit_Click(object sender, EventArgs e)
        {
            entity_users user = new entity_users();
            user.userID = this.username.Text.Trim();
            user.PassWord = Common.passwordHelp.Encrypt(this.userpassword.Text.Trim());
            if (bll.adminLogin(user))
            {
                string where = "userID='" + user.userID + "'";
                entity_users user_admin = bll.GetEntity(user.userID);
                HttpContext.Current.Session["adminName"] = user_admin;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('密码或帐号错误!');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('')", true);
            }

        }
    }
}