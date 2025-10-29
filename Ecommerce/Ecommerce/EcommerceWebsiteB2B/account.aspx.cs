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

namespace EcommerceWebsiteB2B
{
    public partial class account : System.Web.UI.Page
    {
        public string baseUrl
        {
            get
            {
                return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerId"] != null)
                {
                    int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                    GetCustomerDetail(idCustomer);
                    Dictionary<int, string> gender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToDictionary(x => (int)x, x => x.ToString());
                    rbGender.DataSource = gender;
                    rbGender.DataTextField = "Value";
                    rbGender.DataValueField = "Key";
                    rbGender.DataBind();

                    pnlMyOrder.Visible = false;


                    //string lnk = Convert.ToString(Page.RouteData.Values["link"]);
                    //switch (lnk)
                    //{
                    //    case "WishList":
                    //        ShoWPanel(4);
                    //        break;
                    //    case "Order":
                    //        ShoWPanel(3);
                    //        break;
                    //    default:
                    //        break;
                    //}

                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
           // pnlMyOrder.Visible = false;
        }
        private void GetAllAddress()
        {
            if (Session["CustomerId"] != null)
            {
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                UserDL objUserDL = new UserDL();
                DataSet ds = objUserDL.GetAllAddress(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptAddress.DataSource = ds.Tables[0];
                    rptAddress.DataBind();
                }
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
                    lblGender.Text = Enum.GetName(typeof(Gender), Convert.ToInt16(ds.Tables[0].Rows[0]["Gender"]));
                lblMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            CustomerCls objCustomerCls = new CustomerCls();
            objCustomerCls.sName = txtName.Text.Trim();
            objCustomerCls.Gender = Convert.ToInt16(rbGender.SelectedValue);
            objCustomerCls.Email = txtEmail.Text.Trim();
            objCustomerCls.Username = txtEmail.Text.Trim();
            objCustomerCls.Mobile = txtPhoneNo.Text.Trim();
            objCustomerCls.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            if (!string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                objCustomerCls.Password = CommonControl.SHA256Encryption(txtNewPassword.Text.Trim());
                objCustomerCls.CurrentPassword = CommonControl.SHA256Encryption(txtCurrentPassword.Text.Trim());
            }
            int ResponseData = objUserDL.EditCustomer(objCustomerCls);
            if (ResponseData == 0)
            {
                GetCustomerDetail(objCustomerCls.idCustomer);
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Account update Successfully.');", true);
              //  Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(5);", true);
               // pnlEditAccount.Visible = false;
               // GetCustomerDetail(Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))));
                //lblMessage.Text = "Your information update successfully.";
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','Account Not Update.');", true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowTab(5);", true);
                //pnlEditAccount.Visible = true;
                txtCurrentPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = "";
                //lblMessage.Text = "<strong>Error!</strong> Your information did not update.";
            }
        }

        protected void btnSaveAddress_Click(object sender, EventArgs e)
        {
            Label lblCountry = (Label)Master.FindControl("lblCountryName");
            UserDL objUserDL = new UserDL();
            CustomerAddress objCustomerAddr = new CustomerAddress();
            objCustomerAddr.CountryName = lblCountry.Text;
            objCustomerAddr.sName = txtCustName.Text.Trim();
            objCustomerAddr.Mobile = txtMobile.Text.Trim();
            objCustomerAddr.PinCode = txtPinCode.Text.Trim();
            objCustomerAddr.sAddress1 = txtAddress1.Text.Trim();
            objCustomerAddr.sAddress2 = txtAddress2.Text.Trim();
            objCustomerAddr.sCity = txtCity.Text.Trim();
            objCustomerAddr.sState = txtState.Text.Trim();
            objCustomerAddr.sLandMark = txtLandmark.Text.Trim();
            objCustomerAddr.AddressType = rdbAddressType.SelectedItem.Text;
            objCustomerAddr.AlternateNo = txtAlternateContact.Text.Trim();
            objCustomerAddr.idCustomerAddress = !string.IsNullOrEmpty(hdnidCustomerAddress.Value) ? Convert.ToInt32(hdnidCustomerAddress.Value) : 0;
            objCustomerAddr.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            string resp = objUserDL.AddEditAddress(objCustomerAddr);
            GetAllAddress();
            pnlEditAddress.Visible = false;
            pnlAddress.Visible = true;
        }

        protected void btnEditAddress_Click(object sender, EventArgs e)
        {
            pnlAddress.Visible = false;
            pnlEditAddress.Visible = true;
            pnlNe.Visible = false;
            pnlNewAddress.Visible = false;
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
            string mobile = (item.FindControl("lblMobile") as Label).Text;
            string addressType = (item.FindControl("hdnAddressType") as HiddenField).Value;
            string alternateNo = (item.FindControl("hdnAlternateNo") as HiddenField).Value;

            txtCustName.Text = custName;
            txtAddress1.Text = address1;
            txtAddress2.Text = address2;
            txtLandmark.Text = landmark.Trim();
            txtCity.Text = city;
            txtState.Text = state;
            txtPinCode.Text = pincode.Trim();
            txtMobile.Text = mobile;
            rdbAddressType.SelectedValue = addressType;
            txtAlternateContact.Text = alternateNo.Trim();
            hdnidCustomerAddress.Value = idCustomerAddress;

        }

        //protected void btnMyAddress_Click(object sender, EventArgs e)
        //{
        //    ShoWPanel(2);
        //    //LinkButton btn = sender as LinkButton;
        //    //btn.Attributes.Add("class", "active");
        //}

        protected void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            ShoWPanel(1);
        }

        protected void btnCancelAddress_Click(object sender, EventArgs e)
        {
            pnlEditAddress.Visible = false;
            pnlNe.Visible = false;
            pnlAddress.Visible = true;
            chkAddNewAddress.Checked = false;
            pnlNewAddress.Visible = true;
        }

        protected void btnSetDefault_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            UserDL objUserDL = new UserDL();
            objUserDL.SetDefaultAddress(Convert.ToInt32(btn.CommandArgument));
            GetAllAddress();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            UserDL objUserDL = new UserDL();
            int resp = objUserDL.DeleteAddress(Convert.ToInt32(btn.CommandArgument));
            if (resp > 0)
                GetAllAddress();
        }

        protected void btnMyOrder_Click(object sender, EventArgs e)
        {
            ShoWPanel(3);
        }

        private void ShoWPanel(int id)
        {
            pnlAddress.Visible = false;
            pnlPersonalInfo.Visible = false;
            pnlAllAddress.Visible = false;
            pnlMyOrder.Visible = false;
            //pnlWishlist.Visible = false;
            switch (id)
            {
                case 1:
                    pnlPersonalInfo.Visible = true;
                    break;
                case 2:
                    pnlAllAddress.Visible = true;
                    pnlAddress.Visible = true;
                    pnlEditAddress.Visible = false;
                    GetAllAddress();
                    break;
                case 3:
                    pnlMyOrder.Visible = true;
                    if (Session["CustomerId"] != null)
                    {
                        int pageno = Convert.ToInt32(hdPageNo.Value);
                        int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                        GetOrders(idCustomer, Convert.ToInt16(ConfigurationManager.AppSettings["OrderPageSize"]), pageno);
                    }
                    break;
                //case 4:
                //    pnlWishlist.Visible = true;
                //    GetWishlistDetail();
                //    break;
                default:
                    break;
            }

        }

        private void GetOrders(int idCustomer, int pageSize, int pageNo)
        {
            pnlEmptyOrder.Visible = false;
            int recordCount = 0;
           // pnlPaggination.Visible = false;
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetAllOrder(idCustomer, pageSize, pageNo);
            if (ds != null)
            {
                ViewState["AllOrder"] = ds;
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {

                    rptOrder.DataSource = ds.Tables[2];
                    rptOrder.DataBind();
                    //pnlPaggination.Visible = true;
                }
                else
                {
                    rptOrder.Visible = false;
                    pnlEmptyOrder.Visible = true;
                }

                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    recordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["RecordCount"]);
                }
            }
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    ViewState["AllOrder"] = ds;
            //    rptOrder.DataSource = ds.Tables[0];
            //    rptOrder.DataBind();
            //}
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
        }

