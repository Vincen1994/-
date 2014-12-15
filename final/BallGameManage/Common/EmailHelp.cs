using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;

/// <summary>
///EmailHelp 的摘要说明
/// </summary>
/// 
namespace Common
{
    public class EmailHelp
    {
        public EmailHelp()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static void Send(string from, string to, string subject, string content)
        {
            SmtpClient client = new SmtpClient("smtp.sina.cn", 25);
            client.Credentials = new NetworkCredential("svesvesve", "svesvesve");
            MailMessage msg = new MailMessage(from, to, subject, content);
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            client.Send(msg);
        }

        public static void SendConfirmMail(string to, string code)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("点击这个链接进行激活。<a href='http://localhost:5550/Member/Active?code={0}'>http://localhost:5550/Member/Active?code={0}</a>", code);
            //EmailHelper.Send("svesvesve@sina.cn", to, "小说网注册确认邮件", sb.ToString());
        }
    }
}