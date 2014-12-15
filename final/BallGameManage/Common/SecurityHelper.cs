using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class SecurityHelper
    {
        /// <summary>
        /// 设置登录用户标识
        /// </summary>
        public static void SetLoginIdentity(string Identity)
        {
            HttpContext context = HttpContext.Current;
            HttpCookie cookie = new HttpCookie("KEY_Identity");
            cookie.Value = Identity;
            //cookie.Expires = DateTime.Now.AddDays(1);
            if(null != context.Request.Cookies["KEY_Identity"])
            {
                context.Request.Cookies.Remove("KEY_Identity");
            }
            context.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取登录用户标识
        /// </summary>
        public static string GetLoginIdentity()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["KEY_Identity"];
            if(null == cookie || string.IsNullOrEmpty(cookie.Value))
                return null;
            return cookie.Value;
        }

        /// <summary>
        /// 移除登录用户标识
        /// </summary>
        public static void RemoveLoginIdentity()
        {
            HttpContext context = HttpContext.Current;
            HttpCookie cookie = context.Request.Cookies["KEY_Identity"];
            if(cookie == null || string.IsNullOrEmpty(cookie.Value))
                return;
            context.Response.Cookies["KEY_Identity"].Expires = DateTime.Now.AddDays(-1);
        }

        /// <summary>
        /// 获取默认角色Id
        /// </summary>
        public static string GetDefaultRoleId()
        {
            return "DefaultRoleId";
        }
    }
}