        protected void rptOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater lstCountryConfig = e.Item.FindControl("rptOrderproduct") as Repeater;

            HiddenField hdnidOrder = e.Item.FindControl("hdnidOrder") as HiddenField;

            AdminDL objAdminCls = new AdminDL();
            DataSet ds = (DataSet)ViewState["AllOrder"];
            customerID.Value = hdnidOrder.Value;
            ds.Tables[0].DefaultView.RowFilter = "idCustomerOrder = " + hdnidOrder.Value;
            DataTable dt = (ds.Tables[0].DefaultView).ToTable();
            lstCountryConfig.DataSource = dt;
            lstCountryConfig.DataBind();
        }

        protected void chkAddNewAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddNewAddress.Checked)
            {
                pnlNe.Visible = true;
                pnlEditAddress.Visible = false;
            }
            else
            {
                pnlNe.Visible = false;
            }
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            Label lblCountry = (Label)Master.FindControl("lblCountryName");
            UserDL objAdminCls = new UserDL();
            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));

            CustomerAddress objCustomerAddress = new CustomerAddress();
            objCustomerAddress.idCustomer = idCustomer;
            objCustomerAddress.idCustomerAddress = 0;
            objCustomerAddress.sName = txtNam.Text;
            objCustomerAddress.Mobile = txtMob.Text;
            objCustomerAddress.PinCode = txtPin.Text;
            objCustomerAddress.sAddress1 = txtAdd1.Text;
            objCustomerAddress.sAddress2 = txtAdd2.Text;
            objCustomerAddress.sCity = txtCty.Text;
            objCustomerAddress.sState = txtStte.Text;
            objCustomerAddress.sLandMark = txtLandark.Text;
            objCustomerAddress.AddressType = rdbAddresType.SelectedValue;
            objCustomerAddress.AlternateNo = txtAlternatContact.Text;
            objCustomerAddress.CountryName = lblCountry.Text;

            string str = objAdminCls.AddEditAddress(objCustomerAddress);
            GetAllAddress();
            pnlEditAddress.Visible = false;
            pnlAddress.Visible = true;
        }

        //private void ShowPanel(int panel)
        //{
        //    switch (panel)
        //    {
        //        case 1:
        //            //pnl1.Visible = true;
        //            //Pnl2.Visible = false;
        //            //Pnl3.Visible = false;
        //            //Pnl4.Visible = false;
        //            //pnlEmpty.Visible = false;
        //            break;
        //        case 2:
        //            //pnl1.Visible = false;
        //            //Pnl2.Visible = true;
        //            //Pnl3.Visible = false;
        //            //Pnl4.Visible = false;
        //            //pnlEmpty.Visible = false;

        //            chkAddNewAddress.Checked = false;
        //            pnlNe.Visible = false;
        //            hdnidCustomerAddress.Value = "0";
        //            txtNam.Text = "";
        //            txtMob.Text = "";
        //            txtPin.Text = "";
        //            txtAdd1.Text = "";
        //            txtAdd2.Text = "";
        //            txtCty.Text = "";
        //            txtStte.Text = "";
        //            txtLandark.Text = "";
        //            //rdbAddressType.Text = "";
        //            txtAlternatContact.Text = "";

        //            break;
        //        case 3:
        //            //pnl1.Visible = false;
        //            //Pnl2.Visible = false;
        //            //Pnl3.Visible = true;
        //            //Pnl4.Visible = false;
        //            //pnlEmpty.Visible = false;
        //            break;
        //        case 4:
        //            //pnl1.Visible = false;
        //            //Pnl2.Visible = false;
        //            //Pnl3.Visible = false;
        //            //Pnl4.Visible = true;
        //            //pnlEmpty.Visible = false;
        //            break;
        //        default:
        //            //pnl1.Visible = false;
        //            //Pnl2.Visible = false;
        //            //Pnl3.Visible = false;
        //            //pnlEmpty.Visible = true;
        //            break;
        //    }

        //}

        //protected void btnMywishlist_Click(object sender, EventArgs e)
        //{
        //    ShoWPanel(4);
        //}

        //protected void rptWishlistProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    HiddenField hdnidProduct = e.Item.FindControl("hdnidProduct") as HiddenField;
        //    HiddenField hdnidCustomerCart = e.Item.FindControl("hdnidCustomerCart") as HiddenField;
        //    TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
        //    if (!string.IsNullOrEmpty(hdnidProduct.Value))
        //    {
        //        if (e.CommandName == "qtyUpdate")
        //        {
        //            HiddenField hdn = e.Item.FindControl("hdnidProduct") as HiddenField;
        //            if (hdn != null)
        //            {

        //                //txtQty
        //                Session["IdProduct"] = hdn.Value;
        //                if (Session["CustomerId"] != null)
        //                {
        //                    //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
        //                    int qty = 1;
        //                    AddProductInCart(qty, null, null);
        //                    this.Master.GetCartDetail();
        //                }
        //                else
        //                {
        //                    Response.Redirect("login");
        //                }
        //            }
        //            //  UserDL objAdminCls = new UserDL();
        //            //string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), Convert.ToInt32(txtQty.Text), "UPDATE");
        //            //  string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
        //        }
        //        if (e.CommandName == "qtyDelete")
        //        {
        //            UserDL objAdminCls = new UserDL();
        //            string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
        //        }
        //        GetWishlistDetail();
        //    }
        //}

        //private void GetWishlistDetail()
        //{
        //    if (Session["CustomerId"] != null)
        //    {
        //        UserDL objAdminCls = new UserDL();
        //        int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
        //        DataSet ds = objAdminCls.GetWishlistCart(idCustomer);
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            rptWishlistProduct.DataSource = ds.Tables[0];
        //            rptWishlistProduct.DataBind();
        //        }
        //        else
        //        {
        //            rptWishlistProduct.DataSource = null;
        //            rptWishlistProduct.DataBind();
        //        }

        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");
        //    }

        //}

        //private void AddProductInCart(int Quantity, string Color, string Size)
        //{
        //    UserDL objAdminCls = new UserDL();
        //    int idProduct = Convert.ToInt32(Session["IdProduct"]);
        //    int idCountry = GetCountryId();
        //    int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

        //    int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
        //    string Response = objAdminCls.SaveProductInCart(idProduct, idCountry, isB2B, idCustomer, Quantity);
        //    if (!string.IsNullOrEmpty(Response) && Response.ToUpper() == "SUCCESS")
        //    {

        //    }
        //    else
        //    {

        //    }
        //}
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
                    //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    //{

                    int subtotal = 0, PurchasePrice = 0, ShippingCharges = 0, Quantity = 0;
                    subtotal = Convert.ToInt32(ds.Tables[2].Rows[0]["SubTotal"]);
                    PurchasePrice = Convert.ToInt32(ds.Tables[2].Rows[0]["PurchasePrice"]);
                    if (Convert.ToInt32(freeshippingamount) <= Convert.ToInt32(PurchasePrice))
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
                    //}                    

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

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            ShoWPanel(3);
        }

        protected void btnAddresses_Click(object sender, EventArgs e)
        {
            
            ShoWPanel(2);
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