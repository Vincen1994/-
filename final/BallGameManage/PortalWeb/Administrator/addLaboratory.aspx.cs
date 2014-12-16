using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Entity;
namespace BallGameManage.Administrator
{
    public partial class addLaboratory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bll_Laboratory bll = new bll_Laboratory();
        protected void Submit_Click(object sender, EventArgs e)
        {
            entity_Laboratory model = new entity_Laboratory();
            model.SID = Guid.NewGuid().ToString();
            model.Name = this.adminName.Text;
            if (bll.Add(model))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功!');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加成功')", true);
                    Response.Redirect("selectLaboratory.aspx?mm="+new Random().Next(), true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加失败!');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加失败')", true);
                }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            this.adminName.Text = "";
        }
    }
}