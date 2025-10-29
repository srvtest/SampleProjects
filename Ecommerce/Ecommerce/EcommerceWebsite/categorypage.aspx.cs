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
    public partial class categorypage : System.Web.UI.Page
    {
        UserDL objUserCls = null;
        public string ListViewtype
        {
            get
            {
                return Convert.ToString(hdnviewType.Value);
            }
            set
            {

                hdnviewType.Value = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ListViewtype = "GRID";
                //  Page.RouteData.Values["categoryname"];
                lblCategory.Text = Convert.ToString(Page.RouteData.Values["categoryname"]);
                GetProductList(Convert.ToInt32(ddlLimit.SelectedValue), 1, ddlSort.SelectedItem.Text, ddlSort.SelectedValue.Split('_').Last());
            }
        }

        private void GetProductList(int pageSize, int pageNo, string sortBy, string sortDirection)
        {
            int recordCount = 0;
            string sCategory = Convert.ToString(Page.RouteData.Values["categoryname"]);
            int idCountry = GetCountryId(); 
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);
            //int pageSize = Convert.ToInt32(hdPageSize.Value); 
            //int pageNo = Convert.ToInt32(hdPageNo.Value);
            if (objUserCls == null)
                objUserCls = new UserDL();
            DataSet ds = objUserCls.GetAllProductByCategory(sCategory, idCountry, isB2B, pageSize, pageNo, sortBy, sortDirection,0);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    recordCount = Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]);
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    RptProducts.DataSource = ds.Tables[1];
                    RptProducts.DataBind();
                }
            }

            double dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int iPageCount = (int)Math.Ceiling(dPageCount);
            ViewState["iPageCount"] = iPageCount;
            List<ListItem> lPages = new List<ListItem>();
            if (iPageCount > 0)
            {
                for (int i = 1; i <= iPageCount; i++)
                    lPages.Add(new ListItem(i.ToString(), i.ToString(), i != pageNo));
            }
            rptPagination.DataSource = lPages;
            rptPagination.DataBind();
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

        protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int pageNum = Convert.ToInt32(e.CommandArgument);
            if (pageNum == -1)
            {
                pageNum = 1;
            }
            else if (pageNum == -2)
            {
                pageNum = (int)ViewState["iPageCount"];
            }

            hdPageNo.Value = pageNum.ToString();
            GetProductList(Convert.ToInt32(ddlLimit.SelectedValue), pageNum, ddlSort.SelectedItem.Text.Split(' ').First(), ddlSort.SelectedValue.Split('_').Last());
        }

        protected void ddlLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            GetProductList(Convert.ToInt32(ddlLimit.SelectedValue), Convert.ToInt32(hdPageNo.Value), ddlSort.SelectedItem.Text.Split(' ').First(), ddlSort.SelectedValue.Split('_').Last());
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            GetProductList(Convert.ToInt32(ddlLimit.SelectedValue), Convert.ToInt32(hdPageNo.Value), ddlSort.SelectedItem.Text.Split(' ').First(), ddlSort.SelectedValue.Split('_').Last());
        }

        protected void RptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        //TextBox tqty = e.Item.FindControl("txtQty") as TextBox;
                        int qty = 1;
                        AddProductInCart(qty);
                        this.Master.GetCartDetail();
                    }
                    else
                    {
                        Response.Redirect("../login");
                    }
                }
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