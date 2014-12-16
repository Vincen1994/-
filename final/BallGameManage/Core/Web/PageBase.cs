using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web
{
    /// <summary>
    /// 页面基础类.
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!this.IsPostBack)   
            {
               // Log.LogHelper.WriteSystemLog(this.Request.Cookies["KEY_Identity"].Value, this.Request.Params["ResId"], "");
            }
        }
    }
}
