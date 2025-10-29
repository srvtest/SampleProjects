using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class BusinessSource : System.Web.UI.Page
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
                GetBusinessSource();
                hdnBusinessSourceId.Value = "0";
            }
        }

        public void ClearControls()
        {
            hdnBusinessSourceId.Value = "0";
            txtBusinessSource.Text = "";
            chkStatus.Checked = true;
            lblMessage.Text = "";
        }

        private void GetBusinessSource()
        {
            DataSet ds = objHotalManagment.GetBusinessSource(Convert.ToInt32(Session["UserId"]));
            grdBusinessSource.DataSource = ds.Tables[0];
            grdBusinessSource.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            BusinessSourceCls objBusinessSource = new BusinessSourceCls();
            if (Convert.ToInt32(hdnBusinessSourceId.Value) > 0)
            {
                objBusinessSource.Id = Convert.ToInt32(hdnBusinessSourceId.Value);
                objBusinessSource.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                objBusinessSource.Id = 0;
                objBusinessSource.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            objBusinessSource.BusinessSourceName = txtBusinessSource.Text.Trim();
            objBusinessSource.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetBusinessSource(objBusinessSource);
            if (Response > 0)
            {
                ClearControls();
                Page.ClientScript.RegisterStartupScript(GetType(), "BusinessSource", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "BusinessSource", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            GetBusinessSource();
        }

        protected void grdBusinessSource_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void grdBusinessSource_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdnBusinessSourceId.Value = Convert.ToString(((HiddenField)grdBusinessSource.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtBusinessSource.Text = ((Label)grdBusinessSource.Rows[e.NewEditIndex].FindControl("lblBusinessSource")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdBusinessSource.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            Page.ClientScript.RegisterStartupScript(GetType(), "BusinessSource", "ShowEditForm();", true);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "BusinessSource", "$('#AddBusinessSource').modal('show');", true);
            hdnBusinessSourceId.Value = null;
        }
    }
}