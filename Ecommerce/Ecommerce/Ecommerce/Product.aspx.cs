using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Product : System.Web.UI.Page
    {
        //List<ProductImageCls> lstDeletedProductImg;
        //List<ProductVideoCls> lstDeletedProductVideo;
        AdminDL objAdminCls = null;
        string ProductImageFolder = ConfigurationManager.AppSettings["ProductImageFolder"].ToString();
        string ProductVideoFolder = ConfigurationManager.AppSettings["ProductVideoFolder"].ToString();

        private ProductCls objProductCls
        {
            get
            {

                if (ViewState["objProductCls"] == null)
                {
                    ViewState["objProductCls"] = new ProductCls();
                }
                return (ProductCls)ViewState["objProductCls"];
            }
            set
            {
                ViewState["objProductCls"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            objAdminCls = new AdminDL();
            if (!IsPostBack)
            {
                GetProducts();
                frmProduct.Style.Add("display", "none");


                //FilterProductsCls obj = new FilterProductsCls();
                //obj.lstMasterCategory = new List<MasterCategoryCls>();
                //obj.lstMasterCategory.Add(new MasterCategoryCls { idMasterCategory = 1 });
                //obj.lstCollection = new List<CollectionCls>();
                //obj.lstCollection.Add(new CollectionCls { idCollection = 1 });
                //obj.lstMaterial = new List<MaterialCls>();
                //obj.lstMaterial.Add(new MaterialCls { idMaterial = 1 });
                //obj.lstGemstone = new List<GemstoneCls>();
                //obj.lstGemstone.Add(new GemstoneCls { idGemstone = 1 });
                //obj.lstGender = new List<GenderCls>();
                //obj.lstGender.Add(new GenderCls { idGender = 1 });

                //string str= obj.ToXML();


            }
        }

        private void GetProducts()
        {
            DataSet ds = objAdminCls.GetAllProducts();
            lstProduct.DataSource = ds.Tables[0];
            lstProduct.DataBind();
            ClearControls();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearControls();
            BindAllDropdown();
            frmProduct.Style.Add("display", "flex");
            tblProduct.Style.Add("display", "none");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmProduct.Style.Add("display", "none");
            tblProduct.Style.Add("display", "flex");
        }

        private void BindAllDropdown()
        {
            DataSet dsMasterCategory = objAdminCls.GetAllMasterCategory();
            ddlMasterCategory.DataSource = dsMasterCategory.Tables[0];
            ddlMasterCategory.DataTextField = "sName";
            ddlMasterCategory.DataValueField = "idMasterCategory";
            ddlMasterCategory.DataBind();
            ddlMasterCategory.Items.Insert(0, new ListItem() { Text = "Select Master Category", Value = "0" });

            DataSet dsCategory = objAdminCls.GetAllCategory();
            ddlCategory.DataSource = dsCategory.Tables[0];
            ddlCategory.DataTextField = "sName";
            ddlCategory.DataValueField = "idCategory";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem() { Text = "Select Category", Value = "0" });

            DataSet dsCollection = objAdminCls.GetAllCollection();
            ddlCollection.DataSource = dsCollection.Tables[0];
            ddlCollection.DataTextField = "sName";
            ddlCollection.DataValueField = "idCollection";
            ddlCollection.DataBind();
            ddlCollection.Items.Insert(0, new ListItem() { Text = "Select Collection", Value = "0" });

            DataSet dsMaterial = objAdminCls.GetAllMaterial();
            ddlMaterial.DataSource = dsMaterial.Tables[0];
            ddlMaterial.DataTextField = "sName";
            ddlMaterial.DataValueField = "idMaterial";
            ddlMaterial.DataBind();
            ddlMaterial.Items.Insert(0, new ListItem() { Text = "Select Material", Value = "0" });

            DataSet dsGemstone = objAdminCls.GetAllGemstone();
            ddlGemstone.DataSource = dsGemstone.Tables[0];
            ddlGemstone.DataTextField = "sName";
            ddlGemstone.DataValueField = "idGemstone";
            ddlGemstone.DataBind();
            ddlGemstone.Items.Insert(0, new ListItem() { Text = "Select Gemstone", Value = "0" });

            DataSet dsGender = objAdminCls.GetAllGender();
            ddlGender.DataSource = dsGender.Tables[0];
            ddlGender.DataTextField = "sName";
            ddlGender.DataValueField = "idGender";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem() { Text = "Select Gender", Value = "0" });

            DataSet dsColor = objAdminCls.GetAllColor();
            ddlColor.DataSource = dsColor.Tables[0];
            ddlColor.DataTextField = "sName";
            ddlColor.DataValueField = "idColor";
            ddlColor.DataBind();
            ddlColor.Items.Insert(0, new ListItem() { Text = "Select Color", Value = "0" });

            DataSet dsSize = objAdminCls.GetAllSize();
            ddlSize.DataSource = dsSize.Tables[0];
            ddlSize.DataTextField = "sName";
            ddlSize.DataValueField = "idSize";
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, new ListItem() { Text = "Select Size", Value = "0" });

            DataSet dsShape = objAdminCls.GetAllShape();
            ddlShape.DataSource = dsShape.Tables[0];
            ddlShape.DataTextField = "sName";
            ddlShape.DataValueField = "idShape";
            ddlShape.DataBind();
            ddlShape.Items.Insert(0, new ListItem() { Text = "Select Shape", Value = "0" });



        }

        protected void lstProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
            Label lblFeatures = e.Item.FindControl("lblFeatures") as Label;
            if (e.CommandName == "delete")
            {
                int Response = objAdminCls.DeleteProduct(Convert.ToInt32(e.CommandArgument));
                if (Response > 0)
                {
                    GetProducts();
                    hdMessage.Value += "Data deleted successfully";
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                    frmProduct.Style.Add("display", "none");
                    tblProduct.Style.Add("display", "block");
                }
                else
                {
                    hdMessage.Value += "Data not deleted, please try again...";
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                }
            }
            else if (e.CommandName == "edit")
            {
                BindAllDropdown();
                DataSet ds = objAdminCls.GetProductInfo(Convert.ToInt32(e.CommandArgument));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    ProductCls product = new ProductCls();
                    product.idProduct = Convert.ToInt32(ds.Tables[0].Rows[0]["idProduct"]);
                    product.sName = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                    product.SEOName = Convert.ToString(ds.Tables[0].Rows[0]["SEOName"]);
                    product.idCategory = Convert.ToInt32(ds.Tables[0].Rows[0]["idCategory"]);
                    product.Features = Convert.ToString(ds.Tables[0].Rows[0]["Features"]);
                    product.ImageURL = Convert.ToString(ds.Tables[0].Rows[0]["ImageURL"]);
                    product.IsFeatureProduct = Convert.ToInt16(ds.Tables[0].Rows[0]["IsFeatureProduct"]);
                    product.bStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["bStatus"]);
                    product.idMasterCategory = Convert.ToInt32(ds.Tables[0].Rows[0]["idMasterCategory"]);
                    product.idCollection = Convert.ToInt32(ds.Tables[0].Rows[0]["idCollection"]);
                    product.idMaterial = Convert.ToInt32(ds.Tables[0].Rows[0]["idMaterial"]);
                    product.idGemstone = Convert.ToInt32(ds.Tables[0].Rows[0]["idGemstone"]);
                    product.idGender = Convert.ToInt32(ds.Tables[0].Rows[0]["idGender"]);

                    product.idColor = Convert.ToInt32(ds.Tables[0].Rows[0]["idColor"]);
                    product.idSize = Convert.ToInt32(ds.Tables[0].Rows[0]["idSize"]);
                    product.idShape = Convert.ToInt32(ds.Tables[0].Rows[0]["idShape"]);

                    if (ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        product.ProductImageCls = new List<ProductImageCls>();
                        ProductImageCls productImage = null;

                        foreach (DataRow item in ds.Tables[1].Rows)
                        {
                            productImage = new ProductImageCls();
                            productImage.imageurl = Convert.ToString(item["imageurl"]);
                            productImage.ImageName = Convert.ToString(item["ImageName"]);
                            productImage.bStatus = Convert.ToInt16(item["bStatus"]);
                            productImage.idProductImage = Convert.ToInt32(item["idProductImage"]);
                            productImage.guid = Convert.ToString(Guid.NewGuid());
                            product.ProductImageCls.Add(productImage);
                        }
                    }
                    if (ds.Tables.Count > 2 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        product.ProductVideoCls = new List<ProductVideoCls>();
                        ProductVideoCls productVideo = null;
                        foreach (DataRow item in ds.Tables[2].Rows)
                        {
                            productVideo = new ProductVideoCls();
                            productVideo.Videourl = Convert.ToString(item["Videourl"]);
                            productVideo.VideoName = Convert.ToString(item["VideoName"]);
                            productVideo.bStatus = Convert.ToInt16(item["bStatus"]);
                            productVideo.idProductVideo = Convert.ToInt32(item["idProductVideo"]);
                            productVideo.guid = Convert.ToString(Guid.NewGuid());
                            product.ProductVideoCls.Add(productVideo);
                        }
                    }

                    if (product != null)
                    {
                        hdProductId.Value = Convert.ToString(product.idProduct);
                        txtProductName.Text = product.sName;
                        txtSEOName.Text = product.SEOName;
                        txtFeature.Text = product.Features;
                        ddlCategory.SelectedValue = Convert.ToString(product.idCategory);
                        chkStatus.Checked = product.bStatus == 1 ? true : false;
                        chkIsFeatureProduct.Checked = product.IsFeatureProduct == 1 ? true : false;
                        objProductCls = product;
                        if (product.ProductImageCls != null && product.ProductImageCls.Count > 0)
                        {
                            BindProductImageList();
                        }
                        if (product.ProductVideoCls != null && product.ProductVideoCls.Count > 0)
                        {
                            BindProductVideoList();
                        }

                        ddlCategory.SelectedValue = Convert.ToString(product.idCategory);
                        ddlMasterCategory.SelectedValue = Convert.ToString(product.idMasterCategory);
                        ddlCollection.SelectedValue = Convert.ToString(product.idCollection);
                        ddlMaterial.SelectedValue = Convert.ToString(product.idMaterial);
                        ddlGemstone.SelectedValue = Convert.ToString(product.idGemstone);
                        ddlGender.SelectedValue = Convert.ToString(product.idGender);

                        ddlColor.SelectedValue = Convert.ToString(product.idColor);
                        ddlSize.SelectedValue = Convert.ToString(product.idSize);
                        ddlShape.SelectedValue = Convert.ToString(product.idShape);

                        UpdateDefaultImage();
                        frmProduct.Style.Add("display", "block");
                        tblProduct.Style.Add("display", "none");
                    }
                }
                else
                {
                    hdMessage.Value = "Data not getting, please try again...";
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            if (Convert.ToInt32(hdProductId.Value) > 0)
            {
                hdMessage.Value = "Product Update |";
                objProductCls.idProduct = Convert.ToInt32(hdProductId.Value);
                objProductCls.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Product Insert |";
                objProductCls.idProduct = 0;
                objProductCls.Createdby = Convert.ToInt32(Session["UserId"]);
            }
            objProductCls.sName = txtProductName.Text.Trim();
            objProductCls.SEOName = txtSEOName.Text.Trim();
            objProductCls.idCategory = Convert.ToInt32(ddlCategory.SelectedValue);
            objProductCls.Features = txtFeature.Text.Trim();
            objProductCls.IsFeatureProduct = (Int16)(chkIsFeatureProduct.Checked ? 1 : 0);
            objProductCls.bStatus = (Int16)(chkStatus.Checked ? 1 : 0);

            objProductCls.idMasterCategory = Convert.ToInt32(ddlMasterCategory.SelectedValue);
            objProductCls.idCollection = Convert.ToInt32(ddlCollection.SelectedValue);
            objProductCls.idMaterial = Convert.ToInt32(ddlMaterial.SelectedValue);
            objProductCls.idGemstone = Convert.ToInt32(ddlGemstone.SelectedValue);
            objProductCls.idGender = Convert.ToInt32(ddlGender.SelectedValue);

            objProductCls.idColor = Convert.ToInt32(ddlColor.SelectedValue);
            objProductCls.idSize = Convert.ToInt32(ddlSize.SelectedValue);
            objProductCls.idShape = Convert.ToInt32(ddlShape.SelectedValue);

            //string imgUrl = "";
            string productImagePath = Server.MapPath(ProductImageFolder);
            string productVideoPath = Server.MapPath(ProductVideoFolder);
            if (objProductCls.ProductImageCls == null)
            {

            }
            else
            {
                foreach (ProductImageCls image in objProductCls.ProductImageCls.Where(X => X.bStatus == 3))
                {
                    if (Directory.Exists(productImagePath))
                    {
                        string filePath = productImagePath + image.imageurl;
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                }
            }
            if (objProductCls.ProductVideoCls == null)
            {

            }
            else
            {
                foreach (ProductVideoCls image in objProductCls.ProductVideoCls.Where(X => X.bStatus == 3))
                {
                    if (Directory.Exists(productVideoPath))
                    {
                        string filePath = productVideoPath + image.Videourl;
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                }
            }
            int Response = objAdminCls.InsertUpdateProductDetail(objProductCls);
            if (Response == 0)
            {
                GetProducts();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmProduct.Style.Add("display", "none");
                tblProduct.Style.Add("display", "block");
            }
            else
            {
                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (productImageUpload.HasFile)
            {
                //string strGuid = Guid.NewGuid().ToString();
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (productImageUpload.PostedFile != null && productImageUpload.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)productImageUpload.PostedFile.ContentLength)) < MaxSize)
                    {
                        if (objProductCls.ProductImageCls == null)
                            objProductCls.ProductImageCls = new List<ProductImageCls>();
                        string fileName = CommonControl.GenerateRandomNumber(6) + productImageUpload.PostedFile.FileName;
                        productImageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(ProductImageFolder, fileName)));
                        objProductCls.ProductImageCls.Add(new ProductImageCls() { imageurl = fileName, idProductImage = 0, bStatus = 1, guid = Convert.ToString(Guid.NewGuid()) });
                        BindProductImageList();
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        //protected void btnUploadVideo_Click(object sender, EventArgs e)
        //{
        //    if (productVideoUpload.HasFile)
        //    {
        //        int MaxSize = 100 * 1024 * 1024;//100MB
        //        if (productVideoUpload.PostedFile != null && productVideoUpload.PostedFile.ContentLength > 0)
        //        {
        //            if (Math.Round(((decimal)productVideoUpload.PostedFile.ContentLength)) < MaxSize)
        //            {
        //                if (objProductCls.ProductVideoCls == null)
        //                    objProductCls.ProductVideoCls = new List<ProductVideoCls>();

        //                string fileName = CommonControl.GenerateRandomNumber(6) + productVideoUpload.PostedFile.FileName;
        //                productVideoUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(ProductVideoFolder, fileName)));
        //                objProductCls.ProductVideoCls.Add(new ProductVideoCls() { Videourl = fileName, idProductVideo = 0, bStatus =  1 , guid = Convert.ToString(Guid.NewGuid()) });
        //                BindProductVideoList();
        //            }
        //            else
        //                return;
        //        }
        //    }
        //}

        public void BindProductImageList()
        {
            rptimage.DataSource = null;
            if (objProductCls != null && objProductCls.ProductImageCls != null && objProductCls.ProductImageCls.Where(x => x.bStatus < 3).Count() > 0)
                rptimage.DataSource = objProductCls.ProductImageCls.Where(x => x.bStatus < 3).ToList();
            rptimage.DataBind();
        }

        public void BindProductVideoList()
        {
            rptVideo.DataSource = null;
            if (objProductCls != null && objProductCls.ProductVideoCls != null && objProductCls.ProductVideoCls.Where(x => x.bStatus < 3).Count() > 0)

                rptVideo.DataSource = objProductCls.ProductVideoCls.Where(x => x.bStatus < 3).ToList();
            rptVideo.DataBind();
        }

        //protected void grdImageList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    List<ProductImageCls> lstProductImageCls = new List<ProductImageCls>();
        //    Guid hdnDelGuid = new Guid(((HiddenField)grdImageList.Rows[e.RowIndex].FindControl("hdnGuid")).Value);
        //    for (int i = 0; i < grdImageList.Rows.Count; i++)
        //    {
        //        Int16 bStatus = Convert.ToInt16(((HiddenField)grdImageList.Rows[i].FindControl("hdnStatus")).Value);
        //        int idProductImage = Convert.ToInt32(((HiddenField)grdImageList.Rows[i].FindControl("hdnIdProductImage")).Value);
        //        string imageurl = Convert.ToString(((Label)grdImageList.Rows[i].FindControl("lblImageurl")).Text);
        //        Guid hdnGuid = new Guid(((HiddenField)grdImageList.Rows[i].FindControl("hdnGuid")).Value);
        //        lstProductImageCls.Add(new ProductImageCls() { imageurl = imageurl, idProductImage = idProductImage, bStatus = bStatus, guid = hdnGuid });
        //    }
        //    lstDeletedProductImg = new List<ProductImageCls>();
        //    ProductImageCls objProductImageCls = lstProductImageCls.Where(a => a.guid == hdnDelGuid).FirstOrDefault();
        //    if (ViewState["DeletedImage"] != null)
        //    {
        //        List<ProductImageCls> objList = ViewState["DeletedImage"] as List<ProductImageCls>;
        //        foreach (ProductImageCls obj in objList)
        //        {
        //            lstDeletedProductImg.Add(obj);
        //        }
        //        lstDeletedProductImg.Add(objProductImageCls);
        //        ViewState["DeletedImage"] = lstDeletedProductImg;
        //    }
        //    else
        //    {
        //        lstDeletedProductImg.Add(objProductImageCls);
        //        ViewState["DeletedImage"] = lstDeletedProductImg;
        //    }
        //    lstProductImageCls.RemoveAt(e.RowIndex);
        //    grdImageList.DataSource = lstProductImageCls;
        //    grdImageList.DataBind();
        //}

        public void ClearControls()
        {
            hdProductId.Value = Convert.ToString(0);
            txtProductName.Text = "";
            txtSEOName.Text = "";
            txtFeature.Text = "";
            ddlCategory.SelectedIndex = -1;
            imgDefault.ImageUrl = "";
            chkStatus.Checked = true;
            chkIsFeatureProduct.Checked = false;
            rptimage.DataSource = null;
            rptimage.DataBind();
            rptVideo.DataSource = null;
            rptVideo.DataBind();
            objProductCls = new ProductCls();
        }

        protected void rptimage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnIdProductImage = e.Item.FindControl("hdnIdProductImage") as HiddenField;
            HiddenField hdnGuid = e.Item.FindControl("hdnGuid") as HiddenField;

            if (!string.IsNullOrEmpty(hdnGuid.Value))
            {
                if (e.CommandName == "Edit")
                {
                    objProductCls.ProductImageCls.Where(w => w.guid == hdnGuid.Value).ToList().ForEach(i => i.bStatus = (i.bStatus == 0 ? (Int16)1 : (Int16)0));
                }
                else if (e.CommandName == "Delete")
                {
                    objProductCls.ProductImageCls.Where(w => w.guid == hdnGuid.Value).ToList().ForEach(i => i.bStatus = 3);
                }
            }
            BindProductImageList();
        }

        protected void rptVideo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdnIdProductImage = e.Item.FindControl("hdnidProductVideo") as HiddenField;
            HiddenField hdnGuid = e.Item.FindControl("hdnGuid") as HiddenField;

            if (!string.IsNullOrEmpty(hdnGuid.Value))
            {
                if (e.CommandName == "Edit")
                {
                    objProductCls.ProductVideoCls.Where(w => w.guid == hdnGuid.Value).ToList().ForEach(i => i.bStatus = (i.bStatus == 0 ? (Int16)1 : (Int16)0));
                }
                else if (e.CommandName == "Delete")
                {
                    objProductCls.ProductVideoCls.Where(w => w.guid == hdnGuid.Value).ToList().ForEach(i => i.bStatus = 3);
                }
            }
            BindProductVideoList();

        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (imageUpload.HasFile)
            {
                //string strGuid = Guid.NewGuid().ToString();
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (imageUpload.PostedFile != null && imageUpload.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)imageUpload.PostedFile.ContentLength)) < MaxSize)
                    {
                        if (objProductCls.ProductImageCls == null)
                            objProductCls.ProductImageCls = new List<ProductImageCls>();
                        string fileName = CommonControl.GenerateRandomNumber(6) + imageUpload.PostedFile.FileName;
                        imageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(ProductImageFolder, fileName)));
                        objProductCls.ImageURL = fileName;
                        UpdateDefaultImage();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void UpdateDefaultImage()
        {
            if (objProductCls != null && !string.IsNullOrEmpty(objProductCls.ImageURL))
            {
                imgDefault.ImageUrl = "ProductImage/" + objProductCls.ImageURL;
            }
            else
            {
                imgDefault.ImageUrl = "ProductImage/NoImage.png";
            }
        }

        //protected void btnAdd_Click1(object sender, EventArgs e)
        //{

        //}

        protected void btnAddVideo_Click(object sender, EventArgs e)
        {
            if (objProductCls != null && objProductCls.ProductVideoCls != null)
                objProductCls.ProductVideoCls.Add(new ProductVideoCls { VideoName = txtVideoName.Text, Videourl = txtVideoUrl.Text, bStatus = 1 });
            BindProductVideoList();
        }

        [WebMethod]
        public static string[] GetProducts(string prefix)
        {
            List<string> products = new List<string>();
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetSearchProduct(prefix);
            if (ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    products.Add(string.Format("{0}-{1}", ds.Tables[0].Rows[i]["sName"], ds.Tables[0].Rows[i]["idSimilerProduct"]));
                }
            }
            return products.ToArray();
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