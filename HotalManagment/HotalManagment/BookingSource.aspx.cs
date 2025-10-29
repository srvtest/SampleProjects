using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class BookingSource : System.Web.UI.Page
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
                GetBookingSource();
                hdnBookingSourceId.Value = "0";
                BindBookingSourceType();
                btnsave.Text = "Add";
                ClearControls();
            }
        }

        private void BindBookingSourceType()
        {
            DataSet ds = objHotalManagment.GetBookingSourceType(Convert.ToInt32(Session["UserId"]));
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlBookingSourceType.DataSource = ds.Tables[0];
                ddlBookingSourceType.DataTextField = "BookingSourceTypeName";
                ddlBookingSourceType.DataValueField = "Id";
                ddlBookingSourceType.DataBind();
            }
            ddlBookingSourceType.Items.Insert(0, new ListItem() { Text = "Select Booking Source Type",Value="0" });
           
        }

        private void GetBookingSource()
        {
            DataSet ds = objHotalManagment.GetBookingSource();
            grdBookingSource.DataSource = ds.Tables[0];
            grdBookingSource.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        public void ClearControls()
        {
            hdnBookingSourceId.Value = "0";
            txtBookingSource.Text = "";
            ddlBookingSourceType.SelectedValue = "0";
            chkStatus.Checked = true;
            lblMessage.Text = "";
            txtOTANameChannel.Text = "";
            txtCommision.Text = "";
            status.Attributes.Add("style", "display:none");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            BookingSourceCls objBookingSource= new BookingSourceCls();
            if (Convert.ToInt32(hdnBookingSourceId.Value) > 0)
            {
                objBookingSource.Id = Convert.ToInt32(hdnBookingSourceId.Value);
                objBookingSource.ModifyBy = Convert.ToInt32(Session["UserId"]);
                hdMessage.Value = "Booking Source Update |";
            }
            else
            {
                objBookingSource.Id = 0;
                objBookingSource.CreatedBy = Convert.ToInt32(Session["UserId"]);
                hdMessage.Value = "Booking Source Insert |";
            }
            objBookingSource.BookingSourceName = txtBookingSource.Text.Trim();
            objBookingSource.BookingSourceTypeId = Convert.ToInt32(ddlBookingSourceType.SelectedValue);
            objBookingSource.IsActive = chkStatus.Checked;
            objBookingSource.OTANameChannel = txtOTANameChannel.Text.Trim();
            objBookingSource.Commision = Convert.ToDecimal(txtCommision.Text.Trim());
            int Response = objHotalManagment.SetBookingSource(objBookingSource);
            if (Response > 0)
            {
                ClearControls();
                Page.ClientScript.RegisterStartupScript(GetType(), "BookingSource", "Successmsg();", true);
                hdMessage.Value+= "Data saved successfully";

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "BookingSource", "Errormsg();", true);
                hdMessage.Value += "Data not saved successfully please try again...";
            }
            GetBookingSource();
            ClearControls();
           
            hdnBookingSourceId.Value = "0";
            btnsave.Text = "Add";
        }

        protected void grdBookingSource_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            ClearControls();
            hdnBookingSourceId.Value = null;
            GetBookingSource();
          
           
        }

        protected void grdBookingSource_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdnBookingSourceId.Value = Convert.ToString(((HiddenField)grdBookingSource.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtBookingSource.Text = ((Label)grdBookingSource.Rows[e.NewEditIndex].FindControl("lblBookingSourceName")).Text;
            ddlBookingSourceType.SelectedValue = Convert.ToString(((HiddenField)grdBookingSource.Rows[e.NewEditIndex].FindControl("hdnBookingSourceTypeId")).Value);
            chkStatus.Checked = Convert.ToString(((HiddenField)grdBookingSource.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            txtOTANameChannel.Text = ((Label)grdBookingSource.Rows[e.NewEditIndex].FindControl("lblOTANameChannel")).Text;
            txtCommision.Text = ((Label)grdBookingSource.Rows[e.NewEditIndex].FindControl("lblCommision")).Text;
            btnsave.Text = "Update";

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "BookingSource", "$('#AddBookingSource').modal('show');", true);
            hdnBookingSourceId.Value = null;
        }
    }
}