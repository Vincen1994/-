using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

/// <summary>
///fileUp 的摘要说明
/// </summary>
/// 
namespace Common
{
    public static class fileUpHelper
    {

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="PosPhotoUpload">控件</param>
        /// <param name="saveFileName">保存的文件名</param>
        /// <param name="imagePath">保存的文件路径</param>
        public static string FileSc(FileUpload PosPhotoUpload, string saveFileName, string imagePath)
        {
            string state = "";
            if (PosPhotoUpload.HasFile)//判断是否有文件
            {
                if (PosPhotoUpload.PostedFile.ContentLength / 1024 < 10240)//判断文件是否大于10M
                {
                    if (CheckFileType(saveFileName))
                    {
                        PosPhotoUpload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(imagePath));
                    }
                    else
                    {
                        state = "上传文件类型不正确";
                    }
                }
                else
                {
                    state = "上传文件不能大于10M";
                }
            }
            else
            {
                state = "没有上传文件";
            }
            return state;
        }


        //用来获取文件类型

        public static bool CheckFileType(string fileName)
        {

            //获取文件的扩展名,前提要用这个方法必须引入命名空间io

            string ext = Path.GetExtension(fileName);

            switch (ext.ToLower())
            {

                case ".gif":

                    return true;

                case ".png":

                    return true;

                case ".jpeg":

                    return true;

                case ".jpg":

                    return true;

                default:

                    return false;

            }

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="Controlfile"></param>
        /// <param name="FileType"></param>
        /// <param name="FileSize"></param>
        /// <param name="SaveFileName"></param>
        /// <returns></returns>
        public static string UpFileFun(FileUpload Controlfile, string[] FileType, int FileSize, string SaveFileName)
        {
            string FileDir = Controlfile.PostedFile.FileName;
            string FileName = FileDir.Substring(FileDir.LastIndexOf("\\") + 1);                  //获取上传文件名称
            string FileNameType = FileDir.Substring(FileDir.LastIndexOf(".") + 1).ToString();    //获取上传文件类型
            int FileNameSize = Controlfile.PostedFile.ContentLength;                             //获取上传文件大小
            //  定义上传文件类型，并初始化
            string Types = "";
            Random r = new Random();
            //string strDate = DateTime.Now.ToString();//取当前时间用来修改上传文件名   
            //string str = strDate.Replace("/", "").Replace(":", "").Replace("   ", "");   //过滤当前时间里的特殊字符，如: - / : ,
            string EditFileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + r.Next(10000, 99999).ToString();
            //string strNewFileName = Guid.NewGuid().ToString();   
            //HttpContext.Current.Response.Write("<hr><br>" + strNewFileName + "<br><br><br><hr");

            try
            {
                if (FileNameSize / 1024 < FileSize)
                {
                    for (int i = 0; i < FileType.Length; i++)
                    {
                        if (FileNameType == FileType[i])
                        {
                            Types = FileNameType;
                        }
                    }
                    if (FileNameType == Types)
                    {
                        Controlfile.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(SaveFileName) + "/" + EditFileName + "." + FileNameType);
                        return ((SaveFileName) + "/" + EditFileName + "." + FileNameType).ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}