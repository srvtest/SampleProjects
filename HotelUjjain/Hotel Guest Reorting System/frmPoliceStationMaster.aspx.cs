using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmPoliceStationMaster : System.Web.UI.Page
    {
        PoliceStationMasterDL objPoliceStationMasterDL = new PoliceStationMasterDL();
        PoliceStationMasterDto userDto;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Police Station Master Details";
            lbl2.Text = "Police Station";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                LoadGridData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionAddData();", true);
        }

        public void LoadGridData()

        {
            ResponseDto obj = objPoliceStationMasterDL.GetPoliceStationMaster();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<PoliceStationMasterDto> userDto = (List<PoliceStationMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        RptUser.DataSource = userDto;
                        RptUser.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected async void RptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Police Station";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objPoliceStationMasterDL.GetPoliceStationProfileById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    PoliceStationMasterDto userDto = (PoliceStationMasterDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        BindDistrictDropdown(Convert.ToString(userDto.idState));
                        BindCityDropdown(Convert.ToString(userDto.idDistrict));
                        txtPoliceStationname.Text = userDto.PoliceStationName;
                        if (userDto.Password != null)
                        {
                            txtPassword.Text = (userDto.Password);
                            //txtPassword.Text = EncryptionHelper.Decrypt(userDto.Password);
                        }
                        ddlDistrict.SelectedValue = Convert.ToString(userDto.idDistrict);
                        ddlCityId.SelectedValue = Convert.ToString(userDto.idCity);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.idState);
                        hdPoliceStationMasterId.Value = Convert.ToString(userDto.idPoliceStationMaster);
                        txtMobile.Text = userDto.MobileNumber;
                        txtLandline.Text = userDto.landLineNumber;
                        txtEmail.Text = userDto.EmailId;
                        EnableDisableControl(true);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                if (hiddenField.Value != null)
                {
                    hdnId.Value = hiddenField.Value;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
                }
            }
            else if (e.CommandName == "View")
            {
                lbl4.Text = "View Police Station";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objPoliceStationMasterDL.GetPoliceStationProfileById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    PoliceStationMasterDto userDto = (PoliceStationMasterDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        BindDistrictDropdown(Convert.ToString(userDto.idState));
                        BindCityDropdown(Convert.ToString(userDto.idDistrict));
                        txtPoliceStationname.Text = userDto.PoliceStationName;
                        if (userDto.Password != null)
                        {
                            txtPassword.Text = (userDto.Password);
                            //txtPassword.Text = EncryptionHelper.Decrypt(userDto.Password);
                        }
                        ddlDistrict.SelectedValue = Convert.ToString(userDto.idDistrict);
                        ddlCityId.SelectedValue = Convert.ToString(userDto.idCity);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.idState);
                        hdPoliceStationMasterId.Value = Convert.ToString(userDto.idPoliceStationMaster);
                        txtMobile.Text = userDto.MobileNumber;
                        txtLandline.Text = userDto.landLineNumber;
                        txtEmail.Text = userDto.EmailId;
                        EnableDisableControl(false);
                    }
                }
            }
            else if (e.CommandName == "Send")
            {
                string regMobileNumber = "", UserName = "", Password = "", Name = "", Email = "";
                Random generator = new Random();
                string randomPassword = Convert.ToString(generator.Next(100000, 1000000));
                string encryptedPassword = EncryptionHelper.Encrypt(randomPassword);
                lbl4.Text = "Reset Password";
                //BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objPoliceStationMasterDL.ResetPoliceStationPassword(Convert.ToInt32(e.CommandArgument), encryptedPassword);
                if (response != null)
                {
                    ShowUserPanal(false);
                    EnableDisableControl(false);
                    userDto = (PoliceStationMasterDto)response.Result;
                    if (userDto != null)
                    {
                        regMobileNumber = userDto.MobileNumber;
                        UserName = userDto.MobileNumber.ToString();
                        Password = EncryptionHelper.Decrypt(userDto.Password);
                        Name = userDto.PoliceStationName.ToString();
                        Email = userDto.EmailId.ToString();
                        string Message = "Welcome to GuestReport.in Your login detail as follow - UN -" + UserName + " Pwd -" + Password + " login url -https://guestreport.in/hotellogin Thanks GuestReport.in";
                        ResponseDto response1 = await objPoliceStationMasterDL.InsertNotificationLogsAsync(Convert.ToInt32(e.CommandArgument), regMobileNumber, Message);
                        if (response != null)
                        {
                        }
                    }
                }
            }
        }
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            ddlStateId.Enabled = v;
            ddlDistrict.Enabled = v;
            ddlCityId.Enabled = v;
            txtPoliceStationname.Enabled = v;
            txtPassword.Enabled = v;

            txtEmail.Enabled = v;
            txtLandline.Enabled = v;
            txtMobile.Enabled = v;
            // chkme.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtPoliceStationname.Text = "";
            txtPassword.Text = "";

            ddlDistrict.SelectedIndex = -1;
            ddlCityId.SelectedIndex = -1;
            ddlStateId.SelectedIndex = -1;
            hdPoliceStationMasterId.Value = "";
            txtMobile.Text = "";
            txtLandline.Text = "";
            txtEmail.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            BindAllDropdown();
            BindDistrictDropdown("");
            BindCityDropdown("");
            lbl4.Text = "Add Police Station";
            EnableDisableControl(true);
        }
        private void BindAllDropdown()
        {
            DataSet dsState = objPoliceStationMasterDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });
        }

        //protected void ddlCityId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindPoliceStationDropdown(ddlCityId.SelectedValue);
        //}
        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }
        private void BindDistrictDropdown(string selectedValue)
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataSet dsDistrict = objPoliceStationMasterDL.GetAllDistrict(selectedValue);
                ddlDistrict.DataSource = dsDistrict.Tables[0];
                ddlDistrict.DataTextField = "sName";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
            }
            ddlDistrict.Items.Insert(0, new ListItem() { Text = "Select District", Value = "0" });
        }
        private void BindCityDropdown(string selectedValue)
        {
            if (!string.IsNullOrEmpty(selectedValue))
            {
                DataSet dsCity = objPoliceStationMasterDL.GetAllCity(selectedValue);
                ddlCityId.DataSource = dsCity.Tables[0];
                ddlCityId.DataTextField = "sName";
                ddlCityId.DataValueField = "CityId";
                ddlCityId.DataBind();
            }
            ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrict.SelectedValue);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            PoliceStationMasterDto userDto = new PoliceStationMasterDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.idPoliceStationMaster = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objPoliceStationMasterDL.InsertUpdateDeletePoliceStationMaster(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    LoadGridData();
                    hdMessage.Value = response.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
                else
                {
                    hdMessage.Value = response.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
            }
        }
        private static readonly string Key = "AAAAAABBBBBBCCCC"; // Replace with your secure key
        private static readonly string IV = "ddwdszlpiojinckf"; // Replace with your secure IV (16 bytes)
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.Close();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            PoliceStationMasterDto userDto = new PoliceStationMasterDto();
            userDto.PoliceStationName = txtPoliceStationname.Text;
            userDto.Password = EncryptionHelper.Encrypt(txtPassword.Text);

            userDto.idDistrict = Convert.ToInt32(ddlDistrict.SelectedValue);
            userDto.idCity = Convert.ToInt32(ddlCityId.SelectedValue);
            userDto.idState = Convert.ToInt32(ddlStateId.SelectedValue);
            userDto.MobileNumber = txtMobile.Text;
            userDto.landLineNumber = txtLandline.Text;
            userDto.EmailId = txtEmail.Text;
            if (!string.IsNullOrEmpty(hdPoliceStationMasterId.Value))
            {
                userDto.idPoliceStationMaster = Convert.ToInt32(hdPoliceStationMasterId.Value);
            }

            ResponseDto response = objPoliceStationMasterDL.InsertUpdateDeletePoliceStationMaster(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    LoadGridData();
                    hdMessage.Value = response.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
                else
                {
                    hdMessage.Value = response.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
            }
        }
    }
}