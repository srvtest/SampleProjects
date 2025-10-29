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

namespace EcommerceWebsite
{
    public partial class Products : System.Web.UI.Page
    {
        UserDL objUserCls = new UserDL();
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
                string sName = Convert.ToString(Page.RouteData.Values["mastercategoryname"]);
                DataSet ds;
                if (!string.IsNullOrEmpty(sName))
                {
                    if (sName.Contains("search="))
                    {
                        sName = sName.Replace("search=", "");
                        txtSearch.Text = sName;
                        BindAllData();
                    }
                    else
                    {
                        ds = objUserCls.GetMasterCategoryByName(sName);
                        int idMasterCategory = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        BindAllData(idMasterCategory);
                    }
                    
                }
                else
                {
                    BindAllData();
                }

            }
        }

        protected void ddlLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            BindAllData();
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            BindAllData();
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
            BindAllData();
        }

        private void BindAllData(int idMasterCategory = 0)

        {
            pnlEmpty.Visible = false;
            pnlProducts.Visible = false;

            string sText = txtSearch.Text;
            string abc = txtSearch.Text;
            string[] username = abc.Split('.');
            //sText = sText.Replace(' ', '~');
            sText = username[0];
            FilterProductsCls objFilterProductsCls = new FilterProductsCls();

            objFilterProductsCls.lstMasterCategory = new List<MasterCategoryCls>();
            foreach (ListItem li in ddlMasterCategory.Items)
                if (li.Selected == true)
                    objFilterProductsCls.lstMasterCategory.Add(new MasterCategoryCls { idMasterCategory = Convert.ToInt32(li.Value) });
            if (idMasterCategory > 0)
                objFilterProductsCls.lstMasterCategory.Add(new MasterCategoryCls { idMasterCategory = idMasterCategory });


            objFilterProductsCls.lstCategory = new List<CategoryCls>();
            foreach (ListItem li in ddlCategory.Items)
                if (li.Selected == true)
                    objFilterProductsCls.lstCategory.Add(new CategoryCls { idCategory = Convert.ToInt32(li.Value) });

            objFilterProductsCls.lstCollection = new List<CollectionCls>();
            foreach (ListItem li in ddlCollection.Items)
                if (li.Selected == true)
                    objFilterProductsCls.lstCollection.Add(new CollectionCls { idCollection = Convert.ToInt32(li.Value) });

            objFilterProductsCls.lstMaterial = new List<MaterialCls>();
            foreach (ListItem li in ddlMaterial.Items)
                if (li.Selected == true)
                    objFilterProductsCls.lstMaterial.Add(new MaterialCls { idMaterial = Convert.ToInt32(li.Value) });

            objFilterProductsCls.lstGemstone = new List<GemstoneCls>();
            foreach (ListItem li in ddlGemstone.Items)
                if (li.Selected == true)
                    objFilterProductsCls.lstGemstone.Add(new GemstoneCls { idGemstone = Convert.ToInt32(li.Value) });

            objFilterProductsCls.lstGender = new List<GenderCls>();
            foreach (ListItem li in ddlGender.Items)
                if (li.Selected == true)
                    objFilterProductsCls.lstGender.Add(new GenderCls { idGender = Convert.ToInt32(li.Value) });

            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

            int pageSize = Convert.ToInt32(ddlLimit.SelectedValue);
            int pageNo = Convert.ToInt32(hdPageNo.Value);


            string s = ddlSort.SelectedItem.Text;
            string[] subs = s.Split(' ');
            string sortBy = subs[0];
            string sortDirection = ddlSort.SelectedValue.Split('_').Last();

            DataSet ds = objUserCls.GetFilterProductsByidMasterCategory(objFilterProductsCls, idCountry, isB2B, pageSize, pageNo, sortBy, sortDirection, sText,0,0,30,0);
            

            string strExpr = string.Empty;
            var dataview = ds.Tables[1].DefaultView;
            DataTable dtData;

            dataview = ds.Tables[1].DefaultView;
            strExpr = "TableName='MASTERCATEGORY'";
            dataview.RowFilter = strExpr;
            dtData = dataview.ToTable();
            if (objFilterProductsCls.lstMasterCategory.Count == 0)
            {
                ddlMasterCategory.DataSource = dtData;
                ddlMasterCategory.DataTextField = "sName";
                ddlMasterCategory.DataValueField = "ID";
                ddlMasterCategory.DataBind();
                if (idMasterCategory > 0)
                    foreach (ListItem li in ddlMasterCategory.Items)
                        if (Convert.ToInt32(li.Value) == idMasterCategory)
                            li.Selected = true;
            }
            else
            {
                if (idMasterCategory > 0)
                {
                    ddlMasterCategory.DataSource = dtData;
                    ddlMasterCategory.DataTextField = "sName";
                    ddlMasterCategory.DataValueField = "ID";
                    ddlMasterCategory.DataBind();
                    foreach (ListItem li in ddlMasterCategory.Items)
                        if (Convert.ToInt32(li.Value) == idMasterCategory)
                            li.Selected = true;
                }

                foreach (ListItem li in ddlMasterCategory.Items)
                    for (int i = 0; i < dtData.Rows.Count; i++)
                        if (li.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                            li.Text = Convert.ToString(dtData.Rows[i]["sName"]);
            }

            dataview = ds.Tables[1].DefaultView;
            strExpr = "TableName='CATEGORY'";
            dataview.RowFilter = strExpr;
            dtData = dataview.ToTable();
            if (objFilterProductsCls.lstCategory.Count == 0)
            {
                ddlCategory.DataSource = dtData;
                ddlCategory.DataTextField = "sName";
                ddlCategory.DataValueField = "ID";
                ddlCategory.DataBind();
            }
            else
            {
                foreach (ListItem li in ddlCategory.Items)
                    for (int i = 0; i < dtData.Rows.Count; i++)
                        if (li.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                            li.Text = Convert.ToString(dtData.Rows[i]["sName"]);
            }

            dataview = ds.Tables[1].DefaultView;
            strExpr = "TableName='COLLECTION'";
            dataview.RowFilter = strExpr;
            dtData = dataview.ToTable();
            if (objFilterProductsCls.lstCollection.Count == 0)
            {
                ddlCollection.DataSource = dtData;
                ddlCollection.DataTextField = "sName";
                ddlCollection.DataValueField = "ID";
                ddlCollection.DataBind();

            }
            else
            {
                foreach (ListItem li in ddlCollection.Items)
                    for (int i = 0; i < dtData.Rows.Count; i++)
                        if (li.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                            li.Text = Convert.ToString(dtData.Rows[i]["sName"]);
            }

            dataview = ds.Tables[1].DefaultView;
            strExpr = "TableName='GEMSTONE'";
            dataview.RowFilter = strExpr;
            dtData = dataview.ToTable();
            if (objFilterProductsCls.lstGemstone.Count == 0)
            {
                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='GEMSTONE'";
                dataview.RowFilter = strExpr;
                ddlGemstone.DataSource = dtData;
                ddlGemstone.DataTextField = "sName";
                ddlGemstone.DataValueField = "ID";
                ddlGemstone.DataBind();

            }
            else
            {
                foreach (ListItem li in ddlGemstone.Items)
                    for (int i = 0; i < dtData.Rows.Count; i++)
                        if (li.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                            li.Text = Convert.ToString(dtData.Rows[i]["sName"]);
            }

            dataview = ds.Tables[1].DefaultView;
            strExpr = "TableName='GENDER'";
            dataview.RowFilter = strExpr;
            dtData = dataview.ToTable();
            if (objFilterProductsCls.lstGender.Count == 0)
            {
                ddlGender.DataSource = dtData;
                ddlGender.DataTextField = "sName";
                ddlGender.DataValueField = "ID";
                ddlGender.DataBind();

            }
            else
            {
                foreach (ListItem li in ddlGender.Items)
                    for (int i = 0; i < dtData.Rows.Count; i++)
                        if (li.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                            li.Text = Convert.ToString(dtData.Rows[i]["sName"]);
            }

            dataview = ds.Tables[1].DefaultView;
            strExpr = "TableName='MATERIAL'";
            dataview.RowFilter = strExpr;
            dtData = dataview.ToTable();
            if (objFilterProductsCls.lstMaterial.Count == 0)
            {
                ddlMaterial.DataSource = dtData;
                ddlMaterial.DataTextField = "sName";
                ddlMaterial.DataValueField = "ID";
                ddlMaterial.DataBind();

            }
            else
            {
                foreach (ListItem li in ddlMaterial.Items)
                    for (int i = 0; i < dtData.Rows.Count; i++)
                        if (li.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                            li.Text = Convert.ToString(dtData.Rows[i]["sName"]);
            }

            RptProducts.DataSource = ds.Tables[0];
            RptProducts.DataBind();

            int recordCount = Convert.ToInt32(ds.Tables[2].Rows[0]["RecordCount"]);
            double dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int iPageCount = (int)Math.Ceiling(dPageCount);
            ViewState["iPageCount"] = iPageCount;
            List<ListItem> lPages = new List<ListItem>();
            if (iPageCount > 0)
            {
                for (int i = 1; i <= iPageCount; i++)
                    lPages.Add(new ListItem(i.ToString(), i.ToString(), i != pageNo));
            }

            if (lPages.Count>0)
            {
                rptPagination.DataSource = lPages;
                rptPagination.DataBind();
                pnlProducts.Visible = true;
            }
            else
            {
                pnlEmpty.Visible = true;
                rptPagination.DataSource = null;
                rptPagination.DataBind();
            }
            
        }

        protected void ddlMasterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindAllData();
        }
    }
}