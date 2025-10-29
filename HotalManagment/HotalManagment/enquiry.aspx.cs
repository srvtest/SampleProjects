using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;

namespace HotalManagment
{
    public partial class enquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                getControlData();
                getEnquiry();
                hdEnquiryId.Value = "0";
                btnsave.Text = "Add";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            EnquiryCls objEnquiry = new EnquiryCls();
            if (Convert.ToInt32(hdEnquiryId.Value) > 0)
            {
                objEnquiry.Id = Convert.ToInt32(hdEnquiryId.Value);
                objEnquiry.Modifyby = Convert.ToInt32(Session["UserId"]);
                hdMessage.Value = "Enquiry Update |";
            }
            else
            {
                hdMessage.Value = "Enquiry Insert |";
                objEnquiry.Id = 0;
                objEnquiry.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            objEnquiry.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objEnquiry.ToDate = Convert.ToDateTime(txtTodate.Text);
            objEnquiry.categoryId = Convert.ToInt32(ddCategory.SelectedValue);
            objEnquiry.BookingSourceId = Convert.ToInt32(ddBookingSource.SelectedValue);
            objEnquiry.RoomId = Convert.ToInt32(ddRoomNo.SelectedValue);
            objEnquiry.EnquiryBy = txtEnquiryBy.Text;
            objEnquiry.ContactNo = txtContactNo.Text;
            objEnquiry.Notes = txtNotes.Text;
            objEnquiry.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetEnquiryDetail(objEnquiry);
            if (Response > 0)
            {
                ClearControl();
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                hdMessage.Value += "Data saved successfully";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                hdMessage.Value += "Data not saved successfully please try again...";
            }
            getEnquiry();
            hdEnquiryId.Value = "0";
            ClearControl();
            btnsave.Text = "Add";
        }

        public void getControlData()
        {

            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet dsCategory = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            ddCategory.DataValueField = "Id";
            ddCategory.DataTextField = "CategoryName";
            ddCategory.DataSource = dsCategory.Tables[0];
            ddCategory.DataBind();
            ddCategory.Items.Insert(0, new ListItem("Select Category", "0"));

            DataSet dsBookingSource = objHotalManagment.GetBookingSource();
            ddBookingSource.DataValueField = "Id";
            ddBookingSource.DataTextField = "BookingSourceName";
            ddBookingSource.DataSource = dsBookingSource.Tables[0];
            ddBookingSource.DataBind();
            ddBookingSource.Items.Insert(0, new ListItem("Select Booking Source", "0"));

            ddRoomNo.Items.Insert(0, new ListItem() { Text="Select RoomNo",Value="0" });
        }

        public void getEnquiry()
        {


            grdEnquiry.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetEnquiry(Convert.ToInt32(Session["UserId"]));
            grdEnquiry.DataSource = ds.Tables[0];
            grdEnquiry.DataBind();

        }

        public void SetRoomNoByCategory()
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetRoomNoForBooking(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddCategory.SelectedValue));
            ddRoomNo.DataSource = ds;
            ddRoomNo.DataTextField = "RoomNo";
            ddRoomNo.DataValueField = "Id";
            ddRoomNo.DataBind();
            ddRoomNo.Items.Insert(0, new ListItem("Select RoomNo", "0"));
        }

        protected void grdEnquiry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdEnquiryId.Value = Convert.ToString(((HiddenField)grdEnquiry.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            EnquiryCls objEnquiyCls = getEnquiryBiId(Convert.ToInt32(hdEnquiryId.Value));
            if (objEnquiyCls != null)
            {
                txtFromDate.Text =  Convert.ToString(objEnquiyCls.FromDate.ToShortDateString());
                txtTodate.Text = Convert.ToString(objEnquiyCls.ToDate.ToShortDateString());
                ddCategory.SelectedValue =  Convert.ToString(objEnquiyCls.categoryId);
                ddBookingSource.SelectedValue =  Convert.ToString(objEnquiyCls.BookingSourceId);
                txtEnquiryBy.Text = objEnquiyCls.EnquiryBy;
                txtContactNo.Text = objEnquiyCls.ContactNo;
                txtNotes.Text = objEnquiyCls.Notes;
                chkStatus.Checked = objEnquiyCls.IsActive;
                if (objEnquiyCls.RoomId > 0)
                {
                    ddRoomNo.Items.Insert(1, new ListItem(Convert.ToString(objEnquiyCls.RoomNo), Convert.ToString(objEnquiyCls.RoomId)));
                }
                ddRoomNo.SelectedValue = Convert.ToString(objEnquiyCls.RoomId);
                btnsave.Text = "Update";
            }
        }

        public EnquiryCls getEnquiryBiId(int EnquiryId)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetEnquiryById(EnquiryId);
            EnquiryCls obj = new EnquiryCls();
            obj.Id = EnquiryId;
            obj.FromDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FromDate"].ToString());
            obj.ToDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Todate"].ToString());
            obj.categoryId = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryId"].ToString());
            obj.RoomId = Convert.ToInt32(ds.Tables[0].Rows[0]["RoomId"].ToString());
            obj.RoomNo=Convert.ToInt32(ds.Tables[0].Rows[0]["RoomNo"].ToString());
            obj.BookingSourceId = Convert.ToInt32(ds.Tables[0].Rows[0]["BookingSourceId"].ToString());
            obj.EnquiryBy = ds.Tables[0].Rows[0]["EnquiryBy"].ToString();
            obj.ContactNo = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            obj.Notes = ds.Tables[0].Rows[0]["Notes"].ToString();
            obj.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
            return obj;
        }



        public void ClearControl()
        {
            hdEnquiryId.Value = "0";
            lblMessage.Text = "";
            txtFromDate.Text = "";
            txtTodate.Text = "";
            ddCategory.ClearSelection();
            ddCategory_SelectedIndexChanged(null, null);
            ddBookingSource.ClearSelection();
            chkStatus.Checked = true;
            txtContactNo.Text = string.Empty;
            txtEnquiryBy.Text = string.Empty;
            txtNotes.Text = string.Empty;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClearControl();

            btnsave.Text = "Add";
        }

        protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRoomNoByCategory();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            ClientScript.RegisterStartupScript(GetType(), "Enquiry", "ShowEditForm();", true);
            hdEnquiryId.Value = "0";
        }
    }
}