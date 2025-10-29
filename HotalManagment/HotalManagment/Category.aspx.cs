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
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if ( hdSKey.Value == "1")
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
                getCategory();
                ClearControl();
                hdCategoryId.Value = "0";
            }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            CategoryCls category = new CategoryCls();
            if (Convert.ToInt32(hdCategoryId.Value) > 0)
            {
                hdMessage.Value = "Category Update |";
                category.Id = Convert.ToInt32(hdCategoryId.Value);
                category.ModifyBy = Convert.ToInt32(Session["UserId"]);
                category.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Category Insert |";
                category.Id = 0;
                category.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }

            category.CategoryName = txtcategory.Text.Trim();
            category.IsActive = chkStatus.Checked;
            category.CpCategoryId = txtCpCategoryId.Text.Trim();
            category.CpAuthentication = txtCpAuthentication.Text.Trim();

            int Response = objHotalManagment.SetCategory(category);
            if (Response > 0)
            {
                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {
               
                 hdMessage.Value+="Data not saved successfully please try again...";
                 Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            btnsave.Text = "Add";
            getCategory();
            ClearControl();
            hdCategoryId.Value = "0";
        }

        public void getCategory()
        {
            grdCategory.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            grdCategory.DataSource = ds.Tables[0];
            grdCategory.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }


        protected void grdCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdCategoryId.Value = Convert.ToString(((HiddenField)grdCategory.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtcategory.Text = ((Label)grdCategory.Rows[e.NewEditIndex].FindControl("lblCategoryName")).Text;
            txtCpCategoryId.Text = ((Label)grdCategory.Rows[e.NewEditIndex].FindControl("lblCpCategoryId")).Text;
            txtCpAuthentication.Text = ((Label)grdCategory.Rows[e.NewEditIndex].FindControl("lblCpAuthentication")).Text;

            chkStatus.Checked = Convert.ToString(((HiddenField)grdCategory.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
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
            hdCategoryId.Value = "0";
            txtcategory.Text = "";
            chkStatus.Checked = true;
            txtCpCategoryId.Text = "";
            txtCpAuthentication.Text = "";
            status.Attributes.Add("style", "display:none");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
          
            btnsave.Text = "Add";
            getCategory();
            ClearControl();
            hdCategoryId.Value = "0";

        }

        protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
           
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Addcategory", "$('#Addcategory').modal('show');", true);
           
        }
    }
}