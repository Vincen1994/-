using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;

namespace Common
{
    public class JSHelper
    {
        public JSHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static Page CurrPage
        {
            get
            {
                return HttpContext.Current.Handler as Page;
            }
        }
        /// <summary>
        /// 向一个控件添加一个确认对话框.(如果取消则不提交服务器端)
        /// </summary>
        /// <param name="control">需要添加确认的控件</param>
        /// <param name="message">对话框中显示的文本</param>
        public static void AddConfirmToControl(IAttributeAccessor control, string message)
        {
            message = message.Replace("\\", "\\\\").Replace("\n", "\\n").Replace("\'", "\\'");
            control.SetAttribute("onclick", "return confirm('" + message + "');");
        }

        /// <summary>
        /// 直接关闭页面(忽略其他提示)
        /// </summary>
        public static void ClosePage()
        {
            HttpContext.Current.Response.Write(@"<script>window.opener=null;window.close();</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 给控件增加客户端属性
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="attributeName">属性名</param>
        /// <param name="attributeValue">属性值</param>
        /// <example>
        /// JS.AddAttributesToControl(TextBox1,"oncopy","return false;");  --生成的客户端html中增加  oncopy="return false;"
        /// </example>
        public static void AddAttributesToControl(IAttributeAccessor control, string attributeName, string attributeValue)
        {
            control.SetAttribute(attributeName, attributeValue);
        }

        /// <summary>
        /// 添加要执行的脚本
        /// </summary>
        /// <param name="scripts">脚本内容</param>
        /// <param name="key">脚本的键(如果该键已有则不重复创建)</param>
        public static void AddScript(string scripts, string key)
        {
            StringBuilder sb = new StringBuilder("<script language='javascript'>");
            sb.Append(scripts);
            sb.Replace("\\", "\\\\");
            sb.Replace("\n", "\\n");
            sb.Replace("\t", "\\t");
            sb.Replace("\r", "\\r");
            sb.Append("</script>");
            CurrPage.ClientScript.RegisterStartupScript(CurrPage.GetType(), key, sb.ToString());
        }

        /// <summary>
        /// 打开窗口(不允许一个页面打开多个窗口)
        /// </summary>
        /// <param name="page">this</param>
        /// <param name="URL">地址</param>
        /// <param name="Target">目标框架</param>
        public static void open(string url, string target)
        {
            AddScript("window.open('" + url + "','','" + target + "');", "open");
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url">地址</param>
        public static void location(string url)
        {
            AddScript("window.location.href='" + url + "';", "redirect");
        }

        /// <summary>
        /// 在页面顶部添加脚本
        /// </summary>
        /// <param name="values">脚本</param>
        public static void AddHead(string script)
        {
            StringBuilder sb = new StringBuilder("<script language=\"javascript\">");
            sb.Append(script);
            sb.Append("</script>");
            CurrPage.Response.Write(sb.ToString());
        }

        /// <summary>
        /// 弹出
        /// </summary>
        /// <param name="Msg">提示文本</param>
        public static void alert(string message)
        {
            AddScript("alert('" + message + "');", "alert");
        }


        /// <summary>
        /// 弹出
        /// </summary>
        /// <param name="Msg">提示文本</param>
        public static void confirm(string message, string a, string b)
        {
            AddScript("if(confirm('" + message + "')){" + a + "}else{" + b + "};", "confirm");
        }


        /// <summary>
        /// 带有图标的弹出窗口
        /// </summary>
        /// <param name="Icon">1 信息  2 错误  3警告</param>
        /// <param name="Message">弹出的信息内容</param>
        public static void alert(int Icon, string Message)
        {
            StringBuilder sb = new StringBuilder();
            Message = Message.Replace("\"", "\u201c");
            Message = Message.Replace("'", "\u2018");
            sb.Append("<script language=vbscript>\n");
            switch(Icon)
            {
                case 1:
                    sb.Append("msgbox \"" + Message + "\",\"64\"\n");
                    break;

                case 2:
                    sb.Append("msgbox \"" + Message + "\",\"16\"\n");
                    break;

                case 3:
                    sb.Append("msgbox \"" + Message + "\",\"48\"\n");
                    break;
            }
            sb.Append("</script>");
            CurrPage.ClientScript.RegisterStartupScript(typeof(string), "ALERT", sb.ToString());
        }




        /// <summary>
        /// 弹出提示并跳转页面
        /// </summary>
        /// <param name="page">this</param>
        /// <param name="Msg">提示信息</param>
        /// <param name="URL">跳转地址</param>
        /// <param name="Target">目标框架</param>
        public static void AlertAndRedirect(string message, string url, string target)
        {
            alert(message);
            open(url, target);
        }

        /// <summary>
        ///先弹出提示框后跳转
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void AlertAndRedirect(string message, string url)
        {
            alert(message);
            location(url);
        }

        /// <summary>
        ///先弹出提示框后跳转
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void AlertAndRedirectScroll(string message, string url)
        {
            alert(message);
            AddScript("window.open('" + url + "','null', 'height=700, width=1000, top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');", "redirect");
            //location(url);
        }

        /// <summary>
        ///先弹出提示框后跳转
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void AlertAndRedirectScroll(string url)
        {
            AddScript("window.open('" + url + "','null', 'height=700, width=1000, top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');", "redirect");
            //location(url);
        }
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
    }
}