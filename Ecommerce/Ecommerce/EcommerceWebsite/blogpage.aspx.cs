using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class blogpage : System.Web.UI.Page
    {
        UserDL objUserCls = null;
        static int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllBlogs(1, pageSize);
            }
        }

        private void GetAllBlogs(int pageNum, int pageSize)
        {
            int recordCount = 0;
            if(objUserCls == null)
                objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllBlogs(pageNum, pageSize);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    recordCount = Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]);
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    rptBlogs.DataSource = ds.Tables[1];
                    rptBlogs.DataBind();
                }
            }

            double dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int iPageCount = (int)Math.Ceiling(dPageCount);
            ViewState["iPageCount"] = iPageCount;
            List<ListItem> lPages = new List<ListItem>();
            if (iPageCount > 0)
            {
                for (int i = 1; i <= iPageCount; i++)
                    lPages.Add(new ListItem(i.ToString(), i.ToString(), i != pageNum));
            }
            rptPagination.DataSource = lPages;
            rptPagination.DataBind();
        }

        protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int pageNum = Convert.ToInt32(e.CommandArgument);
            if (pageNum == -1)
            {
                pageNum = 1;
            }
            else if (pageNum == -2)
            {
                pageNum = (int)ViewState["iPageCount"];
            }

            hdnPageNum.Value = pageNum.ToString();
            GetAllBlogs(pageNum, pageSize);
        }
    }
}