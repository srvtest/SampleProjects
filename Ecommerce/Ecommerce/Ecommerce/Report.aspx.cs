using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllReport();
            }
        }

        private void GetAllReport()
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Report |";
            DataSet ds = objAdminCls.GetAllReport();
            lstReport.DataSource = ds.Tables[0];
            lstReport.DataBind();
        }

        private void GetAllReportByFilters(string StartDate, string EndDate, string Status, string Country)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Report |";
            //DataSet ds = objAdminCls.GetAllReportByFilters(StartDate, EndDate, Status, Country);
            //ViewState["DataTable"] = ds.Tables[0];
            //lstReport.DataSource = ds.Tables[0];
            lstReport.DataBind();
            //throw new NotImplementedException();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            ReportCls objReport = new ReportCls();
            objReport.StartDate = txtStartDate.Text;
            objReport.EndDate = txtEndDate.Text;
            objReport.Status = new List<CustomerOrderCls>();
            objReport.lstCountry = new List<CountryCls>();
            foreach (ListItem li in lstStatus.Items)
            {
                if (li.Selected == true)
                {
                    objReport.Status.Add(new CustomerOrderCls
                    {
                        bStatus = Convert.ToInt32(li.Value)
                    });
                }
            }
            foreach (ListItem li in lstCountry.Items)
            {
                if (li.Selected == true)
                {
                    objReport.lstCountry.Add(new CountryCls
                    {
                        idCountry = Convert.ToInt32(li.Value)
                    });
                }
            }
            DataSet ds = objAdminCls.GetAllReportByFilters(objReport);
            lstReport.DataSource = ds.Tables[0];
            lstReport.DataBind();
        }

       
    }
}