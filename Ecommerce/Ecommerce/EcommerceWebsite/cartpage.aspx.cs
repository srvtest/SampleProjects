using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class cartpage : System.Web.UI.Page
    {
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void GetCartDetail()
        {
            this.Master.GetCartDetail();
            if (Session["CustomerId"] != null)
            {
                UserDL objAdminCls = new UserDL();
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                DataSet ds = objAdminCls.GetCustomerCart(idCustomer);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptCartProduct.DataSource = ds.Tables[0];
                    rptCartProduct.DataBind();
                    pnlEmpty.Visible = false;
                    PnlCart.Visible = true;
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
                    PnlCart.Visible = false;
                }

            }
            else
            {
                Response.Redirect("Login.aspx"); 
            }

        }

        protected void rptCartProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnidProduct = e.Item.FindControl("hdnidProduct") as HiddenField;
            HiddenField hdnidCustomerCart = e.Item.FindControl("hdnidCustomerCart") as HiddenField;
            TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
            if (!string.IsNullOrEmpty(hdnidProduct.Value))
            {
                if (e.CommandName == "qtyUpdate")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce= objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), Convert.ToInt32(txtQty.Text), "UPDATE");
                }
                if (e.CommandName == "qtyDelete")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                }
                GetCartDetail();
            }
        }
    }
}