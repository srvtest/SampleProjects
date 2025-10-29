using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsiteB2B
{
    public partial class checkout : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        string AdminUrl = ConfigurationManager.AppSettings["AdminUrl"].ToString();
        string producthtml = string.Empty, country = string.Empty;
        string Name = string.Empty, Address = string.Empty, Address1 = string.Empty, Address2 = string.Empty,
            Address3 = string.Empty, OrderNo = string.Empty, OrderDate = string.Empty, TotalAmount = string.Empty, emailTo = string.Empty;
        public decimal SubtotalAmount
        {
            get
            {
                return Convert.ToDecimal(ViewState["SubtotalAmount"]);
            }
            set
            {

                ViewState["SubtotalAmount"] = value;
            }
        }

        public decimal ShipmentCharges
        {
            get
            {
                return Convert.ToDecimal(ViewState["ShipmentCharges"]);
            }
            set
            {

                ViewState["ShipmentCharges"] = value;
            }
        }

        public decimal totalAmount
        {
            get
            {
                return Convert.ToDecimal(ViewState["totalAmount"]);
            }
            set
            {

                ViewState["totalAmount"] = value;
            }
        }
        public decimal freeShippingAmount
        {
            get
            {
                return Convert.ToDecimal(ViewState["freeShippingAmount"]);
            }
            set
            {

                ViewState["freeShippingAmount"] = value;
            }
        }
        public int freeShippingCount
        {
            get
            {
                return Convert.ToInt32(ViewState["freeShippingCount"]);
            }
            set
            {

                ViewState["freeShippingCount"] = value;
            }
        }
        public int productCount
        {
            get
            {
                return Convert.ToInt32(ViewState["productCount"]);
            }
            set
            {

                ViewState["productCount"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                GetCustomerCardDetail();
            }
        }

        private void GetCustomerCardDetail()
        {
            if (Session["CustomerId"] != null)
            {
                UserDL objAdminCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                DataSet ds = objAdminCls.GetCustomerCardDetail(idCustomer);
                if (ds != null && ds.Tables.Count > 0)
                {
                    ViewState["CartData"] = ds;
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                        //lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    }
                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        rptAddress.DataSource = ds.Tables[1];
                        rptAddress.DataBind();
                    }
                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        rptProductDetail.DataSource = ds.Tables[2];
                        rptProductDetail.DataBind();


                        SubtotalAmount = 0;
                        ShipmentCharges = 0;
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            productCount++;
                            // country = Convert.ToString(ds.Tables[2].Rows[i]["Country"]);
                            int qty = Convert.ToInt32(ds.Tables[2].Rows[i]["Quantity"]);
                            decimal amount = Convert.ToDecimal(ds.Tables[2].Rows[i]["price"]);
                            SubtotalAmount += qty * amount;
                            ShipmentCharges += Convert.ToDecimal(ds.Tables[2].Rows[i]["ShipmentCharges"]);
                        }
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        List<ConfigCls> lstConfig = ds.Tables[3].AsEnumerable()
                                .Select(dataRow => new ConfigCls
                                {
                                    idConfig = dataRow.Field<int>("idConfig"),
                                    sValue = dataRow.Field<string>("sValue")
                                }).ToList();
                        freeShippingAmount = Convert.ToDecimal(lstConfig.Where(x => x.idConfig == 1).Select(x => x.sValue).FirstOrDefault());
                        freeShippingCount = Convert.ToInt32(lstConfig.Where(x => x.idConfig == 3).Select(x => x.sValue).FirstOrDefault());
                    }
                    if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                        totalAmount = SubtotalAmount;
                    else
                        totalAmount = SubtotalAmount + ShipmentCharges;
                    ShowPanel(1);
                }
                else
                {
                    ShowPanel(0);
                }
            }
        }

        private void ShowPanel(int panel)
        {
            switch (panel)
            {
                case 1:
                    pnlCoupon.Visible = false;
                    pnlDeliveryAddress.Visible = true;
                    pnlNewAddress.Visible = false;
                    pnlBillingShipping.Visible = false;
                    pnlMessage.Visible = false;
                    pnlEmpty.Visible = false;
                    break;
                case 2:
                    pnlCoupon.Visible = false;
                    pnlDeliveryAddress.Visible = true;
                    pnlNewAddress.Visible = true;
                    pnlBillingShipping.Visible = false;
                    pnlMessage.Visible = false;
                    pnlEmpty.Visible = false;

                    ////chkAddNewAddress.Checked = false;
                   // //pnlNew.Visible = false;
                    hdnidCustomerAddress.Value = "0";
                    txtName.Text = "";
                    txtMobile.Text = "";
                    txtPinCode.Text = "";
                    txtAddress1.Text = "";
                    txtAddress2.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtLandmark.Text = "";
                    rdbAddressType.SelectedIndex = 0;
                    txtAlternateContact.Text = "";
                    break;
                case 3:
                    pnlCoupon.Visible = true;
                    pnlDeliveryAddress.Visible = false;
                    pnlNewAddress.Visible = false;
                    pnlBillingShipping.Visible = true;
                    pnlMessage.Visible = false;
                    pnlEmpty.Visible = false;
                    break;
                case 4:
                    pnlCoupon.Visible = false;
                    pnlDeliveryAddress.Visible = false;
                    pnlNewAddress.Visible = false;
                    pnlBillingShipping.Visible = false;
                    pnlMessage.Visible = true;
                    pnlEmpty.Visible = false;
                    break;
                default:
                    pnlCoupon.Visible = false;
                    pnlDeliveryAddress.Visible = false;
                    pnlNewAddress.Visible = false;
                    pnlBillingShipping.Visible = false;
                    pnlMessage.Visible = false;
                    pnlEmpty.Visible = true;
                    break;
            }

        }

        protected void btnAddAddress_Click(object sender, EventArgs e)
        {
            Label lblCountry = (Label)Master.FindControl("lblCountryName");
            UserDL objUserDL = new UserDL();
            CustomerAddress objCustomerAddr = new CustomerAddress();
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
            objCustomerAddr.idCustomerAddress = 0;
            objCustomerAddr.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            string resp = objUserDL.AddEditAddress(objCustomerAddr);
            if (!string.IsNullOrEmpty(resp) && Convert.ToInt32(resp) > 0)
            {
                hdnidAddress.Value = resp;
                lblSName.Text = objCustomerAddr.sName;
                lblSMobile.Text = objCustomerAddr.Mobile;
                lblSAddress1.Text = objCustomerAddr.sAddress1;
                lblSAddress2.Text = objCustomerAddr.sAddress2;
                lblSCity.Text = objCustomerAddr.sCity;
                lblSState.Text = objCustomerAddr.sState;
                lblSPincode.Text = objCustomerAddr.PinCode;
                lblSLandmark.Text = objCustomerAddr.sLandMark;
                lblSAddressType.Text = objCustomerAddr.AddressType;
                lblSCountry.Text = objCustomerAddr.CountryName;
                ShowPanel(3);
            }
            else
            {
                //lblMessage.Text = "<strong>Error!</strong> Address did not save.";
                //lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnNewAddressCancel_Click(object sender, EventArgs e)
        {
            ShowPanel(1);
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            PlaceOrder();
            string result = "Successfully order is palced.";
            Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','" + result + "');", true);
        }

        protected void btnNewAddress_Click(object sender, EventArgs e)
        {
            ShowPanel(2);
            Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "ShowFormNewAddress();", true);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void PlaceOrder()
        {
            CustomerOrderCls objCustomerOrderCls = new CustomerOrderCls();
            DataSet ds = (DataSet)ViewState["CartData"];

            decimal totalAmount = 0;
            int totalQty = 0;
            int totalProduct = 0;
            int idCountry = GetCountryId();

            UserDL objUserDL = new UserDL();
            DataSet ds1 = objUserDL.GetAllClientMaster(idCountry);
            string host = "", fromMail = "", password = "";
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                host = Convert.ToString(ds1.Tables[0].Rows[0]["host"]);
                fromMail = Convert.ToString(ds1.Tables[0].Rows[0]["fromEmail"]);
                password = Convert.ToString(ds1.Tables[0].Rows[0]["password"]);
            }

            if (ds != null)
            {
                if (Session["CustomerId"] != null)
                {
                    int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                    objCustomerOrderCls.idCustomer = idCustomer;
                    emailTo = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[1].Rows[i];
                        if (hdnidAddress.Value == Convert.ToString(ds.Tables[1].Rows[i]["idCustomerAddress"]))
                        {
                            objCustomerOrderCls.sName = Convert.ToString(dr["sName"]);
                            objCustomerOrderCls.Mobile = Convert.ToString(dr["Mobile"]);
                            objCustomerOrderCls.PinCode = Convert.ToString(dr["PinCode"]);
                            objCustomerOrderCls.sAddress1 = Convert.ToString(dr["sAddress1"]);
                            objCustomerOrderCls.sAddress2 = Convert.ToString(dr["sAddress2"]);
                            objCustomerOrderCls.sCity = Convert.ToString(dr["sCity"]);
                            objCustomerOrderCls.sState = Convert.ToString(dr["sState"]);
                            objCustomerOrderCls.sLandMark = Convert.ToString(dr["sLandMark"]);
                            objCustomerOrderCls.AddressType = Convert.ToString(dr["AddressType"]);
                            objCustomerOrderCls.AlternateNo = Convert.ToString(dr["AlternateNo"]);
                        }
                    }
                }
                decimal total = 0;
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    objCustomerOrderCls.CustomerOrderProductCls = new List<CustomerOrderProductCls>();
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        string htr = "<tr><td style='padding-right: 0px;padding-left: 0px;' align='center'><img align='center' border='0' src='" + AdminUrl + "/ProductImage/" + ds.Tables[2].Rows[i]["ImageURL"] + "' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;width: 100%;max-width: 130px;' width='130' class='v-src-width v-src-max-width' /></td><td style = 'overflow-wrap:break-word;word-break:break-word;padding:37px 30px 36px;font-family:arial,helvetica,sans-serif;' align = 'left'><div class='v-text-align' style='color: #000000; line-height: 140%; text-align: left; word-wrap: break-word;'><p style = 'font-size: 14px; line-height: 140%;' ><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> " + ds.Tables[2].Rows[i]["sName"] + "</span ></strong ></span ></p ><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Size:&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;7</span></strong></span></p><p style = 'font-size: 14px; line-height: 140%;'><span style='color: #444444; font-size: 16px; line-height: 20px;'><strong><span style = 'line-height: 20px; font-size: 16px;'> Quantity: &nbsp; &nbsp;" + ds.Tables[2].Rows[i]["Quantity"] + "</span></strong></span></p></div></td></tr>";
                        producthtml += htr;
                        DataRow dr = ds.Tables[2].Rows[i];
                        CustomerOrderProductCls objCustomerOrderProductCls = new CustomerOrderProductCls();
                        objCustomerOrderProductCls.idProduct = Convert.ToInt32(dr["idProduct"]);
                        objCustomerOrderProductCls.Quantity = Convert.ToInt32(dr["Quantity"]);
                        objCustomerOrderProductCls.ProductPrice = Convert.ToDecimal(dr["APrice"]);
                        objCustomerOrderProductCls.PurchasePrice = Convert.ToDecimal(dr["Price"]);
                        objCustomerOrderProductCls.Discount = Convert.ToDecimal(dr["Discount"]);
                        objCustomerOrderProductCls.ShippingCharge = Convert.ToDecimal(dr["ShipmentCharges"]);
                        objCustomerOrderProductCls.idCountry = idCountry;
                        objCustomerOrderCls.CustomerOrderProductCls.Add(objCustomerOrderProductCls);
                        //totalAmount += (Convert.ToInt32(dr["Quantity"]) * Convert.ToDecimal(dr["Price"])) + Convert.ToDecimal(dr["ShipmentCharges"]);
                        //totalQty += Convert.ToInt32(dr["Quantity"]);
                        totalAmount += (Convert.ToInt32(dr["Quantity"]) * Convert.ToDecimal(dr["Price"]));
                        totalQty += Convert.ToInt32(dr["Quantity"]);
                        //TotalAmount = Convert.Todecimal(dr["Price"]);
                    }
                    decimal freeShippingAmount = 0;
                    int freeShippingCount = 0;
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        List<ConfigCls> lstConfig = ds.Tables[3].AsEnumerable()
                                .Select(dataRow => new ConfigCls
                                {
                                    idConfig = dataRow.Field<int>("idConfig"),
                                    sValue = dataRow.Field<string>("sValue")
                                }).ToList();
                        freeShippingAmount = Convert.ToDecimal(lstConfig.Where(x => x.idConfig == 1).Select(x => x.sValue).FirstOrDefault());
                        freeShippingCount = Convert.ToInt32(lstConfig.Where(x => x.idConfig == 3).Select(x => x.sValue).FirstOrDefault());
                    }
                    if (freeShippingAmount <= totalAmount || freeShippingCount <= totalQty)
                        total = totalAmount;
                    else
                        total = totalAmount + ShipmentCharges;

                    totalProduct = ds.Tables[2].Rows.Count;
                }
                objCustomerOrderCls.totalAmount = totalAmount;
                objCustomerOrderCls.TotalProduct = totalProduct;
                objCustomerOrderCls.TotalQuantity = totalQty;
                objCustomerOrderCls.Comment = txtOrderNote.Text.Trim();
                UserDL objAdminCls = new UserDL();
                string res = objAdminCls.CreateOrder(objCustomerOrderCls);
                DataSet ds2 = objAdminCls.GetOrderById(res);

                ///////
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        Name = Convert.ToString(ds2.Tables[0].Rows[i]["sName"]); ;
                        Address = Convert.ToString(ds2.Tables[0].Rows[i]["sAddress1"]);
                        Address1 = Convert.ToString(ds2.Tables[0].Rows[i]["sAddress2"]);
                        Address2 = Convert.ToString(ds2.Tables[0].Rows[i]["sCity"]);
                        Address3 = Convert.ToString(ds2.Tables[0].Rows[i]["sState"]);
                        OrderNo = Convert.ToString(ds2.Tables[0].Rows[i]["sOrderNo"]);
                        OrderDate = Convert.ToString(ds2.Tables[0].Rows[i]["dtOrder"]);
                        TotalAmount = Convert.ToString(ds2.Tables[0].Rows[i]["totalAmount"]);
                    }
                }
                //string emailTo = "testsrv111@gmail.com";
                string subject = "Order Place";
                // Code to send mail
                string link = string.Empty;
                //   link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>");               
                keywordsToReplace.Add("##Name##", Name);
                keywordsToReplace.Add("##ABCDE##", Name);
                keywordsToReplace.Add("##12345##", Address);
                keywordsToReplace.Add("##ABC##", Address2);
                keywordsToReplace.Add("##ACD##", Address3);
                keywordsToReplace.Add("##38337398##", OrderNo);
                keywordsToReplace.Add("##December##", OrderDate);
                keywordsToReplace.Add("##$14.83##", TotalAmount);
                keywordsToReplace.Add("##Sleek##", producthtml);
                string body = GenrateMail("OrderPlace");
                CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                ///////

                if (!string.IsNullOrEmpty(res))
                {
                    lblOrderNo.Text = res;
                    this.Master.GetCartDetail();
                    ShowPanel(4);
                }
            }
        }

        protected void rptAddress_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lblCntryName = (Label)Master.FindControl("lblCountryName");
            Label lblAddress = e.Item.FindControl("lblAddress") as Label;
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            Label lblCountry = e.Item.FindControl("lblCountry") as Label;
            if (lblCntryName.Text == lblCountry.Text)
            {
                if (!string.IsNullOrEmpty(lblAddress.Text))
                {
                    if (e.CommandName == "Deliveraddress")
                    {
                        hdnidAddress.Value = hdn.Value;

                        lblSName.Text = (e.Item.FindControl("lblCustName") as Label).Text;
                        lblSMobile.Text = (e.Item.FindControl("lblMobile") as Label).Text;
                        lblSAddress1.Text = (e.Item.FindControl("lblAddress1") as Label).Text;
                        lblSAddress2.Text = (e.Item.FindControl("lblAddress2") as Label).Text;
                        lblSCity.Text = (e.Item.FindControl("lblCity") as Label).Text;
                        lblSState.Text = (e.Item.FindControl("lblState") as Label).Text;
                        lblSPincode.Text = (e.Item.FindControl("lblPincode") as Label).Text;
                        lblSLandmark.Text = (e.Item.FindControl("lblLandmark") as Label).Text;
                        lblSAddressType.Text = (e.Item.FindControl("hdnAddressType") as HiddenField).Value;
                        lblSCountry.Text = (e.Item.FindControl("lblCountry") as Label).Text;
                        ShowPanel(3);
                    }
                }
            }
            else
            {
                string result = "Order can not deliver on selected address.";
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','" + result + "');", true);
               // Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
               // lblMsg.Text = "Order can not deliver on selected address.";
            }
        }

        protected void rptAddress_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataSet ds = (DataSet)ViewState["CartData"];
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    string strAddress = string.Empty;
                    Label lblAddress = e.Item.FindControl("lblAddress") as Label;
                    HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[1].Rows[i];
                        if (Convert.ToString(dr["idCustomerAddress"]) == hdn.Value)
                        {
                            strAddress += dr["idCustomerAddress"];
                            strAddress += dr["sName"];
                            strAddress += "< br />";
                            strAddress += dr["AddressType"];
                            strAddress += "< br /> ";
                            strAddress += dr["sAddress1"];
                            strAddress += dr["sAddress2"];
                            strAddress += "< br /> ";
                            strAddress += dr["sLandMark"];
                            strAddress += "< br /> ";
                            strAddress += dr["sCity"];
                            strAddress += dr["PinCode"];
                            strAddress += dr["sState"];
                            strAddress += "< br /> ";
                            strAddress += dr["Mobile"];
                            strAddress += dr["AlternateNo"];
                            lblAddress.Text = strAddress;
                        }

                    }

                    lblAddress.Text = strAddress;
                }
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

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            switch (mailType)
            {
                case "OrderPlace":
                    contentFilePath = Server.MapPath("HTMLMail/OrderPlace.html");
                    break;

                default:
                    break;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.File.ReadAllText(contentFilePath));
            foreach (string keyword in keywordsToReplace)
            {
                sb.Replace(keyword, keywordsToReplace.Get(keyword));
            }
            return sb.ToString();
        }
    }
}