using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Bll;
using Dal;
using System.Data;
namespace BallGameManage.Main
{
    public partial class Proceedingsdetail : System.Web.UI.Page
    {
        bll_ImageList bll = new bll_ImageList();
        string pid = "";
        public int page;
        string type = "";
        public int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            pid = Request["pid"].ToString();
            type = Request["type"];
            if (!IsPostBack)
            {
                switch (type)
                {
                    case "1": this.HeadTitle.Text = "总商会会刊"; break;
                    case "2": this.HeadTitle.Text = "各行业会刊"; break;
                }
                Refresh(1);
            }
            page = Convert.ToInt32(this.ddl_.SelectedValue.ToString());
        }
        private void Refresh(int Pages)
        {
            ddl_bind();
            getcount();
            this.img_btn2.Enabled = true;
            this.img_btn1.ImageUrl = "~/img/l.gif";
            this.img_btn2.ImageUrl = "~/img/r.gif";
            this.img_btn1.Enabled = true;
            this.link_shang.Visible = true;
            this.link_xia.Visible = true;
            if (Pages == 1)
            {
                this.img_btn1.Enabled = false;
                this.img_btn1.ImageUrl = "~/img/lxx.gif";
                this.link_shang.Visible = false;
            }
            if (Pages == count)
            {
                this.img_btn2.ImageUrl = "~/img/rxx.gif";
                this.img_btn2.Enabled = false;
                this.link_xia.Visible = false;
            }
            page = Pages;
            string where = " pid='" + pid + "' and name='" + Pages + "'";
            DataSet table = bll.GetList(where);
            this.ImageList.DataSource = table.Tables[0];
            this.ImageList.DataBind();
            this.ddl_.SelectedValue = Pages.ToString();

        }
        protected void link_shang_Click(object sender, EventArgs e)
        {
            Refresh(page - 1);
        }
        protected void link_xia_Click(object sender, EventArgs e)
        {
            Refresh(page + 1);
        }
        private void getcount()
        {
            string sql = "select  name from  [ImageList] where pid='" + pid + "' order by name  ";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                count = ds.Tables[0].Rows.Count;
            }
        }
        private void ddl_bind()
        {
            this.ddl_.Items.Clear();
            string sql = "select name from  [ImageList] where pid='" + pid + "' order by name  ";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    this.ddl_.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));
                }
            }
        }
        protected void ddl__SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(this.ddl_.SelectedValue.ToString());
            Refresh(i);
            page = i;
        }
        protected void img_btn1_Click(object sender, ImageClickEventArgs e)
        {
            Refresh(page - 1);
        }
        protected void img_btn2_Click(object sender, ImageClickEventArgs e)
        {
            Refresh(page + 1);
        }
    }
}