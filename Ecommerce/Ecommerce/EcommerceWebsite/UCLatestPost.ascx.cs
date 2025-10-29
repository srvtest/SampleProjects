using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class UCLatestPost : System.Web.UI.UserControl
    {
        UserDL objUserCls = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLatestPosts(1,10);
            }
        }

        private void GetLatestPosts(int pageNum, int pageSize)
        {
            if(objUserCls == null)
                objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllBlogs(pageNum, pageSize);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                rptLatestPosts.DataSource = ds.Tables[1];
                rptLatestPosts.DataBind();
            }
        }
    }
}