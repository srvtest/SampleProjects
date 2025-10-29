using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;

namespace HotalManagment
{
    public partial class rptCPDetails : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = objHotalManagment.RptCPDetail(0);
            if (ds != null && ds.Tables.Count > 0)
            {
                rptCPdetail.DataSource = ds.Tables[0];
                rptCPdetail.DataBind();
            }

        }
    }
}