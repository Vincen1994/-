using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bll;
using Entity;
using System.IO;

namespace BallGameManage.Administrator
{
    public partial class UpdateNews : System.Web.UI.Page
    {
        private bll_NewList bll = new bll_NewList();
        string sid = "";
        string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sid = Request["id"].ToString();
            type = Request["type"].ToString();

            if (!IsPostBack)
            {
                databinding();
                if (true)
                {
                    this.Panel.Visible = true;
                }
            }
            if (type == "gg")
            {
                this.ImgPanel.Visible = false;
                this.Panel.Visible = false;
            }
            getImage();
        }
        /// <summary>
        /// 将获取到的值绑定到控件中
        /// </summary>
        public void databinding()
        {

            entity_News news = bll.GetModel(sid);
            this.newsName.Text = news.title;
            this.CreateTime.Value = news.CreateTime;
            this.newsContent.InnerText = Common.StringHelp.TextToHTMl(news.Content);
        }
        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Submit_Click(object sender, EventArgs e)
        {
            entity_users user = Session["adminName"] as entity_users;
            entity_News news = bll.GetModel(sid);
            news.Content = Common.StringHelp.HTMLToText(this.newsContent.Value.Trim());

            news.title = this.newsName.Text.Trim();
            news.type = type;
            news.CreateTime = this.CreateTime.Value;
            news.CreatePeople = user.userID;
            if (bll.Update(news))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('修改成功')", true);
                Response.Redirect("selectedNews.aspx?type=" + type);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改失败');</script>");
                //////ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('修改失败')", true);
            }
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Reset_Click(object sender, EventArgs e)
        {
            databinding();
        }
        private void getImage()
        {
            bool isImage = false;
            isImage = img.ImgExists(sid);
            if (isImage)
            {
                this.Panel.Visible = true;
                entity_ImageList imgs = img.imgGetModel(sid);
                this.Image.ImageUrl = imgs.url;
            }
            else
            {
                this.Panel.Visible = false;
            }
        }
        private bll_ImageList img = new bll_ImageList();
        protected void linkbtn_delete_Click(object sender, EventArgs e)
        {
            this.Panel.Visible = false;
            /*
            if (img.Delete(Sid))
            {
                File.Delete(ImagePath);
            }
            this.Image.ImageUrl = "";*/
        }
        protected void linkbtn_select_Click(object sender, EventArgs e)
        {

        }
        protected void upload_Click(object sender, EventArgs e)
        {
            string Extension = Path.GetExtension(this.FileUpload.FileName);
            string ImageName = Path.GetFileNameWithoutExtension(this.FileUpload.FileName);
            Entity.entity_ImageList image = new Entity.entity_ImageList();
            image.sid = Guid.NewGuid().ToString();
            image.url = UpLoad(DateTime.Now.ToString("yyyyMMddhhmmssff"), Extension);
            image.Pid = sid;
            image.bookName = type;
            image.Type = "";
            image.name = ImageName;
            this.Panel.Visible = true;
            this.Image.ImageUrl = image.url;
            if (img.Add(image))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功');</script>");
                ////// ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('添加成功')", true);
            }
        }
        private string UpLoad(string date, string extension)
        {
            string path = "../UpLoad/" + type;
            if (!Directory.Exists(Server.MapPath(path)))
            {
                Directory.CreateDirectory(Server.MapPath(path));
            }
            this.FileUpload.SaveAs(Server.MapPath(path + "/" + date + extension));
            return path + "/" + date + extension;
        }
    }
}