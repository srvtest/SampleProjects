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
    public partial class UCRelatedProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetProductList(string sCategory)
        {
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
            int pageSize = Convert.ToInt32(10);
            int pageNo = Convert.ToInt32(1);
            UserDL objUserCls = new UserDL();

            DataSet ds = objUserCls.GetAllProductByCategory(sCategory, idCountry, isB2B, pageSize, pageNo,"","",0);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                rptProducts.DataSource = ds.Tables[1];
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