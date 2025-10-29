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
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        public void BindGrid()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetUsersByUserId(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables[0].Rows.Count>0)
                {
                    grdUserDetails.DataSource = ds;
                    grdUserDetails.DataBind();

                }
            }

        }
        public void ClearControl()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkStatus.Checked = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserCls objUserCls = new UserCls();
            objUserCls.UserName = txtUserName.Text;            
            objUserCls.IsActive = Convert.ToInt16(chkStatus.Checked);
            objUserCls.Password = CommanClasses.Encrypt(txtPassword.Text.Trim()); 
            objUserCls.CreatedBy = (Session["UserId"] != null) ? Convert.ToInt32(Session["UserId"]) : 0;
            objUserCls.ModifyBy = (Session["UserId"] != null) ? Convert.ToInt32(Session["UserId"]) : 0;
            int Response = 0;
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (!string.IsNullOrEmpty(hdnUpadteId.Value) && Convert.ToInt32(hdnUpadteId.Value) > 0)
            {
                objUserCls.Id = Convert.ToInt32(hdnUpadteId.Value);
                Response = objDL_HotalManagment.UpdateuserDetails(objUserCls);
                hdnUpadteId.Value = null;
                btnSave.Text = "Add";
            }
            else
            {
                Response = objDL_HotalManagment.insertUserDetails(objUserCls);

            }
            if (Response > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data saved successfully";
                ClearControl();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "Data not saved successfully please try again...";
            }
            BindGrid();

        }

        protected void grdUserDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdnUpadteId.Value = Convert.ToString(((HiddenField)grdUserDetails.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtUserName.Text = ((Label)grdUserDetails.Rows[e.NewEditIndex].FindControl("lblUserName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdUserDetails.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            txtPassword.Text = Convert.ToString(((HiddenField)grdUserDetails.Rows[e.NewEditIndex].FindControl("hdnPassword")).Value);

            btnSave.Text = "UPdate";
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowEditForm();", true);
        }

        protected void grdUserDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}