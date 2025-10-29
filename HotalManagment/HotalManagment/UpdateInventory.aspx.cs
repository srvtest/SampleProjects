using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataLayer;
using System.Data;

namespace HotalManagment
{
    public partial class UpdateInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                getCategory();
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
            CommonUtilitys objCommonUtilitys = new CommonUtilitys();
            for (int i = 0; i < chkCategory.Items.Count; i++)
            {
                if (chkCategory.Items[i].Selected)
                {
                    objCommonUtilitys.UpdateAvailability(Convert.ToInt32(Session["UserId"]), Convert.ToString(Fromdate), Convert.ToString(Todate), Convert.ToInt32(chkCategory.Items[i].Value), txtRoomAvailable.Text);
                }
            }

            ClearControl();
            hdMessage.Value = "Data saved successfully";
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        }

        public void ClearControl()
        {
            txtRoomAvailable.Text = "";
        }

        public void getCategory()
        {

            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ds.Tables[0].DefaultView.RowFilter = "isnull(CpCategoryId,'') <> ''";
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();

                chkCategory.DataSource = dt;
                chkCategory.DataBind();
            }


        }
    }
}