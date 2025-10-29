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

namespace Ecommerce
{
    public partial class Blogs : System.Web.UI.Page
    {     
        string Blogpath = ConfigurationManager.AppSettings["Blogpath"].ToString();
        BlogsCls objBlog = new BlogsCls();

        private BlogsCls objBlogsCls
        {
            get
            {

                if (ViewState["objBlogsCls"] == null)
                {
                    ViewState["objBlogsCls"] = new BlogsCls();
                }
                return (BlogsCls)ViewState["objBlogsCls"];
            }
            set
            {
                ViewState["objBlogsCls"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox.DisabledCssClass = null;
            if (!IsPostBack)
            {
                GetBlogs();
                frmBlog.Style.Add("display", "none");               
            }
        }
        private void GetBlogs()
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Blog |";
            DataSet ds = objAdminCls.GetAllBlogs();
            lstBlog.DataSource = ds.Tables[0];
            lstBlog.DataBind();
            
            resetControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //BlogsCls objBlog = new BlogsCls();
            objBlog.Name = txtName.Text;
            objBlog.Description = txtDescription.Text;
            //temDescription = txtDescription.Text;
            objBlog.URL = txtURL.Text;
            objBlog.MetaTags = txtMetaTags.Text;
            if (imageUpload.HasFile)
            {
                if (imageUpload.PostedFile != null && imageUpload.PostedFile.ContentLength > 0)
                {
                    objBlog.Photo = imageUpload.PostedFile.FileName;
                    imageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(Blogpath, imageUpload.PostedFile.FileName)));

                }
                else
                {
                    return;
                }
            }
            else
            {
                //objBlog.Photo = Blogpath + Path.GetFileName(imgpreview.ImageUrl);
                objBlog.Photo = Path.GetFileName(imgDefault.ImageUrl);
            }
            AdminDL objAdminCls = new AdminDL();
            if (Convert.ToInt32(hdBlogId.Value) > 0)
            {
                hdMessage.Value = "Blog Update |";

                objBlog.Id = Convert.ToInt32(hdBlogId.Value);
                //objBlog.ModifyBy = Convert.ToInt32(Session["UserId"]);
                //objBlog.Createdby = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Blog Insert |";
                objBlog.Id = 0;
                //objBlog.Createdby = Convert.ToInt32(Session["UserId"]);
            }

            //objBlog.sName = txtBlog.Text.Trim();
            //objBlog.bStatus = chkStatus.Checked;


            int Response = objAdminCls.InsertUpdateBlogs(objBlog);
            if (Response > 0)
            {
                GetBlogs();
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmBlog.Style.Add("display", "none");
                tblBlog.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            //else
            //{

            //    hdMessage.Value += "Data not saved successfully please try again...";
            //    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            //}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmBlog.Style.Add("display", "none");
            tblBlog.Style.Add("display", "flex");
        }

        protected void btnCategory_Click1(object sender, EventArgs e)
        {
            frmBlog.Style.Add("display", "flex");
            tblBlog.Style.Add("display", "none");
        }

        private void DeleteBlog(int Id)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Blog Delete |";
            int Response = objAdminCls.DeleteBlog(Id);
            if (Response > 0)
            {
                GetBlogs();
                hdMessage.Value += "Blog Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmBlog.Style.Add("display", "none");
                tblBlog.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Blog not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        private void GetBlog(int Id)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Blog Edit |";
            DataSet ds = objAdminCls.GetBlog(Id);
            //if (Response > 0)
            //{
            //    //GetBlogs();
            //    //hdMessage.Value += "Blog Delete successfully";
            //    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            //    frmBlog.Style.Add("display", "none");
            //    tblBlog.Style.Add("display", "block");
            //}
            //else if (Response == 0)
            //{
            //    hdMessage.Value += "Blog not exists.";
            //    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            //}
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtURL.Text="";
            txtMetaTags.Text = "";
            imgDefault.ImageUrl = "";
            //chkStatus.Checked = false;
            hdBlogId.Value = "0";
            frmBlog.Style.Add("display", "none");
            tblBlog.Style.Add("display", "flex");
        }

        protected void lstBlog_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            HiddenField hdnDescription = new HiddenField();
            List<Blogs> lstBlogs = new List<Blogs>();
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Blog Edit";
            lblMessage.Text = hdMessage.Value;
            DataSet ds = objAdminCls.GetBlog(Convert.ToInt32(hdn.Value));
            //lstBlog.DataSource = ds.Tables[0];
          //  lstBlog.DataBind();
            string title = ds.Tables[0].Rows[0]["sDescription"].ToString();
            Label lblName = e.Item.FindControl("lblName") as Label;
            Label lblDescription = e.Item.FindControl("lblDescription") as Label;
            Label lblCreatedDate = e.Item.FindControl("lblCreatedDate") as Label;
            
            Image imgsPhoto = e.Item.FindControl("imgPhoto") as Image;
            Label lblURL = e.Item.FindControl("lblURL") as Label;
            Label lblMetaTags = e.Item.FindControl("lblMetaTags") as Label;
            LinkButton lnkread = e.Item.FindControl("ReadMoreLinkButton") as LinkButton;
           
            hdBlogId.Value = hdn.Value;

            if (!string.IsNullOrEmpty(lblName.Text))
            {
                if (e.CommandName == "CatEdit")
                {
                    frmBlog.Style.Add("display", "flex");
                    tblBlog.Style.Add("display", "none");
                    //GetBlog(Convert.ToInt32(hdBlogId.Value));
                    txtName.Text = lblName.Text;
                    txtDescription.Text = title;
                    imgDefault.ImageUrl = imgsPhoto.ImageUrl;
                    txtURL.Text = lblURL.Text;
                    txtMetaTags.Text = lblMetaTags.Text;
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteBlog(Convert.ToInt32(hdBlogId.Value));
                }
                else if (e.CommandName == "Readmore")
                {
                    lnkread.Text = (lnkread.Text == "Read More") ? "Hide" : "Read More";
                    string temp = lblDescription.Text;
                    lblDescription.Text = lblDescription.ToolTip;
                    lblDescription.ToolTip = temp;
                }
            }
        }

        protected void btnBlog_Click1(object sender, EventArgs e)
        {
            hdMessage.Value = "Add New";
            lblMessage.Text = hdMessage.Value;
            frmBlog.Style.Add("display", "flex");
            tblBlog.Style.Add("display", "none");
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

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            //BlogsCls objBlog = new BlogsCls();
            if (imageUpload.HasFile)
            {
                //string strGuid = Guid.NewGuid().ToString();
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (imageUpload.PostedFile != null && imageUpload.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)imageUpload.PostedFile.ContentLength)) < MaxSize)
                    {
                        //if (objBlogsCls.Photo == null)
                        //    objBlogsCls.Photo = new List<BlogsCls>();
                        string fileName = CommonControl.GenerateRandomNumber(6) + imageUpload.PostedFile.FileName;
                        imageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(Blogpath, fileName)));
                        objBlog.Photo = fileName;
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
            if (objBlog != null && !string.IsNullOrEmpty(objBlog.Photo))
            {
                imgDefault.ImageUrl = "Image/Blog/" + objBlog.Photo;
            }
            else
            {
                imgDefault.ImageUrl = "Image/Blog/NoImage.png";
            }
        }
    }
}