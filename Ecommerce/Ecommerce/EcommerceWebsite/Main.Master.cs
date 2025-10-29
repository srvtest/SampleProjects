using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class Main : System.Web.UI.MasterPage
    {
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

        protected override void OnInit(EventArgs e)
        {
            GetCartDetail();
            GetAllMasterCategory();
            GetAllAdditionalLink();
            GetAllCountry();
            SetCookies();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                myAccount.InnerHtml = "<li class='account'><a href='../account'>My Account</a></li>";
                myAccount.InnerHtml += "<li class='account'><a href='../logout'>Logout</a></li>";
            }
            else
            {
                myAccount.InnerHtml = "<li class='account'><a href='../login'>Login</a></li>";
            }
            GetMasterPageById();
            //GetCartDetail();
            //GetAllCountry();
            if (!IsPostBack)
            {
                GetAllCountry();
                //string title = "Greetings";
                //string body = "Welcome to ASPSnippets.com";
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowPopup('" + title + "', '" + body + "');", true);
                // lblMsg.Text = "Password set successfully";
                // GetAllCategory();
                // GetAllAdditionalLink();
                // frmProduct.Style.Add("display", "none");
            }
            //<li class="account"><a href="../login">My Account</a></li>
        }

        private void GetAllMasterCategory()
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllMasterCategory();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                double count = (double)((decimal)ds.Tables[0].Rows.Count / 2);
                int catCount = (int)Math.Ceiling(count);
                rptCategory1.DataSource = ds.Tables[0];
                //rptCategory1.DataSource = ds.Tables[0].AsEnumerable().Skip(catCount * 0).Take(catCount).CopyToDataTable();
                rptCategory1.DataBind();
                //  rptCategory2.DataSource = ds.Tables[0].AsEnumerable().Skip(catCount * 1).Take(catCount).CopyToDataTable();
                //  rptCategory2.DataBind();
                //rptCategory3.DataSource = ds.Tables[0].AsEnumerable().Skip(catCount * 2).Take(catCount).CopyToDataTable();
                // rptCategory3.DataBind();
            }
        }

        public void SetCookies()
        {
            GetAllCountry();
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            if (Session["firstLoad"] == null)
            {
                Session["firstLoad"] = true;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "showshoppopup();", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "shownowpopup();", true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "showSubscribepopup();", true);
            }
           
            if (reqCookies == null)
            {
                HttpCookie userInfo = new HttpCookie("WebInfo");
                userInfo["idCountry"] = CommonControl.Encrypt("1");
                userInfo["CurrencySymbol"] = "Rs";
                userInfo.Expires.Add(new TimeSpan(20, 0, 0));
                Response.Cookies.Add(userInfo);
                hdnIdCountry.Value = "0";

            }
            else
            {
                ddlcountry.SelectedValue = CommonControl.Decrypt(reqCookies["idCountry"]);
                hdnIdCountry.Value = Convert.ToString(ddlcountry.SelectMethod);
                lblCountry.Text = Convert.ToString(ddlcountry.SelectedItem.Text);
                string country = Convert.ToString(ddlcountry.SelectedItem.Text);
                btn.Text = Convert.ToString(country);
                
            }
        }

        public void GetCartDetail()
        {
            hdnItemInCart.Value = "0";
            nTotalItems.InnerText = "0";
            if (Session["CustomerId"] != null)
            {
                UserDL objAdminCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                DataSet ds = objAdminCls.GetCustomerCart(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    hdnItemInCart.Value = Convert.ToString(ds.Tables[0].Rows.Count);
                    nTotalItems.InnerText = Convert.ToString(ds.Tables[0].Rows.Count);
                    rptProductes.DataSource = ds.Tables[0];
                    rptProductes.DataBind();
                    pnlEmpty.Visible = false;
                    rptProductes.Visible = true;
                    SubtotalAmount = 0;
                    ShipmentCharges = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                        double amount = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                        SubtotalAmount += (qty * amount);
                        ShipmentCharges += Convert.ToInt32(ds.Tables[0].Rows[i]["ShipmentCharges"]);
                    }
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
            //  ClearControls();
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
                }
                if (e.CommandName == "qtyDelete")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                }
                GetCartDetail();
            }
        }

        public void SetCountry(int idCountry)
        {
            ddlcountry.SelectedValue = Convert.ToString(idCountry);
            ddlcountry_SelectedIndexChanged(null, null);
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
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
                        hdnIdCountry.Value = Convert.ToString(ddlcountry.SelectedIndex);
                        if (hdnItemInCart.Value != "0")
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
            Response.Redirect("~/home");
        }

        private void GetMasterPageById()
        {
            string Id = hdnContactUsId.Value;
            //HiddenField hdnAboutUsId = e.Item.FindControl("hdnAboutUsId") as HiddenField;
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetMasterPageById(Convert.ToInt16(Id));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lstContactUs.DataSource = ds.Tables[0];
                lstContactUs.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SubscribeCls objSubscribeCls = new SubscribeCls();
            string sEmail = Convert.ToString(txtEmailId.Text);
            int bStatus = 1;
            SaveSubscribe(sEmail, bStatus);
        }
        private void SaveSubscribe(string sEmail, int bStatus)
        {
            UserDL objUserDL = new UserDL();
            string Response = objUserDL.SaveSubscribe(sEmail, bStatus);
            if (!string.IsNullOrEmpty(Response) && Response.ToUpper() == "SUCCESS")
            {
                hdMessage.Value += "Email saved successfully";
                lblMessage.Text = "Email saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {
                hdMessage.Value = "Email Already Exists";
                lblMessage.Text = Response;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            resetcontrol();
        }

        private void resetcontrol()
        {
            txtEmailId.Text = "";
        }

        protected void btnWomen_Click(object sender, EventArgs e)
        {

        }

        protected void btnMen_Click(object sender, EventArgs e)
        {

        }

        protected void lnkClickhere_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PrivacyPolicy");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string abc = txtSearch.Text;
            string[] username = abc.Split(' ');
            string search = abc.Trim();
            Response.Redirect("~/products/search="+ username[0]);
        }
        //protected void ddlCountry_SelectedIndexChanged1(object sender, EventArgs e)
        //{

        //}
    }
}