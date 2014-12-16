using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace BallGameManage.Main
{
    public partial class Economydetail : System.Web.UI.Page
    {
        Bll.bll_ScheduleDetail bll = new Bll.bll_ScheduleDetail();
        string sid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = Request["id"].ToString();
            if (!IsPostBack)
            {
                DataBind(sid);
            }
        }
        private void DataBind(string sid)
        {
            entity_ScheduleDetail news = bll.GetModel(sid);

            this.title.Text = news.HomeCourtName+" VS "+news.awayName;

            ReleaseDate.Text = news.StartTime.ToString();
            ReleaseDate2.Text = news.EndTime.ToString();
            lab_one.Text = news.HomeCourt_Fraction.ToString();
            lab_two.Text = news.away_Fraction.ToString();
            lab_zt.Text = news.hh_State;
        }
    }
}