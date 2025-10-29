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
    public partial class WebForm4 : System.Web.UI.Page
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
                btnSave.Text = "Add";
                getCategory();
                ClearControl();
                hdRateId.Value = "0";

            }
          }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            RateTypeCls RateType = new RateTypeCls();
            if (Convert.ToInt32(hdRateId.Value) > 0)
            {
                hdMessage.Value = "RateType Update |";
                RateType.Id = Convert.ToInt32(hdRateId.Value);
                RateType.ModifyBy = Convert.ToInt32(Session["UserId"]);
                RateType.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "RateType Insert |";
                RateType.Id = 0;
                RateType.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            RateType.Name = txtName.Text.Trim();
            RateType.IsActive = chkStatus.Checked;
            RateType.RateTypeId = txtRateTypeId.Text.Trim();
            RateType.PlanId = ddlPlanName.SelectedValue.Trim();

            int Response = objHotalManagment.SetRateType(RateType);
            if (Response > 0)
            {
                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because plan Name already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            btnSave.Text = "Add";
            getCategory();
            ClearControl();
            hdRateId.Value = "0";
        }


        protected void grdRateType_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdRateId.Value = Convert.ToString(((HiddenField)grdRateType.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtName.Text = ((Label)grdRateType.Rows[e.NewEditIndex].FindControl("lblName")).Text;
            txtRateTypeId.Text = ((Label)grdRateType.Rows[e.NewEditIndex].FindControl("lblRateTypeId")).Text;
            ddlPlanName.SelectedValue = ((Label)grdRateType.Rows[e.NewEditIndex].FindControl("lblPlanName")).Text;

            chkStatus.Checked = Convert.ToString(((HiddenField)grdRateType.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            btnSave.Text = "Update";
        }



        public void getCategory()
        {
            grdRateType.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllRateType(Convert.ToInt32(Session["UserId"]));
            grdRateType.DataSource = ds.Tables[0];
            grdRateType.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
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
            hdRateId.Value = "0";
            txtName.Text = "";
            txtRateTypeId.Text = "";

            chkStatus.Checked = true;

            status.Attributes.Add("style", "display:none");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            btnSave.Text = "Add";
            getCategory();
            ClearControl();
            hdRateId.Value = "0";

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