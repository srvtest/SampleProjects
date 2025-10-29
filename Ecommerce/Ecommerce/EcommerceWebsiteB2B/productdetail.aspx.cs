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
    public partial class productdetail : System.Web.UI.Page
    {
        public String MainImage { get; set; }
        public String MainVideo { get; set; }
        List<ImageCls> lstImageCls = new List<ImageCls>();
        string sCategory = string.Empty;

        protected override void OnInit(EventArgs e)
        {
            GetProductDetail();
            GetRelatedProducts();
        }

        private void GetRelatedProducts()
        {
            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
            int pageSize = Convert.ToInt32(10);
            int pageNo = Convert.ToInt32(1);
            UserDL objUserCls = new UserDL();
            int idCustomer = !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))) : 0;
            DataSet ds = objUserCls.GetAllProductByCategory(sCategory, idCountry, isB2B, pageSize, pageNo, "", "", idCustomer);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                rptRelated.DataSource = ds.Tables[1];
                rptRelated.DataBind();
                pnlRelatedProduct.Visible = true;
            }
            else
            {
                pnlRelatedProduct.Visible = false;
            }


            //UserDL objUserCls = new UserDL();
            //int idCountry = GetCountryId();
            //int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
            //DataSet ds = new DataSet();
            //if (ViewState["HomePageProducts"] != null)
            //    ds = (DataSet)ViewState["HomePageProducts"];
            //else
            //{
            //    ds = objUserCls.GetHomePageProduct(idCountry, isB2B);
            //    ViewState["HomePageProducts"] = ds;
            //}
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    ViewState["ColorAndSize"] = this.Master.GetColorAndSize();
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        pnlNewArrivals.DataSource = ds.Tables[0];
            //        pnlNewArrivals.DataBind();
            //    }
            //    if (ds.Tables[1].Rows.Count > 0)
            //    {
            //        pnlBestSeller.DataSource = ds.Tables[1];
            //        pnlBestSeller.DataBind();
            //    }
            //    if (ds.Tables[2].Rows.Count > 0)
            //    {
            //        pnlFeatured.DataSource = ds.Tables[2];
            //        pnlFeatured.DataBind();
            //    }
            //}
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
            int idCustomer = !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))) : 0;
            DataSet ds = objUserCls.GetProductById(sName, idCountry, isB2B, idCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                sCategory = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                hdnIdpro.Value = Convert.ToString(ds.Tables[0].Rows[0]["idProduct"]);
                ViewState["ProductData"] = ds;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //ViewState["ColorAndSize"] = this.Master.GetColorAndSize();
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

        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataSet ds = (DataSet)ViewState["ProductData"];
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    (e.Item.FindControl("lblDescription") as Label).Text = ds.Tables[0].Rows[0]["Features"].ToString();

                    MainImage = Convert.ToString(ds.Tables[0].Rows[0]["ImageURL"]);
                    ((Repeater)e.Item.FindControl("rptProductImage")).DataSource = ds.Tables[1];
                    ((Repeater)e.Item.FindControl("rptProductImage")).DataBind();
                    ((Repeater)e.Item.FindControl("rptProductImages")).DataSource = ds.Tables[1];
                    ((Repeater)e.Item.FindControl("rptProductImages")).DataBind();
                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        string idCustomer = Convert.ToString(Session["CustomerId"]);
                        if (!string.IsNullOrEmpty(idCustomer))
                        {
                            var customerReview = ds.Tables[2].AsEnumerable()
                                        .Select(dataRow => new CustomerReview
                                        {
                                            headline = dataRow.Field<string>("headline"),
                                            review = dataRow.Field<string>("review"),
                                            starRating = dataRow.Field<decimal>("starRating"),
                                            idProduct = dataRow.Field<int>("idProduct"),
                                            idCustomer = dataRow.Field<int>("idCustomer"),
                                            imageURL = dataRow.Field<string>("imageURL")
                                        }).ToList().Exists(x => x.idCustomer == Convert.ToInt32(CommonControl.Decrypt(idCustomer)));

                            //.ToList().Where(x => x.idCustomer == Convert.ToInt32(CommonControl.Decrypt(idCustomer))
                            //                && x.idProduct == Convert.ToInt32(ds.Tables[0].Rows[0]["idProduct"])).FirstOrDefault();
                            //if (customerReview != null)
                            //{
                            //    (e.Item.FindControl("txtHeadline") as TextBox).Text = customerReview.headline;
                            //    (e.Item.FindControl("txtReview") as TextBox).Text = customerReview.review;
                            //    (e.Item.FindControl("rblRating") as RadioButtonList).SelectedValue = Convert.ToString(customerReview.starRating);
                            //}
                            ((Panel)e.Item.FindControl("pnlReviewNew")).Visible = !customerReview;
                        }
                        else
                            ((Panel)e.Item.FindControl("pnlReviewNew")).Visible = Session["CustomerId"] != null;
                        ((Repeater)e.Item.FindControl("rptReviews")).DataSource = ds.Tables[2];
                        ((Repeater)e.Item.FindControl("rptReviews")).DataBind();
                    }
                    else
                    {
                        ((Panel)e.Item.FindControl("pnlReviewNew")).Visible = Session["CustomerId"] != null;
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        ((Repeater)e.Item.FindControl("rptSimilarProduct")).DataSource = ds.Tables[3];
                        ((Repeater)e.Item.FindControl("rptSimilarProduct")).DataBind();
                    }
                }
                //DataSet dsColorAndSize = (DataSet)ViewState["ColorAndSize"];
                //if (dsColorAndSize != null)
                //{
                //    if (dsColorAndSize.Tables.Count > 0 && dsColorAndSize.Tables[0].Rows.Count > 0)
                //    {
                //        var colors = dsColorAndSize.Tables[0].AsEnumerable().Select(s => s.Field<string>("sName")).ToArray();
                //        string allColors = string.Join(", ", colors);
                //        (e.Item.FindControl("lblColors") as Label).Text = allColors;
                //        ((Repeater)e.Item.FindControl("rptColor")).DataSource = dsColorAndSize.Tables[0];
                //        ((Repeater)e.Item.FindControl("rptColor")).DataBind();
                //    }
                //    if (dsColorAndSize.Tables.Count > 1 && dsColorAndSize.Tables[1].Rows.Count > 0)
                //    {
                //        var sizes = dsColorAndSize.Tables[1].AsEnumerable().Select(s => s.Field<string>("sName")).ToArray();
                //        string allSizes = string.Join(", ", sizes);
                //        (e.Item.FindControl("lblSizes") as Label).Text = allSizes;
                //        ((Repeater)e.Item.FindControl("rptSize")).DataSource = dsColorAndSize.Tables[1];
                //        ((Repeater)e.Item.FindControl("rptSize")).DataBind();
                //    }
                //}
            }
            if (Session["CustomerId"] == null)
            {
                ((Panel)e.Item.FindControl("pnlLogin")).Visible = true;
               // ((Panel)e.Item.FindControl("pnlReview")).Visible = false;
            }
            else
            {
                ((Panel)e.Item.FindControl("pnlLogin")).Visible = false;
               // ((Panel)e.Item.FindControl("pnlReview")).Visible = true;
            }
        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            Label lblFeatures = e.Item.FindControl("lblFeatures") as Label;
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
            if (e.CommandName == "WishAdd")
            {
                if (hdn != null)
                {
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
                                    GetProductDetail();
                                }
                                else
                                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','" + result[1] + "');", true);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("../login.aspx");
                    }
                }
            }
            else if (e.CommandName == "CrtAdd")
            {
                if (hdn != null)
                {
                    Session["IdProduct"] = hdn.Value;
                    if (Session["CustomerId"] != null)
                    {
                        HiddenField hdnQty = e.Item.FindControl("hdnQty") as HiddenField;
                        AddProductInCart(Convert.ToInt32(hdnQty.Value));
                        this.Master.GetCartDetail();
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Product(s) added in your cart successfully.');", true);
                    }
                    else
                    {
                        Response.Redirect("../login.aspx");
                    }
                }
            }
            else if (e.CommandName == "Review")
            {
                TextBox txtHeadline = e.Item.FindControl("txtHeadline") as TextBox;
                TextBox txtReview = e.Item.FindControl("txtReview") as TextBox;
                RadioButtonList rblRating = (RadioButtonList)e.Item.FindControl("rblRating");
                UserDL objUserCls = new UserDL();
                CustomerReview objCustomerReview = new CustomerReview();
                string idCustomer = Convert.ToString(Session["CustomerId"]);
                if (!string.IsNullOrEmpty(idCustomer) && !string.IsNullOrEmpty(hdn.Value))
                {
                    objCustomerReview.idProduct = Convert.ToInt32(hdn.Value);
                    objCustomerReview.idCustomer = Convert.ToInt32(CommonControl.Decrypt(idCustomer));
                    objCustomerReview.imageURL = "";
                    objCustomerReview.review = txtReview.Text;
                    objCustomerReview.starRating = Convert.ToDecimal(rblRating.SelectedValue);
                    objCustomerReview.headline = txtHeadline.Text;

                    int response = objUserCls.InsertUpdateReview(objCustomerReview);
                    if (response > 0)
                    {
                        GetProductDetail();
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Review saved successfully.');", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Your review did not save.');", true);
                    }
                }
                else
                {
                    Response.Redirect("../login.aspx");
                }
            }
            else if (e.CommandName == "SimilarProduct")
            {

            }
            else if (e.CommandName == "Readmore")
            {
                lnkread.Text = (lnkread.Text == "Read More") ? "Hide" : "Read More";
                string temp = lblFeatures.Text;
                lblFeatures.Text = lblFeatures.ToolTip;
                lblFeatures.ToolTip = temp;
            }
        }

        protected void pnl_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //HiddenField hdn = e.Item.FindControl("hdnIdProduct") as HiddenField;
            if (e.CommandName == "WishAdd")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(e.CommandArgument)))
                {
                    Session["IdProduct"] = Convert.ToString(e.CommandArgument);
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
                                    GetRelatedProducts();
                                }
                                else
                                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','" + result[1] + "');", true);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("../login.aspx");
                    }
                }
            }
            else if (e.CommandName == "CrtAdd")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(e.CommandArgument)))
                {
                    Session["IdProduct"] = Convert.ToString(e.CommandArgument);
                    if (Session["CustomerId"] != null)
                    {
                        AddProductInCart(1);
                        this.Master.GetCartDetail();
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Product(s) added in your cart successfully.');", true);
                    }
                    else
                    {
                        Response.Redirect("../login.aspx");
                    }
                }
            }
            //else if (e.CommandName == "Review")
            //{
            //    Session["IdProduct"] = hdn.Value;
            //    Response.Redirect("../CreateReview.aspx");
            //}
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

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }

        protected void btnProduct_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgButton = sender as ImageButton;
            Response.Redirect("../productdetail/" + imgButton.ToolTip);
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

        protected void rptReviews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.Parent.Parent.FindControl("hdnId") as HiddenField;
            if (e.CommandName == "Review")
            {
                TextBox txtHeadline = e.Item.FindControl("txtHeadline") as TextBox;
                TextBox txtReview = e.Item.FindControl("txtReview") as TextBox;
                RadioButtonList rblRating = (RadioButtonList)e.Item.FindControl("rblRating");
                UserDL objUserCls = new UserDL();
                CustomerReview objCustomerReview = new CustomerReview();
                string idCustomer = Convert.ToString(Session["CustomerId"]);
                if (!string.IsNullOrEmpty(idCustomer) && !string.IsNullOrEmpty(hdn.Value))
                {
                    objCustomerReview.idProduct = Convert.ToInt32(hdn.Value);
                    objCustomerReview.idCustomer = Convert.ToInt32(CommonControl.Decrypt(idCustomer));
                    objCustomerReview.imageURL = "";
                    objCustomerReview.review = txtReview.Text;
                    objCustomerReview.starRating = Convert.ToDecimal(rblRating.SelectedValue);
                    objCustomerReview.headline = txtHeadline.Text;

                    int response = objUserCls.InsertUpdateReview(objCustomerReview);
                    if (response > 0)
                    {
                        GetProductDetail();
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Review saved successfully.');", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Your review did not save.');", true);
                    }
                }
                else
                {
                    Response.Redirect("../login.aspx");
                }
            }
            //Response.Redirect(Request.RawUrl);
        }
    }
}