using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Bll;

namespace WebApplication1.Main
{
    public partial class NewListDetail : System.Web.UI.Page
    {
        private bll_NewList bll = new bll_NewList();
        string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["type"].ToString();
            if (!IsPostBack)
            {
                switch (type)
                {
                    case "zc": this.HeadTitle.Text = "章程"; break;
                    case "jj": this.HeadTitle.Text = "简介"; break;
                    case "jgnsjg": this.HeadTitle.Text = "机关内设机构"; break;
                }
                DataBind(type);
            }
        }
        private void DataBind(string TitleType)
        {
            entity_News news = bll.GetEntity(TitleType);

            this.title.Text = news.title;
            this.Content.Text = StringHelp.TextToHTMl(news.Content);
            this.ReleaseDate.Text = news.CreateTime;
        }
    }
}