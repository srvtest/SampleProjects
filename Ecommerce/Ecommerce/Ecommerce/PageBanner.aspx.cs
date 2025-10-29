using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class PageBanner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPageBanner();
                resetControl();
                frmPageBanner.Style.Add("display", "none");
            }
        }

        private void GetPageBanner()
        {
            AdminDL objAdminCls = new AdminDL();
            rptPageBanner.DataSource = null;
            DataSet ds = objAdminCls.GetAllBanners();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptPageBanner.DataSource = ds.Tables[0];
                rptPageBanner.DataBind();
            }
        }

        protected void btnPageBanner_Click(object sender, EventArgs e)
        {
            resetControl();
            frmPageBanner.Style.Add("display", "flex");
            tblPageBanner.Style.Add("display", "none");
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtDimension.Text = "";
            chkStatus.Checked = false;
            frmPageBanner.Style.Add("display", "none");
            tblPageBanner.Style.Add("display", "inline");
        }

        protected void rptPageBanner_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                AdminDL objAdminCls = new AdminDL();
                DataSet ds = objAdminCls.GetAllBanners(Convert.ToString(e.CommandArgument));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblbStatus.Text = Convert.ToBoolean(ds.Tables[0].Rows[0]["bActive"]) ? "Active" : "Inactive";
                    frmPageBanner.Style.Add("display", "flex");
                    tblPageBanner.Style.Add("display", "none");
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                    //txtLogo.Text = Convert.ToString(ds.Tables[0].Rows[0]["slogo"]);
                    txtDimension.Text = Convert.ToString(ds.Tables[0].Rows[0]["sDimension"]);
                    chkStatus.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["bActive"]);
                }
                hdnPageBannerId.Value = Convert.ToString(e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                DeletePageBanner(Convert.ToInt32(e.CommandArgument));
            }
        }

        private void DeletePageBanner(int Id)
        {
            PageBannersCls objPageBannersCls = new PageBannersCls();
            objPageBannersCls.idPageBanners = Id;
            objPageBannersCls.isDelete = 1;
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Page Banner Delete |";
            int Response = objAdminCls.InsertUpdateDeltePageBanners(objPageBannersCls);
            if (Response > 0)
            {
                hdMessage.Value += "Page Banner Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmPageBanner.Style.Add("display", "none");
                tblPageBanner.Style.Add("display", "block");
                GetPageBanner();
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Page Banner does not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnSavePageBanner_Click(object sender, EventArgs e)
        {
            PageBannersCls objPageBannersCls = new PageBannersCls();
            objPageBannersCls.sName = txtName.Text;
            objPageBannersCls.sDimension = txtDimension.Text;
            objPageBannersCls.bActive = (Int16)(chkStatus.Checked ? 1 : 0);
            objPageBannersCls.idPageBanners = Convert.ToInt32(hdnPageBannerId.Value);
            objPageBannersCls.idCountry = 1;
            string fileName = "";
            if (imageUpload.HasFile)
            {
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (imageUpload.PostedFile != null && imageUpload.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)imageUpload.PostedFile.ContentLength)) < MaxSize)
                    {
                        fileName = CommonControl.GenerateRandomNumber(6) + imageUpload.PostedFile.FileName;
                        if (!Directory.Exists(Server.MapPath("Images/Banners")))
                            Directory.CreateDirectory(Server.MapPath("Images/Banners"));
                        imageUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine("Images/Banners", fileName)));
                        objPageBannersCls.ImageURL = fileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            AdminDL objAdminCls = new AdminDL();
            if (Convert.ToInt32(hdnPageBannerId.Value) > 0)
            {
                hdMessage.Value = "Page Banner Update |";
                objPageBannersCls.ModifiedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Page Banner Insert |";
                objPageBannersCls.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            int Response = objAdminCls.InsertUpdateDeltePageBanners(objPageBannersCls);
            if (Response > 0)
            {
                GetPageBanner();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmPageBanner.Style.Add("display", "none");
                tblPageBanner.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                if (File.Exists(Server.MapPath(Path.Combine("Images/Banners", fileName))))
                    File.Delete(Server.MapPath(Path.Combine("Images/Banners", fileName)));
                hdMessage.Value += "Data not saved. Because already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancelPageBanner_Click(object sender, EventArgs e)
        {
            frmPageBanner.Style.Add("display", "none");
            tblPageBanner.Style.Add("display", "inline");
        }
    }
}