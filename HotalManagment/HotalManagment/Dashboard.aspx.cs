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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDashBoardAgainstId();
                GetChartData();
            }
        }
        public void GetChartData()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            DataSet ds = objDL_HotalManagment.GetBookedRoomDetail(Convert.ToInt32(Session["UserId"]));
            BindBookingAmount(ds.Tables[0]);
            BindBookingRooms(ds.Tables[1]);
            BindTop20Booking(ds.Tables[2]);
            BindTodaysCheckIn(ds.Tables[3]);
            BindTodaysCheckOut(ds.Tables[4]);
            BindWeeklyAmount(ds.Tables[5]);
        }

        public void BindWeeklyAmount(DataTable dt)
        {

            RepterDetails.DataSource = dt;
            RepterDetails.DataBind();
        }

        public void BindBookingAmount(DataTable dt)
        {
            string chartDetail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "<div class='singleBar'>";
                chartDetail += "<div class='bar'>";
                chartDetail += "<div class='value'>";
                chartDetail += "<span>" + Convert.ToInt32(dt.Rows[i][2]) + "</span>";
                chartDetail += "</div>";
                chartDetail += "</div>";
                chartDetail += "<div class='title'>" + dt.Rows[i][0] + " " + dt.Rows[i][1] + "</div>";
                chartDetail += "</div>";
            }
            BookingAmount.InnerHtml = chartDetail;

        }

        public void BindBookingRooms(DataTable dt)
        {
            string chartDetail = "";
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "<div class='singleBar'>";
                chartDetail += "<div class='bar'>";
                chartDetail += "<div class='value'>";
                chartDetail += "<span>" + Convert.ToInt32(dt.Rows[i][2]) + "</span>";
                chartDetail += "</div>";
                chartDetail += "</div>";
                chartDetail += "<div class='title'>" + dt.Rows[i][0] + " " + dt.Rows[i][1] + "</div>";
                chartDetail += "</div>";
            }
            BookingRoom.InnerHtml = chartDetail;

        }

        public void BindTop20Booking(DataTable dt)
        {
            string chartDetail = " <ul class='todo-list'>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "<li>" + dt.Rows[i][0] + " ";
                //chartDetail += "<span class='label label-important'>today</span> ";
                chartDetail += "<span class='todo-actions'>";
                chartDetail += "<a href='#'><i class='halflings-icon ok'></i></a>";
                chartDetail += "<a href='#' class='todo-remove'><i class='halflings-icon remove'></i></a></span>";
                chartDetail += "</li>";
            }
            chartDetail += "</ul>";
            lstlast20.InnerHtml = chartDetail;
        }

        public void BindTodaysCheckIn(DataTable dt)
        {
            string chartDetail = " <ul class='todo-list'>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "<li>" + dt.Rows[i][0] + " ";
               // chartDetail += "<span class='label label-important'>today</span> ";
                chartDetail += "<span class='todo-actions'>";
                chartDetail += "<a href='#'><i class='halflings-icon ok'></i></a>";
                chartDetail += "<a href='#' class='todo-remove'><i class='halflings-icon remove'></i></a></span>";
                chartDetail += "</li>";
            }
            chartDetail += "</ul>";
            lstCheckin.InnerHtml = chartDetail;
        }

        public void BindTodaysCheckOut(DataTable dt)
        {
            string chartDetail = " <ul class='todo-list'>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartDetail += "<li>" + dt.Rows[i][0] + " ";
               // chartDetail += "<span class='label label-important'>today</span> ";
                chartDetail += "<span class='todo-actions'>";
                chartDetail += "<a href='#'><i class='halflings-icon ok'></i></a>";
                chartDetail += "<a href='#' class='todo-remove'><i class='halflings-icon remove'></i></a></span>";
                chartDetail += "</li>";
            }
            chartDetail += "</ul>";
            lstCheckOut.InnerHtml = chartDetail;
        }



        public void GetDashBoardAgainstId()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Session["Type"] != null)
            {
                DataSet ds = objDL_HotalManagment.GetDashBoardAgainstId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["Type"]));
                if (ds != null)
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataColumnCollection columns = ds.Tables[0].Columns;

                        idBookingdays.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfBookingToday"]);
                        idWeekgdays.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfWeekBooking"]);
                        idMonthdays.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfMonthBooking"]);
                        idTotalRooms.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfRooms"]);

                        if (Convert.ToInt32(Session["Type"]) == 2)
                        {
                            idRoomHK.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsHK"]);
                            idRoomBooked.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsBooked"]);
                            idAvailableRoom.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfRoomsAvailable"]);
                            idNoOfChecking.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoofTodayChecking"]);
                            idNoOfCheckOut.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfTodayChaeckOut"]);
                            idGreenBox2.Visible = true;
                            idYellowBox2.Visible = true;
                            idBlueBox2.Visible = true;
                            idPurpleBox2.Visible = true;
                            idGreenBox3.Visible = true;
                            idPurpleBox1.Visible = true;
                        }
                        else
                        {

                            noOfHotels.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["NoOfHotels"]);
                            idPurpleBox.Visible = true;
                            idPurpleBox1.Visible = true;
                        }

                    }
                }
            }
        }
    }
}