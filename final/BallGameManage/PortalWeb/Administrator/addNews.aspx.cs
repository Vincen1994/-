using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Bll;
using Entity;

namespace BallGameManage.Administrator
{
    public partial class addNews : System.Web.UI.Page
    {
        private bll_NewList bll = new bll_NewList();
        private Bll_Helper help = new Bll_Helper();
        private bll_ImageList img = new bll_ImageList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["sid"] = Guid.NewGuid().ToString();
                this.Panel.Visible = false;
            }
        }



        protected void Submit_Click(object sender, EventArgs e)
        {

            if (this.CreateTime.Value == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('创建时间不能为空！');</script>");
                return;
            }
            entity_users user = Session["adminName"] as entity_users;


            entity_News news = new entity_News();
            news.Content = Common.StringHelp.HTMLToText(this.newsContent.Value.Trim());
            news.sid = ViewState["sid"].ToString();
            news.type = "";
            news.title = this.newsName.Text.Trim();
            news.CreateTime = this.CreateTime.Value;
            news.CreatePeople = user.userID;
            if (this.FileUpload.FileName != null)
            {
                //img.Add();
            }

            if (bll.Add(news))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功');</script>");
                ////// ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加成功')", true);
                Response.Redirect("selectedNews.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加失败');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加失败')", true);
            }

        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            this.newsName.Text = "";
        }

        string ImagePath = "";
        protected void upload_Click(object sender, EventArgs e)
        {
            if (this.FileUpload.FileName.Equals(""))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "alert('请选择图片');", true);
                return;
            }
            if (!Common.fileUpHelper.CheckFileType(this.FileUpload.FileName))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "alert('上传文件不是图片');", true);
                return;
            }
            entity_ImageList imgs = new entity_ImageList();
            string ImagePath = "../UpLoad/";
            if (!Directory.Exists(Server.MapPath(ImagePath)))
            {
                Directory.CreateDirectory(Server.MapPath(ImagePath));
            }
            imgs.sid = Guid.NewGuid().ToString();
            imgs.name = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(this.FileUpload.FileName);
            imgs.url = ImagePath + imgs.name;
            //ImagePath = imgs.url;
            imgs.bookName = "";
            imgs.Pid = ViewState["sid"].ToString();
            imgs.Type = "";
            this.FileUpload.SaveAs(Server.MapPath(imgs.url));
            img.Add(imgs);

            //todo:把图片显示在页面上
            this.Image.ImageUrl = ImagePath + imgs.name;
            this.Panel.Visible = true;
        }

        protected void linkbtn_delete_Click(object sender, EventArgs e)
        {
            this.Panel.Visible = false;
            if (img.Delete(ViewState["sid"].ToString()))
            {
                File.Delete(ImagePath);
            }
            this.Image.ImageUrl = "";
        }
        protected void linkbtn_select_Click(object sender, EventArgs e)
        {

        }
    }
}