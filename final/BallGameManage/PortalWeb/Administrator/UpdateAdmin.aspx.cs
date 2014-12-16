using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BallGameManage.Administrator
{
    public partial class UpdateAdmin : System.Web.UI.Page
    {
        Bll.bll_users bll = new Bll.bll_users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillingData();
            }
        }
        Entity.entity_users user = new Entity.entity_users();
        protected void Submit_Click(object sender, EventArgs e)
        {
            //Entity.entity_users user = new Entity.entity_users();
            //user.sid = this.adminID.Text.ToString().Trim();
            //user.userID = this.adminName.Text.Trim();
            //user.RealName = this.realName.Text.Trim();
            string id = Request.QueryString["id"].ToString();
            user = bll.GetModel(id);

            if (this.adminPwd.Text.Trim() != "")
            {
                user.PassWord = Common.passwordHelp.Encrypt(this.adminPwd.Text.Trim());
                if (bll.Update(user))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('修改成功')", true);
                    Response.Redirect("selectdAdmin.aspx", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改失败');</script>");
                    ////// ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('修改失败')", true);
                    Reset_Click(null, null);
                }
            }
            else
            {
                user.RealName = this.realName.Text.Trim();
                if (bll.Update(user))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('修改成功')", true);
                    Response.Redirect("selectdAdmin.aspx", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改失败');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('修改失败')", true);
                    Reset_Click(null, null);
                }
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        public void FillingData()
        {
            string id = Request.QueryString["id"].ToString();
            user = bll.GetModel(id);
            this.adminID.Text = user.sid;
            this.adminName.Text = user.userID;
            //this.adminPwd.Text = user.PassWord;
            this.realName.Text = user.RealName;
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            FillingData();
        }
    }
}