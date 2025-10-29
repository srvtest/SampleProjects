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

namespace EcommerceWebsite2
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        public String MainImage { get; set; }
        public String MainVideo { get; set; }
        List<ImageCls> lstImageCls = new List<ImageCls>();
        string sCategory = string.Empty;

        protected override void OnInit(EventArgs e)
        {
            //int month = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf("December") + 1;
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
                    rptProduct.DataSource = ds.Tables[0];
                    rptProduct.DataBind();

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
            }
            ((Panel)e.Item.FindControl("pnlLogin")).Visible = Session["CustomerId"] == null;
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
                        AddProductInCart(Convert.ToInt32(hdnUpdatedQuantity.Value));
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
                        AddProductInCart(Convert.ToInt32(hdnUpdatedQuantity.Value));
                        this.Master.GetCartDetail();
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Product(s) added in your cart successfully.');", true);
                    }
                    else
                    {
                        Response.Redirect("../login.aspx");
                    }
                }
            }
        }

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
        }
    }
}