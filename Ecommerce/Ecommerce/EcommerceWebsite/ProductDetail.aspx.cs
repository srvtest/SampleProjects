using DataLayer;
using EcommerceWebsite;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        public String MainImage { get; set; }
        public String MainVideo { get; set; }
        //public String allRating { get; set; }
        public Int32 totalReview { get; set; }
        public decimal avgReview { get; set; }
        public Int32 rate1 { get; set; }
        public Int32 rate2 { get; set; }
        public Int32 rate3 { get; set; }
        public Int32 rate4 { get; set; }
        public Int32 rate5 { get; set; }
        List<ImageCls> lstImageCls = new List<ImageCls>();
        protected override void OnInit(EventArgs e)
        {

            GetProductDetail();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void GetProductDetail()
        {
            string sName = Convert.ToString(Page.RouteData.Values["productname"]);

            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetProductById(sName, idCountry, isB2B,0);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewState["ProductData"] = ds;
                if (ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    rptProduct.DataSource = ds.Tables[0];
                    rptProduct.DataBind();
                }
                //List<CustomerReview> lstCustomerReview = new List<CustomerReview>();
                //CustomerReview objCustomerReview = null;
                //if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                //    {
                //        objCustomerReview = new CustomerReview();
                //        objCustomerReview.starRating = Convert.ToDecimal(ds.Tables[2].Rows[i]["starRating"]);
                //        objCustomerReview.review = Convert.ToString(ds.Tables[2].Rows[i]["review"]);
                //        objCustomerReview.headline = Convert.ToString(ds.Tables[2].Rows[i]["headline"]);
                //        objCustomerReview.imageURL = Convert.ToString(ds.Tables[2].Rows[i]["imageURL"]);
                //        lstCustomerReview.Add(objCustomerReview);
                //    }
                //}
                //if (lstCustomerReview != null && lstCustomerReview.Count > 0)
                //{
                //    totalReview = lstCustomerReview.Count;
                //    avgReview = Convert.ToDecimal(lstCustomerReview.Average(x => x.starRating));
                //    rate1 = lstCustomerReview.Where(x => x.starRating == 1).ToList().Count();
                //    rate2 = lstCustomerReview.Where(x => x.starRating == 2).ToList().Count();
                //    rate3 = lstCustomerReview.Where(x => x.starRating == 3).ToList().Count();
                //    rate4 = lstCustomerReview.Where(x => x.starRating == 4).ToList().Count();
                //    rate5 = lstCustomerReview.Where(x => x.starRating == 5).ToList().Count();
                //    ImageCls objImageCls = null;
                    
                //    foreach (var item in lstCustomerReview)
                //    {
                //        objImageCls = new ImageCls();
                //        if (!string.IsNullOrEmpty(item.imageURL))
                //        {
                //            string[] images = item.imageURL.Split(new[] { "★" }, StringSplitOptions.RemoveEmptyEntries);
                //            for (int i = 0; i < images.Count(); i++)
                //            {
                //                lstImageCls.Add(new ImageCls() { Name = images[i], guid = Convert.ToString(Guid.NewGuid()) });
                //            }
                //        }
                //    }
                //    ((Repeater)rptProduct.FindControl("rptImages")).DataSource = lstImageCls;
                //    ((Repeater)rptProduct.FindControl("rptImages")).DataBind();
                //}
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

        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataSet ds = (DataSet)ViewState["ProductData"];
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    MainImage = Convert.ToString(ds.Tables[0].Rows[0]["ImageURL"]);
                    ((Repeater)e.Item.FindControl("rptProductImage")).DataSource = ds.Tables[1];
                    ((Repeater)e.Item.FindControl("rptProductImage")).DataBind();
                    string categoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                    ((UCRelatedProduct)e.Item.FindControl("UCRelatedProduct1")).GetProductList(categoryName);
                }
                //if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    //string Image = "";
                //    //Image = Convert.ToString(ds.Tables[1].Rows[0]["type"]);
                //    //if (Image == "image")
                //    //{
                //        MainImage = Convert.ToString(ds.Tables[1].Rows[0]["url"]);
                //        //MainImage = Convert.ToString(ds.Tables[1].Rows[2]["url"]);
                //        //MainImage = Convert.ToString(ds.Tables[1].Rows[3]["url"]);
                //    //}
                //    //if(Image == "video")
                //    //{
                //        //MainVideo = Convert.ToString(ds.Tables[1].Rows[0]["url"]);
                //    //}

                //    //((Repeater)e.Item.FindControl("rptProductImage")).DataSource = ds.Tables[1];

                //    ((Repeater)e.Item.FindControl("rptProductImage")).DataSource = ds.Tables[1];
                //    ((Repeater)e.Item.FindControl("rptProductImage")).DataBind();
                //    string categoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                //    ((UCRelatedProduct)e.Item.FindControl("UCRelatedProduct1")).GetProductList(categoryName);
                //}
            }
        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
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
                        Response.Redirect("../login");
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
                        
                        //int qty = 1;
                        AddProductInCart(Convert.ToInt32(tqty.Text));
                        this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("../login");
                    }
                }
            }
            else if (e.CommandName == "Review")
            {
                Session["IdProduct"] = hdn.Value;
                Response.Redirect("../CreateReview.aspx");
            }



            //Label lblsName = e.Item.FindControl("lblsName") as Label;
            //Label lblstatus = e.Item.FindControl("lblStatus") as Label;
            //HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            //if (!string.IsNullOrEmpty(lblsName.Text))
            // {
            //     if (e.CommandName == "CatEdit")
            //     {
            //     }
            // }
        }

        private void AddProductInCart( int Quantity)
        {
            UserDL objAdminCls = new UserDL();
            int idProduct= Convert.ToInt32(Session["IdProduct"]);
            int idCountry= GetCountryId();
            int isB2B=Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]); 

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

    }
}