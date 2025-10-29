using System;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class Plan : System.Web.UI.Page
    {
        DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
              
                BindGridPlan();
                btnsave.Text = "Add";
            }

        }

        public void ClearControls()
        {
            txtPlan.Text = "";
            txtDuration.Text = "";
            txtPrice.Text = "";
            chkStatus.Checked = true;
        }

        private void BindGridPlan()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetPlan(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    grdPlan.DataSource = ds;
                    grdPlan.DataBind();
                }
            }
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        
        
        protected void grdPlan_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdnPlanId.Value = Convert.ToString(((HiddenField)grdPlan.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtPlan.Text = ((Label)grdPlan.Rows[e.NewEditIndex].FindControl("lblPlan")).Text;
            txtDuration.Text = ((Label)grdPlan.Rows[e.NewEditIndex].FindControl("lblduration")).Text;
            txtPrice.Text = ((Label)grdPlan.Rows[e.NewEditIndex].FindControl("lblPrice")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdPlan.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            btnsave.Text = "Update";
            ClientScript.RegisterStartupScript(GetType(), "Rooms", "ShowEditForm()", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PlanCls objPlan = new PlanCls();
            objPlan.Id = !string.IsNullOrEmpty(hdnPlanId.Value) ? Convert.ToInt32(hdnPlanId.Value) : 0;
            objPlan.PlanName = txtPlan.Text.Trim();
            objPlan.Duration = Convert.ToInt32(txtDuration.Text.Trim());
            objPlan.Price = !string.IsNullOrEmpty(txtPrice.Text) ? Convert.ToDecimal(txtPrice.Text.Trim()) : 0;
            if (objPlan.Id == 0)
            {
                hdMessage.Value = "Plan Insert |";
            }
            else
            {
                hdMessage.Value = "Plan Update |";
            }
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                objPlan.CreatedBy = Convert.ToInt32(Session["UserId"]);
                objPlan.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            objPlan.IsActive = chkStatus.Checked ? Convert.ToInt16(1) : Convert.ToInt16(0);

            int Response = objDL_HotalManagment.InsertUpdatePlan(objPlan);
            if (Response == -1)
            {
                hdMessage.Value += "Any one room no. already exists, please try again...";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Errormsg();", true);
            }
            else if (Response > 1)
            {

                hdMessage.Value += "Data saved successfully";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Successmsg();", true);
                ClearControls();
            }
            else if (Response > 2)
            {

                hdMessage.Value += "Data updated successfully";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Successmsg();", true);
                ClearControls();
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Errormsg();", true);
            }
            btnsave.Text = "Add";
            BindGridPlan();
            ClearControls();
            hdnPlanId.Value = "0";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            BindGridPlan();
            ClearControls();
            hdnPlanId.Value = "0";
        }

    }
}