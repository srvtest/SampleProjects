using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsiteB2B
{
    public partial class index : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
        public string baseUrl
        {
            get
            {
                return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetHomePageSlide();
            GetHomePageSlider(isB2B);
            GetHomePageProducts();
            GetFeatureCategory();
            GetLatestBlogs(1, 5);
        }

        private void GetFeatureCategory()
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetFeatureCategory();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptFeatureCategory.DataSource = ds.Tables[0];
                rptFeatureCategory.DataBind();
                pnlFeatureCategory.Visible = true;
            }
            else
                pnlFeatureCategory.Visible = false;
        }

        private void GetLatestBlogs(int pageNum, int pageSize)
        {
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllBlogs(pageNum, pageSize);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                imgBlog.ImageUrl = DataLayer.CommonControl.GetImagesUrlAdmin() + "/blog/" + ds.Tables[1].Rows[0]["sPhoto"].ToString();
                lnkReadMore.NavigateUrl = this.Master.baseUrl + "blog/" + ds.Tables[1].Rows[0]["Name"].ToString();
                lblName.Text = ds.Tables[1].Rows[0]["Name"].ToString();
                lblDate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["CreatedDate"]).ToString("dd MMM yyyy");
                rptBlogs.DataSource = ds.Tables[1].AsEnumerable().Skip(1).Take(4).CopyToDataTable();
                rptBlogs.DataBind();
                pnlBlogs.Visible = true;
            }
            else
            {
                pnlBlogs.Visible = false;
            }
        }

        //private void GetHomePageSlide()
        //{
        //    UserDL objUserCls = new UserDL();
        //    DataSet ds = objUserCls.GetHomePageSlide();
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        pgBanner.DataSource = ds.Tables[0];
        //        pgBanner.DataBind();
        //    }
        //}
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
                pnlNewArrivels.Visible = false;
                pnlBestSeller.Visible = false;
                pnlFeatured.Visible = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptNewArrivels.DataSource = ds.Tables[0];
                    rptNewArrivels.DataBind();
                    pnlNewArrivels.Visible = true;
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

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
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
    }
}