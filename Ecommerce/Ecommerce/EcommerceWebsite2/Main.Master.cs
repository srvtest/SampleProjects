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

namespace EcommerceWebsite2
{
    public partial class Main : System.Web.UI.MasterPage
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        public string CurrencySymbol
        {
            get
            {
                HttpCookie reqCookies = Request.Cookies["WebInfo"];
                string value = string.Empty;
                if (reqCookies != null)
                {
                    if (reqCookies["CurrencySymbol"] != null && !string.IsNullOrEmpty(Convert.ToString(reqCookies["CurrencySymbol"])))
                    {
                        value = reqCookies["CurrencySymbol"];
                    }
                    else
                    {
                        reqCookies["CurrencySymbol"] = "Rs";
                        reqCookies.Expires.Add(new TimeSpan(20, 0, 0));
                        Response.Cookies.Add(reqCookies);
                    }
                }
                return value;
            }
            set
            {
                ViewState["CurrencySymbol"] = value;
            }
        }

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

        public int NewProductDuration
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["NewProductDuration"]);
            }
        }

        public string sContactTitle;
        public double freeShippingAmount = 0;
        public int freeShippingCount = 0;
        public int productCount = 0;

        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                GetWishlistCount();
                GetCartDetail();
                GetAllMasterCategory();
                GetAllAdditionalLink();
                GetAllCountry();
                SetCookies();
            }
        }

        public string AddProductInWishList()
        {
            UserDL objAdminCls = new UserDL();
            int idProduct = Convert.ToInt32(Session["IdProduct"]);
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            string response = objAdminCls.SaveProductInWishlist(idProduct, idCountry, idCustomer, isB2B);
            return response;
        }

        public List<int> GetWishlistCount()
        {
            List<int> idWishlist = new List<int>();
            if (Session["CustomerId"] != null)
            {
                UserDL objUserCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                DataSet ds = objUserCls.GetWishlistCart(idCustomer);
                if (ds != null && ds.Tables != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        idWishlist.Add(Convert.ToInt32(ds.Tables[0].Rows[i]["idWishList"]));
                    }
                    nCountWishlist.InnerText = Convert.ToString(ds.Tables[0].Rows.Count);
                    nCountWishlistMobile.InnerText = Convert.ToString(ds.Tables[0].Rows.Count);
                    hdnWishListInCart.Value = nCountWishlist.InnerText;
                }
                else
                {
                    nCountWishlist.InnerText = "0";
                    nCountWishlistMobile.InnerText = "0";
                    hdnWishListInCart.Value = "0";
                }
            }
            else
            {
                nCountWishlist.InnerText = "0";
                nCountWishlistMobile.InnerText = "0";
                hdnWishListInCart.Value = "0";
            }
            return idWishlist;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "load", "ShowProgress();", true);
            //if (Session["CustomerId"] != null)
            //{
            //    //myAccount.InnerHtml = "<li class='account'><a href='../account'>My Account</a></li>";
            //    //myAccount.InnerHtml += "<li class='account'><a href='../logout'>Logout</a></li>";
            //}
            //else
            //{
            //    //myAccount.InnerHtml = "<li class='account'><a href='../login'>Login</a></li>";
            //}
            GetMasterPageById();
            //GetCartDetail();
            //GetAllCountry();
            if (!IsPostBack)
            {
                GetAllCountry();
            }
            //string sName = Convert.ToString(Page.RouteData.Values["mastercategoryname"]);
            //if (sName.Contains("search="))
            //{
            //    string sText = sName.Replace("search=", "");
            //    txtSearch.Text = sText;
            //}
        }

        private void GetAllMasterCategory()
        {
            UserDL objUserCls = new UserDL();
            //DataSet ds = objUserCls.GetAllMasterCategory();
            DataSet ds = objUserCls.GetAllCategory();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                double count = (double)((decimal)ds.Tables[0].Rows.Count / 2);
                int catCount = (int)Math.Ceiling(count);
                rptMainCategory.DataSource = ds.Tables[0];
                rptMainCategory.DataBind();
                rptMainCategoryMobile.DataSource = ds.Tables[0];
                rptMainCategoryMobile.DataBind();
            }
        }

        public void SetCookies()
        {
            GetAllCountry();
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            //if (Session["firstLoad"] == null)
            //{
            //    Session["firstLoad"] = true;
            //    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "showshoppopup();", true);
            //}

            if (reqCookies == null)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "showshoppopup();", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "shownowpopup();", true);
                HttpCookie userInfo = new HttpCookie("WebInfo");
                userInfo["idCountry"] = CommonControl.Encrypt("1");
                userInfo["CurrencySymbol"] = "Rs";
                userInfo.Expires.Add(new TimeSpan(20, 0, 0));
                Response.Cookies.Add(userInfo);
                hdnIdCountry.Value = Convert.ToString(ddlcountry.SelectedValue);
                lblCountry.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
                lblCountryName.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
                lblCountryNameMobile.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
            }
            else
            {
                ddlcountry.SelectedValue = CommonControl.Decrypt(reqCookies["idCountry"]);
                hdnIdCountry.Value = Convert.ToString(ddlcountry.SelectedValue);
                lblCountry.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
                string country = Convert.ToString(ddlcountry.SelectedItem.Text);
                lblCountryName.Text = Convert.ToString(country);
                lblCountryNameMobile.Text= Convert.ToString(country);

            }
        }

        public void GetCartDetail()
        {
            hdnItemInCart.Value = "0";
            //hdnWishListInCart.Value = "0";
            nTotalItems.InnerText = "0";
            nTotalItemsMobile.InnerText = "0";
            if (Session["CustomerId"] != null)
            {
                UserDL objAdminCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                DataSet ds = objAdminCls.GetCustomerCart(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    hdnItemInCart.Value = Convert.ToString(ds.Tables[0].Compute("Sum(Quantity)", string.Empty));
                    nTotalItems.InnerText = hdnItemInCart.Value;
                    nTotalItemsMobile.InnerText = hdnItemInCart.Value;
                    rptProductes.DataSource = ds.Tables[0];
                    rptProductes.DataBind();
                    pnlEmpty.Visible = false;
                    rptProductes.Visible = true;
                    SubtotalAmount = 0;
                    ShipmentCharges = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        productCount++;
                        int qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                        double amount = Convert.ToInt32(ds.Tables[0].Rows[i]["price"]);
                        SubtotalAmount += (qty * amount);
                        ShipmentCharges += Convert.ToInt32(ds.Tables[0].Rows[i]["ShipmentCharges"]);
                    }


                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        List<ConfigCls> lstConfig = ds.Tables[1].AsEnumerable()
                                .Select(dataRow => new ConfigCls
                                {
                                    idConfig = dataRow.Field<int>("idConfig"),
                                    sValue = dataRow.Field<string>("sValue")
                                }).ToList();
                        freeShippingAmount = Convert.ToDouble(lstConfig.Where(x => x.idConfig == 1).Select(x => x.sValue).FirstOrDefault());
                        freeShippingCount = Convert.ToInt32(lstConfig.Where(x => x.idConfig == 3).Select(x => x.sValue).FirstOrDefault());
                    }
                    if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                        totalAmount = SubtotalAmount;
                    else
                        totalAmount = SubtotalAmount + ShipmentCharges;
                }
                else
                {
                    pnlEmpty.Visible = true;
                    rptProductes.Visible = false;
                }
            }
        }

        private void GetAllAdditionalLink()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllAdditionalLink();
            lstAdditionalLink.DataSource = ds.Tables[0];
            lstAdditionalLink.DataBind();
            ////  ClearControls();
        }

        private void GetAllCountry()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetCountry();
            ddlcountry.DataSource = ds.Tables[0];
            ddlcountry.DataTextField = "sName";
            ddlcountry.DataValueField = "idCountry";
            ddlcountry.DataBind();
            ViewState["CountryDetail"] = ds;
            //ClearControls();
        }

        protected void lstAdditionalLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink lnkDetails = e.Item.FindControl("lnkDetails") as HyperLink;
            }
        }

        protected void rptProductes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnidProduct = e.Item.FindControl("hdnidProduct") as HiddenField;
            HiddenField hdnidCustomerCart = e.Item.FindControl("hdnidCustomerCart") as HiddenField;
            TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
            if (!string.IsNullOrEmpty(hdnidProduct.Value))
            {
                if (e.CommandName == "qtyUpdate")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), Convert.ToInt32(txtQty.Text), "UPDATE");
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowCart();", true);
                }
                if (e.CommandName == "qtyDelete")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowCart();", true);
                }
                if (!string.IsNullOrEmpty(Request.Url.PathAndQuery) && Request.Url.PathAndQuery.ToUpper().Equals("/CHECKOUT"))
                {
                    Response.Redirect("/cart.aspx");
                }
                else if (!string.IsNullOrEmpty(Request.Url.PathAndQuery) && Request.Url.PathAndQuery.ToUpper().Equals("/CART"))
                {
                    Response.Redirect(Request.Url.PathAndQuery);
                }
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowCart();", true);
                GetCartDetail();
            }
        }

        public void SetCountry(int idCountry)
        {
            ddlcountry.SelectedValue = Convert.ToString(idCountry);
            CountryChange(true);
        }

        protected void CountryChange(bool bChange = false)
        {
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            if (reqCookies != null)
            {
                DataSet ds = (DataSet)ViewState["CountryDetail"];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[i]["idCountry"]) == ddlcountry.SelectedValue)
                    {
                        HttpContext.Current.Request.Cookies.Remove("WebInfo");
                        HttpCookie userInfo = new HttpCookie("WebInfo");
                        userInfo["idCountry"] = CommonControl.Encrypt(ddlcountry.SelectedValue);
                        userInfo["CurrencySymbol"] = Convert.ToString(ds.Tables[0].Rows[i]["sNameCurrency"]);
                        userInfo.Expires.Add(new TimeSpan(20, 0, 0));
                        Response.Cookies.Add(userInfo);
                        hdnIdCountry.Value = Convert.ToString(ddlcountry.SelectedValue);
                        lblCountry.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
                        lblCountryName.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
                        if (nTotalItems.InnerText != "0" || nCountWishlist.InnerText != "0")
                        {
                            if (Session["CustomerId"] != null)
                            {
                                UserDL objAdminCls = new UserDL();
                                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                                string responce = objAdminCls.UpdateCustomerCountry(idCustomer);
                            }
                        }
                    }
                }
            }
            if (bChange)
                Response.Redirect("~/index");
        }

        private void GetMasterPageById()
        {
            string Id = hdnContactUsId.Value;
            //HiddenField hdnAboutUsId = e.Item.FindControl("hdnAboutUsId") as HiddenField;
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetMasterPageById(Convert.ToInt16(Id));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                sContactTitle = Convert.ToString(ds.Tables[0].Rows[0]["sMasterPage"]);
                lstContactUs.DataSource = ds.Tables[0];
                lstContactUs.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (hdnIdCountry.Value != ddlcountry.SelectedValue)
            {
                CountryChange();
                Response.Redirect("~/");
            }
            else
                Response.Redirect("~/Products");
        }

        protected void btnShowNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            // SetCookies();
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "shownowpopup();", true);
        }

        private string SaveSubscribe(string sEmail, int bStatus)
        {
            UserDL objUserDL = new UserDL();
            string Response = objUserDL.SaveSubscribe(sEmail, bStatus);
            if (Response != "Email Already Exist")
            {
                DataSet ds = objUserDL.GetAllClientMaster(GetCountryId());
                string host = "", fromMail = "", password = "";
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    host = Convert.ToString(ds.Tables[0].Rows[0]["host"]);
                    fromMail = Convert.ToString(ds.Tables[0].Rows[0]["fromEmail"]);
                    password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                }

                if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(fromMail) && !string.IsNullOrEmpty(password))
                {
                    string emailTo = sEmail;
                    string subject = "Subscribe";

                    // Code to send mail
                    string link = string.Empty;
                    //link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>");
                    keywordsToReplace.Add("##Name##", emailTo);

                    string body = GenrateMail("Subscribe");
                    CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                }
            }
            else
            {

            }
            if (!string.IsNullOrEmpty(Response) && Response.ToUpper() == "SUCCESS")
            {
                //hdMessage.Value += "Email saved successfully";
                //lblMessage.Text = "Email saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {
                //hdMessage.Value = "Email Already Exists";
                //lblMessage.Text = Response;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            return Response;
        }

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            switch (mailType)
            {
                case "Subscribe":
                    contentFilePath = Server.MapPath("HTMLMail/EmailSubscription.html");
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

        protected void lnkClickhere_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PrivacyPolicy");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string result = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(result))
            {
                Response.Redirect("~/products/search=" + result);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SubscribeEmail(txtEmail.Text.Trim());
        }

        public void SubscribeEmail(string sEmail)
        {
            int bStatus = 1;
            if (!string.IsNullOrEmpty(sEmail))
            {
                string response = SaveSubscribe(sEmail, bStatus);
                if (!string.IsNullOrEmpty(response) && response.ToUpper().Equals("SUCCESS"))
                {
                    lblMessage.Text = "You subscribe successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtEmail.Text = string.Empty;
                }
                else
                {
                    lblMessage.Text = response;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}