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
    public partial class UCBlogsArchives : System.Web.UI.UserControl
    {
        public string baseUrl = string.Empty;
        
        //public DataTable blogs;
        UserDL objUserCls = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objUserCls = new UserDL();
            DataSet ds = objUserCls.GetBlogSidebar();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptBlogArchives.DataSource = ds.Tables[0];
                    rptBlogArchives.DataBind();
                }
            }
        }
    }
}