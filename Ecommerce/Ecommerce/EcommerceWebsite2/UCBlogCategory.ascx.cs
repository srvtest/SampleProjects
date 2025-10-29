using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite2
{
    public partial class UCBlogCategory : System.Web.UI.UserControl
    {
        public List<BlogsCls> blogs;
        protected void Page_Load(object sender, EventArgs e)
        {
            rptBlogCategory.DataSource = blogs;
            rptBlogCategory.DataBind();
        }
    }
}