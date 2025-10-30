using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Guest_Reporting_System
{
    public partial class SubmitData : System.Web.UI.Page
    {
        private DateTime submitdate
        {
            get
            {
                string _submitdate = Request.QueryString["submitdate"];
                _submitdate = UtilityFunction.Decrypt(_submitdate);
                if (string.IsNullOrEmpty(_submitdate))
                {
                    _submitdate = DateTime.Now.AddDays(-1).Date.ToShortDateString();
                }
                return Convert.ToDateTime(_submitdate);
            }
        }
        private string EmailId
        {
            get
            {
                string EmailId = Request.QueryString["EmailId"];
                EmailId = UtilityFunction.Decrypt(EmailId);                
                return EmailId;
            }
        }
        private string YcheckIn
        {
            get
            {
                string YcheckIn = Convert.ToString(Request.QueryString["YcheckIn"]);
                return YcheckIn;
            }
        }

        private int snsHotelId
        {
            get
            {
                if (Session["snsHotelId"] == null)
                {
                    Session["snsHotelId"] = 0;
                }
                return (int)Session["snsHotelId"];
            }
            set
            {
                Session["snsHotelId"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                string strMonthName = mfi.GetMonthName(submitdate.Month).ToString(); //August
                SpDateCom.InnerText = spDateN.InnerText = spDate.InnerText = submitdate.Day.ToString() + "-" + strMonthName;


                GuestMasterDL objGuestMasterDL = new GuestMasterDL();
                ResponseDto response = objGuestMasterDL.ValidateSubmitDate(snsHotelId, submitdate);
                if (response != null)
                {
                    int count = (int)response.Result;
                    if (count == 0)
                    {
                        int totalGuest = 0;
                        ResponseDto obj = objGuestMasterDL.GetPandingGuestByHotelId(snsHotelId, submitdate);
                        if (obj != null)
                        {
                            if (obj.StatusCode == 0)
                            {
                                List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                                if (userDto != null)
                                {
                                    totalGuest = userDto.Sum(x => x.AddionalGuest);
                                }
                            }
                        }
                        divSubmit.Visible = true;
                        Button4.Visible = false;
                        if (totalGuest == 0)
                        {
                            lblmasg.InnerText = "तारीख " + submitdate.ToString("dd-MMMM-yyyy") + " को मेरी होटल में कोई गेस्ट नहीं रुका था |";
                        }
                        else
                        {
                            if (YcheckIn == "a18qp9ytr")
                            {
                                lblmasg.InnerText = "आपने पहले ही तारीख " + submitdate.ToString("dd-MMMM-yyyy") + " के लिए गेस्ट  की चेक इन एंट्री कर ली है , इसलिए यह विकल्प आपके लिए निष्क्रिय है।\r\n यहां से आप केवल तभी रिपोर्ट सबमिट कर सकते हैं यदि आपके होटल में 0 चेक इन हैं।";
                                divSubmit.Visible = false;
                                Button4.Visible = true;
                                Button1.Visible = false;
                                lblData.Visible = false;
                            }
                            else
                           
                                lblmasg.InnerText = "तारीख " + submitdate.ToString("dd-MMMM-yyyy") + " को मेरी होटल में टोटल " + totalGuest + " गेस्ट रुके थे |";
                        }
                    }
                    else
                    {
                        lblmasg.InnerText = "तारीख " + submitdate.ToString("dd-MMMM-yyyy") + " की रिपोर्ट सबमिट हो चुकी है |";
                        divSubmit.Visible = false;
                        Button1.Visible = false;
                        lblData.Visible = false;
                    }

                }


            }
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(Session["snsHotelId"]);
            guestFilterDto.SubmitDate = submitdate;
            guestFilterDto.SubmitBy = txtName.Text;
            string par = Convert.ToString(submitdate) + "$$" + Convert.ToString(submitdate);
            par = UtilityFunction.Encrypt(par);
            ResponseDto response = objuserDL.SubmitGuestData(guestFilterDto);
            if (response.StatusCode == 0)
            {
                SpDateCom.InnerText = response.Message;
                Page.ClientScript.RegisterStartupScript(GetType(), "OpenWindow", "window.open('ReportGuestDetail.aspx?para="+ par +"&sendMail=1','_newtab');", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestDataCom()", true);
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            string para = Convert.ToString(submitdate) + "$$" + Convert.ToString(submitdate);
            Response.Redirect("ReportGuestDetail.aspx?para=" + UtilityFunction.Encrypt(para));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData();", true);
        }
    }
}