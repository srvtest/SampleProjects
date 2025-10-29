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

namespace EcommerceWebsite
{
    public partial class checkoutpage : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        string AdminUrl = ConfigurationManager.AppSettings["AdminUrl"].ToString();
        string producthtml = string.Empty, country = string.Empty;
        string Name = string.Empty, Address = string.Empty, Address1 = string.Empty, Address2 = string.Empty,
            Address3 = string.Empty,OrderNo = string.Empty,OrderDate = string.Empty,TotalAmount = string.Empty, emailTo= string.Empty;
        public double SubtotalAmount
        {
            get
            {
                return Convert.ToDouble(ViewState["SubtotalAmount"]);
            }
            set
            {

                ViewState["SubtotalAmount"] = value;
            }
        }

        public double ShipmentCharges
        {
            get
            {
                return Convert.ToDouble(ViewState["ShipmentCharges"]);
            }
            set
            {

                ViewState["ShipmentCharges"] = value;
            }
        }

        public double totalAmount
        {
            get
            {
                return Convert.ToDouble(ViewState["totalAmount"]);
            }
            set
            {

                ViewState["totalAmount"] = value;
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
                        lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                        lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    }
                    if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        rptAddress.DataSource = ds.Tables[1];
                        rptAddress.DataBind();
                    }
                    if (ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                    {
                        rptProductDetail.DataSource = ds.Tables[2];
                        rptProductDetail.DataBind();
                        

                        SubtotalAmount = 0;
                        ShipmentCharges = 0;
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                           // country = Convert.ToString(ds.Tables[2].Rows[i]["Country"]);
                            int qty = Convert.ToInt32(ds.Tables[2].Rows[i]["Quantity"]);
                            double amount = Convert.ToInt32(ds.Tables[2].Rows[i]["Price"]);
                            SubtotalAmount += (qty * amount);
                            ShipmentCharges += Convert.ToInt32(ds.Tables[2].Rows[i]["ShipmentCharges"]);
                        }
                        totalAmount = SubtotalAmount + ShipmentCharges;

                        ShowPanel(1);
                    }
                    else
                    {
                        ShowPanel(0);
                    }
                }
            }
        }

        private void ShowPanel(int panel)
        {
            switch (panel)
            {
                case 1:
                    pnl1.Visible = true;
                    Pnl2.Visible = false;
                    Pnl3.Visible = false;
                    Pnl4.Visible = false;
                    pnlEmpty.Visible = false;
                    break;
                case 2:
                    pnl1.Visible = false;
                    Pnl2.Visible = true;
                    Pnl3.Visible = false;
                    Pnl4.Visible = false;
                    pnlEmpty.Visible = false;

                    chkAddNewAddress.Checked = false;
                    pnlNew.Visible = false;
                    hdnidCustomerAddress.Value = "0";
                    txtName.Text = "";
                    txtMobile.Text = "";
                    txtPinCode.Text = "";
                    txtAddress1.Text = "";
                    txtAddress2.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtLandmark.Text = "";
                    //rdbAddressType.Text = "";
                    txtAlternateContact.Text = "";

                    break;
                case 3:
                    pnl1.Visible = false;
                    Pnl2.Visible = false;
                    Pnl3.Visible = true;
                    Pnl4.Visible = false;
                    pnlEmpty.Visible = false;
                    break;
                case 4:
                    pnl1.Visible = false;
                    Pnl2.Visible = false;
                    Pnl3.Visible = false;
                    Pnl4.Visible = true;
                    pnlEmpty.Visible = false;
                    break;
                default:
                    pnl1.Visible = false;
                    Pnl2.Visible = false;
                    Pnl3.Visible = false;
                    pnlEmpty.Visible = true;
                    break;
            }

        }

        protected void pnl1Continue_Click(object sender, EventArgs e)
        {
            ShowPanel(2);
        }

        protected void pnl2Previous_Click(object sender, EventArgs e)
        {
            ShowPanel(1);
        }

        protected void pnl2Continue_Click(object sender, EventArgs e)
        {
            ShowPanel(3);
        }

        protected void pnl3Continue_Click(object sender, EventArgs e)
        {
            PlaceOrder();
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
                if (ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
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
                        totalAmount += (Convert.ToInt32(dr["Quantity"]) * Convert.ToDecimal(dr["Price"]));
                        totalQty += Convert.ToInt32(dr["Quantity"]);
                        //TotalAmount = Convert.ToDouble(dr["Price"]);
                    }
                    totalProduct = ds.Tables[2].Rows.Count;
                }
                objCustomerOrderCls.totalAmount = totalAmount;
                objCustomerOrderCls.TotalProduct = totalProduct;
                objCustomerOrderCls.TotalQuantity = totalQty;
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
                keywordsToReplace.Add("##Vipul##", Name);
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

                if (! string.IsNullOrEmpty(res))
                {
                    lblOrderNo.Text = res;
                    this.Master.GetCartDetail();
                    ShowPanel(4);
                }



            }
        }

        protected void pnl3Previous_Click(object sender, EventArgs e)
        {
            ShowPanel(2);
        }

        protected void btnSelectAddress_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            Button btn = (Button)Master.FindControl("btn");
            UserDL objAdminCls = new UserDL();
            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
           
            CustomerAddress objCustomerAddress = new CustomerAddress();
            objCustomerAddress.idCustomer = idCustomer;
            objCustomerAddress.idCustomerAddress = 0;
            objCustomerAddress.sName = txtName.Text;
            objCustomerAddress.Mobile = txtMobile.Text;
            objCustomerAddress.PinCode = txtPinCode.Text;
            objCustomerAddress.sAddress1 = txtAddress1.Text;
            objCustomerAddress.sAddress2 = txtAddress2.Text;
            objCustomerAddress.sCity = txtCity.Text;
            objCustomerAddress.sState = txtState.Text;
            objCustomerAddress.sLandMark = txtLandmark.Text;
            objCustomerAddress.AddressType = rdbAddressType.SelectedValue;
            objCustomerAddress.AlternateNo = txtAlternateContact.Text;
            objCustomerAddress.CountryName = btn.Text;


            string str = objAdminCls.AddEditAddress(objCustomerAddress);
            GetCustomerCardDetail();
            ShowPanel(2);
        }

        protected void chkAddNewAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddNewAddress.Checked)
            {
                pnlNew.Visible = true;
            }
            else
            {
                pnlNew.Visible = false;
            }

        }

        protected void rptAddress_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Button btn = (Button)Master.FindControl("btn");
            Label lblAddress = e.Item.FindControl("lblAddress") as Label;
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            Label lblCountry = e.Item.FindControl("lblCountry") as Label;
            if (btn.Text == lblCountry.Text)
            {
                if (!string.IsNullOrEmpty(lblAddress.Text))
                {
                    if (e.CommandName == "Deliveraddress")
                    {
                        hdnidAddress.Value = hdn.Value;
                        ShowPanel(3);
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMsg.Text = "Order not deliver on selected address.";
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



                    //  ((Repeater)e.Item.FindControl("rptProductImage")).DataSource = ds.Tables[1];
                    //  ((Repeater)e.Item.FindControl("rptProductImage")).DataBind();
                    //  string categoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                    //  ((UCRelatedProduct)e.Item.FindControl("UCRelatedProduct1")).GetProductList(categoryName);
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
            var path = "";
            switch (mailType)
            {
                case "OrderPlace":
                    contentFilePath = Server.MapPath("HTMLMail/OrderPlace.html");
                    //StreamReader reader = File.OpenText(path);
                    //contentFilePath = "~/";
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