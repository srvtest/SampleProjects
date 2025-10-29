using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class BookingSourceType : System.Web.UI.Page
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
                btnsave.Text = "Add";
                GetBookingSourceType();
                ClearControls();
                hdnBookingSourceTypeId.Value = "0";
            }
        }

        public void ClearControls()
        {
            hdnBookingSourceTypeId.Value = "0";
            txtBookingSourceType.Text = "";
            chkStatus.Checked = true;
            lblMessage.Text = "";
            chkStatus.Checked = true;
            status.Attributes.Add("style", "display:none");
        }

        private void GetBookingSourceType()
        {
            DataSet ds = objHotalManagment.GetBookingSourceType(Convert.ToInt32(Session["UserId"]));
            grdBookingSourceType.DataSource = ds.Tables[0];
            grdBookingSourceType.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            BookingSourceTypeCls objBookingSourceType = new BookingSourceTypeCls();
            if (Convert.ToInt32(hdnBookingSourceTypeId.Value) > 0)
            {
                objBookingSourceType.Id = Convert.ToInt32(hdnBookingSourceTypeId.Value);
                objBookingSourceType.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                objBookingSourceType.Id = 0;
                objBookingSourceType.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            objBookingSourceType.BookingSourceTypeName = txtBookingSourceType.Text.Trim();
            objBookingSourceType.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetBookingSourceType(objBookingSourceType);
            if (Response > 0)
            {
                ClearControls();
                Page.ClientScript.RegisterStartupScript(GetType(), "BookingSourceType", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "BookingSourceType", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            btnsave.Text = "Add";
            GetBookingSourceType();
            ClearControls();
            hdnBookingSourceTypeId.Value = "0";
        }

        protected void grdBookingSourceType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            GetBookingSourceType();
            ClearControls();
            hdnBookingSourceTypeId.Value = "0";
           
        }

        protected void grdBookingSourceType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdnBookingSourceTypeId.Value = Convert.ToString(((HiddenField)grdBookingSourceType.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtBookingSourceType.Text = ((Label)grdBookingSourceType.Rows[e.NewEditIndex].FindControl("lblBookingSourceTypeName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdBookingSourceType.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            btnsave.Text = "Update";
          
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "BookingSourceType", "$('#AddBookingSourceType').modal('show');", true);
            hdnBookingSourceTypeId.Value = null;
        }
    }
}