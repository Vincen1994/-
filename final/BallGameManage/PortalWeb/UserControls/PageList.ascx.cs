using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BallGameManage.UserControls
{
    public partial class PageList : System.Web.UI.UserControl
    {
        private int pagesize;
        private int currentPageIndex;
        private int pageCount;
        public delegate void PageListChang(object sender, PageListEventArgs el);
        public event PageListChang pagelistchang;
        public class PageListEventArgs : System.EventArgs
        {

        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return Convert.ToInt32(this.Lbpagecount.Text); }
            set
            {
                pageCount = value;
            }

        }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int Pagesize
        {
            get { return Convert.ToInt32(DDLpageindex.SelectedValue); }
            set
            {
                if (value == 10)
                {
                    DDLpageindex.SelectedIndex = 0;
                }
                if (value == 15)
                {
                    DDLpageindex.SelectedIndex = 1;
                }
                else if (value == 20)
                {
                    DDLpageindex.SelectedIndex = 2;
                }
                else if (value == 50)
                {
                    DDLpageindex.SelectedIndex = 3;
                }
                else if (value == 100)
                {
                    DDLpageindex.SelectedIndex = 4;
                }
                else if (value == 50000000)
                {
                    DDLpageindex.SelectedIndex = 5;
                }
            }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPageIndex
        {
            get { return Convert.ToInt32(LbCurrentPage.Text); }
            set
            {
                LbCurrentPage.Text = value.ToString();
                //this.pageCount = recordCount % Convert.ToInt16(this.DDLpageindex.SelectedValue) == 0 ? recordCount / Convert.ToInt16(this.DDLpageindex.SelectedValue) : recordCount / Convert.ToInt16(this.DDLpageindex.SelectedValue) + 1;
                //this.Page_bind();
            }
        }
        /// <summary>
        /// 记录数目
        /// </summary>
        public int RecordCount
        {
            get { return Convert.ToInt32(this.LbRecordCount.Text); }
            set
            {
                this.LbRecordCount.Text = value.ToString();
                this.Lbpagecount.Text = (Convert.ToInt32(this.LbRecordCount.Text) % Convert.ToInt32(this.DDLpageindex.SelectedValue) == 0 ? Convert.ToInt32(this.LbRecordCount.Text) / Convert.ToInt32(this.DDLpageindex.SelectedValue) : Convert.ToInt32(this.LbRecordCount.Text) / Convert.ToInt32(this.DDLpageindex.SelectedValue) + 1).ToString();

                if (Convert.ToInt32(this.LbCurrentPage.Text) == 1)
                {//如果当前为首页，那么上页和首页按纽不可用 
                    BtnPageTop.Enabled = false;
                    BtnPageUp.Enabled = false;
                }
                else
                {
                    BtnPageTop.Enabled = true;
                    BtnPageUp.Enabled = true;
                }
                if (Convert.ToInt32(this.LbCurrentPage.Text) >= Convert.ToInt32(this.Lbpagecount.Text))
                {//如果当前为末页,那么下页和末页按纽不可用 
                    BtnPageDown.Enabled = false;
                    BtnPageLast.Enabled = false;
                }
                else
                {
                    BtnPageDown.Enabled = true;
                    BtnPageLast.Enabled = true;
                }

                if (Convert.ToInt32(this.Lbpagecount.Text) == 0 || Convert.ToInt32(this.Lbpagecount.Text) == 1)
                {
                    BtnPageTop.Enabled = false;
                    BtnPageUp.Enabled = false;
                    BtnPageDown.Enabled = false;
                    BtnPageLast.Enabled = false;
                    BtnGo.Enabled = false;
                }
                else
                {
                    BtnGo.Enabled = true;
                }
                if (Lbpagecount.Text == "0")
                {
                    Lbpagecount.Text = "1";
                }
                this.Pagesize = Convert.ToInt32(this.DDLpageindex.SelectedValue);
                this.CurrentPageIndex = Convert.ToInt32(this.LbCurrentPage.Text);
            }
        }
        private void Page_bind()
        {

            //this.Lbpagecount.Text = this.PageCount.ToString();
            //this.LbRecordCount.Text=this.RecordCount.ToString();

            if (Convert.ToInt32(this.LbCurrentPage.Text) == 1)
            {//如果当前为首页，那么上页和首页按纽不可用 
                BtnPageTop.Enabled = false;
                BtnPageUp.Enabled = false;
            }
            else
            {
                BtnPageTop.Enabled = true;
                BtnPageUp.Enabled = true;
            }
            if (Convert.ToInt32(this.LbCurrentPage.Text) >= Convert.ToInt32(this.Lbpagecount.Text))
            {//如果当前为末页,那么下页和末页按纽不可用 
                BtnPageDown.Enabled = false;
                BtnPageLast.Enabled = false;
            }
            else
            {
                BtnPageDown.Enabled = true;
                BtnPageLast.Enabled = true;
            }

            if (Convert.ToInt32(this.Lbpagecount.Text) == 0 || Convert.ToInt32(this.Lbpagecount.Text) == 1)
            {
                BtnPageTop.Enabled = false;
                BtnPageUp.Enabled = false;
                BtnPageDown.Enabled = false;
                BtnPageLast.Enabled = false;
                BtnGo.Enabled = false;
            }
            else
            {
                BtnGo.Enabled = true;
            }

            this.Pagesize = Convert.ToInt32(this.DDLpageindex.SelectedValue);
            this.CurrentPageIndex = Convert.ToInt32(this.LbCurrentPage.Text);
            if (Lbpagecount.Text == "0")
            {
                this.LbCurrentPage.Text = "0";
            }
            //this.RecordCount = Convert.ToInt16(this.LbRecordCount.Text);
            PageListEventArgs el = new PageListEventArgs();
            //事件发生
            pagelistchang(this, el);


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPageTop_Click(object sender, EventArgs e)
        {
            this.LbCurrentPage.Text = "1";
            Page_bind();

        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPageUp_Click(object sender, EventArgs e)
        {
            this.LbCurrentPage.Text = (Convert.ToInt32(this.LbCurrentPage.Text) - 1).ToString();
            Page_bind();

        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPageDown_Click(object sender, EventArgs e)
        {
            this.LbCurrentPage.Text = (Convert.ToInt32(this.LbCurrentPage.Text) + 1).ToString();
            Page_bind();

        }
        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPageLast_Click(object sender, EventArgs e)
        {
            this.LbCurrentPage.Text = this.Lbpagecount.Text;
            Page_bind();

        }
        protected void BtnGo_Click(object sender, EventArgs e)
        {
            if (TBPage.Text.Trim().Length == 0)
            {
            }
            else
            {
                if (Convert.ToInt32(TBPage.Text) > Convert.ToInt32(this.Lbpagecount.Text))
                {
                    this.LbCurrentPage.Text = this.Lbpagecount.Text;
                    this.TBPage.Text = this.Lbpagecount.Text;
                }
                else
                {
                    this.LbCurrentPage.Text = Convert.ToInt32(TBPage.Text).ToString();
                }
            }
            this.Page_bind();
        }
        protected void DDLpageindex_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LbCurrentPage.Text = "1";
            this.Lbpagecount.Text = (Convert.ToInt32(this.LbRecordCount.Text) % Convert.ToInt32(DDLpageindex.SelectedValue) == 0 ? Convert.ToInt32(this.LbRecordCount.Text) / Convert.ToInt32(DDLpageindex.SelectedValue) : Convert.ToInt32(this.LbRecordCount.Text) / Convert.ToInt32(DDLpageindex.SelectedValue) + 1).ToString();
            this.Page_bind();

        }
   
    }
}