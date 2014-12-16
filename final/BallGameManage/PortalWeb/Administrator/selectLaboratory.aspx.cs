using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;


namespace BallGameManage.Administrator
{
    public partial class selectLaboratory : System.Web.UI.Page
    {
        private Bll.Bll_Helper help = new Bll.Bll_Helper();
        private Bll.bll_Laboratory bll = new Bll.bll_Laboratory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pagelist_chang(null, null);
            }
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
        /// <summary>
        /// 批量删除
        /// </summary>
        public void batchDelete()
        {
            for (int i = 0; i < Repeater.Items.Count; i++)
            {
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)Repeater.Items[i].FindControl("checkbox");
                string id = ckb.Value;
                if (ckb.Checked == true)
                {
                    if (bll.Delete(id))
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                        ////// ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('删除成功')", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除失败');</script>");
                        ////// ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('删除失败')", true);
                    }
                }
            }
            pagelist_chang(null, null);
        }
        protected void lk_btn_batchDelete_Click(object sender, EventArgs e)
        {
            batchDelete();
        }
        protected void batchDelete_Click(object sender, ImageClickEventArgs e)
        {
            batchDelete();
        }
        protected void Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = ((ImageButton)e.Item.FindControl("Delete")).CommandArgument;
            if (e.CommandName == "Delete")
            {
                if (bll.Delete(id))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('删除成功')", true);
                    pagelist_chang(null, null);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除失败');</script>");
                    //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('删除失败')", true);
                }
            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/addLaboratory.aspx?mm="+new Random().Next(),true);
        }
    }
}