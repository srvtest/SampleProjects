using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite2
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerId"] != null)
                {
                    Response.Redirect("~/index.aspx");
                }
                else
                {
                    if (Request != null && Request.UrlReferrer != null)
                    {
                        ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
                    }
                    Request.Url.GetLeftPart(UriPartial.Authority);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            CustomerCls objCustomerCls = new CustomerCls();
            String pass = CommonControl.SHA256Encryption(txtlpassword.Text);
            objCustomerCls.Email = txtLEmail.Text.Trim();
            objCustomerCls.Password = pass;
            DataSet ds = objUserDL.LoginCustomer(objCustomerCls);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["idCustomer"]) == "0")
                {
                    lblMessage.Text = "Your email address or password is incorrect.";
                }
                else if (Convert.ToString(ds.Tables[0].Rows[0]["isEmailVerified"]) == "")
                {
                    lblMessage.Text = "Your email address is not Verified.";
                }
                else
                {
                    if (Convert.ToInt16(hdnCheckbox.Value) == 1)
                    {

                    }
                    Session["CustomerId"] = CommonControl.Encrypt(Convert.ToString(ds.Tables[0].Rows[0]["idCustomer"]));
                    this.Master.SetCountry(Convert.ToInt32(ds.Tables[0].Rows[0]["idCountry"]));
                    if (ViewState["PreviousPage"] != null)
                    {
                        Response.Redirect(Convert.ToString(ViewState["PreviousPage"]));
                    }
                    else
                    {
                        Response.Redirect("~/index.aspx");
                    }
                }
            }
            else
            {
                lblMessage.Text = "Your email address or password is incorrect.";
            }
        }
    }
}