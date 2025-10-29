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
    public partial class AdditionalLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                hdIdAdditionalLink.Value = Convert.ToString(Page.RouteData.Values["link"]);
                GetAdditionalLinkByLink();
                // frmProduct.Style.Add("display", "none");
            }
        }
        private void GetAdditionalLinkByLink()
        {
            string link = Convert.ToString(Page.RouteData.Values["link"]);           
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAdditionalLinkByLink(link);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lstAdditionalLink.DataSource = ds.Tables[0];
                lstAdditionalLink.DataBind();
            }
        }


    }
}