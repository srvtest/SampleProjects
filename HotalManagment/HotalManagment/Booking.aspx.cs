using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace HotalManagment
{
    public partial class Booking : System.Web.UI.Page
    {
        string folderDocumentsName = ConfigurationManager.AppSettings["folderCustDocuments"].ToString();
        string folderCustPhotos = ConfigurationManager.AppSettings["folderCustPhotos"].ToString();
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        List<EntityLayer.BookingCls.Documents> lstDeletedDoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (!IsPostBack)
            {

                date.Text = CommanClasses.CurrentDateTime().Date.ToShortDateString();
                getControlData();
            }

            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }



        public void getControlData()
        {
            DataSet dsCategory = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            if (dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
            {
                ddCategoryData.DataValueField = "Id";
                ddCategoryData.DataTextField = "CategoryName";
                if (dsCategory.Tables[0].Select("IsActive = 1").Count() > 0)
                {
                    ddCategoryData.DataSource = dsCategory.Tables[0].Select("IsActive = 1").CopyToDataTable();
                    ddCategoryData.DataBind();
                    ddCategoryData.Items.Insert(0, new ListItem("All", "0"));
                    ddCategoryData_SelectedIndexChanged(null, null);
                }

            }

        }

        protected void btnAddNew_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("addUpdateBooking.aspx");
        }
        protected void ddCategoryData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddCategoryData.SelectedValue))
            {
                UpdateBookingScreen();
            }

        }

        private void UpdateBookingScreen()
        {
            if (string.IsNullOrEmpty(date.Text)) date.Text = CommanClasses.CurrentDateTime().ToShortDateString();
            DateTime Chartdate = Convert.ToDateTime(date.Text);
            DateTime Currdate = Convert.ToDateTime(CommanClasses.CurrentDateTime().ToShortDateString());
            double BackDays = (Currdate - Chartdate).TotalDays;

            DataSet dsCategory = objHotalManagment.GetRoomCategoryWise(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddCategoryData.SelectedValue), Convert.ToDateTime(date.Text));
            string htmlCode = "";

            DataSet dsPreBookingStatus = objHotalManagment.GetPreBookingStatus(Convert.ToInt32(Session["UserId"]), Convert.ToDateTime(date.Text));
            lblPrebooking.Text = "Pre-Booking : ";
            for (int j = 0; j < dsPreBookingStatus.Tables[0].Rows.Count; j++)
            {
                if (j > 0)
                {
                    lblPrebooking.Text += " and ";
                }
                lblPrebooking.Text += Convert.ToString(dsPreBookingStatus.Tables[0].Rows[j]["PreBooking"]) + " " + Convert.ToString(dsPreBookingStatus.Tables[0].Rows[j]["CategoryName"]);
            }


            for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
            {
                bool curStatus = true;
                for (int j = 0; j < dsPreBookingStatus.Tables[0].Rows.Count; j++)
                {
                    if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["categoryId"]) == Convert.ToInt32(dsPreBookingStatus.Tables[0].Rows[j]["categoryId"]) && Convert.ToInt32(dsPreBookingStatus.Tables[0].Rows[j]["roomsAvl"]) == Convert.ToInt32(dsPreBookingStatus.Tables[0].Rows[j]["PreBooking"]))
                    {
                        curStatus = false;
                    }
                }
                string colorCode = "purpleNew";
                if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["IsUnderHK"]) == 0)
                {
                    //colorCode = getColorCode(Convert.ToInt32(dsCategory.Tables[0].Rows[i]["categoryId"]));
                    if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["status"]) == 0)
                    {
                        colorCode = "blueNew";
                    }
                    else
                    {
                        if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["statusCheckIn"]) == 0)
                        {
                            colorCode = "warning";
                        }
                        else
                        {
                            colorCode = "redNew";

                        }



                    }
                }
                htmlCode += "<div class='box-room'>";
                htmlCode += "<div class='info-box bg-" + colorCode + "'>";
                htmlCode += "<span class='header'>" + dsCategory.Tables[0].Rows[i]["CategoryName"] + "</span><br>";
                if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["IsUnderHK"]) == 0)
                {
                    if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["status"]) == 0)

                        if (curStatus == false)
                        {
                            htmlCode += "<a href='javascript:popupmsg();' önclick='popupmsg();' style='color: white;'>";
                        }
                        else
                        {
                            //if (BackDays > 0)
                            //{
                            //     htmlCode += "<a href=#  style='color: white;'>";
                            //}
                            //else
                            {
                                if (chkMiltipleBooking.Checked)
                                {
                                    htmlCode += "<input type='checkbox' class='chkClass' onclick='handleClick(this);' value='" + dsCategory.Tables[0].Rows[i]["roomno"] + "_" + dsCategory.Tables[0].Rows[i]["roomId"] + "_" + dsCategory.Tables[0].Rows[i]["categoryId"] + "'  ><a href=#  style='color: white;'>";

                                }
                                else
                                {
                                    htmlCode += "<a href=addUpdateBooking.aspx?prm=" + CommanClasses.Encrypt(Convert.ToString("RoomNo=" + dsCategory.Tables[0].Rows[i]["roomno"] + "&RoomId=" + dsCategory.Tables[0].Rows[i]["roomId"] + "&CategoryId=" + dsCategory.Tables[0].Rows[i]["categoryId"] + "&BookFrom=" + Convert.ToDateTime(date.Text))) + " style='color: white;'>";
                                }
                            }
                        }
                    else
                        htmlCode += "<a href=addUpdateBooking.aspx?prm=" + CommanClasses.Encrypt(Convert.ToString("BookingId=" + dsCategory.Tables[0].Rows[i]["status"] + "&RoomNo=" + dsCategory.Tables[0].Rows[i]["RoomNo"])) + " style='color: white;'>";
                }
                else
                {
                    htmlCode += "<a href=#  style='color: white;'>";
                }
                htmlCode += "<span class='push-bottom'>" + dsCategory.Tables[0].Rows[i]["roomno"] + "</span></a>";
                htmlCode += "<div class='info-box-content'>";

                if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["IsUnderHK"]) == 0)
                {
                    if (Convert.ToInt32(dsCategory.Tables[0].Rows[i]["status"]) == 0)
                        htmlCode += "<span class='info-box-number'>Vacant</span>";
                    else
                        htmlCode += "<span class='info-box-number'>Booked</span>";
                    //htmlCode += "<span class='info-box-number' style='white-space: nowrap; background: rgba(228, 11, 41, 0.87); font-size: 13px; padding: 0 30px;' >Booked</span>";
                }
                else
                {
                    htmlCode += "<span class='info-box-number'>House keeping</span>";
                }
                htmlCode += "</div>";
                htmlCode += "</div></a>";
                htmlCode += "</div>";
            }
            lstRoom.InnerHtml = htmlCode;
        }


        private string getColorCode(int CategoryId)
        {
            string ColorName = string.Empty;
            int ColorId = CategoryId % 6;
            switch (ColorId)
            {
                case 0:
                    ColorName = "primary";
                    break;
                case 1:
                    ColorName = "warning";
                    break;
                case 2:
                    ColorName = "success";
                    break;
                case 3:
                    ColorName = "blue";
                    break;
                case 4:
                    ColorName = "orange";
                    break;
                case 5:
                    ColorName = "info";
                    break;
                default:
                    break;
            }
            return ColorName;
        }

        protected void btnShowBooking_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowBookingData.aspx");
        }

        protected void txtBookingDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddCategoryData.SelectedValue))
            {
                UpdateBookingScreen();
            }

        }

        protected void chkMiltipleBooking_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBookingScreen();
        }

        protected void btnMultipleBooking_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdroomId.Value))
            {
                string RoomDetails = hdroomId.Value;
                string roomNo = string.Empty;
                string roomId = string.Empty;
                string categoryId = string.Empty;
                string[] str = RoomDetails.Split(',');
                if (str.Count() > 0)
                {
                    roomNo = str[0].Split('_')[0];
                    roomId = str[0].Split('_')[1];
                    categoryId = str[0].Split('_')[2];
                }
                string pageUrl = "addUpdateBooking.aspx?prm=" + CommanClasses.Encrypt(Convert.ToString("RoomNo=" + roomNo + "&RoomId=" + roomId + "&CategoryId=" + categoryId + "&BookFrom=" + Convert.ToDateTime(date.Text) + "&RoomDetails=" + RoomDetails));
                Response.Redirect(pageUrl);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                hdMessage.Value += "Please select rooms.";
            }
        }
    }
}
