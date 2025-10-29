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
    public partial class MasterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMasterPage();
                
                frmMasterPage.Style.Add("display", "none");
            }
        }

        private void GetMasterPage()
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "MasterPage |";
            DataSet ds = objAdminCls.GetAllMasterPage();
            lstMasterPage.DataSource = ds.Tables[0];
            lstMasterPage.DataBind();
            resetControl();
        }

        private void resetControl()
        {
            txtMasterPage.Text = "";
            txtContent.Text = "";
            hdMasterPageId.Value = "0";
            frmMasterPage.Style.Add("display", "none");
            tblMasterPage.Style.Add("display", "flex");
        }

        protected void lstMasterPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetMasterPageById(Convert.ToInt32(hdn.Value));
            string title = ds.Tables[0].Rows[0]["sContent"].ToString();
            Label lblMasterPage = e.Item.FindControl("lblMasterPage") as Label;
            Label lblContent = e.Item.FindControl("lblContent") as Label;
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
            hdMasterPageId.Value = hdn.Value;

            if (!string.IsNullOrEmpty(lblMasterPage.Text))
            {
                if (e.CommandName == "CatEdit")
                {
                    frmMasterPage.Style.Add("display", "flex");
                    tblMasterPage.Style.Add("display", "none");
                    txtMasterPage.Text = lblMasterPage.Text;
                    txtContent.Text = title;
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteMasterPage(Convert.ToInt32(hdMasterPageId.Value));
                }
                else if (e.CommandName == "Readmore")
                {
                    lnkread.Text = (lnkread.Text == "Read More") ? "Hide" : "Read More";
                    string temp = lblContent.Text;
                    lblContent.Text = lblContent.ToolTip;
                    lblContent.ToolTip = temp;
                }

            }
        }

        private void DeleteMasterPage(int idMasterPage)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Master page Delete |";
            int Response = objAdminCls.DeleteMasterPage(idMasterPage);
            if (Response > 0)
            {
                GetMasterPage();
                hdMessage.Value += "Category Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmMasterPage.Style.Add("display", "none");
                tblMasterPage.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Category not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            MasterpageCls objMasterPage = new MasterpageCls();
            if (Convert.ToInt32(hdMasterPageId.Value) > 0)
            {
                hdMessage.Value = "Masterpage Update |";
                objMasterPage.idMasterPage = Convert.ToInt32(hdMasterPageId.Value);
                // objcategory.ModifyBy = Convert.ToInt32(Session["UserId"]);
                // objcategory.Createdby = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Masterpage Insert |";
                objMasterPage.idMasterPage = 0;
                //objcategory.Createdby = Convert.ToInt32(Session["UserId"]);
            }

            objMasterPage.sMasterPage = txtMasterPage.Text;
            objMasterPage.sContent = txtContent.Text;


            int Response = objAdminCls.InsertUpdateMasterPage(objMasterPage);
            if (Response > 0)
            {
                GetMasterPage();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmMasterPage.Style.Add("display", "none");
                tblMasterPage.Style.Add("display", "block");
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
            frmMasterPage.Style.Add("display", "none");
            tblMasterPage.Style.Add("display", "flex");
        }

        protected void btnMasterPage_Click(object sender, EventArgs e)
        {
            frmMasterPage.Style.Add("display", "flex");
            tblMasterPage.Style.Add("display", "none");
        }

        protected bool SetVisibility(object desc, int maxLength)
        {
            var description = (string)desc;
            if (string.IsNullOrEmpty(description)) { return false; }
            return description.Length > maxLength;
        }

        protected string Limit(object desc, int maxLength)
        {
            var description = (string)desc;
            if (string.IsNullOrEmpty(description)) { return description; }
            return description.Length <= maxLength ?
                description : description.Substring(0, maxLength) + "...";
        }
    }
}