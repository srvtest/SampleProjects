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
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                getItems();
                getGSTSlab();
                hdItemId.Value = "0";
                btnsave.Text = "Add";
                ClearControl();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            ItemsCls item = new ItemsCls();
            if (Convert.ToInt32(hdItemId.Value) > 0)
            {
                hdMessage.Value = "Item Update |";
                item.Id = Convert.ToInt32(hdItemId.Value);
                item.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Item Insert |";
                item.Id = 0;
                item.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            item.ItemName = txtItem.Text.Trim();
            if (!string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                item.Price = Convert.ToDouble(txtPrice.Text.Trim());
            }
            else
            {
                hdMessage.Value += "Please enter valid price.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
            }
            item.Code = txtCode.Text.Trim();
            if (!string.IsNullOrEmpty(ddlGstSlab.SelectedValue))
            {
                item.GSTSlabeId = Convert.ToInt32(ddlGstSlab.SelectedValue);
            }
            item.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetItem(item);
            if (Response > 0)
            {
                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
            }
            else
            {
                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
            }
            getItems();
            ClearControl();
            hdItemId.Value = "0";
            btnsave.Text = "Add";
        }

        public void getItems()
        {
            grdItem.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllItems(Convert.ToInt32(Session["UserId"]));
            grdItem.DataSource = ds.Tables[0];
            grdItem.DataBind();
            ClearControl();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        public void getGSTSlab()
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetGSTSlab(Convert.ToInt32(Session["UserId"]));
            ddlGstSlab.DataTextField = "GSTSlab";
            ddlGstSlab.DataValueField = "Id";
            ddlGstSlab.DataSource = ds.Tables[0];
            ddlGstSlab.DataBind();
        }

        public void ClearControl()
        {
            hdItemId.Value = "0";
            txtItem.Text = "";
            chkStatus.Checked = true;
            txtPrice.Text = "";
            txtCode.Text = "";

            ddlGstSlab.ClearSelection();
            status.Attributes.Add("style", "display:none");
        }

        protected void grdItem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdItemId.Value = Convert.ToString(((HiddenField)grdItem.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtItem.Text = ((Label)grdItem.Rows[e.NewEditIndex].FindControl("lblItemName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdItem.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            txtPrice.Text = ((Label)grdItem.Rows[e.NewEditIndex].FindControl("lblPrice")).Text;
            txtCode.Text = ((Label)grdItem.Rows[e.NewEditIndex].FindControl("lblCode")).Text;
            ddlGstSlab.SelectedValue = ((HiddenField)grdItem.Rows[e.NewEditIndex].FindControl("hdnGSTSlabeId")).Value;
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowEditForm();", true);
            btnsave.Text = "Update";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClearControl();
            hdItemId.Value = "0";
            btnsave.Text = "Add";
            getItems();
        }


        protected void grdItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Items", "$('#AddItem').modal('show');", true);
            hdItemId.Value = "0";
        }
    }
}