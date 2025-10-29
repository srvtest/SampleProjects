using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite2
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerId"] != null)
                {
                    string id = (Session["CustomerId"].ToString());
                    //Response.Redirect("~/index.aspx");
                    GetCustomerDetail(Convert.ToInt32(CommonControl.Decrypt(id)));
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }

        private void GetCustomerDetail(int idCustomer)
        {
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetCustomerDetail(idCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdName.Value = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Gender"])))
                    hdGender.Value = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                 hdMobile.Value = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                hdEmail.Value = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                hdUserName.Value = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
               // string password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
              //  hdCurrentPassword.Value = password;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                UserDL objUser = new UserDL();
                CustomerCls objCustomerCls = new CustomerCls();
                //hdMessage.Value = "Change Password |";
                //lblMess.Text = hdMessage.Value;
                objCustomerCls.sName = hdName.Value;
                objCustomerCls.Gender = Convert.ToInt16(hdGender.Value);
                objCustomerCls.Email = hdEmail.Value;
                objCustomerCls.Mobile = hdMobile.Value;
                objCustomerCls.Username = Convert.ToString(hdUserName.Value);
                objCustomerCls.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                objCustomerCls.Password = CommonControl.SHA256Encryption(txtNewPassword.Text);
                objCustomerCls.CurrentPassword = CommonControl.SHA256Encryption(txtCurrentPassword.Text);
                int Respon = 0;               
                    Respon = objUser.EditCustomer(objCustomerCls); 
                if (Respon >= 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Change Password Successfully.');", true);
                    txtCurrentPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','Password Not Change.');", true);
                    txtCurrentPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = "";
                }
            }
        }
    }
}