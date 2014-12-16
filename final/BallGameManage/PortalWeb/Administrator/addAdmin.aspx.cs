using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Entity;
namespace BallGameManage.Administrator
{
    public partial class addAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bll_users u_bll = new bll_users();
        protected void Submit_Click(object sender, EventArgs e)
        {


            entity_users user = new entity_users();
            user.sid = Guid.NewGuid().ToString();
            user.userID = this.adminName.Text.Trim();
            user.RealName = this.realName.Text.Trim();
            user.PassWord = Common.passwordHelp.Encrypt(this.adminPwd.Text.ToString().Trim());
            string where = " userID='" + user.userID + "'";
            if (u_bll.Exists(where))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('帐号已存在,请从更换帐号!');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('帐号已存在,请从更换帐号')", true);
                return;
            }
            else
            {
                if (u_bll.Add(user))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功!');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加成功')", true);
                    Response.Redirect("selectdAdmin.aspx", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加失败!');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加失败')", true);
                }
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            this.adminName.Text = "";
            this.adminPwd.Text = "";
            this.confirmPwd.Text = "";
        }
    }
}