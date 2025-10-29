using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox.DisabledCssClass = null;
            if (!IsPostBack)
            {
                GetCategory();
                frmCategory.Style.Add("display", "none");
            }
        }

        private void GetCategory()
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Category |";
            DataSet ds = objAdminCls.GetAllCategory();
            lstCategory.DataSource = ds.Tables[0];
            lstCategory.DataBind();
            resetControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            CategoryCls objcategory = new CategoryCls();
            if (Convert.ToInt32(hdCategoryId.Value) > 0)
            {
                hdMessage.Value = "Category Update |";
                objcategory.idCategory = Convert.ToInt32(hdCategoryId.Value);
                objcategory.ModifyBy = Convert.ToInt32(Session["UserId"]);
                objcategory.Createdby = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Category Insert |";
                objcategory.idCategory = 0;
                objcategory.Createdby = Convert.ToInt32(Session["UserId"]);
            }

            objcategory.sName = txtcategory.Text.Trim();
            objcategory.bStatus = chkStatus.Checked;


            int Response = objAdminCls.SetCategory(objcategory);
            if (Response > 0)
            {
                GetCategory();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmCategory.Style.Add("display", "none");
                tblCategory.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmCategory.Style.Add("display", "none");
            tblCategory.Style.Add("display", "flex");
            resetControl();
        }

        protected void btnCategory_Click1(object sender, EventArgs e)
        {
            frmCategory.Style.Add("display", "flex");
            tblCategory.Style.Add("display", "none");
        }

        protected void lstCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lblsName = e.Item.FindControl("lblsName") as Label;
            Label lblstatus = e.Item.FindControl("lblStatus") as Label;
            HiddenField hdn=  e.Item.FindControl("hdnId") as HiddenField;
            hdCategoryId.Value = hdn.Value;
            if (!string.IsNullOrEmpty(lblsName.Text))
            {
                if (e.CommandName== "CatEdit")
                {
                    frmCategory.Style.Add("display", "flex");
                    tblCategory.Style.Add("display", "none");
                    txtcategory.Text = lblsName.Text;
                    chkStatus.Checked = (lblstatus.Text.ToUpper()=="ACTIVE");
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteCategory(Convert.ToInt32(hdCategoryId.Value));
                }
                
            }
        }

        private void DeleteCategory(int idCategory) {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Category Delete |";
            int Response = objAdminCls.DeleteCategory(idCategory);
            if (Response > 0)
            {
                GetCategory();
                hdMessage.Value += "Category Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmCategory.Style.Add("display", "none");
                tblCategory.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Category not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        private void resetControl()
        {
            txtcategory.Text = "";
            chkStatus.Checked = true;
            hdCategoryId.Value = "0";
            frmCategory.Style.Add("display", "none");
            tblCategory.Style.Add("display", "flex");

        }
    }
}