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
    public partial class ExpanseDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                getExpanse();
                getExpanseHead();
                hdItemId.Value = "0";
                btnsave.Text = "Add";
                ClearControl();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            ExpanseCls expanse = new ExpanseCls();
            if (Convert.ToInt32(hdItemId.Value) > 0)
            {
                hdMessage.Value = "Item Update |";
                expanse.Id = Convert.ToInt32(hdItemId.Value);
                expanse.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Item Insert |";
                expanse.Id = 0;
                expanse.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }

            if (!string.IsNullOrEmpty(txtPrice.Text.Trim()) && Convert.ToInt32(txtPrice.Text)!=0)
            {
                expanse.Amount = Convert.ToDouble(txtPrice.Text.Trim());
            }
            else
            {
                hdMessage.Value += "Please Enter Expanse Amount.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                return;
            }

            if (!string.IsNullOrEmpty(txtDate.Text.Trim()))
            {
                expanse.ExpanseDate = Convert.ToDateTime(txtDate.Text.Trim());
            }
            else
            {
                hdMessage.Value += "Please Select Expanse Date";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                return;
            }
          
          
            if (!string.IsNullOrEmpty(ddlExpanseHead.SelectedValue))
            {
                expanse.ExpanseHeadId = Convert.ToInt32(ddlExpanseHead.SelectedValue);
            }
            else
            {
                hdMessage.Value += "Please Select Expanse Head";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                return;
            }
            expanse.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetExpance(expanse);
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
            getExpanse();
            ClearControl();
            hdItemId.Value = "0";
            btnsave.Text = "Add";
        }

        public void getExpanse()
        {
            grdExpanse.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllExpance(Convert.ToInt32(Session["UserId"]));
            grdExpanse.DataSource = ds.Tables[0];
            grdExpanse.DataBind();
            ClearControl();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        public void getExpanseHead()
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllExpanseHead(Convert.ToInt32(Session["UserId"]));
            if (ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0 )
            {
                 ddlExpanseHead.DataTextField = "ExpanseHead";
            ddlExpanseHead.DataValueField = "Id";
            ddlExpanseHead.DataSource = ds.Tables[0].Select("Status=1").CopyToDataTable();
            ddlExpanseHead.DataBind(); 
            }
          
        }

        public void ClearControl()
        {
            hdItemId.Value = "0";
            txtPrice.Text = "";
            chkStatus.Checked = true;
            ddlExpanseHead.SelectedIndex = 0;
            status.Attributes.Add("style", "display:none");
        }

        protected void grdExpanse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdItemId.Value = Convert.ToString(((HiddenField)grdExpanse.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtDate.Text = ((Label)grdExpanse.Rows[e.NewEditIndex].FindControl("lblItemName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdExpanse.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            txtPrice.Text = ((Label)grdExpanse.Rows[e.NewEditIndex].FindControl("lblPrice")).Text;
            ddlExpanseHead.SelectedValue = ((HiddenField)grdExpanse.Rows[e.NewEditIndex].FindControl("hdnGSTSlabeId")).Value;
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowEditForm();", true);
            btnsave.Text = "Update";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClearControl();
            hdItemId.Value = "0";
            btnsave.Text = "Add";
            getExpanse();
        }


      

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Items", "$('#AddItem').modal('show');", true);
            hdItemId.Value = "0";
        }
    }
}