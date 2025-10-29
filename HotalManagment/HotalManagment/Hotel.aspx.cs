using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataLayer;
using System.Data;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace HotalManagment
{
    public partial class Hotel : System.Web.UI.Page
    {
        string HotelLogo = ConfigurationManager.AppSettings["HotelLogo"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 2)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                BindState();
                btnsave.Text = "Add";
                ClearControl();
                BindGrid();
                hdnUpadteId.Value = "0";
            }

        }

        public void BindGrid()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetHotelDetailsByUserId(Convert.ToInt32(Session["UserId"]));
                if (ds != null)
                {
                    grdHotelDetails.DataSource = ds;
                    grdHotelDetails.DataBind();
                   // grdHotelDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }
        public void BindState()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            DataSet ds = objDL_HotalManagment.GetState();
            drpState.DataSource = ds;
            drpState.DataTextField = "Name";
            drpState.DataValueField = "Id";
            drpState.DataBind();
            drpState.Items.Insert(0, new ListItem("Select State", "0"));
        }
        public void ClearControl()
        {
            txtHotelName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtGSTNo.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtCpHotelId.Text = string.Empty;
            txtCpAuthenticationCode.Text = string.Empty;
            txtPropertyName.Text = string.Empty;
            txtReviewLink.Text = string.Empty;
            chkStatus.Checked = true;
            drpState.SelectedIndex = 0;
            status.Attributes.Add("style", "display:none");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            hotelCls objHotelCls = new hotelCls();
            objHotelCls.HotelName = txtHotelName.Text;
            objHotelCls.GSTNo = txtGSTNo.Text;
            //objHotelCls.Logo = txtLogo.Text;
            objHotelCls.MobileNo = txtMobileNo.Text;
            objHotelCls.PhoneNo = txtPhoneNo.Text;
            objHotelCls.Address = txtAddress.Text;
            objHotelCls.GSTNo = txtGSTNo.Text;
            objHotelCls.EmailId = txtEmailId.Text;
            objHotelCls.CpHotelId = txtCpHotelId.Text;
            objHotelCls.CpAuthenticationCode = txtCpAuthenticationCode.Text;

            objHotelCls.PropertyName = txtPropertyName.Text;
            objHotelCls.ReviewLink = txtReviewLink.Text;

            // objHotelCls.Password = CommanClasses.Encrypt(System.Web.Security.Membership.GeneratePassword(8, 3));
            objHotelCls.CreatedBy = (Session["UserId"] != null) ? Convert.ToInt32(Session["UserId"]) : 0;
            objHotelCls.ModifyBy = (Session["UserId"] != null) ? Convert.ToInt32(Session["UserId"]) : 0;
            objHotelCls.IsActive = Convert.ToInt16(chkStatus.Checked);
            objHotelCls.StateId = Convert.ToInt32(drpState.SelectedValue);
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                objHotelCls.Password = CommanClasses.Encrypt(txtPassword.Text);
            }
            else
            {
                objHotelCls.Password = "";
            }
            
            if (imgUpload.HasFile)
            {
                if (imgUpload.PostedFile != null && imgUpload.PostedFile.ContentLength > 0)
                {
                    objHotelCls.Logo = imgUpload.PostedFile.FileName;
                    imgUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(HotelLogo, imgUpload.PostedFile.FileName)));

                }
                else
                {
                    return;
                }
            }
            int Response = 0;
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (!string.IsNullOrEmpty(hdnUpadteId.Value) && Convert.ToInt32(hdnUpadteId.Value) > 0)
            {
                objHotelCls.Id = Convert.ToInt32(hdnUpadteId.Value);
                Response = objDL_HotalManagment.UpdateHotelDetails(objHotelCls);
                hdnUpadteId.Value = null;
                btnsave.Text = "Add";
                hdMessage.Value = "Hotel Update |";
            }
            else
            {
                Response = objDL_HotalManagment.insertHotelDetails(objHotelCls);
                hdMessage.Value = "Hotel Insert |";

            }
            if (Response > 0)
            {
                SendEmail(txtEmailId.Text, "Confirmation Mail", "<br>Your hotel register successfully! Your passoword is:" + "<br>" + CommanClasses.Decrypt(objHotelCls.Password));
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                hdMessage.Value += "Data saved successfully";
                ClearControl();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                hdMessage.Value += "Email Already Exists";
            }
            btnsave.Text = "Add";
            ClearControl();
            BindGrid();
            hdnUpadteId.Value = "0";

        }
        public static string SendEmail(String bcc, String Subj, string Message)
        {
            try
            {
                //Reading sender Email credential from web.config file  

                string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                string Pass = ConfigurationManager.AppSettings["Password"].ToString();

                //creating the object of MailMessage  
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
                mailMessage.Subject = Subj; //Subject of Email  
                mailMessage.Body = Message; //body or message of Email  
                mailMessage.IsBodyHtml = true;

                string[] bccid = bcc.Split(',');

                foreach (string bccEmailId in bccid)
                {
                    mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id  
                }
                SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  

                //network and security related credentials  

                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = Pass;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage); //sending Email   
                return "Please check your email for set password";
            }
            catch (Exception e)
            {
                return e.Message.ToString();

            }

        }
        protected void grdHotelDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            hdnUpadteId.Value = Convert.ToString(((HiddenField)grdHotelDetails.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtHotelName.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblHotelName")).Text;
            txtEmailId.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblEmailId")).Text;
            txtAddress.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblAddress")).Text;
            txtPhoneNo.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblPhoneNo")).Text;
            txtGSTNo.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblGSTNo")).Text;
            txtMobileNo.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblMobileNo")).Text;
            txtCpHotelId.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblCpHotelId")).Text;
            txtCpAuthenticationCode.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblCpAuthenticationCode")).Text;
            drpState.SelectedValue = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblStateId")).Text;
            //lblpassword
            lblOldpassword.Text = ((Label)grdHotelDetails.Rows[e.NewEditIndex].FindControl("lblpassword")).Text;
            lblOldpassword.Text = CommanClasses.Decrypt(lblOldpassword.Text);
            chkStatus.Checked = Convert.ToString(((HiddenField)grdHotelDetails.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";

            txtPropertyName.Text = Convert.ToString(((HiddenField)grdHotelDetails.Rows[e.NewEditIndex].FindControl("hdnPropertyName")).Value);
            txtReviewLink.Text = Convert.ToString(((HiddenField)grdHotelDetails.Rows[e.NewEditIndex].FindControl("hdnReviewLink")).Value);

            status.Attributes.Add("style", "display:block");
            //chkStatus.Checked = ((CheckBox)grdHotelDetails.Rows[e.NewEditIndex].FindControl("CheckIsActive")).Checked;
            btnsave.Text = "UPdate";
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowEditForm();", true);
        }

       

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            ClearControl();
            BindGrid();
            hdnUpadteId.Value = "0";
        }
    }
}