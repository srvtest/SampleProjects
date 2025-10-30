using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class HotelLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the browser capabilities
            HttpBrowserCapabilities browser = Request.Browser;
            string userAgent = HttpContext.Current.Request.UserAgent;
            // Get browser name and version
            string browserName = browser.Browser;
            string browserVersion = browser.Version;

            // Display the browser name and version
            //Response.Write("Browser: " + browserName + "<br>");
            //Response.Write("Version: " + browserVersion + "<br>");
          
            // Check if the browser is Firefox
            if (userAgent != null && userAgent.Contains("Edg"))
            {
                // Redirect to a custom error page or display an error message
                Response.Redirect("~/UnsupportedBrowser.aspx");
                // Or show a message
                // Response.Write("This website is not supported in Firefox. Please use Chrome or Edge.");
            }
            else
            {
                if (browserName.Contains("Firefox"))
                {
                    int ver = string.Compare(browserVersion, ConfigurationManager.AppSettings["FirefoxVersion"].ToString());
                    if (ver < 0)
                    {
                        Response.Redirect("~/defaultPage.aspx");
                    }
                }
                else if (browserName.Contains("Chrome"))
                {
                    int ver = string.Compare(browserVersion, ConfigurationManager.AppSettings["ChromeVersion"].ToString());
                    if (ver < 0)
                    {
                        Response.Redirect("~/defaultPage.aspx");
                    }
                }
            }
        }

        protected void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            spnmsg.Visible = false;
            spnmsgSuccess.Visible = false;
            string OTP = txtOTP.Text + txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;
            LoginDL objLoginDL = new LoginDL();
            ResponseDto response = objLoginDL.ValidateHotelLogin(txtMobileNo.Text, OTP);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    HotelMasterDto hotelMasterDto = (HotelMasterDto)response.Result;
                    if (hotelMasterDto != null)
                    {
                        Session["snsHotelId"] = hotelMasterDto.idHotelMaster;
                        Session["snsHotelName"] = hotelMasterDto.HotelName;
                        Session["snsHotelContact"] = hotelMasterDto.Contact;
                        Session["snsHotelAddress"] = hotelMasterDto.Address + ", "+ hotelMasterDto.CityName;
                        Session["snspoliceContact"] = hotelMasterDto.policeContact;

                        HttpCookie hotelInfo = new HttpCookie("hotelInfo");
                        string str = Convert.ToString(Session["snsHotelId"]) + "~" + Convert.ToString(Session["snsHotelName"]) + "~" +
                            Convert.ToString(Session["snsHotelContact"]) + "~" + Convert.ToString(Session["snsHotelAddress"]);

                        hotelInfo["RdataHotel"] = UtilityFunction.Encrypt(str);
                        Response.Redirect("Dashboard.aspx");
                    }
                }
                else
                {
                    spnmsg.Visible = true;
                    spnmsg.InnerText = response.Message;
                }
            }
        }

        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            string MobileOTP = Convert.ToString(generator.Next(100000, 1000000));
            if (ConfigurationManager.AppSettings["test"].ToString() == "1")
            {
                MobileOTP = "123456";
            }
            LoginDL objLoginDL = new LoginDL();
            spnmsg.Visible = false;
            spnPlan.Visible = false;
            spnmsgSuccess.Visible = false;
            ResponseDto response = objLoginDL.SetOTP(txtMobileNo.Text, MobileOTP);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    if (ConfigurationManager.AppSettings["test"].ToString() != "1")
                    {
                        string sSms = "Hello, Your OTP to Login is " + MobileOTP + " Thanks Fanatical Technologies";
                        UtilityFunction.SendSMS(sSms, txtMobileNo.Text, ConfigurationManager.AppSettings["TemplateIdOtp"].ToString());
                    }
                    spnmsgSuccess.Visible = true;
                    spnmsgSuccess.InnerText = "OTP send successfully.";
                    btnSendOTP.Visible = false;
                    btnResend.Visible = true;
                }
                else
                {
                    if (response.StatusCode == 1)
                    {
                        spnPlan.Visible = true;
                        spnPlan.InnerHtml = "आपका सब्सक्रिप्शन प्लान समाप्त हो गया है। कृपया नीचे दिए गए लिंक पर जाकर अपना प्लान सक्रिय करें। <a href = \"subscribePlan.aspx?MobileNo=" + txtMobileNo.Text + "\"> Click here...</a>";
                    }
                    else
                    {
                        spnmsg.Visible = true;
                        spnmsg.InnerText = response.Message;
                    }
                    //spnmsg.Visible = true;
                    //spnmsg.InnerText = response.Message;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}