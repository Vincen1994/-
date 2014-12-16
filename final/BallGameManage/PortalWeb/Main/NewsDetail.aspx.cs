using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Bll;

namespace BallGameManage
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        string sid = "";
        private bll_NewList bll = new bll_NewList();
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = Request["id"].ToString();
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        private void DataBind()
        {
            entity_News news = bll.GetModel(sid);

            this.title.Text = news.title;
            this.Content.Text = Common.StringHelp.TextToHTMl(news.Content);
            this.ReleaseDate.Text = news.CreateTime;
        }
    }
}