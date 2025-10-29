using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite2
{
    public partial class UCTopCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCategory();
        }

        private void GetCategory()
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllCategory();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string innerHtml = string.Empty;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string catName = Convert.ToString(ds.Tables[0].Rows[i]["sName"]);
                    innerHtml += "<li><a href= '../Category/" + catName + "'>" + catName + "</a></li>";
                }


                //ucCategory.InnerHtml = innerHtml;
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter h = new HtmlTextWriter(sw);
                //ucCategory.RenderControl(h);
            }

        }
    }
}