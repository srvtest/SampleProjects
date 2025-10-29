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
    public partial class index : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
        protected void Page_Load(object sender, EventArgs e)
        {
             //GetHomePageSlide();
            GetHomePageSlider(isB2B);
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
                pnlBlogs.Visible = true;
            }
            else
            {
                pnlBlogs.Visible = false;
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
        private void GetHomePageSlider(int IsB2B)
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetHomePageSlider(isB2B);
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
                ds = (DataSet)ViewState["HomePageProducts"];
            else
            {
                int idCustomer = !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))) : 0;
                ds = objUserCls.GetHomePageProduct(idCountry, isB2B, this.Master.NewProductDuration, idCustomer);
                ViewState["HomePageProducts"] = ds;
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                pnlNewArrival.Visible = false;
                pnlBestSeller.Visible = false;
                pnlFeatured.Visible = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptNewArrivals.DataSource = ds.Tables[0];
                    rptNewArrivals.DataBind();
                    pnlNewArrival.Visible = true;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    rptBestSeller.DataSource = ds.Tables[1];
                    rptBestSeller.DataBind();
                    pnlBestSeller.Visible = true;
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    rptFeatured.DataSource = ds.Tables[2];
                    rptFeatured.DataBind();
                    pnlFeatured.Visible = true;
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
            HiddenField hdn = e.Item.FindControl("hdnIdProduct") as HiddenField;
            if (e.CommandName == "WishAdd")
            {
                if (hdn != null)
                {
                    //txtQty
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        string response = this.Master.AddProductInWishList();
                        if (!string.IsNullOrEmpty(response))
                        {
                            string[] result = response.Split('?');
                            if (result != null && result.Count() == 2)
                            {
                                if (result[0].ToUpper() == "SUCCESS")
                                {
                                    this.Master.GetWishlistCount();
                                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','" + result[1] + "');", true);
                                    ViewState["HomePageProducts"] = null;
                                    GetHomePageProducts();
                                }
                                else
                                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','" + result[1] + "');", true);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx");
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
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Product added in your cart successfully.');", true);
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx");
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

        //private string AddProductInWishList()
        //{
        //    UserDL objAdminCls = new UserDL();
        //    int idProduct = Convert.ToInt32(Session["IdProduct"]);
        //    int idCountry = GetCountryId();
        //    int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

        //    int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
        //    string response = objAdminCls.SaveProductInWishlist(idProduct, idCountry, idCustomer, isB2B);
        //    return response;
        //}
        
        private void resetcontrol()
        {
            //txtEmail.Text = "";
        }

        protected void btnLearnMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products");
        }

        //protected void pnl_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        DataSet ds = (DataSet)ViewState["ColorAndSize"];
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            ((Repeater)e.Item.FindControl("rptColor")).DataSource = ds.Tables[0];
        //            ((Repeater)e.Item.FindControl("rptColor")).DataBind();
        //        }
        //    }
        //}
    }
}