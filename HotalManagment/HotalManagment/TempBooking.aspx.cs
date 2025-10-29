using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;
using System.Text;
using System.Net;
using System.Collections.Specialized;

namespace HotalManagment
{
    public partial class TempBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {
                getControlData();

                getPreBookingdata();
                btnsave.Text = "Add";
                ClearControl();
                hdPreBookingId.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            PreBookingCls objPreBookingCls = new PreBookingCls();
            if (Convert.ToInt32(hdPreBookingId.Value) > 0)
            {
                hdMessage.Value = "Pre booking Update |";
                objPreBookingCls.Id = Convert.ToInt32(hdPreBookingId.Value);
                objPreBookingCls.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Pre booking Insert |";
                objPreBookingCls.Id = 0;
                objPreBookingCls.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            objPreBookingCls.BookingSourceId = Convert.ToInt32(ddBookingSource.SelectedItem.Value);
            objPreBookingCls.ContactNo = txtContactNo.Text;
            objPreBookingCls.ContactPerson = txtContactPerson.Text;
            objPreBookingCls.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objPreBookingCls.Notes = txtNotes.Text;
            objPreBookingCls.ToDate = Convert.ToDateTime(txtTodate.Text);
            objPreBookingCls.CategoryId = Convert.ToInt32(ddCategory.SelectedItem.Value);
            objPreBookingCls.Status = Convert.ToInt32(ddSataus.SelectedItem.Value);
            objPreBookingCls.RefNo = txtrefNo.Text;
            objPreBookingCls.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetPreBooking(objPreBookingCls);
            if (Response > 0)
            {
                string HotelName = Convert.ToString(Session["Hotelname"]);
                string Address = Convert.ToString(Session["Address"]);

                if (Convert.ToInt32(hdPreBookingId.Value) == 0)
                {
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("Dear Guest ,<br>Greetings from " + HotelName + ". Your booking is confirmed with us<br>");
                    //sb.Append("<div id='MainDiv' class='card-body'><div class='table-scrollable'>");
                    //sb.Append("<div class='row-fluid sortable'><div class='box span12'>");
                    //sb.Append("<div class='box-content'><div class='booking-header'>");
                    //sb.Append("<div class='text-center col-md-12' style='text-align: center;'>");
                    //sb.Append("<h3><img id='imgBooking' class='pull-left' src='HotelLogo\\A.png' style='height:80px;' />");
                    //sb.Append("<span id='lblHotelName'>" + HotelName + "</span></h3>");
                    //sb.Append("<p><span id='lblHotelAddress'>" + Address + "</span><br />");
                    //sb.Append("</p><hr/></div>");
                    //sb.Append("<table border='0' width='100%' style='border-top-width: 1px; border-right-width: 1px;border-bottom-width: 1px; border-left-width: 1px; width: 100%;'>");
                    //sb.Append("<tr><td colspan='3'><b>Customor Name</b></td><td><span id='ContentPlaceHolder1_lblGuestName'>" + txtContactPerson.Text + "</span></td><td colspan='3'><b>Hotel Details</b></td></tr>");
                    //sb.Append("<tr><td rowspan='2' colspan='3'><span style='border-radius: 50px; padding: 2px 7px; background: green; color: White'><span id='lblBookingStatus'>Pre Booking</span></span></td><td rowspan='2'></td><td><b>Bill no</b></td><td colspan='2'><span id='lblBookingId'>26</span></td></tr>");
                    //sb.Append("<tr><td><b>Booking Date</b></td><td colspan='2'><span id='lblBookedOn'>" + CommanClasses.CurrentDateTime().ToString() + "</span></td></tr>");
                    //sb.Append("<tr><td colspan='3'><b>Customar Contact no</b></td><td><span id='lblPhoneNo'>" + txtContactNo.Text + "</span></td><td><b>Room Type</b></td><td colspan='2'><span id='lblRoomNo'>" + ddCategory.SelectedItem.Text + "</span></td></tr>");
                    //sb.Append("<tr><td colspan='3'><b>Arrival date & time</b></td><td><span id='lblCheckinDate'>" + txtFromDate.Text + "</span></td><td><b>Hotel GST no</b></td><td colspan='2'><span id='ContentPlaceHolder1_lblHotelGSTNo'>1258963458</span></td></tr>");
                    //sb.Append("<tr><td colspan='3'><b>Depature Date & time</b></td><td><span id='lblCheckoutDate'>" + txtTodate.Text + "</span></td><td></td><td></td><td></td></tr>");
                    //sb.Append("</table></div></div></div></div></div></div>");

                    string NoOfNights = (Convert.ToDateTime(txtTodate.Text) - Convert.ToDateTime(txtFromDate.Text)).TotalDays.ToString();
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append("<div dir='ltr'>");
                    sb1.Append("<div class='gmail_default' style='font-family:verdana,sans-serif'><br></div>");
                    sb1.Append("<div class='gmail_quote'>");
                    sb1.Append("<div dir='ltr'>");
                    sb1.Append("   <div class='gmail_quote'>");
                    sb1.Append("      <p style='margin:0'> </p>");
                    sb1.Append("      <table style='border-style:double;border-width:8px;border-color:black;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000' width='100%'>");
                    sb1.Append("         <tbody>");
                    sb1.Append("            <tr>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;padding:7px'>");
                    sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>CONFIRM PRE BOOKING</span><br><span style='font-size:20px;line-height:21px;color:#000'>BOOKING REFERENCE NO :</span> <span style='font-size:20px;line-height:21px;color:#000'><b>" + Response + "</b></span><br><br><span style='font-size:15px;line-height:18px;color:#000'>Kindly print this confirmation and have it<br>ready upon check-in at the Hotel</span></p>");
                    sb1.Append("               </td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;padding:7px'>");
                    sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>" + HotelName + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>" + Address + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>-</span><br><span style='font-size:13px;line-height:18px;color:#000'><a href='mailto:" + Convert.ToString(Session["UserName"]) + "' style='color:#000000' target='_blank'>" + Convert.ToString(Session["UserName"]) + "</a></span><br><span style='font-size:13px;line-height:18px;color:#000'>Phone : " + txtContactNo.Text + "</span></p>");
                    sb1.Append("               </td>");
                    sb1.Append("            </tr>");
                    sb1.Append("         </tbody>");
                    sb1.Append("      </table>");
                    sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Dear " + txtContactPerson.Text + ",</p>");
                    sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Thank you for choosing " + HotelName + " for your stay. We are pleased to inform you that your reservation request is CONFIRMED and your reservation details are as follows.</p>");
                    sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><b style='font-size:14px'>Booking Details</b><br><span>Pre Booking Date: " + CommanClasses.CurrentDateTime().ToShortDateString() + " </span><br><span>Check In Date: " + txtFromDate.Text + " </span><br><span>Check Out Date :" + txtTodate.Text + " </span><br><span>Nights : " + NoOfNights + "</span><br><span>Arrival Time : 12:00:00 PM</span><br><span>Special Request : </span></p>");
                    sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><span style='font-size:14px'><b>Your Details</b></span><br><span>" + txtContactPerson.Text + "</span></p>");
                    sb1.Append("      <p id='m_-4531955703134020943m_-7990745879711803507guestpref'></p>");
                    sb1.Append("      <p style='margin:0'>");
                    sb1.Append("         <span style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;display:inline-block;margin-bottom:7px'>");
                    sb1.Append("         <b>");
                    sb1.Append("         Rooms Details</b></span>");
                    sb1.Append("      </p>");
                    sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000' width='100%'>");
                    sb1.Append("         <tbody>");
                    sb1.Append("            <tr style='font-size:14px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-right:none' width='30%'>Room Type</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-left:none;border-right:none' width='15%'>Guest(s)</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none;border-right:none' width='20%'>Meal Plan</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none' width='20%'>Promotion if any</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            <tr>");
                    sb1.Append("               <td colspan='5' width='100%'></td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + ddCategory.SelectedItem.Text + "</b></td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>- Person(s) </td>");
                    sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>-</td>");
                    sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            <tr>");
                    sb1.Append("               <td style='padding:2px'></td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            <tr>");
                    sb1.Append("               <td>");
                    sb1.Append("                  <table border='0' width='100%'></table>");
                    sb1.Append("               </td>");
                    sb1.Append("            </tr>");
                    sb1.Append("         </tbody>");
                    sb1.Append("      </table>");
                    sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000' width='100%'>");
                    sb1.Append("         <tbody>");
                    sb1.Append("            <tr style='font-size:14px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black' width='100%'>Conditions &amp; Policies</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Cancellation Policy</b><br></td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Hotel Policy </b><br><br><b>Hotel Check in Time : </b> 12:00 PM<br><b>Hotel Check out Time : </b> 11:00 AM</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("         </tbody>");
                    sb1.Append("      </table>");
                    sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'><span style='font-weight:bold;text-align:center;display:block;color:#000'>This email has been sent from an automated system - please do not reply to it.</span></p>");
                    sb1.Append("      <hr>");
                    sb1.Append("   </div>");
                    sb1.Append("   <br>");
                    sb1.Append("</div>");






                    CommanClasses.SendEmail(Convert.ToString(Session["UserName"]), "Pre Booked Room Information", sb1.ToString());

                }
                //using (var wb = new WebClient())
                //{
                //    byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                //        {
                //            {"username" , "anroute123"},
                //            {"hash" , "<API has key>"},
                //            {"sender" , "TRVNTS"},
                //            {"numbers" , "8358961587"},
                //            {"message" , "Text message"}                
                //        });
                //    string result = System.Text.Encoding.UTF8.GetString(response);
                //}

                // CommanClasses.SendSMS("Test Message", "8358961587");

                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            getPreBookingdata();
            btnsave.Text = "Add";
            ClearControl();
            hdPreBookingId.Value = "0";
        }

        public void getPreBookingdata()
        {
            grdPreBooking.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetPreBookingData(Convert.ToInt32(Session["UserId"]));
            grdPreBooking.DataSource = ds.Tables[0];
            grdPreBooking.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        protected void grdPreBooking_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");

            hdPreBookingId.Value = Convert.ToString(((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtFromDate.Text = ((Label)grdPreBooking.Rows[e.NewEditIndex].FindControl("lblFromDate")).Text;
            txtTodate.Text = ((Label)grdPreBooking.Rows[e.NewEditIndex].FindControl("lblToDate")).Text;
            ddCategory.SelectedValue = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdCategoryId")).Value;
            ddBookingSource.SelectedValue = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdBookingSourceId")).Value;
            txtrefNo.Text = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdRefNo")).Value;
            TxtBoonigId.Text = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdBookingId")).Value;
            txtContactPerson.Text = ((Label)grdPreBooking.Rows[e.NewEditIndex].FindControl("lblContactName")).Text;
            txtContactNo.Text = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdContactNo")).Value;
            txtNotes.Text = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdNotes")).Value;
            ddSataus.SelectedValue = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value;
            txtrefNo.Text = ((HiddenField)grdPreBooking.Rows[e.NewEditIndex].FindControl("hdRefNo")).Value;
            btnsave.Text = "Update";
        }

        public string GetStatusClass(bool status)
        {
            string className = string.Empty;
            if (status)
            {
                className = "label label-success";
            }
            else
            {
                className = "label label-warning";
            }
            return className;
        }

        public void ClearControl()
        {
            hdPreBookingId.Value = "0";
            txtrefNo.Text = "";
            TxtBoonigId.Text = "";
            txtContactNo.Text = "";
            txtContactPerson.Text = "";
            txtFromDate.Text = "";
            txtNotes.Text = "";
            txtTodate.Text = "";
            ddBookingSource.ClearSelection();
            ddCategory.ClearSelection();
            ddSataus.ClearSelection();
            chkStatus.Checked = true;
            //hdMessage.Value = "";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            getPreBookingdata();
            btnsave.Text = "Add";
            ClearControl();
            hdPreBookingId.Value = "0";
        }

        public void getControlData()
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet dsCategory = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            ddCategory.DataValueField = "Id";
            ddCategory.DataTextField = "CategoryName";
            ddCategory.DataSource = dsCategory.Tables[0];
            ddCategory.DataBind();
            //ddCategory.Items.Insert(0, new ListItem("Select Category", "0"));

            DataSet dsBookingSource = objHotalManagment.GetBookingSource();
            ddBookingSource.DataValueField = "Id";
            ddBookingSource.DataTextField = "BookingSourceName";
            ddBookingSource.DataSource = dsBookingSource.Tables[0];
            ddBookingSource.DataBind();
            ddBookingSource.Items.Insert(0, new ListItem("Select Booking Source", "0"));
        }

    }
}