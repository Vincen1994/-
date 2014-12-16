using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace BallGameManage.Main
{
    public partial class BulletinDetail : System.Web.UI.Page
    {
        Bll.bll_NewList bll = new Bll.bll_NewList();
        string sid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = Request["id"].ToString();
            if (!IsPostBack)
            {
                this.HeadTitle.Text = "公告";
                DataBind(sid);
            }
        }
        private void DataBind(string sid)
        {
            entity_News news = bll.GetModel(sid);

            this.title.Text = news.title;
            this.Content.Text = Common.StringHelp.TextToHTMl(news.Content);
            this.ReleaseDate.Text = news.CreateTime;
        }
    }
}