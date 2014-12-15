using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Drawing;
using System.IO;

/// <summary>
///VerificationHelp 的摘要说明
/// </summary>
/// 
namespace Common
{
    public class VerificationHelp
    {
        public VerificationHelp()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private const string VcSessionKey = "VcSessionKey_{07B3470A-1A7D-4D3E-A58B-A45D7A3A65C0}";
        private const string Meta = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int DefaultLength = 4;

        public static void GenerateCode()
        {
            HttpContext.Current.Session[VerificationHelp.VcSessionKey] = VerificationHelp.GenerateCode(null);
        }
        public static string GenerateCode(int? len)
        {
            if (!len.HasValue || len <= 0)
            {
                len = VerificationHelp.DefaultLength;
            }
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                int r = rnd.Next(VerificationHelp.Meta.Length);
                sb.Append(Meta[r]);
            }
            return sb.ToString();
        }

        public static Image GetImage()
        {
            string code = (string)HttpContext.Current.Session[VerificationHelp.VcSessionKey];
            if (code == null) code = String.Empty;
            int width = 60;
            int height = 24;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 1, 1, width - 2, height - 2);
            Font f = new Font("宋体", 16);
            g.DrawString(code, f, Brushes.Red, 0, 0);
            g.Save();
            g.Dispose();
            return bmp;
        }
        public static Stream GetImageStream()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            VerificationHelp.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }

        public static bool Check(string code)
        {
            string vc = (string)HttpContext.Current.Session[VerificationHelp.VcSessionKey];
            if (String.IsNullOrEmpty(vc) || String.IsNullOrEmpty(code))
            {
                return false;
            }
            return vc.ToLower().Equals(code.ToLower());
        }
    }
}