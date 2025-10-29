using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;
using System.Configuration;

namespace HotalManagment
{
    public partial class TaxSlab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (hdSKey.Value == "1")
            {
                pnlList.Visible = true;
                pnlSKey.Visible = false;
            }
            else
            {
                pnlList.Visible = false;
                pnlSKey.Visible = true;
            }
            if (!IsPostBack)
            {
                btnsave.Text = "Add";
                getTaxSlab();
                ClearControl();
                hdTaxSlabId.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            TaxSlabCls taxSlab = new TaxSlabCls();
            if (Convert.ToInt32(hdTaxSlabId.Value) > 0)
            {
                hdMessage.Value = "Tax Update |";
                taxSlab.Id = Convert.ToInt32(hdTaxSlabId.Value);
                taxSlab.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Tax Slab Insert |";
                taxSlab.Id = 0;
                taxSlab.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            taxSlab.TaxSlabName = txtTaxSlab.Text.Trim();
            taxSlab.StartAt = Convert.ToDouble(txtStartAt.Text.Trim());
            taxSlab.EndTo = Convert.ToDouble(txtEndTo.Text.Trim());
            taxSlab.Taxpercent = Convert.ToDouble(txtTaxPercent.Text.Trim());

            taxSlab.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetTaxSlab(taxSlab);
            if (Response > 0)
            {
                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }

            btnsave.Text = "Add";
            getTaxSlab();
            ClearControl();
            hdTaxSlabId.Value = "0";
            
        }

        public void getTaxSlab()
        {
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
            grdTaxSlab.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllTaxSlab(Convert.ToInt32(Session["UserId"]));
            grdTaxSlab.DataSource = ds.Tables[0];
            grdTaxSlab.DataBind();
        }


        protected void grdCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdTaxSlabId.Value = Convert.ToString(((HiddenField)grdTaxSlab.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtEndTo.Text = ((Label)grdTaxSlab.Rows[e.NewEditIndex].FindControl("lblTaxSlabEndTo")).Text;
            txtStartAt.Text = ((Label)grdTaxSlab.Rows[e.NewEditIndex].FindControl("lblTaxSlabStartAt")).Text;
            txtTaxPercent.Text = ((Label)grdTaxSlab.Rows[e.NewEditIndex].FindControl("lblTaxPercent")).Text;
            txtTaxSlab.Text = ((Label)grdTaxSlab.Rows[e.NewEditIndex].FindControl("lblTaxSlabName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdTaxSlab.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            btnsave.Text = "Update";
        }

        public string GetStatusClass(bool status)
        {
            string className = string.Empty;
            if (status)
            {
                className = "label label-success";
            }
            else
            {
                className = "label label-warning";
            }
            return className;
        }

        public void ClearControl()
        {
            hdTaxSlabId.Value = "0";
            txtEndTo.Text = "";
            txtStartAt.Text = "";
            txtTaxPercent.Text = "";
            txtTaxSlab.Text = "";
            chkStatus.Checked = true;
           
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            getTaxSlab();
            ClearControl();
            hdTaxSlabId.Value = "0";
        }

        protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Addcategory", "$('#Addcategory').modal('show');", true);

        }
        protected void btnsKey_Click(object sender, EventArgs e)
        {
            string SKey = ConfigurationManager.AppSettings["SKey"].ToString();
            if (txtSKey.Text == SKey)
            {
                hdSKey.Value = "1";
                pnlList.Visible = true;
                pnlSKey.Visible = false;
            }
            else
            {
                hdMessage.Value = "Authentication | Please enter valid key";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }
    }
}