using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class BookingItem : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getBookingItem();
            }
        }

        public void getBookingItem()
        {
            DataSet ds = objHotalManagment.BookedUserDetail(Convert.ToInt32(Session["UserId"]));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdBookingDetail.DataSource = ds;
                grdBookingDetail.DataBind();
            }
        }

        protected void grdBookingDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdBookingId.Value = ((HiddenField)grdBookingDetail.Rows[e.NewEditIndex].FindControl("hdnId")).Value;
            getBookedItemByBookingId();
            getAllItem();
            Page.ClientScript.RegisterStartupScript(GetType(), "BookedItems", "ShowEditForm();", true);
            cboNewItemName_SelectedIndexChanged(null, null);
        }

        public void getBookedItemByBookingId()
        {
            grdBookedItem.DataSource = null;
            grdBookedItem.DataBind();
            BookingDetailsCls objbookingDetails = new BookingDetailsCls();
            DataSet ds = objHotalManagment.BookedItemDetail(Convert.ToInt32(hdBookingId.Value));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdBookedItem.DataSource = ds;
                grdBookedItem.DataBind();
            }
        }

        public void ClearControls()
        {
            cboNewItemName.SelectedIndex = 0;
            txtQty.Text = "1";
        }


        public void getAllItem()
        {
            DataSet ds = objHotalManagment.GetAllItems(Convert.ToInt32(Session["UserId"]));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                cboNewItemName.DataSource = ds.Tables[0];
                cboNewItemName.DataTextField = "ItemName";
                cboNewItemName.DataValueField = "Id";
                cboNewItemName.DataBind();
            }
            ViewState["AllItems"] = ds.Tables[0];
        }

        protected void grdBookedItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelivered = (e.Row.FindControl("btnItemDelivered") as Button);
                Button btnCancel = (e.Row.FindControl("btnOderCancel") as Button);
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[5].Equals(1))
                {
                    btnDelivered.Visible = true;
                    btnCancel.Visible = true;
                }
                else
                {
                    btnDelivered.Visible = false;
                    btnCancel.Visible = false; ;
                }
            }
        }
        protected void grdBookedItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ItemsCls item = new ItemsCls();
            int bookingitemId = Convert.ToInt32(((HiddenField)grdBookedItem.Rows[e.RowIndex].FindControl("hdbitemId")).Value);
            item.Id = bookingitemId;
            item.Status = 2;
            item.IsActive = true;
            item.ModifyBy = Convert.ToInt32(Session["UserId"]);
            int Response = objHotalManagment.SetBookingItem(item);
            if (Response > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            getBookedItemByBookingId();
        }

        protected void grdBookedItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                DropDownList objItemName = (DropDownList)grdBookedItem.FooterRow.FindControl("cboNewItemName");
                DL_HotalManagment objHotalManagment = new DL_HotalManagment();
                DataSet ds = objHotalManagment.GetAllItems(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objItemName.DataSource = ds.Tables[0];
                    objItemName.DataTextField = "ItemName";
                    objItemName.DataValueField = "Id";
                    objItemName.DataBind();
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ItemsCls item = new ItemsCls();
            item.BookingId = Convert.ToInt32(hdBookingId.Value);
            item.ItemId = Convert.ToInt32(cboNewItemName.SelectedValue);
            if (Convert.ToInt32(item.Id) > 0)
            {
                item.ModifyBy = Convert.ToInt32(Session["UserId"]);
                item.Status = Convert.ToInt32(grdBookedItem.FooterRow.FindControl("lblStatus"));
            }
            else
            {
                item.CreatedBy = Convert.ToInt32(Session["UserId"]);
                item.Status = 1;
            }

            item.Price = !string.IsNullOrEmpty(txtPrice.Text)?Convert.ToDouble(txtPrice.Text.Trim()):0;         
            item.Quantity = Convert.ToInt32(txtQty.Text);
            item.IsActive = true;
            int Response = objHotalManagment.SetBookingItem(item);
            if (Response > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            ClearControls();
            getBookedItemByBookingId();
            ClientScript.RegisterStartupScript(GetType(), "BookingItemMessage", "ShowMessageForm();", true);
        }

        protected void grdBookedItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ItemsCls item = new ItemsCls();
            int bookingitemId = Convert.ToInt32(((HiddenField)grdBookedItem.Rows[e.RowIndex].FindControl("hdbitemId")).Value);
            item.Id = bookingitemId;
            item.Status = 3;
            item.IsActive = true;
            item.ModifyBy = Convert.ToInt32(Session["UserId"]);
            int Response = objHotalManagment.SetBookingItem(item);
            if (Response > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            
            getBookedItemByBookingId();
        }

        protected void cboNewItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ViewState["AllItems"] as DataTable;
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["Id"]) == Convert.ToInt32(cboNewItemName.SelectedValue))
                {
                    txtPrice.Text = !string.IsNullOrEmpty(dr["Price"].ToString())?String.Format("{0:0.00}", dr["Price"]):"";
                }
            }
        }

    }
}
