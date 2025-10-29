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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAdditionalLink();
                resetControl();
                frmAdditionalLink.Style.Add("display", "none");
            }
        }

        private void GetAdditionalLink()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllAdditionalLink();
            lstAdditionalLink.DataSource = ds.Tables[0];
            lstAdditionalLink.DataBind();
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtLink.Text = "";
            //chkStatus.Checked = false;
            hdAdditionalLinkId.Value = "0";
            frmAdditionalLink.Style.Add("display", "none");
            tblAdditionalLink.Style.Add("display", "flex");
        }

        protected void btnAdditionalLink_Click(object sender, EventArgs e)
        {
            resetControl();
             lblbStatus.Text = hdnStatus.Value == "true" ? "InActive" : "Active";
            if (lblbStatus.Text == "Active")
            {
                chkStatus.Checked = true;
            }
            else if (lblbStatus.Text == "InActive")
            {
                chkStatus.Checked = false;
            }
            frmAdditionalLink.Style.Add("display", "flex");
            tblAdditionalLink.Style.Add("display", "none");
        }

        protected void lstAdditionalLink_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            HiddenField hdstatus = e.Item.FindControl("hdStatus") as HiddenField;
            HiddenField hdnDescription = new HiddenField();
            hdMessage.Value = "Additional Link Edit";
            lblMessage.Text = hdMessage.Value;
            Label lblName = e.Item.FindControl("lblName") as Label;
            Label lblDescription = e.Item.FindControl("lblDescription") as Label;
            Label lblLink = e.Item.FindControl("lblLink") as Label;
            Label lblstatus = e.Item.FindControl("LblStatus") as Label;
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
            hdAdditionalLinkId.Value = hdn.Value;
           // hdnStatus.Value = lblstatus.Text;
            if (!string.IsNullOrEmpty(lblName.Text))
            {
                if (e.CommandName == "CatEdit")
                {
                    AdminDL objAdminCls = new AdminDL();
                    DataSet ds = objAdminCls.GetAdditionalLink(Convert.ToInt32(hdn.Value));
                    AdditionalLinkCls objAdditionalLink = new AdditionalLinkCls();
                    objAdditionalLink.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
                    string Description = ds.Tables[0].Rows[0]["sDescription"].ToString();
                    frmAdditionalLink.Style.Add("display", "flex");
                    tblAdditionalLink.Style.Add("display", "none");
                    txtName.Text = lblName.Text;
                    txtDescription.Text = Description;
                    txtLink.Text = lblLink.Text;
                    chkStatus.Checked = objAdditionalLink.bStatus == 1 ? true : false;
                    lblbStatus.Text = hdstatus.Value;
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteAdditionalLink(Convert.ToInt32(hdAdditionalLinkId.Value));
                }
                else if (e.CommandName == "Readmore")
                {
                    lnkread.Text = (lnkread.Text == "Read More") ? "Hide" : "Read More";
                    string temp = lblDescription.Text;
                    lblDescription.Text = lblDescription.ToolTip;
                    lblDescription.ToolTip = temp;
                }
            }
        }

        private void DeleteAdditionalLink(int Id)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Additional Link Delete |";
            int Response = objAdminCls.DeleteAdditionalLink(Id);
            if (Response > 0)
            {
                GetAdditionalLink();
                hdMessage.Value += "Additional Link Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmAdditionalLink.Style.Add("display", "none");
                tblAdditionalLink.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Blog not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
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

        protected void btnSaveAdditionalLink_Click(object sender, EventArgs e)
        {
            AdditionalLinkCls objAdditionalLink = new AdditionalLinkCls();
            objAdditionalLink.Name = txtName.Text;
            objAdditionalLink.Description = txtDescription.Text;
            objAdditionalLink.Link = txtLink.Text;
            objAdditionalLink.bStatus = (Int16)(chkStatus.Checked ? 1 : 0);
            AdminDL objAdminCls = new AdminDL();
            if (Convert.ToInt32(hdAdditionalLinkId.Value) > 0)
            {
                hdMessage.Value = "Additional Link Update |";
                objAdditionalLink.idAdditionalLink = Convert.ToInt32(hdAdditionalLinkId.Value);
                objAdditionalLink.bStatus = (Int16)(chkStatus.Checked ? 1 : 0);
            }
            else
            {
                hdMessage.Value = "Additional Link Insert |";
                objAdditionalLink.idAdditionalLink = 0;
            }
            int Response = objAdminCls.InsertUpdateAdditionalLink(objAdditionalLink);
            if (Response > 0)
            {
                GetAdditionalLink();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmAdditionalLink.Style.Add("display", "none");
                tblAdditionalLink.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancelAdditionalLink_Click(object sender, EventArgs e)
        {
            frmAdditionalLink.Style.Add("display", "none");
            tblAdditionalLink.Style.Add("display", "flex");
        }


    }
}