using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class BookingType : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 2)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                GetBookingType();
                hdnBookingTypeId.Value = "0";
            }
        }

        public void ClearControls()
        {
            hdnBookingTypeId.Value = "0";
            txtBookingType.Text = "";
            chkStatus.Checked = true;
            lblMessage.Text = "";
        }

        private void GetBookingType()
        {
            DataSet ds = objHotalManagment.GetBookingType();
            grdBookingType.DataSource = ds.Tables[0];
            grdBookingType.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            BookingTypeCls objBookingType = new BookingTypeCls();
            if (Convert.ToInt32(hdnBookingTypeId.Value) > 0)
            {
                objBookingType.Id = Convert.ToInt32(hdnBookingTypeId.Value);
                objBookingType.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                objBookingType.Id = 0;
                objBookingType.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            objBookingType.BookingTypeName = txtBookingType.Text.Trim();
            objBookingType.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetBookingType(objBookingType);
            if (Response > 0)
            {
                ClearControls();
                Page.ClientScript.RegisterStartupScript(GetType(), "BookingType", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "BookingType", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            GetBookingType();
        }

        protected void grdBookingType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClearControls();
            hdnBookingTypeId.Value = null;
        }

        protected void grdBookingType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdnBookingTypeId.Value = Convert.ToString(((HiddenField)grdBookingType.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtBookingType.Text = ((Label)grdBookingType.Rows[e.NewEditIndex].FindControl("lblBookingTypeName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdBookingType.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            Page.ClientScript.RegisterStartupScript(GetType(), "BookingType", "ShowEditForm();", true);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "BookingType", "$('#AddBookingType').modal('show');", true);
            hdnBookingTypeId.Value = null;
        }
    }
}