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
    public partial class index : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetHomePageSlide();
            GetHomePageProducts();
            GetLatestBlogs(1, 10);
        }

        private void GetLatestBlogs(int pageNum, int pageSize)
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllBlogs(pageNum, pageSize);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                rptBlogs.DataSource = ds.Tables[1];
                rptBlogs.DataBind();
            }
        }

        private void GetHomePageSlide()
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetHomePageSlide();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                pgBanner.DataSource = ds.Tables[0];
                pgBanner.DataBind();
            }
        }

        private void GetHomePageProducts()
        {
            UserDL objUserCls = new UserDL();
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
            DataSet ds = new DataSet();
            if (ViewState["HomePageProducts"] != null)
                ds = (DataSet)ViewState["PreviousPage"];
            else
            {
                ds = objUserCls.GetHomePageProduct(idCountry, isB2B,30,0);
                ViewState["HomePageProducts"] = ds;
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlnArrivals.DataSource = ds.Tables[0];
                    pnlnArrivals.DataBind();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    pnlBestSeller.DataSource = ds.Tables[1];
                    pnlBestSeller.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    pnlFeatured.DataSource = ds.Tables[2];
                    pnlFeatured.DataBind();
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

        protected void pnl_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            if (e.CommandName == "WishAdd")
            {
                if (hdn != null)
                {
                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInWishList();
                        //this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("~/login");
                    }
                }
            }
            else if (e.CommandName == "CrtAdd")
            {
                if (hdn != null)
                {

                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInCart(qty);
                        this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("login");
                    }
                }
            }
        }

        protected void pnlBestSeller_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            if (e.CommandName == "WishAdd")
            {
                if (hdn != null)
                {
                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInWishList();
                        //this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("login");
                    }
                }
            }
            else if (e.CommandName == "CrtAdd")
            {
                if (hdn != null)
                {

                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInCart(qty);
                        this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("login");
                    }
                }
            }
        }

        protected void pnlFeatured_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            if (e.CommandName == "WishAdd")
            {
                if (hdn != null)
                {
                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInWishList();
                        //this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("login");
                    }
                }
            }
            else if (e.CommandName == "CrtAdd")
            {
                if (hdn != null)
                {

                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInCart(qty);
                        this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("login");
                    }
                }
            }
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

        private void AddProductInWishList()
        {
            UserDL objAdminCls = new UserDL();
            int idProduct = Convert.ToInt32(Session["IdProduct"]);
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            string Response = objAdminCls.SaveProductInWishlist(idProduct, idCountry, idCustomer, isB2B);
            if (!string.IsNullOrEmpty(Response) && Response.ToUpper() == "SUCCESS")
            {

            }
            else
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //resetcontrol();
            SubscribeCls objSubscribeCls = new SubscribeCls();
            string sEmail = Convert.ToString(txtEmail.Text);
            int bStatus = 1;

            SaveSubscribe(sEmail, bStatus);
        }

        private void SaveSubscribe(string sEmail, int bStatus)
        {
            UserDL objUserDL = new UserDL();
            string Response = objUserDL.SaveSubscribe(sEmail, bStatus);

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
                keywordsToReplace.Add("##Vipul##", emailTo);

                string body = GenrateMail("Subscribe");
                CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
            }

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
            txtEmail.Text = "";
        }

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            var path = "";
            switch (mailType)
            {
                case "Subscribe":
                    contentFilePath = Server.MapPath("HTMLMail/EmailSubscription.html");
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