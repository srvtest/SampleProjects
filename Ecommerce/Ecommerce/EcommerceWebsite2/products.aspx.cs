using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite2
{
    public partial class products : System.Web.UI.Page
    {
        UserDL objUserCls = new UserDL();
        int idCategory = 0, idMasterCategory = 0, idCollection = 0, idMaterial = 0, idGemstone = 0, idGender = 0;

        public List<int> idWishlists {
            get
            {
                return (List<int>)ViewState["idWishlist"];
            }
            set
            {
                ViewState["idWishlist"] = value;
            }
        }

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

        public string GridViewtype
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
                //if (Request != null && Request.UrlReferrer != null)
                //{
                //    ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
                //}
                //Request.Url.GetLeftPart(UriPartial.Authority);
                //string abc = Request.Url.LocalPath.ToString();
                //string[] username = abc.Split('/');

                //for (int i = 0; i <= 3; i++)
                //{
                //    if (username[0] == "")
                //    {
                //        if (username[1] != "products")
                //        {

                //        }
                //        else
                //        {
                //            //string str = username[2];
                //          //  DataSet ds1 = objUserCls.GetCategoryByName(str);
                //           // Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["idCategory"]);
                //        }                 
                //        // Verificationrequest(user);
                //    }
                //}
                string sName = Convert.ToString(Page.RouteData.Values["mastercategoryname"]);
                DataSet ds;
                if (!string.IsNullOrEmpty(sName))
                {
                    if (sName.Contains("search="))
                    {
                        lblSearchText.Text = sName.Replace("search=", "");
                        BindAllData();
                    }
                    else if (sName.Contains("category="))
                    {
                        BindAllData();
                        hdnSidebar.Value = "Categories";
                        sName = sName.Replace("category=", "");
                        ds = objUserCls.GetCategoryByName(sName);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            idCategory = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                            BindAllData(0, idCategory, 0, 0, 0, 0);
                        }
                    }
                    else if (sName.Contains("gender="))
                    {
                        BindAllData();
                        hdnSidebar.Value = "Gender";
                        sName = sName.Replace("gender=", "");
                        ds = objUserCls.GetGenderByName(sName);
                        idGender = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        BindAllData(0, 0, 0, 0, 0, idGender);
                    }
                    else if (sName.Contains("collection="))
                    {
                        BindAllData();
                        hdnSidebar.Value = "Collection";
                        sName = sName.Replace("collection=", "");
                        ds = objUserCls.GetCollectionByName(sName);
                        idCollection = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        BindAllData(0, 0, idCollection, 0, 0, 0);
                    }
                    else if (sName.Contains("material="))
                    {
                        BindAllData();
                        hdnSidebar.Value = "Material";
                        sName = sName.Replace("material=", "");
                        ds = objUserCls.GetMaterialByName(sName);
                        idMaterial = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        BindAllData(0, 0, 0, idMaterial, 0, 0);
                    }
                    else if (sName.Contains("gemstone="))
                    {
                        BindAllData();
                        hdnSidebar.Value = "Gemstone";
                        sName = sName.Replace("gemstone=", "");
                        ds = objUserCls.GetGemstoneByName(sName);
                        idGemstone = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        BindAllData(0, 0, 0, 0, idGemstone, 0);
                    }
                    else if (sName.Contains("main="))
                    {
                        BindAllData();
                        hdnSidebar.Value = "Main";
                        sName = sName.Replace("main=", "");
                        ds = objUserCls.GetMasterCategorysByName(sName);
                        idMasterCategory = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        BindAllData(idMasterCategory, 0, 0, 0, 0, 0);
                    }
                }
                else
                {
                    BindAllData();
                }

            }
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            BindAllData();
        }

        private void BindAllData(int idMasterCategory = 0, int idCategory = 0, int idCollection = 0, int idMaterial = 0, int idGemstone = 0, int idGender = 0)
        {
            DataSet ds;string sText = "";
            if (!string.IsNullOrEmpty(Convert.ToString(lblSearchText.Text)))
            {
                sText = Convert.ToString(lblSearchText.Text);
            }

            pnlEmpty.Visible = false;
            pnlProducts.Visible = false;
            FilterProductsCls objFilterProductsCls = new FilterProductsCls();

            objFilterProductsCls.lstMasterCategory = new List<MasterCategoryCls>();
            objFilterProductsCls.lstCategory = new List<CategoryCls>();
            objFilterProductsCls.lstCollection = new List<CollectionCls>();
            objFilterProductsCls.lstMaterial = new List<MaterialCls>();
            objFilterProductsCls.lstGemstone = new List<GemstoneCls>();
            objFilterProductsCls.lstGender = new List<GenderCls>();
            objFilterProductsCls.lstColor = new List<ColorCls>();
            objFilterProductsCls.lstShape = new List<ShapeCls>();
            objFilterProductsCls.lstSize = new List<SizeCls>();
            foreach (RepeaterItem li in rptMain.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {
                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstMasterCategory.Add(new MasterCategoryCls { idMasterCategory = Convert.ToInt32(hdnChk.Value) });
                }
            }
            if (idMasterCategory > 0)
                objFilterProductsCls.lstMasterCategory.Add(new MasterCategoryCls { idMasterCategory = idMasterCategory });
            if (idCategory > 0)
                objFilterProductsCls.lstCategory.Add(new CategoryCls { idCategory = idCategory });
            if (idCollection > 0)
                objFilterProductsCls.lstCollection.Add(new CollectionCls { idCollection = idCollection });
            if (idMaterial > 0)
                objFilterProductsCls.lstMaterial.Add(new MaterialCls { idMaterial = idMaterial });
            if (idGemstone > 0)
                objFilterProductsCls.lstGemstone.Add(new GemstoneCls { idGemstone = idGemstone });
            if (idGender > 0)
                objFilterProductsCls.lstGender.Add(new GenderCls { idGender = idGender });

            foreach (RepeaterItem li in rptCategory.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idCategory)
                {

                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstCategory.Add(new CategoryCls { idCategory = Convert.ToInt32(hdnChk.Value) });
                }
            }
            
            foreach (RepeaterItem li in rptCollection.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {
                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstCollection.Add(new CollectionCls { idCollection = Convert.ToInt32(hdnChk.Value) });
                }
            }

           foreach (RepeaterItem li in rptMaterial.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {
                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstMaterial.Add(new MaterialCls { idMaterial = Convert.ToInt32(hdnChk.Value) });
                }
            }
            
            foreach (RepeaterItem li in rptGemstone.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {
                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstGemstone.Add(new GemstoneCls { idGemstone = Convert.ToInt32(hdnChk.Value) });
                }
            }
            
            foreach (RepeaterItem li in rptColors.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {

                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstColor.Add(new ColorCls { idColor = Convert.ToInt32(hdnChk.Value) });
                }
            }
            
            foreach (RepeaterItem li in rptShape.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {

                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstShape.Add(new ShapeCls { idShape = Convert.ToInt32(hdnChk.Value) });
                }
            }
           
            foreach (RepeaterItem li in rptSize.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {

                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstSize.Add(new SizeCls { idSize = Convert.ToInt32(hdnChk.Value) });
                }
            }
           
            foreach (RepeaterItem li in rptGender.Items)
            {
                HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                CheckBox chk = li.FindControl("chk") as CheckBox;
                if (chk.Checked)
                {
                    HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                    objFilterProductsCls.lstGender.Add(new GenderCls { idGender = Convert.ToInt32(hdnChk.Value) });
                }
            }

            int idCountry = GetCountryId();
            int isB2B = Convert.ToInt32(ConfigurationManager.AppSettings["IsB2B"]);

            int pageSize = Convert.ToInt32(ddlLimit.SelectedValue);
            int pageNo = Convert.ToInt32(hdPageNo.Value);


            string s = ddlSort.SelectedItem.Text;
            string[] subs = s.Split(' ');
            string sortBy = subs[0];
            string sortDirection = ddlSort.SelectedValue.Split('_').Last();
            int idCustomer = !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))) : 0;
            ds = objUserCls.GetFilterProductsByidMasterCategory(objFilterProductsCls, idCountry, isB2B, pageSize, pageNo, sortBy, sortDirection, sText, !string.IsNullOrEmpty(Convert.ToString(hdnMinPrice.Value)) ? Convert.ToInt32(hdnMinPrice.Value) : 0, !string.IsNullOrEmpty(Convert.ToString(hdnMaxPrice.Value)) ? Convert.ToInt32(hdnMaxPrice.Value) : 0, this.Master.NewProductDuration, idCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //int minP = Convert.ToInt32(Math.Floor(Convert.ToDecimal(ds.Tables[0].Compute("min([PurchasePrice])", string.Empty))));
                //int maxP = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(ds.Tables[0].Compute("max([PurchasePrice])", string.Empty))));
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    int minP = Convert.ToInt32(Math.Floor(Convert.ToDecimal(ds.Tables[2].Rows[0]["MinPrice"])));
                    int maxP = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(ds.Tables[2].Rows[0]["MaxPrice"])));
                    if (string.IsNullOrEmpty(Convert.ToString(hdnMinPrice.Value)))
                        hdnMinPrice.Value = minP.ToString();
                    if (string.IsNullOrEmpty(Convert.ToString(hdnMaxPrice.Value)))
                        hdnMaxPrice.Value = maxP.ToString();
                    Page.ClientScript.RegisterStartupScript(GetType(), "PriceRange", "SetPriceRange('" + this.Master.CurrencySymbol + "','" + minP + "','" + maxP + "');", true);
                }

                string strExpr = string.Empty;
                var dataview = ds.Tables[1].DefaultView;
                DataTable dtData;

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='MASTERCATEGORY'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstMasterCategory.Count == 0)
                {
                    rptMain.DataSource = dtData;
                    rptMain.DataBind();
                    if (idMasterCategory > 0)
                        foreach (RepeaterItem li in rptMain.Items)
                        {
                            HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            CheckBox chk = li.FindControl("chk") as CheckBox;
                            if (chk.Checked)
                            {
                                HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                                if (Convert.ToInt32(hdnChk.Value) == idMasterCategory)
                                {
                                    chk.Checked = true;
                                }
                            }
                        }
                }
                else
                {
                    if (idMasterCategory > 0)
                    {
                        rptMain.DataSource = dtData;
                        rptMain.DataBind();
                        foreach (RepeaterItem li in rptMain.Items)
                        {
                            HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            CheckBox chk = li.FindControl("chk") as CheckBox;
                            if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idMasterCategory)
                            {
                                chk.Checked = true;
                                HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                                if (Convert.ToInt32(hdnChk.Value) == idMasterCategory)
                                {
                                    chk.Checked = true;
                                }
                            }
                        }
                    }

                    foreach (RepeaterItem li in rptMain.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked)
                        {
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }

                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='CATEGORY'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstCategory.Count == 0)
                {
                    rptCategory.DataSource = dtData;
                    rptCategory.DataBind();
                }
                else
                {
                    foreach (RepeaterItem li in rptCategory.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idCategory)
                        {
                            chk.Checked = true;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='COLLECTION'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstCollection.Count == 0)
                {
                    rptCollection.DataSource = dtData;
                    rptCollection.DataBind();
                }
                else
                {
                    foreach (RepeaterItem li in rptCollection.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idCollection)
                        {
                            chk.Checked = true;
                            //HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='GEMSTONE'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstGemstone.Count == 0)
                {
                    //dataview = ds.Tables[1].DefaultView;
                    //strExpr = "TableName='GEMSTONE'";
                    //dataview.RowFilter = strExpr;
                    rptGemstone.DataSource = dtData;
                    rptGemstone.DataBind();

                }
                else
                {
                    foreach (RepeaterItem li in rptGemstone.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idGemstone)
                        {
                            chk.Checked = true;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='GENDER'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstGender.Count == 0)
                {
                    rptGender.DataSource = dtData;
                    rptGender.DataBind();

                }
                else
                {
                    foreach (RepeaterItem li in rptGender.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idGender)
                        {
                            chk.Checked = true;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='MATERIAL'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstMaterial.Count == 0)
                {
                    rptMaterial.DataSource = dtData;
                    rptMaterial.DataBind();

                }
                else
                {
                    foreach (RepeaterItem li in rptMaterial.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked || Convert.ToInt32(hdnChk.Value) == idMaterial)
                        {
                            chk.Checked = true;
                            //HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='COLOR'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstColor.Count == 0)
                {
                    rptColors.DataSource = dtData;
                    rptColors.DataBind();

                }
                else
                {
                    foreach (RepeaterItem li in rptColors.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked)
                        {
                            chk.Checked = true;
                            //  HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='SHAPE'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstShape.Count == 0)
                {
                    rptShape.DataSource = dtData;
                    rptShape.DataBind();

                }
                else
                {
                    foreach (RepeaterItem li in rptShape.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked)
                        {
                            chk.Checked = true;
                            //  HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }

                dataview = ds.Tables[1].DefaultView;
                strExpr = "TableName='SIZE'";
                dataview.RowFilter = strExpr;
                dtData = dataview.ToTable();
                if (objFilterProductsCls.lstSize.Count == 0)
                {
                    rptSize.DataSource = dtData;
                    rptSize.DataBind();
                }
                else
                {
                    foreach (RepeaterItem li in rptSize.Items)
                    {
                        HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                        CheckBox chk = li.FindControl("chk") as CheckBox;
                        if (chk.Checked)
                        {
                            chk.Checked = true;
                            // HiddenField hdnChk = li.FindControl("hdChk") as HiddenField;
                            HiddenField hdnName = li.FindControl("hdName") as HiddenField;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                                if (hdnChk.Value == Convert.ToString(dtData.Rows[i]["ID"]))
                                {
                                    hdnName.Value = Convert.ToString(dtData.Rows[i]["sName"]);
                                    chk.Text = Convert.ToString(dtData.Rows[i]["sName"]);
                                }
                        }
                    }
                }
                idWishlists = this.Master.GetWishlistCount();
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

                if (lPages.Count > 0)
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
            else
            {
                pnlEmpty.Visible = true;
                pnlProducts.Visible = false;
                pnlSidebar.Visible = false;
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

        protected void RptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            Label lblFeatures = e.Item.FindControl("lblFeatures") as Label;
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
            if (e.CommandName == "WishAdd")
            {
                if (hdn != null)
                {
                    //txtQty
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
                                    BindAllData();
                                }
                                else
                                    Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('danger','" + result[1] + "');", true);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx");
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
                        AddProductInCart(qty, null, null);
                        this.Master.GetCartDetail();
                        Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','Product added in your cart successfully.');", true);
                    }
                    else
                    {
                        Response.Redirect("~/login.aspx");
                    }
                }
            }
            else if (e.CommandName == "Readmore")
            {
                lnkread.Text = (lnkread.Text == "Read More") ? "Hide" : "Read More";
                string temp = lblFeatures.Text;
                lblFeatures.Text = lblFeatures.ToolTip;
                lblFeatures.ToolTip = temp;
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

        private void AddProductInCart(int Quantity, string Color, string Size)
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

        protected void ddlLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            BindAllData();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindAllData();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            hdPageNo.Value = "1";
            BindAllData();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            BindAllData();
           // BindAllData(0, 0, 0, 0, 0, 0, "");
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/products.aspx");
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
    }
}