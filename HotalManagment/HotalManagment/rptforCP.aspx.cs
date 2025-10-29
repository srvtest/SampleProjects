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
    public partial class rptforCP : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            //  if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 2)
            //{
            //    Response.Redirect("MainDashBoard.aspx");
            //}
              if (!IsPostBack)
              {
                  int userId = 0;
                  if (Convert.ToInt32(Session["Type"])>1)
                  {
                      userId = Convert.ToInt32(Session["UserId"]);
                  }


                  DataSet ds = objHotalManagment.RptCPDetail(userId);
                  if (ds != null && ds.Tables.Count > 0)
                  {
                      rptCPdetail.DataSource = ds.Tables[0];
                      rptCPdetail.DataBind();
                  }
              }
        }
    }
}