using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LunarBase.WebData;

namespace LunarBase.WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Configuration.ApplicationDomain = Request.Url.AbsoluteUri.Substring(
                                            0, Request.Url.AbsoluteUri.IndexOf(Request.Url.AbsolutePath));
        }
    }
}