using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite2
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerId"] != null)
                {
                    Dictionary<int, string> gender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToDictionary(x => (int)x, x => x.ToString());
                    rbGender.DataSource = gender;
                    rbGender.DataTextField = "Value";
                    rbGender.DataValueField = "Key";
                    rbGender.DataBind();
                    //rbGender.SelectedIndex = 0;
                    btnDashboard_Click(null, null);
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            pnlEditAddress.Visible = false;
            pnlEditAccount.Visible = false;
        }
        private void GetAllAddress(int idCustomer)
        {
            pnlEmptyAddress.Visible = false;
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetAllAddress(idCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptAddress.DataSource = ds.Tables[0];
                rptAddress.DataBind();
                rptAddress.Visible = true;
            }
            else
            {
                rptAddress.Visible = false;
                pnlEmptyAddress.Visible = true;
            }
        }

        private void GetCustomerDetail(int idCustomer)
        {
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetCustomerDetail(idCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Gender"])))
                    lblGender.Text = Enum.GetName(typeof(Gender), Convert.ToInt32(ds.Tables[0].Rows[0]["Gender"]));
                gender.Visible = !string.IsNullOrEmpty(lblGender.Text);

                lblMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                mobile.Visible = !string.IsNullOrEmpty(lblMobile.Text);
                lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                string password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                hdCurrentPassword.Value = password;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            CustomerCls objCustomerCls = new CustomerCls();
            objCustomerCls.sName = txtFullName.Text.Trim();
            objCustomerCls.Gender = Convert.ToInt16(rbGender.SelectedValue);
            objCustomerCls.Email = txtREmail.Text.Trim();
            objCustomerCls.Username = txtREmail.Text.Trim();
            objCustomerCls.Mobile = txtMobileNum.Text.Trim();
            objCustomerCls.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            if (!string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                objCustomerCls.Password = CommonControl.SHA256Encryption(txtNewPassword.Text.Trim());
                objCustomerCls.CurrentPassword = CommonControl.SHA256Encryption(txtCurrentPassword.Text.Trim());
            }
            int ResponseData = objUserDL.EditCustomer(objCustomerCls);
            if (ResponseData >= 0)
            {
                GetCustomerDetail(objCustomerCls.idCustomer);
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Account update Successfully.');", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(5);", true);
                pnlEditAccount.Visible = false;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','Account Not Update.');", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(5);", true);
                pnlEditAccount.Visible = true;
                txtCurrentPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = "";
            }
        }

        protected void btnSaveAddress_Click(object sender, EventArgs e)
        {
            Label lblCountry = (Label)Master.FindControl("lblCountryName");
            //Button btn = sender as Button;
            UserDL objUserDL = new UserDL();
            CustomerAddress objCustomerAddr = new CustomerAddress();
            //objCustomerAddr.CountryName = btn.CommandArgument;
            objCustomerAddr.CountryName = lblCountry.Text;
            objCustomerAddr.sName = txtName.Text.Trim();
            objCustomerAddr.Mobile = txtMobile.Text.Trim();
            objCustomerAddr.PinCode = txtPinCode.Text.Trim();
            objCustomerAddr.sAddress1 = txtAddress1.Text.Trim();
            objCustomerAddr.sAddress2 = txtAddress2.Text.Trim();
            objCustomerAddr.sCity = txtCity.Text.Trim();
            objCustomerAddr.sState = txtState.Text.Trim();
            objCustomerAddr.sLandMark = txtLandmark.Text.Trim();
            objCustomerAddr.AddressType = rdbAddressType.SelectedValue;
            objCustomerAddr.AlternateNo = txtAlternateContact.Text.Trim();
            objCustomerAddr.idCustomerAddress = !string.IsNullOrEmpty(hdnidCustomerAddress.Value) ? Convert.ToInt32(hdnidCustomerAddress.Value) : 0;
            objCustomerAddr.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            string resp = objUserDL.AddEditAddress(objCustomerAddr);
            if (!string.IsNullOrEmpty(resp) && Convert.ToInt32(resp) > 0)
            {
                GetAllAddress(objCustomerAddr.idCustomer);
                pnlEditAddress.Visible = false;
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Address saved successfully.');", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(4);", true);
            }
            else
            {
                //lblMessage.Text = "<strong>Error!</strong> Address did not save.";
                //lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnEditAddress_Click(object sender, EventArgs e)
        {
            //pnlAddress.Visible = false;
            pnlEditAddress.Visible = true;

            //Reference the Repeater Item using Button.
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

            //Reference the Label and TextBox.
            string idCustomerAddress = Convert.ToString((item.FindControl("hdnIdCustomerAddress") as HiddenField).Value);
            string custName = (item.FindControl("lblCustName") as Label).Text;
            string address1 = (item.FindControl("lblAddress1") as Label).Text;
            string address2 = (item.FindControl("lblAddress2") as Label).Text;
            string landmark = (item.FindControl("lblLandmark") as Label).Text;
            string city = (item.FindControl("lblCity") as Label).Text;
            string state = (item.FindControl("lblState") as Label).Text;
            string pincode = (item.FindControl("lblPincode") as Label).Text;
            string lblCountry = (item.FindControl("lblCountry") as Label).Text; 
            string mobile = (item.FindControl("lblMobile") as Label).Text;
            string addressType = (item.FindControl("hdnAddressType") as HiddenField).Value;
            string alternateNo = (item.FindControl("hdnAlternateNo") as HiddenField).Value;

            txtName.Text = custName;
            txtAddress1.Text = address1;
            txtAddress2.Text = address2;
            txtLandmark.Text = landmark.Trim();
            txtCity.Text = city;
            txtState.Text = state;
            txtPinCode.Text = pincode.Trim();
            txtCountry.Text = lblCountry;
            txtMobile.Text = mobile;
            rdbAddressType.SelectedValue = addressType;
            txtAlternateContact.Text = alternateNo.Trim();
            hdnidCustomerAddress.Value = idCustomerAddress;
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(4);", true);
        }

        protected void btnSetDefault_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            UserDL objUserDL = new UserDL();
            objUserDL.SetDefaultAddress(Convert.ToInt32(btn.CommandArgument));
            btnAddress_Click1(null, null);
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            UserDL objUserDL = new UserDL();
            int resp = objUserDL.DeleteAddress(Convert.ToInt32(btn.CommandArgument));
            if (resp > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Address delete successfully.');", true);
                btnAddress_Click1(null, null);
            }
        }

        private void GetOrders(int idCustomer, int pageSize, int pageNo)
        {
            pnlEmptyOrder.Visible = false;
            int recordCount = 0;
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetAllOrder(idCustomer, pageSize, pageNo);
            if (ds != null)
            {
                ViewState["AllOrder"] = ds;
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    rptOrder.DataSource = ds.Tables[2];
                    rptOrder.DataBind();
                }
                else
                {
                    rptOrder.Visible = false;
                    pnlEmptyOrder.Visible = true;
                }

                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    recordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["RecordCount"]);
                    if (recordCount == 0)
                        rptPagination.Visible = false;
                }
            }
            double dPageCount = 0;
            if (pageSize != 0)
            {
                dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            }
            else
            {
                dPageCount = 1;
            }
            //double dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int iPageCount = (int)Math.Ceiling(dPageCount);
            ViewState["iPageCount"] = iPageCount;
            List<ListItem> lPages = new List<ListItem>();
            if (iPageCount > 0)
            {
                for (int i = 1; i <= iPageCount; i++)
                    lPages.Add(new ListItem(i.ToString(), i.ToString(), i != pageNo));
            }

            rptPagination.DataSource = lPages;
            rptPagination.DataBind();
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(1);", true);
        }
        
        private void AddProductInCart(int Quantity)
        {
            UserDL objAdminCls = new UserDL();
            int idProduct = Convert.ToInt32(Session["IdProduct"]);
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            string Response = objAdminCls.SaveProductInCart(idProduct, idCountry, isB2B, idCustomer, Quantity);
            if (!string.IsNullOrEmpty(Response) && Response.ToUpper() == "SUCCESS")
            {

            }
            else
            {

            }
        }
        private int GetCountryId()
        {
            int value = 0;
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            if (reqCookies != null)
            {
                string rdata = reqCookies["idCountry"].ToString();
                value = Convert.ToInt32(CommonControl.Decrypt(rdata));
            }
            return value;
        }

        protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int pageSize = Convert.ToInt16(ConfigurationManager.AppSettings["OrderPageSize"]);
            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            //HiddenField hdnidOrder = e.Item.FindControl("customerID") as HiddenField;
            //int customerID = Convert.ToInt32(hdnidOrder.Value);
            int pageNum = Convert.ToInt32(e.CommandArgument);
            if (pageNum == -1)
            {
                pageNum = 1;
            }
            else if (pageNum == -2)
            {
                pageNum = (int)ViewState["iPageCount"];
            }

            hdPageNo.Value = pageNum.ToString();
            GetOrders(idCustomer, pageSize, pageNum);
            //GetProductList(Convert.ToInt32(ddlLimit.SelectedValue), pageNum, ddlSort.SelectedItem.Text.Split(' ').First(), ddlSort.SelectedValue.Split('_').Last());
        }

        protected void rptOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lblFeatures = e.Item.FindControl("lblFeatures") as Label;
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetInvoiceDetails(Convert.ToInt32(e.CommandArgument));
            string freeshippingquantity = string.Empty, freeshippingamount = string.Empty;
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblNameTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                    lblAddress1To.Text = Convert.ToString(ds.Tables[0].Rows[0]["sAddress1"]);
                    lblAddress2To.Text = Convert.ToString(ds.Tables[0].Rows[0]["sAddress2"]);
                    lblLandmarkTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["sLandMark"]);
                    lblCityTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["sCity"]);
                    lblStateTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["sState"]);
                    lblPincodeTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PinCode"]);
                    lblEmailTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    lblMobileTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);

                    lblInvoiceNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["sOrderNo"]);
                    lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["todate"]);
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    freeshippingquantity = Convert.ToString(ds.Tables[1].Rows[0]["svalue"]);
                    freeshippingamount = Convert.ToString(ds.Tables[1].Rows[0]["svalue"]);
                }
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    decimal subtotal = 0, PurchasePrice = 0, ShippingCharges = 0;
                    int Quantity = 0;
                    subtotal = Convert.ToDecimal(ds.Tables[2].Rows[0]["SubTotal"]);
                    PurchasePrice = Convert.ToDecimal(ds.Tables[2].Rows[0]["PurchasePrice"]);
                    if (Convert.ToDecimal(freeshippingamount) <= Convert.ToDecimal(PurchasePrice))
                    {
                        ShippingCharges = 0; Quantity = 0;
                    }
                    else
                    {
                        ShippingCharges = Convert.ToInt32(ds.Tables[2].Rows[0]["ShippingCharge"]);
                        Quantity = Convert.ToInt32(ds.Tables[2].Rows[0]["Quantity"]);
                    }
                    lblSubTotal.Text = string.Format("{0:0,0.00}", subtotal);
                    lblDiscount.Text = string.Format("{0:0,0.00}", Convert.ToDecimal(ds.Tables[2].Rows[0]["Discount"]));
                    lblVat.Text = string.Format("{0:0,0.00}", ShippingCharges);
                    lblPurchasePrice.Text = string.Format("{0:0,0.00}", PurchasePrice + ShippingCharges);

                }
                if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    rptInvoice.DataSource = ds.Tables[3];
                    rptInvoice.DataBind();
                }
                if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    lblNameFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sName"]);
                    lblAddressFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sAddress"]);
                    lblCityFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sCity"]);
                    lblStateFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sState"]);
                    lblPincodeFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sZip"]);
                    lblEmailFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sEmail"]);
                    lblPhoneFrom.Text = Convert.ToString(ds.Tables[4].Rows[0]["sPhoneNumber"]);
                }
                if (e.CommandName == "Readmore")
                {
                    lnkread.Text = (lnkread.Text == "Read More") ? "Hide" : "Read More";
                    string temp = lblFeatures.Text;
                    lblFeatures.Text = lblFeatures.ToolTip;
                    lblFeatures.ToolTip = temp;
                }
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowInvoice();", true);
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            DataSet ds = objUserDL.GetCustomerDetail(idCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                lblFullName1.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(0);", true);
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int pageno = Convert.ToInt32(hdPageNo.Value);
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                GetOrders(idCustomer, Convert.ToInt16(ConfigurationManager.AppSettings["OrderPageSize"]), pageno);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(1);", true);
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(2);", true);
        }

        protected void btnPaymentMethod_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(3);", true);
        }

        protected void btnAddress_Click1(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                GetAllAddress(idCustomer);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(4);", true);
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void btnAccountDetails_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                GetCustomerDetail(idCustomer);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(5);", true);
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void btnAccountEdit_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                UserDL objUserDL = new UserDL();
                DataSet ds = objUserDL.GetCustomerDetail(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Gender"])))
                        rbGender.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                    txtMobileNum.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                    txtREmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    txtCurrentPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(5);", true);
                pnlEditAccount.Visible = true;
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void btnNewAddress_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtLandmark.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            txtCountry.Text = ((Label)Master.FindControl("lblCountryName")).Text;
            txtMobile.Text = string.Empty;
            rdbAddressType.SelectedIndex = 0;
            txtAlternateContact.Text = string.Empty;
            hdnidCustomerAddress.Value = string.Empty;

            btnAddress_Click1(null, null);
            pnlEditAddress.Visible = true;
        }

        protected void btnCancelAddress_Click1(object sender, EventArgs e)
        {
            btnAddress_Click1(null, null);
            pnlEditAddress.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAccountDetails_Click(null, null);
            pnlEditAccount.Visible = false;
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