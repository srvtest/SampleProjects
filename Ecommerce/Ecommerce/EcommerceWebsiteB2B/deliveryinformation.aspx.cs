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
    public partial class deliveryinformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMasterPageById();
            }
        }

        private void GetMasterPageById()
        {
            string Id = hdnDeliveryInformationId.Value;
            //HiddenField hdnAboutUsId = e.Item.FindControl("hdnAboutUsId") as HiddenField;
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetMasterPageById(Convert.ToInt16(Id));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lstDeliveryInformation.DataSource = ds.Tables[0];
                lstDeliveryInformation.DataBind();
            }
        }
    }
}