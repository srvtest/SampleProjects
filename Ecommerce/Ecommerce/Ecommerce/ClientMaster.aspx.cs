using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ClientMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountryDDL();
                GetClientMaster(Convert.ToInt32(ddlCountry.SelectedValue));
                resetControl();
                frmClientMaster.Style.Add("display", "none");
            }
        }

        private void BindCountryDDL()
        {
            List<ListItem> lstCountry = new List<ListItem>() {
               new ListItem() { Text="India", Value="1", Selected=true },
               new ListItem() { Text="USA", Value="2"}
            };
            ddlCountry.DataSource = lstCountry;
            ddlCountry.DataTextField = "Text";
            ddlCountry.DataValueField = "Value";
            ddlCountry.DataBind();
            ddlCountryFrm.DataSource = lstCountry;
            ddlCountryFrm.DataTextField = "Text";
            ddlCountryFrm.DataValueField = "Value";
            ddlCountryFrm.DataBind();
            ddlCountryFrm.SelectedValue = "1";
        }

        private void GetClientMaster(int idCountry)
        {
            AdminDL objAdminCls = new AdminDL();
            rptClientMaster.DataSource = null;
            DataSet ds = objAdminCls.GetAllClientMaster(idCountry);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblNoRecordMsg.Visible = false;
                //btnClientMaster.Visible = false;
                rptClientMaster.DataSource = ds.Tables[0];
            }
            else
                lblNoRecordMsg.Visible = true;
            rptClientMaster.DataBind();
        }

        protected void rptClientMaster_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnpassword = e.Item.FindControl("hdnpassword") as HiddenField;
            if (e.CommandName == "Edit")
            {
                AdminDL objAdminCls = new AdminDL();
                DataSet ds = objAdminCls.GetAllClientMaster(Convert.ToInt32(ddlCountry.SelectedValue));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblbStatus.Text = Convert.ToBoolean(ds.Tables[0].Rows[0]["bActive"]) ? "Active" : "Inactive";
                    frmClientMaster.Style.Add("display", "flex");
                    tblClientMaster.Style.Add("display", "none");
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                    //txtLogo.Text = Convert.ToString(ds.Tables[0].Rows[0]["slogo"]);
                    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["sAddress"]);
                    txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["sCity"]);
                    txtState.Text = Convert.ToString(ds.Tables[0].Rows[0]["sState"]);
                    txtZip.Text = Convert.ToString(ds.Tables[0].Rows[0]["sZip"]);
                    txtPhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["sPhoneNumber"]);
                    txtMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["sMobilenumber"]);
                    txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["sEmail"]);
                    txtFacebookUrl.Text = Convert.ToString(ds.Tables[0].Rows[0]["sFBURL"]);
                    txtGoogleUrl.Text = Convert.ToString(ds.Tables[0].Rows[0]["sGURL"]);
                    txtLinkedinUrl.Text = Convert.ToString(ds.Tables[0].Rows[0]["sLinkdinURL"]);
                    txtTwitterUrl.Text = Convert.ToString(ds.Tables[0].Rows[0]["sTwitterURL"]);
                    txtHost.Text = Convert.ToString(ds.Tables[0].Rows[0]["host"]);
                    txtFromEmail.Text= Convert.ToString(ds.Tables[0].Rows[0]["fromEmail"]);
                    txtPassword.Text = hdnpassword.Value;
                    chkStatus.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["bActive"]);

                }
                hdnClientMasterId.Value = Convert.ToString(e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteClientMaster(Convert.ToInt32(e.CommandArgument));
            }
        }

        private void DeleteClientMaster(int Id)
        {
            ClientMasterCls objClientMasterCls = new ClientMasterCls();
            objClientMasterCls.idClientMaster = Id;
            objClientMasterCls.isDelete = 1;
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Client Master Delete |";
            int Response = objAdminCls.InsertUpdateDelteClientMaster(objClientMasterCls);
            if (Response > 0)
            {
                GetClientMaster(Convert.ToInt32(ddlCountry.SelectedValue));
                hdMessage.Value += "Client Master detail Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmClientMaster.Style.Add("display", "none");
                tblClientMaster.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Client Master detail does not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnSaveClientMaster_Click(object sender, EventArgs e)
        {
            ClientMasterCls objClientMasterCls = new ClientMasterCls();
            objClientMasterCls.sName = txtName.Text;
            objClientMasterCls.sAddress = txtAddress.Text;
            objClientMasterCls.sCity = txtCity.Text;
            objClientMasterCls.sState = txtState.Text;
            objClientMasterCls.sZip = txtZip.Text;
            objClientMasterCls.sPhoneNumber = txtPhone.Text;
            objClientMasterCls.sMobilenumber = txtMobile.Text;
            objClientMasterCls.sEmail = txtEmail.Text;
            objClientMasterCls.sFBURL = txtFacebookUrl.Text;
            objClientMasterCls.sGURL = txtGoogleUrl.Text;
            objClientMasterCls.sLinkdinURL = txtLinkedinUrl.Text;
            objClientMasterCls.sTwitterURL = txtTwitterUrl.Text;
            objClientMasterCls.bActive = (Int16)(chkStatus.Checked ? 1 : 0);
            objClientMasterCls.idClientMaster = Convert.ToInt32(hdnClientMasterId.Value);
            objClientMasterCls.idCountry = Convert.ToInt32(ddlCountryFrm.SelectedValue);
            objClientMasterCls.host = txtHost.Text;
            objClientMasterCls.fromEmail = txtFromEmail.Text;
            objClientMasterCls.password= txtPassword.Text;
            string fileName = "";
            if (imageUpload.HasFile)
            {
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (imageUpload.PostedFile != null && imageUpload.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)imageUpload.PostedFile.ContentLength)) < MaxSize)
                    {
                        fileName = CommonControl.GenerateRandomNumber(6) + imageUpload.PostedFile.FileName;
                        if (!Directory.Exists(Server.MapPath("Images")))
                            Directory.CreateDirectory(Server.MapPath("Images"));
                        imageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine("Images", fileName)));
                        objClientMasterCls.slogo= fileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            AdminDL objAdminCls = new AdminDL();
            if (Convert.ToInt32(hdnClientMasterId.Value) > 0)
            {
                hdMessage.Value = "Client Master Update |";
                objClientMasterCls.ModifiedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Client Master Insert |";
                objClientMasterCls.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            int Response = objAdminCls.InsertUpdateDelteClientMaster(objClientMasterCls);
            if (Response > 0)
            {
                GetClientMaster(Convert.ToInt32(ddlCountry.SelectedValue));
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmClientMaster.Style.Add("display", "none");
                tblClientMaster.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                if (File.Exists(Server.MapPath(Path.Combine("Images", fileName))))
                    File.Delete(Server.MapPath(Path.Combine("Images", fileName)));
                hdMessage.Value += "Data not saved. Because already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancelClientMaster_Click(object sender, EventArgs e)
        {
            frmClientMaster.Style.Add("display", "none");
            tblClientMaster.Style.Add("display", "inline");
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtFacebookUrl.Text = "";
            txtGoogleUrl.Text = "";
            txtLinkedinUrl.Text = "";
            txtTwitterUrl.Text = "";
            chkStatus.Checked = false;
            frmClientMaster.Style.Add("display", "none");
            tblClientMaster.Style.Add("display", "inline");
        }

        protected void btnClientMaster_Click(object sender, EventArgs e)
        {
            resetControl();
            frmClientMaster.Style.Add("display", "flex");
            tblClientMaster.Style.Add("display", "none");
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClientMaster(Convert.ToInt32(ddlCountry.SelectedValue));
            frmClientMaster.Style.Add("display", "none");
            tblClientMaster.Style.Add("display", "inline");
        }
    }
}