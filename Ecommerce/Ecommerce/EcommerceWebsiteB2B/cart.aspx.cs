using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsiteB2B
{
    public partial class cart : System.Web.UI.Page
    {
        UserDL objAdminCls = new UserDL();
        public double freeShippingAmount = 0;
        public int freeShippingCount = 0;
        public int productCount = 0;
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
        public string baseUrl
        {
            get
            {
                return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
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
            //if (!IsPostBack)
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
                        productCount++;
                        int qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                        double amount = Convert.ToInt32(ds.Tables[0].Rows[i]["Price"]);
                        SubtotalAmount += (qty * amount);
                        ShipmentCharges += Convert.ToInt32(ds.Tables[0].Rows[i]["ShipmentCharges"]);
                    }

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        List<ConfigCls> lstConfig = ds.Tables[1].AsEnumerable()
                                .Select(dataRow => new ConfigCls
                                {
                                    idConfig = dataRow.Field<int>("idConfig"),
                                    sValue = dataRow.Field<string>("sValue")
                                }).ToList();
                        freeShippingAmount = Convert.ToDouble(lstConfig.Where(x => x.idConfig == 1).Select(x => x.sValue).FirstOrDefault());
                        freeShippingCount = Convert.ToInt32(lstConfig.Where(x => x.idConfig == 3).Select(x => x.sValue).FirstOrDefault());
                    }
                    if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                        totalAmount = SubtotalAmount;
                    else
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
                Response.Redirect("~/login.aspx");
            }
        }

        protected void rptCartProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnidProduct = e.Item.FindControl("hdnidProduct") as HiddenField;
            HiddenField hdnidCustomerCart = e.Item.FindControl("hdnidCustomerCart") as HiddenField;
            TextBox txtQty = e.Item.FindControl("txtQty") as TextBox;
            HiddenField hdnQty = e.Item.FindControl("hdnQty") as HiddenField;
            if (!string.IsNullOrEmpty(hdnidProduct.Value))
            {
                if (e.CommandName == "qtyUpdate")
                {
                    UserDL objAdminCls = new UserDL();
                    //string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), Convert.ToInt32(txtQty.Text), "UPDATE");
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), Convert.ToInt32(hdnQty.Value), "UPDATE");
                }
                if (e.CommandName == "qtyDelete")
                {
                    UserDL objAdminCls = new UserDL();
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(hdnidCustomerCart.Value), 0, "DELETE");
                }
                GetCartDetail();
            }
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            string sVal = hdnCartUpdate.Value;
            if (!string.IsNullOrEmpty(sVal))
            {
                string[] newVal = sVal.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < newVal.Count(); i++)
                {
                    string idCustomerCart = newVal[i].Split('♠')[0];
                    string quantity = newVal[i].Split('♠')[1];
                    string responce = objAdminCls.UpdateDeleteCart(Convert.ToInt32(idCustomerCart), Convert.ToInt32(quantity), "UPDATE");
                }
                GetCartDetail();
            }
        }
    }
}