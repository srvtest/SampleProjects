using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class CreateReview : System.Web.UI.Page
    {
        string ReviewImageFolder = ConfigurationManager.AppSettings["CustomerReviewImage"].ToString();

        private List<ImageCls> lstImageCls
        {
            get
            {
                if (ViewState["lstImageCls"] == null)
                {
                    ViewState["lstImageCls"] = new List<ImageCls>();
                }
                return (List<ImageCls>)ViewState["lstImageCls"];
            }
            set
            {
                ViewState["lstImageCls"] = value;
            }
        }

        private int idProduct
        {
            get
            {
                if (Session["IdProduct"] != null)
                    return Convert.ToInt32(Session["IdProduct"]);
                return 0;
            }
        }
        public string imgProduct
        {
            get
            {
                return Convert.ToString(ViewState["imgProduct"]);
            }
            set
            {
                ViewState["imgProduct"] = value;
            }
        }
        public string productName
        {
            get
            {
                return Convert.ToString(ViewState["productName"]);
            }
            set
            {
                ViewState["productName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                if (idProduct == 0)
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    UserDL objUserDL = new UserDL();
                    DataSet ds = objUserDL.GetProductNameWithImage(idProduct);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        productName = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                        imgProduct = Convert.ToString(ds.Tables[0].Rows[0]["ImageURL"]);
                        hdnidCustomerReview.Value = Convert.ToString(ds.Tables[0].Rows[0]["idCustomerReview"]);
                        hdnRating.Value = Convert.ToString(ds.Tables[0].Rows[0]["starRating"]);
                        txtHeadline.Text = Convert.ToString(ds.Tables[0].Rows[0]["headline"]);
                        txtReview.Text = Convert.ToString(ds.Tables[0].Rows[0]["review"]);
                        string[] images = Convert.ToString(ds.Tables[0].Rows[0]["images"]).Split(new[] { "★" }, StringSplitOptions.RemoveEmptyEntries);

                        if (images.Count() > 0)
                        {
                            lstImageCls = new List<ImageCls>();
                            foreach (var item in images)
                            {
                                lstImageCls.Add(new ImageCls() { Name = item, guid = Convert.ToString(Guid.NewGuid()) });
                            }

                            rptImage.DataSource = lstImageCls;
                            rptImage.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptImage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && !string.IsNullOrEmpty(Convert.ToString(e.CommandArgument)))
            {
                lstImageCls.Remove(lstImageCls.Where(x => x.guid == Convert.ToString(e.CommandArgument)).FirstOrDefault());
                BindReviewImageList();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (reviewImageUpload.HasFile)
            {
                //string strGuid = Guid.NewGuid().ToString();
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (reviewImageUpload.PostedFile != null && reviewImageUpload.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)reviewImageUpload.PostedFile.ContentLength)) < MaxSize)
                    {
                        if (lstImageCls == null)
                            lstImageCls = new List<ImageCls>();
                        string fileName = CommonControl.GenerateRandomNumber(6) + reviewImageUpload.PostedFile.FileName;
                        if (!Directory.Exists(Server.MapPath(ReviewImageFolder)))
                        {
                            Directory.CreateDirectory(Server.MapPath(ReviewImageFolder));
                        }
                        reviewImageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(ReviewImageFolder, fileName)));
                        lstImageCls.Add(new ImageCls() { Name= fileName, guid = Convert.ToString(Guid.NewGuid()) });
                        BindReviewImageList();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void BindReviewImageList()
        {
            rptImage.DataSource = null;
            if (lstImageCls != null && lstImageCls.Count > 0)
                rptImage.DataSource = lstImageCls;
            rptImage.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            CustomerReview objCustomerReview = new CustomerReview();
            objCustomerReview.idProduct = idProduct;
            objCustomerReview.idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            objCustomerReview.idCustomerReview = !string.IsNullOrEmpty(Convert.ToString(hdnidCustomerReview.Value)) ? Convert.ToInt32(hdnidCustomerReview.Value) : 0; 
            objCustomerReview.starRating = !string.IsNullOrEmpty(Convert.ToString(hdnRating.Value)) ? Convert.ToDecimal(hdnRating.Value) : 0;
            objCustomerReview.headline = txtHeadline.Text.Trim();
            objCustomerReview.review = txtReview.Text.Trim();
            foreach (var item in lstImageCls)
            {
                if (item != null)
                {
                    objCustomerReview.imageURL += item.Name + "★";
                }
            }
            
            int Response = objUserDL.InsertUpdateReview(objCustomerReview);
            if (Response > 0)
            {
                lblMsg.Text = "Review saved successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Visible = true;
            }
            else
            {
                lblMsg.Text = "Your review did not save.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }
    }
}