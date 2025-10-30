using DataLayer;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Police_Station_Reporting_System
{
    public partial class frmsurveillance : System.Web.UI.Page
    {
        private List<SurveillanceDto> SurveillanceDetails
        {
            get
            {
                if (ViewState["SurveillanceDetails"] == null)
                {
                    ViewState["SurveillanceDetails"] = new List<SurveillanceDto>();
                }
                return (List<SurveillanceDto>)ViewState["SurveillanceDetails"];
            }
            set
            {
                ViewState["SurveillanceDetails"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadsurveillance("");
            }
        }

        private void Loadsurveillance(string SurveillanceNo)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            ResponseDto response = surveillanceDL.GetSurveillance(Convert.ToInt32(Session["UserId"]), SurveillanceNo);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    SurveillanceDetails = (List<SurveillanceDto>)response.Result;
                    rptSurveillance.DataSource = SurveillanceDetails;
                    rptSurveillance.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                }
            }
            ClearControls();
        }

        protected void rptSurveillance_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                          e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIsTrace") as HiddenField;
                Button btn = e.Item.FindControl("Button1") as Button;
                btn.Visible = (Convert.ToString(hdnId.Value) == "True");
            }
        }

        protected void btnAddSurveillance_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSurveillanceNo.Text))
            {
                SurveillanceDL surveillanceDL = new SurveillanceDL();
                SurveillanceDto surveillanceDto = new SurveillanceDto();
                surveillanceDto.surveillanceDetail = txtSurveillanceNo.Text;
                surveillanceDto.idUser = Convert.ToInt32(Session["UserId"]);
                surveillanceDto.sType = ddlIDType.SelectedValue;
                bool result = SurveillanceDetails.Exists( x => x.surveillanceDetail == txtSurveillanceNo.Text);
                if (result)
                {
                    ResponseDto response = surveillanceDL.InsertUpdateForSurveillance(surveillanceDto);
                    if (response != null)
                    {
                        if (response.StatusCode == 0)
                        {
                            Loadsurveillance("");
                            //lblMessage1.InnerHtml = response.Message;
                            //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "SaveGuestData();", true);
                        }
                        else
                        {
                            Loadsurveillance("");
                            Span1.InnerHtml = response.Message;
                            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "surveillanceData();", true);
                        }
                    }
                }
                else
                {
                    hdnsurveillanceDetail.Value = txtSurveillanceNo.Text;
                    hdnidUser.Value = Convert.ToString(Session["UserId"]);
                    hdnsType.Value = ddlIDType.SelectedValue;
                    if (surveillanceDto.sType== "मोबाइल नंबर")
                    {
                        Span2.InnerHtml = "कृपया ध्यान दें, क्या आप <a href=\"tel://" + surveillanceDto.surveillanceDetail + "\">" + surveillanceDto.surveillanceDetail + "</a> " + surveillanceDto.sType + " को सर्वेलेंस में जोडना चाहते हैं ?";
                    }
                    else
                    {
                        Span2.InnerHtml = "कृपया ध्यान दें, क्या आप "+ surveillanceDto.surveillanceDetail + " " + surveillanceDto.sType + " को सर्वेलेंस में जोडना चाहते हैं ?";
                    }                    
                    Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "QuestionSaveData();", true);                   
                }    
            }            
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            //ClearControls();
            //Loadsurveillance("");
        }

        protected void rptSurveillance_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            if (e.CommandName == "Details")
            {
                HiddenField hdnIdSurveillance = (HiddenField)e.Item.FindControl("hdnIdSurveillance");
                Response.Redirect("frmSurveillanceDetail.aspx?idsurveillance=" + UtilityFunction.Encrypt(Convert.ToString(hdnIdSurveillance.Value)));
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdnIdSurveillance = (HiddenField)e.Item.FindControl("hdnIdSurveillance");
                HiddenField hdnType = (HiddenField)e.Item.FindControl("hdnType");
                if (hdnIdSurveillance.Value != null && hdnType.Value != null)
                {
                    //if (hdnType.Value == "आधार कार्ड" || hdnType.Value == "ड्राइविंग लाइसेंस")
                    //{
                    hdnSurveillanceId.Value = hdnIdSurveillance.Value;
                    Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "QuestionDeleteData();", true);
                    //ResponseDto response = surveillanceDL.DeleteForSurveillance(hdnSurveillanceId.Value);
                    //if (response != null)
                    //{
                    //    if (response.StatusCode == 0)
                    //    {
                    //        Loadsurveillance("");
                    //        Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "DeleteData();", true);
                    //    }
                    //    else
                    //    {
                    //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                    //    }
                    //}
                    //}
                }
                //Response.Redirect("frmSurveillanceDetail.aspx?idsurveillance=" + UtilityFunction.Encrypt(Convert.ToString(hdnIdSurveillance.Value)));
                
            }
            //if (e.CommandName == "Update")
            //{
            //    HiddenField hdnIdSurveillance = (HiddenField)e.Item.FindControl("hdnIdSurveillance");
            //    Response.Redirect("frmSurveillanceDetail.aspx?idsurveillance=" + UtilityFunction.Encrypt(Convert.ToString(hdnIdSurveillance.Value)));
            //}
        }

        protected void ddlIDType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            ResponseDto response = surveillanceDL.DeleteForSurveillance(hdnSurveillanceId.Value);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    Loadsurveillance("");
                    //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "DeleteData();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                }
            }
            //ClearControls();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            SurveillanceDto surveillanceDto = new SurveillanceDto();
            surveillanceDto.surveillanceDetail = hdnsurveillanceDetail.Value;
            surveillanceDto.idUser = Convert.ToInt32(hdnidUser.Value);
            surveillanceDto.sType = hdnsType.Value;
            ResponseDto response = surveillanceDL.InsertUpdateForSurveillance(surveillanceDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    Loadsurveillance("");
                    //lblMessage1.InnerHtml = response.Message;
                    //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "SaveGuestData();", true);
                }
                else
                {
                    //Span1.InnerHtml = response.Message;
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "surveillanceData();", true);
                }
            }
            //ClearControls();
            //Loadsurveillance("");
        }

        protected void btnSurveillanceSearch_Click(object sender, EventArgs e)
        {
            Loadsurveillance(txtSurveillanceId.Text);
            ClearControls();
        }

        private void ClearControls()
        {
            txtSurveillanceNo.Text = "";
            txtSurveillanceId.Text = "";
            ddlIDType.SelectedIndex = 0;
        }
    }
}