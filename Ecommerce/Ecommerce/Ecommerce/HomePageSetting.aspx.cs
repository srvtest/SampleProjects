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
    public partial class HomePageSetting : System.Web.UI.Page
    {
        string imagePath = ConfigurationManager.AppSettings["Imagepath"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetHomeSliders();
                frmHomePageSlider.Style.Add("display", "none");
            }
        }

        private void GetHomeSliders()
        {
            AdminDL objAdminCls = new AdminDL();
            DataSet ds = objAdminCls.GetAllHomeImageSlider();
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            resetControl();
            imgUpload.Visible = true;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            AdminDL objAdminCls = new AdminDL();
            HomeSliderCls objHomeSliderCls = new HomeSliderCls();
            objHomeSliderCls.idHomeSlider = Convert.ToInt32(hdHomeImageSliderId.Value);
            objHomeSliderCls.sName = txtHomeSlider.Text.Trim();
            objHomeSliderCls.bStatus = chkStatus.Checked;
            objHomeSliderCls.URL = txtUrl.Text;
            objHomeSliderCls.isB2B = chkIsB2B.Checked;
            objHomeSliderCls.sText1 = txtText1.Text;
            objHomeSliderCls.sText2 = txtText2.Text;
            objHomeSliderCls.sAlign = txtAlign.Text;
            objHomeSliderCls.isShowHide = chkShowHide.Checked;

            if (imgUpload.HasFile)
            {
                if (imgUpload.PostedFile != null && imgUpload.PostedFile.ContentLength > 0)
                {
                    objHomeSliderCls.ImageURL = imgUpload.PostedFile.FileName;
                    imgUpload.PostedFile.SaveAs(Server.MapPath(Path.Combine(imagePath+"HomeSlider\\", imgUpload.PostedFile.FileName)));
                }
                else
                {
                    return;
                }
            }

            int Response = objAdminCls.SaveHomeSliderImage(objHomeSliderCls);
            if (Response > 0)
            {
                //ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                GetHomeSliders();
                frmHomePageSlider.Style.Add("display", "none");
                lstHomePageSlider.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmHomePageSlider.Style.Add("display", "none");
            lstHomePageSlider.Style.Add("display", "flex");
            resetControl();
            GetHomeSliders();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            frmHomePageSlider.Style.Add("display", "flex");
            lstHomePageSlider.Style.Add("display", "none");
           
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lblstatus = e.Item.FindControl("lblStatus") as Label;
            Label lblsName = e.Item.FindControl("lblsName") as Label;
            Label lblUrl = e.Item.FindControl("lblUrl") as Label;
            Label lblIsB2B = e.Item.FindControl("lblIsB2B") as Label;
            HiddenField hdn = e.Item.FindControl("hdnId") as HiddenField;
            HiddenField hdnText1 = e.Item.FindControl("hdnText1") as HiddenField;
            HiddenField hdnText2 = e.Item.FindControl("hdnText2") as HiddenField;
            HiddenField hdnAlign = e.Item.FindControl("hdnAlign") as HiddenField;
            HiddenField hdnShow = e.Item.FindControl("hdnShow") as HiddenField;
            hdHomeImageSliderId.Value = hdn.Value;
            if (!string.IsNullOrEmpty(lblsName.Text))
            {
                if (e.CommandName == "CatEdit")
                {
                    frmHomePageSlider.Style.Add("display", "flex");
                    lstHomePageSlider.Style.Add("display", "none");
                    txtHomeSlider.Text = lblsName.Text;
                    chkStatus.Checked = (lblstatus.Text.ToUpper() == "ACTIVE");
                    txtUrl.Text = lblUrl.Text;
                    txtText1.Text = hdnText1.Value;
                    txtText2.Text = hdnText2.Value;
                    txtAlign.Text = hdnAlign.Value;
                    chkShowHide.Checked = (hdnShow.Value.ToUpper() == "ACTIVE");
                    imgUpload.Visible = false;
                    chkIsB2B.Checked = (lblIsB2B.Text.ToUpper() == "ACTIVE");
                }
                else if (e.CommandName == "CatDelete")
                {
                    DeleteHomePageSlider(Convert.ToInt32(hdHomeImageSliderId.Value));
                }

            }
        }

        private void DeleteHomePageSlider(int idHomePageSlider)
        {
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Category Delete |";
            int Response = objAdminCls.DeleteHomeSlider(idHomePageSlider);
            if (Response > 0)
            {
                GetHomeSliders();
                hdMessage.Value += "Home Page Slider Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmHomePageSlider.Style.Add("display", "none");
                lstHomePageSlider.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Home Page Slider not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        private void resetControl() {
            txtHomeSlider.Text = "";
            chkStatus.Checked = true;
            txtUrl.Text = "";
            chkIsB2B.Checked = false;
            txtText1.Text = "";
            txtText2.Text = "";
            txtAlign.Text = "";
            chkShowHide.Checked = false;
            hdHomeImageSliderId.Value = "0";
            frmHomePageSlider.Style.Add("display", "none");
            lstHomePageSlider.Style.Add("display", "flex");
            imgUpload.Visible = true;
        }
    }
}