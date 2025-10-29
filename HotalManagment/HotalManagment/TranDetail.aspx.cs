using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace HotalManagment
{
    public partial class TranDetail : System.Web.UI.Page
    {
        string folderDocumentsName = ConfigurationManager.AppSettings["folderCustDocuments"].ToString();
        string folderCustPhotos = ConfigurationManager.AppSettings["folderCustPhotos"].ToString();
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        List<EntityLayer.BookingCls.Documents> lstDeletedDoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {

                date.Text = CommanClasses.CurrentDateTime().Date.ToShortDateString();
                GetTransection();
            }
        }


        private void GetTransection()
        {
            if (string.IsNullOrEmpty(date.Text)) date.Text = CommanClasses.CurrentDateTime().ToShortDateString();
            DateTime Chartdate = Convert.ToDateTime(date.Text);
            DateTime Currdate = Convert.ToDateTime(CommanClasses.CurrentDateTime());
            DataSet dsCategory = objHotalManagment.GetTranSummary(Chartdate,Convert.ToInt32(Session["UserId"]));
            if (dsCategory.Tables.Count>0)
            {
                txtEarning.Text = Convert.ToString(dsCategory.Tables[0].Rows[0]["Earning"]);
                txtExpenses.Text = Convert.ToString(dsCategory.Tables[0].Rows[0]["Expenses"]);
                txtBalance.Text =  (Convert.ToDouble(txtEarning.Text) - Convert.ToDouble(txtExpenses.Text)).ToString();
                txtRemainAmount.Text = Convert.ToString(dsCategory.Tables[0].Rows[0]["Remain"]);
            }
        }
      

        protected void txtBookingDate_TextChanged(object sender, EventArgs e)
        {
            GetTransection();
        }

    }
}