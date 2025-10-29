using DataLayer;
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
    public partial class wishlist : System.Web.UI.Page
    {
        public string baseUrl
        {
            get
            {
                return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["CustomerId"] != null)
                {
                    int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                    GetWishlistDetail();
                    //GetCustomerDetail(idCustomer);
                    // Dictionary<int, string> gender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToDictionary(x => (int)x, x => x.ToString());
                    //  rbGender.DataSource = gender;
                    // rbGender.DataTextField = "Value";
                    // rbGender.DataValueField = "Key";
                    // rbGender.DataBind();

                    //GetAllAddress(idCustomer);


                    string lnk = Convert.ToString(Page.RouteData.Values["link"]);
                    switch (lnk)
                    {
                        case "WishList":
                            //        ShoWPanel(4);
                            break;
                        case "Order":
                            //         ShoWPanel(3);
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }

        //private void GetAllAddress(int idCustomer)
        //{
        //    UserDL objUserDL = new UserDL();
        //    DataSet ds = objUserDL.GetAllAddress(idCustomer);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        rptAddress.DataSource = ds.Tables[0];
        //        rptAddress.DataBind();
        //    }
        //}

        //private void GetCustomerDetail(int idCustomer)
        //{
        //    UserDL objUserDL = new UserDL();
        //    DataSet ds = objUserDL.GetCustomerDetail(idCustomer);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
        //        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Gender"])))
        //            lblGender.Text = Enum.GetName(typeof(Gender), Convert.ToInt16(ds.Tables[0].Rows[0]["Gender"]));
        //        lblMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
        //        lblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
        //    }
        //}

        protected void rptWishlistProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnidProduct = e.Item.FindControl("hdnidProduct") as HiddenField;
            HiddenField hdnidCustomerCart = e.Item.FindControl("hdnidCustomerCart") as HiddenField;
            TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
            if (!string.IsNullOrEmpty(hdnidProduct.Value))
            {
                if (e.CommandName == "qtyUpdate")
                {
                    if (hdnidProduct != null)
                    {
                        Session["IdProduct"] = hdnidProduct.Value;
                        if (Session["CustomerId"] != null)
                        {
                            int qty = 1;
                            AddProductInCart(qty);
                            this.Master.GetCartDetail();
                        }
                        else
                        {
                            Response.Redirect("~/login.aspx");
                        }
                    }
                }
                if (e.CommandName == "qtyDelete")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                }
                GetWishlistDetail();
            }
        }

        private void GetWishlistDetail()
        {
            if (Session["CustomerId"] != null)
            {
                UserDL objAdminCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                //int idCustomer = 3;
                DataSet ds = objAdminCls.GetWishlistCart(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptWishlistProduct.DataSource = ds.Tables[0];
                    rptWishlistProduct.DataBind();
                    pnlEmpty.Visible = false;
                    PnlWishlist.Visible = true;
                }
                else
                {
                    rptWishlistProduct.DataSource = null;
                    rptWishlistProduct.DataBind();
                    pnlEmpty.Visible = true;
                    PnlWishlist.Visible = false;
                }
                this.Master.GetWishlistCount();
            }
            else
            {
                Response.Redirect("~/login.aspx");
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

                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Product added in your cart successfully.');", true);
            }
            else
            {

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

        protected void rptWishlistProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //DataSet dsColorAndSize = (DataSet)ViewState["ColorAndSize"];
                //if (dsColorAndSize != null)
                //{
                //    if (dsColorAndSize.Tables.Count > 0 && dsColorAndSize.Tables[0].Rows.Count > 0)
                //    {
                //        ((Repeater)e.Item.FindControl("rptColor")).DataSource = dsColorAndSize.Tables[0];
                //        ((Repeater)e.Item.FindControl("rptColor")).DataBind();
                //    }
                //    if (dsColorAndSize.Tables.Count > 1 && dsColorAndSize.Tables[1].Rows.Count > 0)
                //    {
                //        ((Repeater)e.Item.FindControl("rptSize")).DataSource = dsColorAndSize.Tables[1];
                //        ((Repeater)e.Item.FindControl("rptSize")).DataBind();
                //    }
                //}
            }
        }
    }
}