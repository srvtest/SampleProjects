using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class PolicestationLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoginDL objLoginDL = new LoginDL();
            spnmsg.Visible = false;
            spnmsgSuccess.Visible = false;
            string OTP = txtOTP.Text + txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;
            ResponseDto response = objLoginDL.ValidatePoliceStationLogin(txtMobileNo.Text, OTP);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    UserDto user = (UserDto)response.Result;
                    if (user != null)
                    {
                        Session["UserId"] = user.idUser;
                        Session["UserName"] = user.Name;
                        Session["MobileNumber"] = user.MobileNumber;
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        string str = Convert.ToString(Session["UserId"]) + "~" +
                                Convert.ToString(Session["UserName"]);

                        userInfo["Rdata"] = UtilityFunction.Encrypt(str);
                        userInfo.Expires.Add(new TimeSpan(20, 0, 0));
                        Response.Cookies.Add(userInfo);


                        SurveillanceDL surveillanceDL = new SurveillanceDL();
                        ResponseDto responseData = surveillanceDL.GetSurveillanceTrace(Convert.ToInt32(Session["UserId"]));
                        if (responseData != null)
                        {
                            if (responseData.StatusCode == 0)
                            {
                                List<UserNotificationDto> lst = (List<UserNotificationDto>)responseData.Result;
                                if (lst.Count>1)
                                {
                                    Response.Redirect("Stationsurveillance.aspx");
                                }
                            }
                        }
                        Response.Redirect("index.aspx");
                    }

                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                }
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
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
            spnmsgSuccess.Visible = false;
            ResponseDto response = objLoginDL.SetPoliceOTP(txtMobileNo.Text, MobileOTP);
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
                    spnmsg.Visible = true;
                    spnmsg.InnerText = response.Message;
                }
            }
        }
    }
}