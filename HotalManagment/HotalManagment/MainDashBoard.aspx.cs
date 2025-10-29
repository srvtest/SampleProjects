using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace HotalManagment
{
    public partial class MainDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDashBoardAgainstId();
                getPlanDetail();
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "SomeThing", "BookingRooms()", true);
                GetBookingSource();

                if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 2)
                {
                    isAdmin11.Visible = true;
                    isAdmin12.Visible = false;
                    idHotelDetail.Visible = false;
                    idRoomsDetail.Visible = true;
                    GetChartData();
                    idOTABooking.Visible = true;
                    idEarning.Visible = true;
                    idBookingDetail.Visible = true;
                    isPlanActive.Visible = false;
                    idPlanAmount.Visible = false;
                    idBookingDetails.Visible = true;
                }
                else
                {
                    isAdmin11.Visible = false;
                    isAdmin12.Visible = true;
                    idHotelDetail.Visible = true;
                    idRoomsDetail.Visible = false;
                    GetChartData_new();
                    idOTABooking.Visible = false;
                    idEarning.Visible = false;
                    idBookingDetail.Visible = false;
                    isPlanActive.Visible = true;
                    idPlanAmount.Visible = true;
                    idBookingDetails.Visible = false;
                }
            }
        }

        public void GetChartData()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            DataSet ds = objDL_HotalManagment.GetBookedRoomDetail(Convert.ToInt32(Session["UserId"]));
            BindBookingAmount(ds.Tables[0]);
            BindBookingRooms(ds.Tables[1]);
            if (Convert.ToInt32(Session["Type"]) != 1)
            {
                BindTop20Booking(ds.Tables[2]);
                BindTodaysCheckIn(ds.Tables[3]);
                BindTodaysCheckOut(ds.Tables[4]);
            }
            BindWeeklyAmount(ds.Tables[5]);
        }

        public void GetChartData_new()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            DataSet ds = objDL_HotalManagment.GetBookedRoomDetail_Admin(Convert.ToInt32(Session["UserId"]));
            if (ds != null)
            {
                BindTop20HotelDetail(ds.Tables[0]);
                BindTop20HotelDetailExpire(ds.Tables[1]);
                BindTop20HotelDetailExpiresIn(ds.Tables[2]);
                int cnt = ds.Tables[0].Rows.Count - ds.Tables[1].Rows.Count;
                idTotalHotelActive.InnerHtml = "<span class='info-box-text'>Active</span>";
                idTotalHotelActive.InnerHtml += "<span class='info-box-number'>" + Convert.ToString(cnt) + "</span>";
                idTotalHotelActive.InnerHtml += "<div class='progress'><div class='progress-bar width-100'>";
                idTotalHotelActive.InnerHtml += "</div></div>";
            }
        }


        public void BindWeeklyAmount(DataTable dt)
        {
            string lst = "Start - 0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(lst))
                {
                    lst += ",";
                }

                lst += dt.Rows[i]["Monday"].ToString() + " to " + dt.Rows[i]["Sunday"].ToString() + "-" + dt.Rows[i]["Amount"].ToString();
            }
            hdWeekltData.Value = lst;
        }

        public void BindBookingAmount(DataTable dt)
        {
            string chartDetail = "0";
            double total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "," + Convert.ToInt32(dt.Rows[i][2]);
                total += Convert.ToInt32(dt.Rows[i][2]);
            }
            hdBookingAmount.Value = chartDetail;
            valBookingAmount.InnerText = Convert.ToString(total);
        }

        public void BindBookingRooms(DataTable dt)
        {
            string chartDetail = "0";
            double total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "," + Convert.ToInt32(dt.Rows[i][2]);
                total += Convert.ToInt32(dt.Rows[i][2]);
            }
            hdBookingRooms.Value = chartDetail;
            valBookingRooms.InnerText = Convert.ToString(total);
        }

        public void BindTop20Booking(DataTable dt)
        {
            //string chartDetail = " <ul class='todo-list'>";
            string chartDetail = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string s = dt.Rows[i][0].ToString();
                string[] words = s.Split('|');
                chartDetail += "<tr>";
                chartDetail += "<td>" + (i + 1) + "</td>";
                chartDetail += "<td>" + words[1] + "</td>";
                chartDetail += "<td>" + words[3] + "</td>";
                chartDetail += "<td>" + words[4] + "</td>";

                switch (words[5].Trim())
                {
                    case "2":
                        chartDetail += "<td><span class='label label-sm label-warning'>Booked</span></td>";
                        break;
                    case "3":
                        chartDetail += "<td><span class='label label-sm label-warning'>CheckOut</span></td>";
                        break;
                    case "4":
                        chartDetail += "<td><span class='label label-sm label-danger'>Cancel</span></td>";
                        break;

                    default:
                        break;
                }


                chartDetail += "<td>" + words[2] + "</td>";
                //chartDetail += "<td>Single</td>";
                //chartDetail += "<td><a href='edit_booking.html' class='btn btn-tbl-edit btn-xs'><i class='fa fa-pencil'></i></a>";
                //    chartDetail += "<button class='btn btn-tbl-delete btn-xs'><i class='fa fa-trash-o '></i></button>";
                //chartDetail += "</td>";
                chartDetail += "</tr>";

            }
            BookingDetail.InnerHtml = chartDetail;
        }

        public void BindTodaysCheckIn(DataTable dt)
        {
            //string chartDetail = " <ul class='todo-list'>";
            string chartDetail = "";

            idTotalRooms.InnerHtml = "<span class='info-box-text'>Today's Checkin</span>";
            idTotalRooms.InnerHtml += "<span class='info-box-number'>" + Convert.ToString(dt.Rows.Count) + "</span>";
            idTotalRooms.InnerHtml += "<div class='progress'><div class='progress-bar width-100'>";
            idTotalRooms.InnerHtml += "</div></div>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string s = dt.Rows[i][0].ToString();
                string[] words = s.Split('|');
                chartDetail += "<tr>";
                chartDetail += "<td>" + (i + 1) + "</td>";
                chartDetail += "<td>" + words[1] + "</td>";
                chartDetail += "<td>" + words[3] + "</td>";
                chartDetail += "<td>" + words[4] + "</td>";
                switch (words[5].Trim())
                {
                    case "2":
                        chartDetail += "<td><span class='label label-sm label-success'>CheckIn</span></td>";
                        break;
                    case "3":
                        chartDetail += "<td><span class='label label-sm label-warning'>CheckOut</span></td>";
                        break;
                    case "4":
                        chartDetail += "<td><span class='label label-sm label-dange'>Cancel</span></td>";
                        break;

                    default:
                        break;
                }


                chartDetail += "<td>" + words[2] + "</td>";
                chartDetail += "</tr>";
            }
            CheckinDetail.InnerHtml = chartDetail;
        }

        public void BindTodaysCheckOut(DataTable dt)
        {
            //string chartDetail = " <ul class='todo-list'>";
            string chartDetail = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string s = dt.Rows[i][0].ToString();
                if (!string.IsNullOrEmpty(s))
                {
                    string[] words = s.Split('|');
                    chartDetail += "<tr>";
                    chartDetail += "<td>" + (i + 1) + "</td>";
                    chartDetail += "<td>" + words[1] + "</td>";
                    chartDetail += "<td>" + words[3] + "</td>";
                    chartDetail += "<td>" + words[4] + "</td>";
                    switch (words[5].Trim())
                    {
                        case "2":
                            chartDetail += "<td><span class='label label-sm label-success'>CheckIn</span></td>";
                            break;
                        case "3":
                            chartDetail += "<td><span class='label label-sm label-warning'>CheckOut</span></td>";
                            break;
                        case "4":
                            chartDetail += "<td><span class='label label-sm label-dange'>Cancel</span></td>";
                            break;

                        default:
                            break;
                    }


                    chartDetail += "<td>" + words[2] + "</td>";
                    //chartDetail += "<td>Single</td>";
                    //chartDetail += "<td><a href='edit_booking.html' class='btn btn-tbl-edit btn-xs'><i class='fa fa-pencil'></i></a>";
                    //chartDetail += "<button class='btn btn-tbl-delete btn-xs'><i class='fa fa-trash-o '></i></button>";
                    //chartDetail += "</td>";
                    chartDetail += "</tr>";
                }
            }
            CheckOutDetail.InnerHtml = chartDetail;
        }

        public void BindTop20HotelDetail(DataTable dt)
        {
            string chartDetail = "";
            //idTotalHotel.InnerHtml = "<span class='info-box-text'>Hotels</span>";
            //idTotalHotel.InnerHtml += "<span class='info-box-number'>" + Convert.ToString(dt.Rows.Count) + "</span>";
            //idTotalHotel.InnerHtml += "<div class='progress'><div class='progress-bar width-100'>";
            //idTotalHotel.InnerHtml += "</div></div>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][0].ToString();
                chartDetail += "<tr>";
                chartDetail += "<td>" + (i + 1) + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["Hotelname"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["Startdate"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["EndDate"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["Duration"] + "</td>";
                chartDetail += "</tr>";
            }
            HotelDetail.InnerHtml = chartDetail;
        }

        public void BindTop20HotelDetailExpire(DataTable dt)
        {
            string chartDetail = "";

            idTotalHotelExp.InnerHtml = "<span class='info-box-text'>Expired</span>";
            idTotalHotelExp.InnerHtml += "<span class='info-box-number'>" + Convert.ToString(dt.Rows.Count) + "</span>";
            idTotalHotelExp.InnerHtml += "<div class='progress'><div class='progress-bar width-100'>";
            idTotalHotelExp.InnerHtml += "</div></div>";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][0].ToString();
                chartDetail += "<tr>";
                chartDetail += "<td>" + (i + 1) + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["Hotelname"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["EmailId"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["PhoneNo"] + "</td>";
                chartDetail += "</tr>";
            }
            expHotelDetail.InnerHtml = chartDetail;
        }

        public void BindTop20HotelDetailExpiresIn(DataTable dt)
        {
            string chartDetail = "";

            idTotalHotelExpMonth.InnerHtml = "<span class='info-box-text'>Expired This Month</span>";
            idTotalHotelExpMonth.InnerHtml += "<span class='info-box-number'>" + Convert.ToString(dt.Rows.Count) + "</span>";
            idTotalHotelExpMonth.InnerHtml += "<div class='progress'><div class='progress-bar width-100'>";
            idTotalHotelExpMonth.InnerHtml += "</div></div>";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][0].ToString();
                chartDetail += "<tr>";
                chartDetail += "<td>" + (i + 1) + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["Hotelname"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["EmailId"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["PhoneNo"] + "</td>";
                chartDetail += "<td>" + dt.Rows[i]["EndDate"] + "</td>";
                chartDetail += "</tr>";
            }
            ExpHotelDetailInMonth.InnerHtml = chartDetail;
        }

        public void GetDashBoardAgainstId()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Session["Type"] != null)
            {
                DataSet ds = objDL_HotalManagment.GetDashBoardAgainstId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["Type"]));
                // if (Convert.ToInt32(Session["Type"]) != 1)
                {

                    if (ds != null)
                    {
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataColumnCollection columns = ds.Tables[0].Columns;
                            double totalRooms = Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfRooms"]);
                            if (totalRooms == 0) totalRooms = 1;
                            double curValue = totalRooms;
                            int per = Convert.ToInt32(curValue / (totalRooms / 100));
                            per = per - (per % 5);
                            idTotalRooms.InnerHtml = "<span class='info-box-text'>Total Rooms</span>";
                            idTotalRooms.InnerHtml += "<span id='idTotalRooms' runat='server' class='info-box-number'>" + Convert.ToString(ds.Tables[0].Rows[0]["NoOfRooms"]) + "</span>";
                            idTotalRooms.InnerHtml += "<div class='progress'>";
                            idTotalRooms.InnerHtml += "<div class='progress-bar width-" + per + "'>";
                            idTotalRooms.InnerHtml += "</div>";
                            idTotalRooms.InnerHtml += "</div>";
                            // idTotalRooms.InnerHtml += "<span  class='progress-description'>" + Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsDetail"]) + " </span>";
                            //  if (Convert.ToInt32(Session["Type"]) == 2)
                            {
                                curValue = 0;
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Arr"])))
                                    curValue = Convert.ToInt32(ds.Tables[0].Rows[0]["Arr"]);    
                                 
                                per = Convert.ToInt32(curValue / (totalRooms / 100));
                                per = per - (per % 5);
                                idRoomHK.InnerHtml = "<span class='info-box-text'>ARR</span>";
                                idRoomHK.InnerHtml += "<span id='idTotalRooms' runat='server' class='info-box-number'>" + Convert.ToString(curValue) + "</span>";
                                idRoomHK.InnerHtml += "<div class='progress'><div class='progress-bar width-" + per + "'>";
                                idRoomHK.InnerHtml += "</div></div>";
                                // idRoomHK.InnerHtml += "<span  class='progress-description'>" + Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsHKDetail"]) + "</span>";

                                curValue = Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfRoomsBooked"]); ;
                                per = Convert.ToInt32(curValue / (totalRooms / 100));
                                per = per - (per % 5);
                                idRoomBooked.InnerHtml = "<span class='info-box-text'>Room Booked</span>";
                                idRoomBooked.InnerHtml += "<span id='idTotalRooms' runat='server' class='info-box-number'>" + Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsBooked"]) + "</span>";
                                idRoomBooked.InnerHtml += "<div class='progress'><div class='progress-bar width-" + per + "'>";
                                idRoomBooked.InnerHtml += "</div></div>";
                                // idRoomBooked.InnerHtml += "<span  class='progress-description'>" + Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsBookedDetail"]) + "</span>";

                                curValue = Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfRoomsAvailable"]); ;
                                per = Convert.ToInt32(curValue / (totalRooms / 100));
                                per = per - (per % 5);
                                idAvailableRoom.InnerHtml = "<span class='info-box-text'>Room Available</span>";
                                idAvailableRoom.InnerHtml += "<span id='idTotalRooms' runat='server' class='info-box-number'>" + Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsAvailable"]) + "</span>";
                                idAvailableRoom.InnerHtml += "<div class='progress'><div class='progress-bar width-" + per + "'>";
                                idAvailableRoom.InnerHtml += "</div></div>";
                                //     idAvailableRoom.InnerHtml += "<span  class='progress-description'>100 Ac 10 Non Ac </span>";

                                TodayIncome.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["AmountOfBookingToday"]);

                                WeekIncome.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["AmountOfWeekBooking"]);

                                MonthIncome.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["AmountOfMonthBooking"]);
                                idTotalHotel.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfHotels"]);

                                string str = Convert.ToString(ds.Tables[0].Rows[0]["OTAWalkIn"]);
                                if (!string.IsNullOrEmpty(str))
                                {
                                    string[] words = str.Split('|');
                                    int Walin = Convert.ToInt32(words[0]);
                                    int OTA = Convert.ToInt32(words[1]);
                                    idbookingTypeWalkInTotal.InnerText = words[0];
                                    idbookingTypeOTATotal.InnerText = words[1];
                                    if ((Walin + OTA) > 0)
                                    {
                                        int percent = 0;
                                        string lst = "";
                                        percent = ((Walin * 100) / (Walin + OTA));
                                        lst += "Walk In" + "-" + percent.ToString();

                                        percent = ((OTA * 100) / (Walin + OTA));
                                        lst += ",OTA" + "-" + percent.ToString();
                                        hdOTAWalkin.Value = lst;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GetBookingSource()
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet dsBookingSource = objHotalManagment.GetBookingSourceOnMonth(Convert.ToString(Session["UserId"]));
            RepeaterOTA.DataSource = dsBookingSource.Tables[0];
            RepeaterOTA.DataBind();
            int totalOTABooking = 0;
            for (int i = 0; i < dsBookingSource.Tables[0].Rows.Count; i++)
            {
                totalOTABooking += Convert.ToInt32(dsBookingSource.Tables[0].Rows[i]["TOTAL"]);
            }
            string lst = "";
            int per = 0;
            for (int i = 0; i < dsBookingSource.Tables[0].Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(lst))
                {
                    lst += ",";
                }
                if (Convert.ToInt32(dsBookingSource.Tables[0].Rows[i]["TOTAL"]) > 0)
                {
                    per = ((Convert.ToInt32(dsBookingSource.Tables[0].Rows[i]["TOTAL"]) * 100) / totalOTABooking);
                }
                else
                {
                    per = 0;
                }
                lst += dsBookingSource.Tables[0].Rows[i]["BookingSourceName"].ToString() + "-" + per.ToString();
            }
            hdOTAList.Value = lst;
        }

        public void getPlanDetail()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Session["Type"] != null)
            {
                DataSet ds = objDL_HotalManagment.GetPlanAdmin();
                {
                    if (ds != null)
                    {
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            int total = Convert.ToInt32(ds.Tables[0].Compute("Sum(PlanCount)", "PlanCount > 0"));
                            int percent = 0;
                            string lst = "";

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                percent = ((Convert.ToInt32(ds.Tables[0].Rows[i]["PlanCount"]) * 100) / (total));
                                if (!String.IsNullOrEmpty(lst)) lst += ",";
                                lst += Convert.ToString(ds.Tables[0].Rows[i]["PlanName"]) + "-" + percent.ToString();

                            }
                            hdPlanActive.Value = lst;

                            if (ds.Tables.Count > 1)
                            {
                                int totalAmount = Convert.ToInt32(ds.Tables[1].Compute("Sum(Amount)", "Amount > 0"));
                                string lst1 = "";
                                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                                {
                                    percent = Convert.ToInt32(ds.Tables[1].Rows[i]["Amount"]);
                                    if (!String.IsNullOrEmpty(lst1)) lst1 += ",";
                                    lst1 += Convert.ToString(ds.Tables[1].Rows[i]["PlanName"]) + "-" + percent.ToString();
                                }
                                hdPlanUsed.Value = lst1;
                            }
                        }
                    }
                }
            }
        }
    }
}