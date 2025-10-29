using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataLayer;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace HotalManagment
{
    public partial class BookingInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            int bookingId = string.IsNullOrEmpty(Convert.ToString(Request.QueryString["Id"])) ? 0 : Convert.ToInt32(Request.QueryString["Id"]);
            DataSet objBooking = objHotalManagment.GetBookingInformationById(bookingId, Convert.ToInt32(Session["UserId"]));
            hdType.Value = Convert.ToString(Request.QueryString["type"]);
            if (objBooking.Tables.Count > 0 && objBooking.Tables[0].Rows.Count > 0)
            {
                CommonUtilitys objCommonUtilitys = new CommonUtilitys();
                lblHtml.Text = objCommonUtilitys.Report(objBooking);
                if (hdType.Value.ToUpper() == "SENDMAIL")
                {
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter h = new HtmlTextWriter(sw);
                    MainDiv.RenderControl(h);
                    string str = lblHtml.Text;// sw.GetStringBuilder().ToString();

                    str = str.Replace("border=\"1\"", "border=\"0\"");
                    // str = new Regex("<tr class='removeTag' style='font-size:13px'>.*</tr>").Replace(str, string.Empty);
                    str = new Regex("<div class='removeTag'>.*?</div>").Replace(str, string.Empty);
                    str = "Dear Guest ,<br>Thank you for your stay with us .<br>We were pleased to note that you appreciated the Food of our hotel, an aspect of our hotel that is preferred by many of our guests. Your encouragingreview will help us constantly improve our restaurant services, and we hope to welcome you back again in the near future! Sincerely,<br>" + str;
                    CommanClasses.SendEmail(Convert.ToString(Session["UserName"]), "Invoice", str);
                }


                lblHtml.Text = new Regex("<span class='removeTag'>.*?</span>").Replace(lblHtml.Text, string.Empty);
            }
        }


 //       private string Report(DataSet objBooking)
 //       {
 //           decimal discount = Convert.ToDecimal(objBooking.Tables[0].Rows[0]["BasePrice"]) - Convert.ToDecimal(objBooking.Tables[0].Rows[0]["RoomCharges"]);
 //           string HotelName = Convert.ToString(Session["Hotelname"]);
 //           string Address = Convert.ToString(Session["Address"]);
 //           string NoOfNights = (Convert.ToDateTime(objBooking.Tables[0].Rows[0]["ToDate"]) - Convert.ToDateTime(objBooking.Tables[0].Rows[0]["FromDate"])).TotalDays.ToString();
 //           string PhoneNo = string.Empty;

 //           int totalDays = 0;
 //           decimal totalAmtS = 0;
 //           totalDays = (NoOfNights == "0" ? 1 : Convert.ToInt32(NoOfNights));

 //           decimal totalPaid = 0;
 //           totalPaid = totalDays * Convert.ToDecimal(objBooking.Tables[0].Rows[0]["RoomCharges"]);


 //           decimal roomsTotal = totalPaid + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]);
 //           // decimal itemTotal = Convert.ToDecimal(totalAmount());

 //           decimal exbadCharge = Convert.ToDecimal(objBooking.Tables[0].Rows[0]["ExtrabadCharge"]) * totalDays;

 //           for (int m = 0; m != Convert.ToDecimal(objBooking.Tables[3].Rows.Count); m++)
 //           {
 //               totalAmtS += Convert.ToDecimal(objBooking.Tables[3].Rows[m]["RoomCharges"]);
 //           }

 //           decimal NetPayment = (totalAmtS) + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) +
 //exbadCharge
 //+
 //Convert.ToDecimal(objBooking.Tables[0].Rows[0]["EarlyCheckin"])
 //+
 //Convert.ToDecimal(objBooking.Tables[0].Rows[0]["LateCheckout"])
 //-
 //Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])
 //-
 //Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Adjustment"])
 //-
 //Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Discount"]);

 //           NetPayment = Math.Round(NetPayment, 0);

 //           DL_HotalManagment objHotalManagment = new DL_HotalManagment();
 //           HttpCookie reqCookies = Request.Cookies["travinitiesUserInfo"];

 //           string HotelPolicy = string.Empty, cancelation = string.Empty;
 //           if (reqCookies != null)
 //           {
 //               string rdata = reqCookies["Rdata"].ToString();
 //               rdata = CommanClasses.Decrypt(rdata);
 //               Char delimiter = '~';
 //               String[] substrings = rdata.Split(delimiter);
 //               PhoneNo = substrings[7];

 //               DataSet ds = objHotalManagment.GetHotelPolicy(Convert.ToInt32(Session["UserId"]));
 //               if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
 //               {
 //                   HotelPolicy = ds.Tables[0].Rows[0]["Hotelpolicy"].ToString();
 //                   cancelation = ds.Tables[0].Rows[0]["Cancellation"].ToString();
 //               }
 //           }

 //           string prefix = Convert.ToString(objBooking.Tables[1].Rows[0]["Gender"]);
 //           prefix = (prefix.ToUpper() == "F") ? "Mrs." : "Mr.";

 //           StringBuilder sb1 = new StringBuilder();
 //           sb1.Append("<div dir='ltr'>");
 //           sb1.Append("<div class='gmail_default' style='font-family:verdana,sans-serif'><br></div>");
 //           sb1.Append("<div class='gmail_quote'>");
 //           sb1.Append("<div dir='ltr'>");
 //           sb1.Append("   <div class='gmail_quote'>");
 //           sb1.Append("      <p style='margin:0'> </p>");
 //           sb1.Append("      <table style='border-style:double;border-width:8px;border-color:black;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000' width='100%'>");
 //           sb1.Append("         <tbody>");
 //           sb1.Append("            <tr>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;padding:7px'>");
 //           sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>CONFIRM BOOKING</span><br><span style='font-size:20px;line-height:21px;color:#000'>BOOKING REFERENCE NO :</span> <span style='font-size:20px;line-height:21px;color:#000'><b>" + objBooking.Tables[0].Rows[0]["HBookingId"].ToString() + "</b></span><br><br><span style='font-size:15px;line-height:18px;color:#000'>Kindly print this confirmation and have it<br>ready upon check-in at the Hotel</span></p>");
 //           sb1.Append("               </td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;padding:7px'>");
 //           sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>" + HotelName + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>" + Address + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>-</span><br><span style='font-size:13px;line-height:18px;color:#000'><a href='mailto:" + Convert.ToString(Session["UserName"]) + "' style='color:#000000' target='_blank'>" + Convert.ToString(Session["UserName"]) + "</a></span><br><span style='font-size:13px;line-height:18px;color:#000'>Phone : " + PhoneNo + "</span></p>");
 //           sb1.Append("               </td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("         </tbody>");
 //           sb1.Append("      </table>");
 //           sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Dear " + prefix + " " + objBooking.Tables[1].Rows[0]["FirstName"] + " " + objBooking.Tables[1].Rows[0]["LastName"] + ",</p>");
 //           sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Thank you for choosing " + HotelName + " for your stay. We are pleased to inform you that your reservation request is CONFIRMED and your reservation details are as follows.</p>");
 //           sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><b style='font-size:14px'>Booking Details</b>");

 //           if (!string.IsNullOrEmpty(Convert.ToString(objBooking.Tables[0].Rows[0]["OTATranId"])) && !string.IsNullOrEmpty(Convert.ToString(objBooking.Tables[0].Rows[0]["VoucherNo"])))
 //           {
 //               sb1.Append("         <br><span>Booking Id: " + Convert.ToString(objBooking.Tables[0].Rows[0]["VoucherNo"]) + " </span>");
 //           }
 //           sb1.Append("         <br><span>Booking Date: " + Convert.ToString(objBooking.Tables[0].Rows[0]["BookingDate"]) + " </span><br><span>Check In Date: " + Convert.ToDateTime(objBooking.Tables[0].Rows[0]["FromDate"]).ToShortDateString() + " </span><br><span>Check Out Date :" + Convert.ToDateTime(objBooking.Tables[0].Rows[0]["ToDate"]).ToShortDateString() + " </span><br><span>Nights : " + totalDays + "</span><br><span>Checkin Time : " + Convert.ToString(objBooking.Tables[0].Rows[0]["CheckinTime"]) + "</span><br><span>CheckOut Time : " + Convert.ToString(objBooking.Tables[0].Rows[0]["CheckoutTime"]) + " </span></p>");
 //           sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><span style='font-size:14px'><b>Your Details</b></span><br><span>" + prefix + " " + objBooking.Tables[1].Rows[0]["FirstName"] + "</span><br><span>Email ID : " + Convert.ToString(objBooking.Tables[1].Rows[0]["Email"]) + "</span><br><span>Mobile No : " + Convert.ToString(objBooking.Tables[1].Rows[0]["Mobile"]) + "</span></p>");
 //           sb1.Append("      <p id='m_-4531955703134020943m_-7990745879711803507guestpref'></p>");
 //           sb1.Append("      <p style='margin:0'>");
 //           sb1.Append("         <span style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;display:inline-block;margin-bottom:7px'>");
 //           sb1.Append("         <b>");
 //           sb1.Append("         Rooms Details</b></span>");
 //           sb1.Append("      </p>");
 //           sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000' width='100%'>");
 //           sb1.Append("         <tbody>");
 //           sb1.Append("            <tr style='font-size:14px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-right:none' width='30%'>Room Type</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-left:none;border-right:none' width='15%'>Guest(s)</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none;border-right:none' width='20%'>Meal Plan</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none' width='20%'>Promotion if any</td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("            <tr>");
 //           sb1.Append("               <td colspan='5' width='100%'></td>");
 //           sb1.Append("            </tr>");

 //           int totalPerson = 0;
 //           int TotalShowperson = 0;
 //           int remainPersons = 0;
 //           for (int i = 0; i < objBooking.Tables[0].Rows.Count; i++)
 //           {
 //               if (totalPerson == 0)
 //               {
 //                   totalPerson = Convert.ToInt32(objBooking.Tables[0].Rows[i]["NoOfPerson"]);
 //                   remainPersons = totalPerson;
 //               }
 //               if (string.IsNullOrEmpty(Convert.ToString(objBooking.Tables[0].Rows[i]["Persons"])))

 //                   TotalShowperson += 0;
 //               else
 //                   TotalShowperson += Convert.ToInt32(objBooking.Tables[0].Rows[i]["Persons"]);

 //               sb1.Append("            <tr style='font-size:13px'>");
 //               //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + objBooking.Tables[0].Rows[i]["CategoryName"] + "</b><br>Room No. " + objBooking.Tables[0].Rows[i]["RoomNo"] + "</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + objBooking.Tables[0].Rows[i]["CategoryName"] + "</b></td>");
 //               if (totalPerson != 0)
 //               {
 //                   if (remainPersons > Convert.ToInt32(objBooking.Tables[0].Rows[i]["Persons"]))
 //                   {
 //                       Int32 PersonStay = Convert.ToInt32(objBooking.Tables[0].Rows[i]["PersonStay"]);
 //                       if (PersonStay == 0)
 //                       {
 //                           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + objBooking.Tables[0].Rows[i]["Persons"] + " Person(s) </td>");
 //                       }
 //                       else
 //                       {
 //                           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + PersonStay + " Person(s) </td>");
 //                       }

 //                       remainPersons -= Convert.ToInt32(objBooking.Tables[0].Rows[i]["Persons"]);
 //                   }
 //                   else
 //                   {
 //                       sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + remainPersons + " Person(s) </td>");
 //                       remainPersons = 0;
 //                   }
 //               }
 //               else
 //               {
 //                   sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + objBooking.Tables[0].Rows[i]["Persons"] + " Person(s) </td>");
 //               }
 //               // sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + objBooking.Tables[0].Rows[i]["Persons"] + " Person(s) </td>");
 //               switch (Convert.ToString(objBooking.Tables[0].Rows[i]["RoomPlanid"]))
 //               {
 //                   case "1":
 //                       sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>EP</td>");
 //                       break;
 //                   case "2":
 //                       sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>CP</td>");
 //                       break;
 //                   case "3":
 //                       sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>MAP</td>");
 //                       break;
 //                   default:
 //                       break;
 //               }
 //               sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (totalPerson > TotalShowperson)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>Extra person</b></td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + (totalPerson - TotalShowperson) + " Person(s) </td>");
 //               sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>-</td>");
 //               sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
 //               sb1.Append("            </tr>");
 //           }



 //           sb1.Append("            <tr>");
 //           sb1.Append("               <td style='padding:2px'></td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("            <tr>");
 //           sb1.Append("               <td>");
 //           sb1.Append("                  <table border='0' width='100%'></table>");
 //           sb1.Append("               </td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("         </tbody>");
 //           sb1.Append("      </table>");
 //           sb1.Append("      <div id='m_-4531955703134020943m_-7990745879711803507tagremove'></div>");
 //           sb1.Append("      <p style='margin:0'><span style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;display:inline-block;margin-top:14px;margin-bottom:7px'><b>Rates Details</b></span></p>");


 //           sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;margin-bottom:25px' width='100%'>");
 //           sb1.Append("         <tbody>");
 //           sb1.Append("            <tr style='font-size:14px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-right:none' width='30%'>Details</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none' width='20%'>Rates (Rs)</td>");
 //           sb1.Append("            </tr>");

 //           //sb1.Append("            <tr style='font-size:13px'>");
 //           //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Total Room Charges</td>");
 //           //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(totalDays * Convert.ToDecimal(objBooking.Tables[0].Rows[0]["RoomCharges"])) + "</td>");
 //           //sb1.Append("            </tr>");
 //           decimal commition = 0;
 //           decimal price = 0;
 //           decimal gst = 0;

 //           for (int m = 0; m != Convert.ToDecimal(objBooking.Tables[3].Rows.Count); m++)
 //           {
 //               price += Convert.ToDecimal(objBooking.Tables[3].Rows[m]["Price"]);
 //               sb1.Append("            <span class='removeTag'>");
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Room Charges (" + Convert.ToDateTime(objBooking.Tables[3].Rows[m]["FDate"]).ToShortDateString() + ")</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[3].Rows[m]["RoomCharges"]) + "</td>");
 //               sb1.Append("            </tr>");
 //               sb1.Append("            </span>");
 //           }

 //           sb1.Append("            <div class='removeTag'>");
 //           sb1.Append("            <tr style='font-size:13px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Room charges for customer</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + price.ToString() + "</td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("            </div>");

         

 //           commition = totalAmtS - price;
 //           if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) > 0)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>CGST</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) / 2) + "</td>");
 //               sb1.Append("            </tr>");

 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>SGST</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) / 2) + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (exbadCharge > 0)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Extra Bad Charges</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + exbadCharge + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["EarlyCheckin"]) > 0)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Early Checkin Charges</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["EarlyCheckin"]) + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["LateCheckout"]) > 0)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Late Checkout Charges</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["LateCheckout"]) + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Adjustment"]) > 0)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Adjustment</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["Adjustment"]) + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"]) > 0)
 //           {
 //               sb1.Append("            <span class='removeTag'>");
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Advance</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["AdvanceAmount"]) + "</td>");
 //               sb1.Append("            </tr>");
 //               sb1.Append("            </span>");
 //           }
 //           if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Discount"]) > 0)
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Discount</td>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["Discount"]) + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           if (objBooking.Tables[3].Rows.Count > 0 && Convert.ToBoolean(objBooking.Tables[3].Rows[0]["Isonline"]))//Isonline
 //           {
 //               sb1.Append("            <div class='removeTag'>");
 //               if (price > NetPayment - Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"]))
 //               {
 //                   sb1.Append("            <tr style='font-size:13px'>");
 //                   sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Travinities pay to hotel</td>");
 //                   sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"]) - commition) + "</td>");
 //                   sb1.Append("            </tr>");
 //               }
 //               else
 //               {
 //                   sb1.Append("            <tr style='font-size:13px'>");
 //                   sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Hotel pay to travinities</td>");
 //                   sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(commition - Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])) + "</td>");
 //                   sb1.Append("            </tr>");
 //               }
 //               sb1.Append("            </div>");
 //           }

 //           sb1.Append("            <div class='removeTag'>");
 //           sb1.Append("            <tr style='font-size:13px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Amount to be collected from guest</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + (NetPayment).ToString() + "</td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("            </div>");

 //           //sb1.Append("         <div class='removeTag'>");
 //           //sb1.Append("            <tr style='font-size:13px'>");
 //           //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Grand Total A</td>");
 //           //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + (NetPayment + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])).ToString() + "</td>");
 //           //sb1.Append("            </tr>");
 //           //sb1.Append("         </div>");

 //           sb1.Append("         <span class='removeTag'>");
 //           sb1.Append("            <tr style='font-size:13px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Grand Total</td>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + (NetPayment).ToString() + "</td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("         </span>");

 //           sb1.Append("            <tr style='font-size:13px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif' colspan=2><hr></td>");
 //           sb1.Append("            </tr>");



 //           sb1.Append("         </tbody>");
 //           sb1.Append("      </table>");
 //           sb1.Append("      <div style='width:30%;display:inline-block;border-style:double;border-width:4px;border-color:black;padding:5px;margin-bottom:0px;vertical-align:top'>");
 //           //sb1.Append("         <div class='removeTag'>");
 //           //sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>AMOUNT IN WORDS A</p>");
 //           //sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>" + changeToWords((NetPayment + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])).ToString(), true).ToUpper() + "</p>");
 //           //sb1.Append("         </div>");

 //           sb1.Append("         <div class='removeTag'>");
 //           sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>AMOUNT IN WORDS</p>");
 //           sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>" + changeToWords(NetPayment.ToString(), true).ToUpper() + "</p>");
 //           sb1.Append("         </div>");


 //           sb1.Append("         <span class='removeTag'>");
 //           sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>AMOUNT IN WORDS</p>");
 //           sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>" + changeToWords(NetPayment.ToString(), true).ToUpper() + "</p>");
 //           sb1.Append("         </span>");
 //           sb1.Append("      </div>");

 //           sb1.Append("      <div style='width:67%;margin-bottom:14px;display:inline-block'>");
 //           sb1.Append("         <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px;text-align:right;margin-top:0'><b>Booked &amp; Payable By</b><br>" + prefix + " " + objBooking.Tables[1].Rows[0]["FirstName"] + " " + objBooking.Tables[1].Rows[0]["LastName"] + "<br>" + objBooking.Tables[1].Rows[0]["Email"] + "<br></p>");
 //           sb1.Append("      </div>");
 //           sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000' width='100%'>");
 //           sb1.Append("         <tbody>");
 //           sb1.Append("            <tr style='font-size:14px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black' width='100%'>Conditions &amp; Policies</td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("            <tr style='font-size:13px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Cancellation Policy</b><br>" + cancelation + "</td>");
 //           sb1.Append("            </tr>");
 //           sb1.Append("            <tr style='font-size:13px'>");
 //           sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Hotel Policy </b><br>" + HotelPolicy);
 //           sb1.Append("                  <br><b>Hotel Check in Time : </b> 12:00 PM<br><b>Hotel Check out Time : </b> 11:00 AM</td>");
 //           sb1.Append("            </tr>");
 //           if (!string.IsNullOrEmpty(objBooking.Tables[0].Rows[0]["SpecialRequest"].ToString()))
 //           {
 //               sb1.Append("            <tr style='font-size:13px'>");
 //               sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Special Request</b><br>" + objBooking.Tables[0].Rows[0]["SpecialRequest"] + "</td>");
 //               sb1.Append("            </tr>");
 //           }
 //           sb1.Append("         </tbody>");
 //           sb1.Append("      </table>");
 //           sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'><span style='font-weight:bold;text-align:center;display:block;color:#000'>This email has been sent from an automated system - please do not reply to it.</span></p>");
 //           sb1.Append("      <hr>");
 //           sb1.Append("   </div>");
 //           sb1.Append("   <br>");
 //           sb1.Append("</div>");
 //           return sb1.ToString();

 //       }


    }

}


