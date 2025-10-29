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
using System.Web.UI.HtmlControls;


namespace HotalManagment
{
    public partial class Reports : System.Web.UI.Page
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
                date1.Text = (CommanClasses.CurrentDateTime().Date.AddDays(1)).ToShortDateString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(date.Text)) date.Text = CommanClasses.CurrentDateTime().ToShortDateString();
            DateTime Fromdate = Convert.ToDateTime(date.Text);
            DateTime Todate = Convert.ToDateTime(date1.Text);

            if (Fromdate > Todate)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Showmsg('Alert','To Date is greater than from date')", true);
                return;
            }


            rptEarning.DataSource = null;
            rptEarning.DataBind();
            rptExpance.DataSource = null;
            rptExpance.DataBind();
            rptRemain.DataSource = null;
            rptRemain.DataBind();


            NoRecordsExp.Visible = false;
            NoRecordsEar.Visible = false;
            NoRecordsBank.Visible = false;
            NoRecordsRemain.Visible = false;

            txtEarning.Text = "0";
            txtExpenses.Text = "0";
            txtBalance.Text = "0";
            txtBankTransfer.Text = "0";
            txtRemainAmount.Text = "0";

            DResult.Visible = false;
            DataSet ds = objHotalManagment.GetTranSummaryDetail(Fromdate, Todate, Convert.ToInt32(Session["UserId"]));
            if (ds.Tables.Count > 0)
            {

                // DataRow[] dr = ds.Tables[0].AsEnumerable().Where(a => a.Field<String>("Type") == "I");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DResult.Visible = true;
                    if (ds.Tables[0].Select("Type = 'I'").Count() > 0)
                    {
                        
                        rptEarning.DataSource = ds.Tables[0].Select("Type = 'I'").CopyToDataTable();
                        object sumObject;
                        sumObject = ds.Tables[0].Select("Type = 'I'").CopyToDataTable().Compute("Sum(Amount)", string.Empty);
                        txtEarning.Text = sumObject.ToString();
                        rptEarning.DataBind();
                    }
                    else
                    {
                        NoRecordsEar.Visible = true;
                    }

                    if (ds.Tables[0].Select("Type = 'E'").Count() > 0)
                    {
                        rptExpance.DataSource = ds.Tables[0].Select("Type = 'E'").CopyToDataTable();
                        object sumObject;
                        sumObject = ds.Tables[0].Select("Type = 'E'").CopyToDataTable().Compute("Sum(Amount)", string.Empty);
                        txtExpenses.Text = sumObject.ToString();
                        rptExpance.DataBind();
                    }
                    else
                    {
                        NoRecordsExp.Visible = true;
                    }

                    if (ds.Tables[0].Select("Type = 'R'").Count() > 0)
                    {
                        rptRemain.DataSource = ds.Tables[0].Select("Type = 'R'").CopyToDataTable();
                        object sumObject;
                        sumObject = ds.Tables[0].Select("Type = 'R'").CopyToDataTable().Compute("Sum(Amount)", string.Empty);
                        txtRemainAmount.Text = sumObject.ToString();
                        rptRemain.DataBind();
                    }
                    else
                    {
                        NoRecordsRemain.Visible = true;
                    }
                    txtBalance.Text = (Convert.ToDouble(txtEarning.Text) - Convert.ToDouble(txtExpenses.Text)).ToString();
                }
            }
            else
            {
                DResult.Visible = false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            date.Text = CommanClasses.CurrentDateTime().Date.ToShortDateString();
            date1.Text = (CommanClasses.CurrentDateTime().Date.AddDays(1)).ToShortDateString();
            DResult.Visible = false;
            rptEarning.DataSource = null;
            rptEarning.DataBind();
            rptExpance.DataSource = null;
            rptExpance.DataBind();
            NoRecordsExp.Visible = false;
            NoRecordsEar.Visible = false;
            DResult.Visible = false;
        }

       
    }
}