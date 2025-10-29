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
    public partial class ExpanseHead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                btnsave.Text = "Add";
                getExpanseHead();
                ClearControl();
                hdExpanseHeadId.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            ExpanseHeadCls expanseHead = new ExpanseHeadCls();
            if (Convert.ToInt32(hdExpanseHeadId.Value) > 0)
            {
                hdMessage.Value = "ExpanseHead Update |";
                expanseHead.Id = Convert.ToInt32(hdExpanseHeadId.Value);
                expanseHead.ModifyBy = Convert.ToInt32(Session["UserId"]);
                expanseHead.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "ExpanseHead Insert |";
                expanseHead.Id = 0;
                expanseHead.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            expanseHead.ExpanseHead = txtExpanseHead.Text.Trim();
            expanseHead.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetExpanseHead(expanseHead);
            if (Response > 0)
            {
                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because ExpanseHead already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            btnsave.Text = "Add";
            getExpanseHead();
            ClearControl();
            hdExpanseHeadId.Value = "0";
        }

        public void getExpanseHead()
        {
            grdExpanseHead.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllExpanseHead(Convert.ToInt32(Session["UserId"]));
            grdExpanseHead.DataSource = ds.Tables[0];
            grdExpanseHead.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }


        protected void grdExpanseHead_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdExpanseHeadId.Value = Convert.ToString(((HiddenField)grdExpanseHead.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtExpanseHead.Text = ((Label)grdExpanseHead.Rows[e.NewEditIndex].FindControl("lblExpanseHead")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdExpanseHead.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
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
            hdExpanseHeadId.Value = "0";
            txtExpanseHead.Text = "";
            chkStatus.Checked = true;
            hdMessage.Value = "";
            status.Attributes.Add("style", "display:none");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            btnsave.Text = "Add";
            getExpanseHead();
            ClearControl();
            hdExpanseHeadId.Value = "0";

        }

     

        protected void btnAddNew_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Addcategory", "$('#Addcategory').modal('show');", true);

        }

    }
}