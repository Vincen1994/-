using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.IO;

namespace BallGameManage.Administrator
{
    public partial class addImage : System.Web.UI.Page
    {
        private bll_ImageList bll = new bll_ImageList();
        private Entity.entity_ImageList img = new Entity.entity_ImageList();
        string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["type"];
            if (!IsPostBack)
            {
                if (type=="one")
                {
                    lab_huikan.Text = "添加精彩片段";
                }
                if (type == "two")
                {
                    lab_huikan.Text = "添加绝杀时刻";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (this.FileUpload.FileName == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请选择图片');</script>");
                return;
            }
            string Extension = Path.GetExtension(this.FileUpload.FileName);
            string ImageName = Path.GetFileNameWithoutExtension(this.FileUpload.FileName);
            Entity.entity_ImageList image = new Entity.entity_ImageList();
            image.sid = Guid.NewGuid().ToString();
            image.url = UpLoad(img.name, Extension, ImageName); ;
            image.Pid = "";
            image.bookName = img.name;
            image.Type = "";
            image.name = ImageName;
            if (bll.Add(image))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功');</script>");
            }
        }
        private string UpLoad(string bookName, string extension, string Name)
        {
            string path = "../UpLoad/" + bookName;
            this.FileUpload.SaveAs(Server.MapPath(path + "/" + Name + extension));
            return path + "/" + Name + extension;
        }
        protected void btn_fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("selectImage.aspx?type="+type);
        }
    }
}

