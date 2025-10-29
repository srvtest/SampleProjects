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
    public partial class GSTSlab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 2)
            //{
            //    Response.Redirect("MainDashBoard.aspx");
            //}
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
                getGSTSlab();
                hdnGSTSlabId.Value = "0";
                ClearControl();
            }
        }

        public void getGSTSlab()
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            //GstSlabCls objGstSlab = new GstSlabCls();
            //objGstSlab.Username = Convert.ToString(Session["UserName"]);
            DataSet ds = objHotalManagment.GetGSTSlab(Convert.ToInt32(Session["UserId"]));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdGSTSlab.DataSource = ds;
                grdGSTSlab.DataBind();
            }
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }
        public void ClearControl()
        {
            txtGstSlab.Text = string.Empty;
            TxtPercent.Text = string.Empty;
            chkStatus.Checked = true;
            status.Attributes.Add("style", "display:none");
        }

        protected void grdGSTSlab_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdnGSTSlabId.Value = Convert.ToString(((HiddenField)grdGSTSlab.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtGstSlab.Text = ((Label)grdGSTSlab.Rows[e.NewEditIndex].FindControl("lblGstSlab")).Text;
            TxtPercent.Text = ((Label)grdGSTSlab.Rows[e.NewEditIndex].FindControl("lblParcentage")).Text;
            //chkStatus.Checked = ((CheckBox)grdGSTSlab.Rows[e.NewEditIndex].FindControl("CheckIsActive")).Checked;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdGSTSlab.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowEditForm();", true); 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            GstSlabCls objGstSlab = new GstSlabCls();
            if (Convert.ToInt32(hdnGSTSlabId.Value) > 0)
            {
                objGstSlab.Id = Convert.ToInt32(hdnGSTSlabId.Value);
                objGstSlab.ModifyBy = Convert.ToInt32(Session["UserId"]);
                hdMessage.Value = "GST Slab Update |";
            }
            else
            {
                objGstSlab.Id = 0;
                objGstSlab.CreatedBy = Convert.ToInt32(Session["UserId"]);
                hdMessage.Value = "GST Slab Insert |";
            }
            if (string.IsNullOrEmpty(TxtPercent.Text))
            {
                TxtPercent.Text = "0";
            }

            objGstSlab.GSTSlab= txtGstSlab.Text.Trim();
            objGstSlab.Percentage = Convert.ToInt32(TxtPercent.Text.Trim());
            objGstSlab.IsActive = chkStatus.Checked;
            int rows = objHotalManagment.SetGSTSlab(objGstSlab);
            if (rows >0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                hdMessage.Value += "Data saved successfully";
                ClearControl();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                hdMessage.Value += "Data not saved successfully please try again...";
            }
            btnsave.Text = "Add";
            ClearControl();
            getGSTSlab();
            hdnGSTSlabId.Value = "0";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            ClearControl();
            getGSTSlab();
            hdnGSTSlabId.Value = "0";
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddGstSlab", "$('#AddGstSlab').modal('show');", true);
            hdnGSTSlabId.Value = null;
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