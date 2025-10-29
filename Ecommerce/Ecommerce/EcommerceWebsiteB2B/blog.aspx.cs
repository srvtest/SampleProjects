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
    public partial class blog : System.Web.UI.Page
    {
        
        UserDL objUserCls = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request.Path.Contains('/') ? Request.Path.Split('/').Last() : null;
                //string id = Request.QueryString["id"];
                //int blogId = 0;
                if (!string.IsNullOrEmpty(name))
                {
                    lblBlogName.Text = name;
                    //lblBlogName1.Text = name;
                    GetBlog(name);
                }
            }
            //  GetBlogSidebar();
            UCBlogsArchives.baseUrl = this.Master.baseUrl;
            UCLatestPosts.baseUrl = this.Master.baseUrl;
        }

        //private void GetBlogSidebar()
        //{
        //    objUserCls = new UserDL();
        //    DataSet ds = objUserCls.GetBlogSidebar();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            rptBlogs.DataSource = ds.Tables[0];
        //            rptBlogs.DataBind();
        //        }
        //    }
        //}

        private void GetBlog(string name)
        {
            objUserCls = new UserDL();
            DataSet ds = objUserCls.GetBlog(name);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptBlogs.DataSource = ds.Tables[0];
                rptBlogs.DataBind();
            }
            else
                lblNotFound.Visible = true;
        }
    }
}