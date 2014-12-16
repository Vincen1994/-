using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Entity;

namespace BallGameManage.Administrator
{
    public partial class Matching : System.Web.UI.Page
    {
        string pid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            pid = Request["sid"];
            if(!IsPostBack){
                DataBind();
            }
        }
        bll_ScheduleDetail bll_sd = new bll_ScheduleDetail();
        private void DataBind()
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
           entity= bll_sd.GetModel(pid);
           this.lab_zhu.Text = entity.HomeCourtName;
           this.lab_ke.Text = entity.awayName;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity.EndTime = DateTime.Now;

            entity.HomeCourt_Fraction = Int32.Parse(this.tbx_Fraction1.Text);
            entity.away_Fraction = Int32.Parse(this.tbx_Fraction2.Text);
            entity.State = 2;
            bll_sd.Update(entity);

            Response.Redirect("MatchList.aspx?mm="+new Random().Next()+"&sid="+entity.T_Extend1);
        }



        bll_gameLog bll_gl = new bll_gameLog();        
        protected void btn_1_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity_gameLog model = new entity_gameLog();
            model.SID = Guid.NewGuid().ToString();
            model.PID = pid;
            model.CreateTime = DateTime.Now;
            model.Score = 1;
            model.TeamID = entity.HomeCourt;
            model.TeamName = entity.HomeCourtName;
            bll_gl.Add(model);
            Additive(this.tbx_Fraction1.Text, 1);
        }

        protected void btn_2_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity_gameLog model = new entity_gameLog();
            model.SID = Guid.NewGuid().ToString();
            model.PID = pid;
            model.CreateTime = DateTime.Now;
            model.Score = 2;
            model.TeamID = entity.HomeCourt;
            model.TeamName = entity.HomeCourtName;
            bll_gl.Add(model);
            Additive(this.tbx_Fraction1.Text, 2);

        }

        protected void btn_3_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity_gameLog model = new entity_gameLog();
            model.SID = Guid.NewGuid().ToString();
            model.PID = pid;
            model.CreateTime = DateTime.Now;
            model.Score = 2;
            model.TeamID = entity.HomeCourt;
            model.TeamName = entity.HomeCourtName;
            bll_gl.Add(model);
            Additive(this.tbx_Fraction1.Text, 3);

        }

        protected void btn_11_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity_gameLog model = new entity_gameLog();
            model.SID = Guid.NewGuid().ToString();
            model.PID = pid;
            model.CreateTime = DateTime.Now;
            model.Score = 1;
            model.TeamID = entity.away;
            model.TeamName = entity.awayName;
            bll_gl.Add(model);
            Additive(this.tbx_Fraction2.Text, 1);

        }

        protected void btn_22_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity_gameLog model = new entity_gameLog();
            model.SID = Guid.NewGuid().ToString();
            model.PID = pid;
            model.CreateTime = DateTime.Now;
            model.Score = 2;
            model.TeamID = entity.away;
            model.TeamName = entity.awayName;
            bll_gl.Add(model);
            Additive(this.tbx_Fraction2.Text, 2);


        }

        protected void btn_33_Click(object sender, EventArgs e)
        {
            entity_ScheduleDetail entity = new entity_ScheduleDetail();
            entity = bll_sd.GetModel(pid);
            entity_gameLog model = new entity_gameLog();
            model.SID = Guid.NewGuid().ToString();
            model.PID = pid;
            model.CreateTime = DateTime.Now;
            model.Score = 3;
            model.TeamID = entity.away;
            model.TeamName = entity.awayName;
            bll_gl.Add(model);
            Additive(this.tbx_Fraction2.Text, 3);
          
        }

        private string Additive(string txt,int fenshu)
        {
            string result="";
            if (string.IsNullOrEmpty(txt))
            {
                result = fenshu.ToString();
            }
            else
            {
                result = (Int32.Parse(txt) + fenshu).ToString();
            }
            return result;
        }
    }
}