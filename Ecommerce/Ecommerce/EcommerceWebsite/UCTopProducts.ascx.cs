using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class UCTopProducts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetProductList();
        }

        public void GetProductList()
        {
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
           
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetTopProduct( idCountry, isB2B);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptProducts.DataSource = ds.Tables[0];
                rptProducts.DataBind();
            }
        }
        private int GetCountryId()
        {
            int value = 0;
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            if (reqCookies != null)
            {
                string rdata = reqCookies["idCountry"].ToString();
                value = Convert.ToInt32(CommonControl.Decrypt(rdata));
            }
            return value;
        }
    }
}