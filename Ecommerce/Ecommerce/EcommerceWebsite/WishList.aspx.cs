using DataLayer;
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
    public partial class WishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetWishlistDetail();
        }

        private void GetWishlistDetail()
        {
           // this.Master.GetWishlistDetail();
            if (Session["CustomerId"] != null)
            {
                UserDL objAdminCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                DataSet ds = objAdminCls.GetWishlistCart(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptWishlistProduct.DataSource = ds.Tables[0];
                    rptWishlistProduct.DataBind();
                    pnlEmpty.Visible = false;
                    PnlCart.Visible = true;
                   // SubtotalAmount = 0;
                   // ShipmentCharges = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                       // int qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                        //double amount = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                    //    SubtotalAmount += (qty * amount);
                   //     ShipmentCharges += Convert.ToInt32(ds.Tables[0].Rows[i]["ShipmentCharges"]);
                    }
                  //  totalAmount = SubtotalAmount + ShipmentCharges;

                }
                else
                {
                    pnlEmpty.Visible = true;
                    PnlCart.Visible = false;
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void rptWishlistProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnidProduct = e.Item.FindControl("hdnidProduct") as HiddenField;
            HiddenField hdnidCustomerCart = e.Item.FindControl("hdnidCustomerCart") as HiddenField;
            TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
            if (!string.IsNullOrEmpty(hdnidProduct.Value))
            {
                if (e.CommandName == "qtyUpdate")
                {
                    HiddenField hdn = e.Item.FindControl("hdnidProduct") as HiddenField;
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
                  //  UserDL objAdminCls = new UserDL();
                    //string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), Convert.ToInt32(txtQty.Text), "UPDATE");
                  //  string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                }
                if (e.CommandName == "qtyDelete")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteWishlist(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                }
                GetWishlistDetail();
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
    }
}