using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace BallGameManage.Administrator
{
    public partial class selectImage : System.Web.UI.Page
    {
        string type = "";
        string Pid = "";
        private Bll.bll_ImageList bll = new Bll.bll_ImageList();
        protected void Page_Load(object sender, EventArgs e)
        {
            Pid = Request["pid"];
            type = Request["type"];
            if (type == "one")
            {
                this.lab_huikan.Text = "精彩片段";
            }
            if (type == "one")
            {
                this.lab_huikan.Text = "绝杀时刻";
            }
            if (!IsPostBack)
            {
                pagelist_chang(null, null);
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        public void batchDelete()
        {
            for (int i = 0; i < ImageList.Items.Count; i++)
            {
                HtmlInputCheckBox ckb = (HtmlInputCheckBox)ImageList.Items[i].FindControl("checkbox");
                string id = ckb.Value;
                if (ckb.Checked == true)
                {
                    if (bll.Delete(id))
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                    }
                }
            }
        }
        private void DataBind(string SID)
        {
            string where = "type='" + type + "'";
            DataSet ds = bll.GetList(where);
            this.ImageList.DataSource = ds.Tables[0];
            this.ImageList.DataBind();
        }
        protected void pagelist_chang(object sender, EventArgs e)
        {
            int recordCount = 0;
            string where = "type='"+type+"'";
            string showfield = " * ";
            DataTable dataTable = bll.GetDataPager(pagelist.CurrentPageIndex - 1, pagelist.Pagesize, ref recordCount, where, showfield);
            this.ImageList.DataSource = dataTable;
            this.ImageList.DataBind();
            pagelist.RecordCount = recordCount;
        }
        protected void batchDelete_Click(object sender, ImageClickEventArgs e)
        {
            batchDelete();
            DataBind(Pid);
        }
        protected void lk_btn_batchDelete_Click(object sender, EventArgs e)
        {
            batchDelete();
            DataBind(Pid);
        }
        protected void lk_btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/addImage.aspx?type=" + type);
        }
        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("delete"))
            {
                if (bll.Delete(e.CommandArgument.ToString()))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除失败');</script>");
                }
            }
            if (e.CommandName.Equals("select"))
            {
                string id = e.CommandArgument.ToString();
                Entity.entity_ImageList img = bll.GetModel(id);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>Open('" + img.url + "');</script>");
            }
            DataBind(Pid);
        }
    }
}