using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ProductPrice : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox.DisabledCssClass = null;
            if (!IsPostBack)
            {
                int pageSize = Convert.ToInt16(ConfigurationManager.AppSettings["ProductPricePageSize"]);
                GetAllProductForPrice();
                //GetAllProductForPricePagination(pageSize, Convert.ToInt32(hdPageNo.Value));
            }
        }

        private void resetControl()
        {
            for (int i = 0; i < lstProductPrice.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)lstProductPrice.Items[i].FindControl("chkbox");
                chk.Checked = false;
                Repeater lstPrice = (Repeater)lstProductPrice.Items[i].FindControl("lstPrice");
            }
        }

        private void GetAllProductForPrice()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllProductForPrice();
            lstProductPrice.DataSource = ds.Tables[0];
            lstProductPrice.DataBind();
        }
        private void GetAllProductForPriceList(int idProduct)
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllProductForPriceList(idProduct);
            // rptPrice.DataSource = ds.Tables[0];
            // rptPrice.DataBind();
            // resetControl();
        }

        protected void lstProductPrice_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                DataSet ds = new DataSet();
                string Id = (e.Item.FindControl("hdnId") as HiddenField).Value;
                Repeater lstPrice = e.Item.FindControl("lstPrice") as Repeater;
                AdminDL objAdminCls = new AdminDL();
                ds = objAdminCls.GetAllProductForPriceList(Convert.ToInt16(Id));
                lstPrice.DataSource = ds.Tables[0];
                // lstPrice.Page = chk.Page;
                lstPrice.DataBind();
            }
        }

        protected void lstPrice_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // GetAllProductForPrice();
                AdminDL objAdminCls = new AdminDL();
                string Id = (e.Item.FindControl("hdId") as HiddenField).Value;
                //Repeater lstCountryCurrency = e.Item.FindControl("lstCountryCurrency") as Repeater;
                ////DropDownList ddCountry = e.Item.FindControl("ddCountry") as DropDownList;              
                ////DataSet ds = objAdminCls.GetAllCountry();
                //DataSet ds = objAdminCls.GetAllCountryProductPricelist(Convert.ToInt16(Id));
                ////ddCountry.DataSource = ds.Tables[0];
                ////ddCountry.DataTextField = "sName";
                ////ddCountry.DataValueField = "idCountry";
                ////ddCountry.DataBind();
                //// country.DataBind();
                //lstCountryCurrency.DataSource = ds.Tables[0];
                //lstCountryCurrency.DataBind();

                //DropDownList ddCurrency = e.Item.FindControl("ddCurrency") as DropDownList;
                //ds = objAdminCls.GetAllCurrency();
                //ddCurrency.DataSource = ds.Tables[0];
                //ddCurrency.DataTextField = "sName";
                //ddCurrency.DataValueField = "idCurrency";
                //ddCurrency.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            AdminDL objAdminCls = new AdminDL();
            // GetAllCurrency();
            ProductPriceCls objProductPrice = new ProductPriceCls();
            List<ProductPriceCls> lstProduct = new List<ProductPriceCls>();
            string Rpt = "";
            for (int i = 0; i < lstProductPrice.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)lstProductPrice.Items[i].FindControl("chkbox");
                if (chk.Checked)
                {
                    Repeater lstPrice = (Repeater)lstProductPrice.Items[i].FindControl("lstPrice");
                    HiddenField IdProduct = (HiddenField)lstProductPrice.Items[i].FindControl("hdnId");
                    for (int a = 0; a < lstPrice.Items.Count; a++)
                    {
                        HiddenField Id = (HiddenField)lstPrice.Items[a].FindControl("hdId");
                        Label Country = (Label)lstPrice.Items[a].FindControl("lblCountry");
                        Label Currency = (Label)lstPrice.Items[a].FindControl("lblCurrency");
                        HiddenField IdCountry = (HiddenField)lstPrice.Items[a].FindControl("hdCountry");
                        TextBox txtPriceB2B = (TextBox)lstPrice.Items[a].FindControl("txtB2B");
                        TextBox txtpriceB2C = (TextBox)lstPrice.Items[a].FindControl("txtB2C");
                        TextBox txtDiscount = (TextBox)lstPrice.Items[a].FindControl("txtDiscount");
                        TextBox txtShipmentCharges = (TextBox)lstPrice.Items[a].FindControl("txtShipmentCharges");
                        CheckBox chkstatus = (CheckBox)lstPrice.Items[a].FindControl("chkCountryStatus");
                        chkstatus.Checked = true;
                        if (chk.Checked && IdCountry.Value != "" && Country.Text != "" && txtPriceB2B.Text != "" && txtpriceB2C.Text != "" && Currency.Text != ""
                            && txtDiscount.Text != "" && txtShipmentCharges.Text != "" && chkstatus.Checked)
                        {
                            string sPriceB2B = txtPriceB2B.Text;
                            string spriceB2C = txtpriceB2C.Text;
                            string sCurrency = Currency.Text;
                            string sCountry = Country.Text;
                            string idCountry = IdCountry.Value;
                            string sDiscount = txtDiscount.Text;
                            string sShipmentCharges = txtShipmentCharges.Text;
                            var id = Session["UserId"];
                            Rpt = (Id.Value);
                            lstProduct.Add(new ProductPriceCls
                            {
                                idProduct = Convert.ToInt16(Rpt),
                                Createdby = Convert.ToInt16(id),
                                idCountry = Convert.ToInt16(idCountry),
                                B2Bprice = Convert.ToDouble(sPriceB2B),
                                B2Cprice = Convert.ToDouble(spriceB2C),
                                Currency = Convert.ToString(sCurrency),
                                bStatus = Convert.ToInt16(chkstatus.Checked),
                                Discount = Convert.ToInt16(sDiscount),
                                ShipmentCharges = Convert.ToDecimal(sShipmentCharges)
                            });
                        }

                    }
                }
            }
            if (Convert.ToInt32(hdIdProductPrice.Value) > 0)
            {
                hdMessage.Value = "Product Price Update |";
                //objProductPrice.idProductPrice = Convert.ToInt32(hdIdProductPrice.Value);
                //objProductPrice.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);
                //objProductPrice.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Product Price Insert |";
                objProductPrice.idProductPrice = 0;
                objProductPrice.Createdby = Convert.ToInt32(Session["UserId"]);
            }
            int Response = objAdminCls.InsertProductPrice(lstProduct);
            if (Response > 0)
            {
                GetAllProductForPriceList(Convert.ToInt16(Rpt));
                resetControl();
                EnableDisableRepeater();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                // frmProductPrice.Style.Add("display", "none");
                //tblProductPrice.Style.Add("display", "none");
                //tblProduct.Style.Add("display", "flex");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because product price already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            //EnableDisableRepeater();
        }

        protected void EnableDisableRepeater()
        {
            for (int i = 0; i < lstProductPrice.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)lstProductPrice.Items[i].FindControl("chk");
                Repeater lstPrice = (Repeater)lstProductPrice.Items[i].FindControl("lstPrice");

                if (chk != null)
                {
                    if (chk.Checked == true)
                    {
                        lstPrice.Visible = true;
                        for (int a = 0; a < lstPrice.Items.Count; a++)
                        {
                            Repeater lstCountryCurrency = (Repeater)lstPrice.Items[a].FindControl("lstCountryCurrency");
                            lstCountryCurrency.Visible = true;

                        }
                    }
                    else if (chk.Checked == false)
                    {
                        lstPrice.Visible = false;
                    }
                }
            }
        }

        protected void lstCountryCurrency_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblCountry = e.Item.FindControl("lblCountry") as Label;
                Label lblCurrency = e.Item.FindControl("lblCurrency") as Label;
                TextBox txtB2B = e.Item.FindControl("txtB2B") as TextBox;
                TextBox txtB2C = e.Item.FindControl("txtB2C") as TextBox;
                HiddenField hdCountry = e.Item.FindControl("hdCountry") as HiddenField;
                TextBox txtDiscount = e.Item.FindControl("txtDiscount") as TextBox;
                TextBox txtShipmentCharges = e.Item.FindControl("txtShipmentCharges") as TextBox;
                CheckBox chkCountryStatus = e.Item.FindControl("chkCountryStatus") as CheckBox;
            }
        }

        //private void GetCountry()
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetAllCountry();
        //    ddCountry.DataSource = ds.Tables[0];
        //    ddCountry.DataTextField = "sName";
        //    ddCountry.DataValueField = "idCountry";
        //    ddCountry.DataBind();
        //}
        //private void GetAllCurrency()
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetAllCurrency();
        //    ddCurrency.DataSource = ds.Tables[0];
        //    ddCurrency.DataTextField = "sName";
        //    ddCurrency.DataValueField = "idCurrency";
        //    ddCurrency.DataBind();
        //}
        //private void GetAllProductFoeDD()
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetAllProductForDD();
        //    ddProductList.DataSource = ds.Tables[0];
        //    ddProductList.DataTextField = "sName";
        //    ddProductList.DataValueField = "idProduct";
        //    ddProductList.DataBind();
        //}
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    ProductPriceCls objProductPrice = new ProductPriceCls();
        //    if (Convert.ToInt32(hdIdProductPrice.Value) > 0)
        //    {
        //        hdMessage.Value = "Product Price Update |";
        //        objProductPrice.idProductPrice = Convert.ToInt32(hdIdProductPrice.Value);
        //        objProductPrice.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);
        //        objProductPrice.ModifyBy = Convert.ToInt32(Session["UserId"]);
        //    }
        //    else
        //    {
        //        hdMessage.Value = "Product Price Insert |";
        //        objProductPrice.idProductPrice = 0;
        //        objProductPrice.Createdby = Convert.ToInt32(Session["UserId"]);
        //    }

        //    objProductPrice.idProduct = Convert.ToInt32(hdIdProduct.Value);
        //    objProductPrice.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);             
        //    objProductPrice.idCountry = Convert.ToInt32(ddCountry.SelectedItem.Value);
        //    objProductPrice.idCurrency = Convert.ToInt32(ddCurrency.SelectedItem.Value);
        //    objProductPrice.B2Bprice = Convert.ToDouble(txtB2B.Text);
        //    objProductPrice.B2Cprice = Convert.ToDouble(txtB2C.Text);
        //    objProductPrice.Discount = Convert.ToInt32(txtDiscount.Text);
        //    objProductPrice.ShipmentCharges = Convert.ToDecimal(txtShipmentCharges.Text);

        //    int Response = objAdminCls.SetProductPrice(objProductPrice);
        //    if (Response > 0)
        //    {
        //        //GetAllProductForPrice();
        //        //ClearControl();
        //        GetAllProductForPriceList(objProductPrice.idProduct);
        //       // chkCountryStatus.Checked = objProductPrice.bStatus == 1 ? true : false;
        //        hdMessage.Value += "Data saved successfully";
        //        //DataSet ds = objAdminCls.GetAllProductForPriceList(objProductPrice.idProduct);
        //        //ProductPriceCls Productprice = new ProductPriceCls();
        //        //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
        //        //DataSet ds = objAdminCls.GetProductId(objProductPrice.idProduct);
        //        //ProductPriceCls Productprice = new ProductPriceCls();
        //        //Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        //        frmProductPrice.Style.Add("display", "none");
        //        tblProductPrice.Style.Add("display", "none");
        //        tblProduct.Style.Add("display", "flex");
        //    }
        //    else if (Response == 0)
        //    {
        //        hdMessage.Value += "Data not saved. Because product price already exists.";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //    else
        //    {

        //        hdMessage.Value += "Data not saved successfully please try again...";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //}
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    frmProductPrice.Style.Add("display", "none");
        //    tblProduct.Style.Add("display", "flex");
        //}
        //protected void btnProductPrice_Click(object sender, EventArgs e)
        //{
        //    GetAllProductForPrice();

        //    chkCountryStatus.Checked = true;
        //    frmProductPrice.Style.Add("display", "flex");
        //    tblProductPrice.Style.Add("display", "none");
        //}
        //protected void lstCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    hdMessage.Value = "Product Price List";
        //    //lblMessage.Text = hdMessage.Value;
        //    Label lblsName = e.Item.FindControl("lblsName") as Label;
        //    Label lblstatus = e.Item.FindControl("lblStatus") as Label;
        //    HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
        //    HiddenField hdnName = e.Item.FindControl("hdnName") as HiddenField;
        //    hdIdProduct.Value = hdn.Value;
        //    lblProductName.Text = hdnName.Value;
        //    if (!string.IsNullOrEmpty(lblsName.Text))
        //    {
        //        if (e.CommandName == "CatEdit")
        //        {
        //            GetAllProductForPriceList(Convert.ToInt32(hdIdProduct.Value));
        //            //hdMessage.Value = "Product Price List";
        //            lblMessage.Text = hdMessage.Value;
        //            frmProductPrice.Style.Add("display", "none");
        //            tblProductPrice.Style.Add("display", "flex");
        //            tblProduct.Style.Add("display", "flex");
        //        }
        //        else if (e.CommandName == "CatDelete")
        //        {
        //            //DeleteProductPrice(Convert.ToInt32(hdIdProduct.Value));
        //        }

        //    }
        //}
        //private void DeleteProductPrice(int idProductPrice)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    hdMessage.Value = "Category Delete |";
        //    int Response = objAdminCls.DeleteProductPrice(idProductPrice);
        //    if (Response > 0)
        //    {
        //        GetAllProductForPrice();
        //        hdMessage.Value += "Category Delete successfully";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        //        frmProductPrice.Style.Add("display", "none");
        //        tblProductPrice.Style.Add("display", "block");
        //        tblProduct.Style.Add("display", "none");
        //    }
        //    else if (Response == 0)
        //    {
        //        hdMessage.Value += "Category not exists.";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //}
        //private void resetControl()
        //{
        //    txtB2B.Text = "";
        //    chkCountryStatus.Checked = false;
        //  //  hdIdProduct.Value = "0";
        //    frmProductPrice.Style.Add("display", "none");
        //    tblProductPrice.Style.Add("display", "flex");
        //}
        //protected void btnAddPrice_Click(object sender, EventArgs e)
        //{
        //    GetAllProductForPrice();
        //    resetControl();
        //    hdMessage.Value = "Add Product Price";
        //    lblMess.Text = hdMessage.Value;
        //    lblProductName.Text = "";
        //    txtB2C.Text = "";
        //    frmProductPrice.Style.Add("display", "flex");
        //    tblProductPrice.Style.Add("display", "none");
        //    tblProduct.Style.Add("display", "none");
        //}
        //protected void ddProductList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    hdIdProduct.Value = ddProductList.SelectedItem.Value;
        //    lblProductName.Text = ddProductList.SelectedItem.Text;
        //}
        //protected void rptPrice_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    //Label lblsName = e.Item.FindControl("lblsName") as Label;         
        //    hdMessage.Value = "Edit Product Price";
        //    lblMess.Text = hdMessage.Value;
        //    Label lblCountry = e.Item.FindControl("lblCountry") as Label;
        //    Label lblPriceB2B = e.Item.FindControl("lblPriceB2B") as Label;
        //    Label lblpriceB2C = e.Item.FindControl("lblpriceB2C") as Label;
        //    Label lblCurrency = e.Item.FindControl("lblCurrency") as Label;
        //    Label lblstatus = e.Item.FindControl("LblStatus") as Label;
        //    Label lbldiscount = e.Item.FindControl("lblDiscount") as Label;
        //    Label lblshipment = e.Item.FindControl("lblShipmentCharges") as Label;
        //    HiddenField hdn = e.Item.FindControl("hdnIdProductprice") as HiddenField;          
        //    HiddenField hdnName = e.Item.FindControl("hdnName") as HiddenField;
        //    hdIdProductPrice.Value = hdn.Value;
        //    if (!string.IsNullOrEmpty(lblCountry.Text))
        //    {
        //        if (e.CommandName == "CatEdit")
        //        {
        //            AdminDL objAdminCls = new AdminDL();                  
        //            DataSet ds = objAdminCls.GetAllProductForPriceList(Convert.ToInt32(hdIdProduct.Value));
        //            ProductPriceCls Productprice = new ProductPriceCls();
        //            Productprice.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);
        //            txtB2B.Text = lblPriceB2B.Text;
        //            txtB2C.Text = lblpriceB2C.Text;
        //            txtDiscount.Text = lbldiscount.Text;
        //            txtShipmentCharges.Text = lblshipment.Text;
        //            chkCountryStatus.Checked = Productprice.bStatus == 1 ? true : false;  
        //            frmProductPrice.Style.Add("display", "flex");
        //            tblProductPrice.Style.Add("display", "none");
        //            tblProduct.Style.Add("display", "none");
        //        }
        //        else if (e.CommandName == "CatDelete")
        //        {
        //            DeleteProductPrice(Convert.ToInt32(hdIdProduct.Value));
        //        }
        //    }
        //}
        //private void GetProductId(int IdProduct)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetProductId(IdProduct);
        //    hdIdProduct.Value = ds.Tables[0].Rows[0]["idProduct"].ToString();
        //}

        //protected void btnCan_Click(object sender, EventArgs e)
        //{
        //    frmProductPrice.Style.Add("display", "none");
        //    tblProductPrice.Style.Add("display", "flex");
        //    tblProduct.Style.Add("display", "none");
        //}

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //}       

        //protected void btnSave_Click1(object sender, EventArgs e)
        //{
        //    AdminDL objAdminCls = new AdminDL();
        //    GetAllCurrency();
        //    ProductPriceCls objProductPrice = new ProductPriceCls();
        //    List<ProductPriceCls> lstProductPrice = new List<ProductPriceCls>();
        //    string Rpt = "";
        //    for (int i = 0; i < rptPrice.Items.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)rptPrice.Items[i].FindControl("chk");
        //        HiddenField Country = (HiddenField)rptPrice.Items[i].FindControl("hdCountry");
        //        TextBox txtPriceB2B = (TextBox)rptPrice.Items[i].FindControl("txtPriceB2B");
        //        TextBox txtpriceB2C = (TextBox)rptPrice.Items[i].FindControl("txtpriceB2C");
        //        //DropDownList Currency = (DropDownList)rptPrice.Items[i].FindControl("ddCurrency");
        //        HiddenField Currency = (HiddenField)rptPrice.Items[i].FindControl("hdCurrency");
        //        TextBox txtDiscount = (TextBox)rptPrice.Items[i].FindControl("txtDiscount");
        //        TextBox txtShipmentCharges = (TextBox)rptPrice.Items[i].FindControl("txtShipmentCharges");
        //        CheckBox chkstatus = (CheckBox)rptPrice.Items[i].FindControl("chkStatus");                
        //        if (chk.Checked && Country.Value != "" && txtPriceB2B.Text != "" && txtpriceB2C.Text != "" && Currency.Value != ""
        //            && txtDiscount.Text != "" && txtShipmentCharges.Text != "" && chkstatus.Checked)
        //        {
        //            string sPriceB2B = txtPriceB2B.Text;
        //            string spriceB2C = txtpriceB2C.Text;
        //            string sCurrency = Currency.Value;
        //            string sCountry = Country.Value;
        //            string sDiscount = txtDiscount.Text;
        //            string sShipmentCharges = txtShipmentCharges.Text;
        //            var id = Session["UserId"];
        //            Rpt = (chk.Text);
        //            //string status =
        //            lstProductPrice.Add(new ProductPriceCls { idProduct = Convert.ToInt16(Rpt), Createdby = Convert.ToInt16(id),
        //                idCountry =Convert.ToInt16(sCountry),
        //                B2Bprice = Convert.ToDouble(sPriceB2B), B2Cprice = Convert.ToDouble(spriceB2C),idCurrency =Convert.ToInt16(sCurrency),
        //                bStatus = Convert.ToInt16(chkstatus.Checked),Discount = Convert.ToInt16(sDiscount), ShipmentCharges =Convert.ToDecimal(sShipmentCharges)
        //            });
        //        }
        //    }
        //    if (Convert.ToInt32(hdIdProductPrice.Value) > 0)
        //    {
        //        hdMessage.Value = "Product Price Update |";
        //        //objProductPrice.idProductPrice = Convert.ToInt32(hdIdProductPrice.Value);
        //        //objProductPrice.bStatus = (Int16)(chkCountryStatus.Checked ? 1 : 0);
        //        //objProductPrice.ModifyBy = Convert.ToInt32(Session["UserId"]);
        //    }
        //    else
        //    {
        //        hdMessage.Value = "Product Price Insert |";
        //        objProductPrice.idProductPrice = 0;
        //        objProductPrice.Createdby = Convert.ToInt32(Session["UserId"]);
        //    }
        //    int Response = objAdminCls.InsertProductPrice(lstProductPrice);
        //    if (Response > 0)
        //    {                
        //        GetAllProductForPriceList(Convert.ToInt16(Rpt));
        //        hdMessage.Value += "Data saved successfully";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        //        frmProductPrice.Style.Add("display", "none");
        //        tblProductPrice.Style.Add("display", "none");
        //        tblProduct.Style.Add("display", "flex");
        //    }
        //    else if (Response == 0)
        //    {
        //        hdMessage.Value += "Data not saved. Because product price already exists.";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //    else
        //    {

        //        hdMessage.Value += "Data not saved successfully please try again...";
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
        //    }
        //}

        //protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    int pageSize = Convert.ToInt16(ConfigurationManager.AppSettings["ProductPricePageSize"]);
        //    //int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
        //    //HiddenField hdnidOrder = e.Item.FindControl("customerID") as HiddenField;
        //    //int customerID = Convert.ToInt32(hdnidOrder.Value);
        //    int pageNum = Convert.ToInt32(e.CommandArgument);
        //    if (pageNum == -1)
        //    {
        //        pageNum = 1;
        //    }
        //    else if (pageNum == -2)
        //    {
        //        pageNum = (int)ViewState["iPageCount"];
        //    }

        //    hdPageNo.Value = pageNum.ToString();
        //    GetAllProductForPricePagination(pageSize, pageNum);
            
        //}

        //private void GetAllProductForPricePagination(int pageSize, int pageNo)
        //{
        //    int recordCount = 0;
        //    AdminDL objAdminCls = new AdminDL();
        //    DataSet ds = objAdminCls.GetAllProductForPricePagination(pageSize,pageNo);
        //    if (ds != null)
        //    {
              
        //        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        //        {

        //            lstProductPrice.DataSource = ds.Tables[1];
        //            lstProductPrice.DataBind();
        //        }
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            recordCount = Convert.ToInt32(ds.Tables[0].Rows[0]["RecordCount"]);
        //        }
        //    }
        
        //    double dPageCount = 0;
        //    if (pageSize != 0)
        //    {
        //        dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
        //    }
        //    else
        //    {
        //        dPageCount = 0;
        //    }
         
        //    int iPageCount = (int)Math.Ceiling(dPageCount);
        //    ViewState["iPageCount"] = iPageCount;
        //    List<ListItem> lPages = new List<ListItem>();
        //    if (iPageCount > 0)
        //    {
        //        for (int i = 1; i <= iPageCount; i++)
        //            lPages.Add(new ListItem(i.ToString(), i.ToString(), i != pageNo));
        //    }
        //    rptPagination.DataSource = lPages;
        //    rptPagination.DataBind();
        //}

    }
}