using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsiteB2B
{
    public partial class UCLatestPosts : System.Web.UI.UserControl
    {
        public string baseUrl = string.Empty;
        UserDL objUserCls = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objUserCls = new UserDL();
            DataSet ds = objUserCls.GetBlogSidebar();
            if (ds != null)
            {
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    rptLatestPost.DataSource = ds.Tables[1];
                    rptLatestPost.DataBind();
                }
            }
        }
    }
}