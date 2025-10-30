using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string baseUrl
        {
            get
            {
                return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}