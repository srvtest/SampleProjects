using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Authentication;
using System.Data;
using EntityLayer;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;

namespace DataLayer
{
    public class CommonUtilitys
    {
        public string CPApi(string xmlDataforPost)
        {
            if (!string.IsNullOrEmpty(xmlDataforPost))
            {

                string url = "https://live.ipms247.com/pmsinterface/reservation.php";
                StreamReader sr = null;
                string xmlResponse = String.Empty;
                try
                {
                    if (!String.IsNullOrEmpty(url))
                    {
                        const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                        const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                        ServicePointManager.SecurityProtocol = Tls12;

                        HttpWebRequest myResponce = (HttpWebRequest)WebRequest.Create(url);
                        myResponce.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequired;

                        xmlDataforPost = xmlDataforPost.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
                        byte[] buffer = Encoding.UTF8.GetBytes(xmlDataforPost);
                        myResponce.Method = "POST";
                        myResponce.ContentType = "application/x-www-form-urlencoded";
                        myResponce.ContentLength = xmlDataforPost.Length;
                        using (Stream request = myResponce.GetRequestStream())
                        {
                            request.Write(buffer, 0, buffer.Length);
                        }
                        try
                        {
                            using (HttpWebResponse res = (HttpWebResponse)myResponce.GetResponse())
                            {
                                using (Stream resst = res.GetResponseStream())
                                {
                                    sr = new StreamReader(resst);
                                    xmlResponse = sr.ReadToEnd();
                                }
                            }
                            RES_Response fileResponse = xmlResponse.FromXML<RES_Response>();


                            RES_Request objRES_Request = xmlDataforPost.FromXML<RES_Request>();
                            if (objRES_Request != null && objRES_Request.Authentication != null)
                            {
                                DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
                                objDL_HotalManagment.InsertResponse(Convert.ToInt32(objRES_Request.Authentication.HotelCode), "", xmlDataforPost, xmlResponse);
                            }




                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        throw new WebException("Url is not specified");
                    }

                }
                catch (WebException ex)
                {

                }
                finally
                {
                    if (sr != null)
                        sr.Dispose();
                    //xmlResponse = null;

                }
                return xmlResponse;
            }

            return null;
        }
        public void UpdateAvailability(int HotelId, string fromDate, string toDate, int categoryId, string roomsAvailable = "")
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();

            string fDate = "";
            RES_Request objRES_Request = new RES_Request();

            DataSet ds1 = objHotalManagment.GetHotelDetailForCP(Convert.ToInt32(HotelId), 0);
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                objRES_Request.Authentication.HotelCode = Convert.ToString(ds1.Tables[0].Rows[0]["CpHotelId"]);
                objRES_Request.Authentication.AuthCode = Convert.ToString(ds1.Tables[0].Rows[0]["AuthCode"]);
            }
            DataView dv = new DataView(ds1.Tables[1]);
            dv.RowFilter = "Id=" + Convert.ToInt32(categoryId); // query example = "id = 10"

            DataTable tblFiltered = ds1.Tables[1].AsEnumerable()
            .Where(row => row.Field<Int32>("Id") == Convert.ToInt32(categoryId))
            .CopyToDataTable();
            objRES_Request.Request_Type = "UpdateAvailability";

            bool chkRate = true;

            int roomAvailable = 0;

            if (string.IsNullOrEmpty(roomsAvailable))
            {
                String tDate = "";
                for (DateTime date = Convert.ToDateTime(fromDate); date <= Convert.ToDateTime(toDate); date = date.AddDays(1))
                {
                    int avail = 0;
                    fDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                    tDate = Convert.ToDateTime(date.AddDays(+1)).ToString("yyyy-MM-dd");
                    DataSet ds = objHotalManagment.GetRoomNoByCategory(Convert.ToInt32(HotelId), Convert.ToInt32(categoryId), fDate, tDate, 0);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        RoomType objRoomType = new RoomType();
                        objRoomType.FromDate = Convert.ToDateTime(fDate).ToString("yyyy-MM-dd");
                        objRoomType.ToDate = Convert.ToDateTime(fDate).ToString("yyyy-MM-dd");
                        objRoomType.RoomTypeID = Convert.ToString(tblFiltered.Rows[0]["CpCategoryId"]);
                        objRoomType.Availability = Convert.ToString(ds.Tables[0].Rows.Count);
                        avail = ds.Tables[0].Rows.Count;
                        objRES_Request.RoomType.Add(objRoomType);
                    }
                    if (chkRate)
                    {
                        if (roomAvailable == 0)
                        {
                            roomAvailable = avail;
                            chkRate = true;
                        }
                        else if (roomAvailable == avail)
                        {
                            chkRate = true;
                        }
                        else
                        {
                            chkRate = false;
                        }
                    }
                }
            }
            else
            {
                roomAvailable = Convert.ToInt32(roomsAvailable);
            }
            string xml = string.Empty;
            if (chkRate)
            {
                objRES_Request.RoomType = new List<RoomType>();
                RoomType objRoomType = new RoomType();
                objRoomType.FromDate = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd");
                objRoomType.ToDate = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd");
                objRoomType.RoomTypeID = Convert.ToString(tblFiltered.Rows[0]["CpCategoryId"]);
                objRoomType.Availability = Convert.ToString(roomAvailable);
                objRES_Request.RoomType.Add(objRoomType);


                xml = objRES_Request.ToXML();
            }
            else
            {
                xml = objRES_Request.ToXML();
            }


            CPApi(xml);
        }

        public void SetBookingDataCP(string xmlDataAddBooking)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();

            RES_Response objRES_Response = new RES_Response();
            objRES_Response = xmlDataAddBooking.FromXML<RES_Response>();



            if (objRES_Response != null)
            {
                if (objRES_Response.Reservations.CancelReservation != null && objRES_Response.Reservations.CancelReservation.Count > 0)
                {
                    string hotelId = "0";
                    for (int i = 0; i < objRES_Response.Reservations.CancelReservation.Count; i++)
                    {
                        DataSet ds1 = objHotalManagment.GetHotelDetailForCP(0, Convert.ToInt32(objRES_Response.Reservations.CancelReservation[i].LocationId));
                        if (ds1 != null && ds1.Tables.Count > 0)
                        {
                            hotelId = Convert.ToString(ds1.Tables[0].Rows[0]["hotelId"]);
                            int Response = objHotalManagment.CancelBooking(Convert.ToInt32(objRES_Response.Reservations.CancelReservation[i].LocationId), Convert.ToString(objRES_Response.Reservations.CancelReservation[i].VoucherNo));
                            if (Response == 1)
                            {
                                BookingResponse(Convert.ToString(ds1.Tables[0].Rows[0]["CpHotelId"]), Convert.ToString(ds1.Tables[0].Rows[0]["AuthCode"]), Convert.ToString(objRES_Response.Reservations.CancelReservation[i].UniqueID), xmlDataAddBooking, null);
                            }
                        }
                    }
                }
                else if (objRES_Response.Reservations.Reservation != null && objRES_Response.Reservations.Reservation.Count > 0)
                {

                    List<Booking> lstBooking = new List<Booking>();
                    if (objRES_Response != null && objRES_Response.Reservations != null && objRES_Response.Reservations.Reservation.Count > 0)
                    {
                        int bookingCount = 0;
                        Reservation objReservation = objRES_Response.Reservations.Reservation[0];
                        DataSet ds1 = objHotalManagment.GetHotelDetailForCP(0, Convert.ToInt32(objReservation.BookByInfo.LocationId));
                        for (int j = 0; j < objRES_Response.Reservations.Reservation[0].BookByInfo.lstBookingTran.Count; j++)
                        {
                            string hotelId = "0";
                            if (ds1 != null && ds1.Tables.Count > 0)
                            {
                                hotelId = Convert.ToString(ds1.Tables[0].Rows[0]["hotelId"]);
                                string strGuid = Guid.NewGuid().ToString();
                                bool isDelete = false;
                                BookingCls objBooking = new BookingCls();
                                List<EntityLayer.BookingCls.Documents> objDocuments = new List<EntityLayer.BookingCls.Documents>();
                                objBooking.Id = 0;//R


                                objBooking.CreatedBy = Convert.ToInt32(hotelId);
                                objBooking.Modifyby = Convert.ToInt32(hotelId);
                                objBooking.FromDate = Convert.ToDateTime(objReservation.BookByInfo.lstBookingTran[j].Start);
                                objBooking.ToDate = Convert.ToDateTime(objReservation.BookByInfo.lstBookingTran[j].End);
                                objBooking.CheckinDate = Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].Start);
                                objBooking.CheckinTime = "";//R
                                objBooking.ExCheckout = "";//R


                                if (ds1 != null && ds1.Tables.Count > 1 && ds1.Tables[1].AsEnumerable().Where(row => row.Field<String>("CpCategoryId") == Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].RoomTypeCode)).Count() > 0)
                                {
                                    DataTable tblFiltered = ds1.Tables[1].AsEnumerable()
                               .Where(row => row.Field<String>("CpCategoryId") == Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].RoomTypeCode))
                               .CopyToDataTable();

                                    objBooking.categoryId = Convert.ToInt32(tblFiltered.Rows[0]["Id"]);

                                }

                                objBooking.RoomPlanid = 1;

                                if (ds1 != null && ds1.Tables.Count > 2 && ds1.Tables[2].AsEnumerable().Where(row => row.Field<String>("RTid").Trim() == Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].PackageCode)).Count() > 0)
                                {
                                    DataTable tblFilteredRateType = ds1.Tables[2].AsEnumerable()
                              .Where(row => row.Field<String>("RTid").Trim() == Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].PackageCode))
                              .CopyToDataTable();
                                    objBooking.RoomPlanid = Convert.ToInt32(tblFilteredRateType.Rows[0]["Id"]);
                                }



                                DataSet ds = objHotalManagment.GetRoomNoByCategory(Convert.ToInt32(ds1.Tables[0].Rows[0]["hotelId"]), objBooking.categoryId, Convert.ToString(objBooking.FromDate), Convert.ToString(objBooking.ToDate), 0);
                                DataSet dsBookingSourceDetail = objHotalManagment.GetBookingSourceDetail(Convert.ToInt32(objReservation.BookByInfo.LocationId), Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].TransactionId));

                                if (dsBookingSourceDetail != null && dsBookingSourceDetail.Tables.Count > 0 && dsBookingSourceDetail.Tables[0].Rows.Count > 0)
                                {
                                    bookingCount++;
                                }
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    bookingCount++;
                                }


                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    if (dsBookingSourceDetail != null && dsBookingSourceDetail.Tables.Count > 0 && dsBookingSourceDetail.Tables[0].Rows.Count == 0)
                                    {
                                        objBooking.RoomId = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);//R
                                        objBooking.BookingSourceId = 1;
                                        objBooking.Status = 2;
                                        objBooking.RoomCharges = Convert.ToDouble(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Rent);
                                        objBooking.TotalPay = Convert.ToDouble(0);
                                        objBooking.AdvanceAmount = 0;//Convert.ToDouble(objReservation.BookByInfo.lstBookingTran[j].TotalPayment);
                                        objBooking.OTATranId = objReservation.BookByInfo.lstBookingTran[j].TransactionId;
                                        objBooking.ArrivalFrom = "";
                                        objBooking.DepartureTo = "";
                                        objBooking.Tax = 0;
                                        objBooking.EarlyCheckin = 0;
                                        objBooking.LateCheckout = 0;
                                        objBooking.IsInclusive = 1;

                                        objBooking.ExtrabadCharge = 0;

                                        objBooking.BasePrice = Convert.ToDouble(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Rent);

                                        objBooking.ExtraBad = 0;
                                        objBooking.Persons = Convert.ToInt32(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Adult) + Convert.ToInt32(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Child);
                                        objBooking.Commission = 0;

                                        objBooking.SpecialRequest = "";
                                        objBooking.PersonCheckIn = 0;
                                        string b = null;
                                        b = Convert.ToString(objReservation.BookByInfo.Source);
                                        decimal c = 0;
                                        DataSet a = objHotalManagment.GetCommision(b);
                                        if (a != null && a.Tables.Count > 0 && a.Tables[0].Rows.Count > 0)
                                        {
                                            c = Convert.ToDecimal(a.Tables[0].Rows[0]["Commision"]);
                                            objBooking.BookingSourceId = Convert.ToInt32(a.Tables[0].Rows[0]["Id"]);
                                        }

                                        EntityLayer.BookingCls.Contacts objContacts = new BookingCls.Contacts();
                                        objContacts.FirstName = objReservation.BookByInfo.FirstName;
                                        objContacts.LastName = objReservation.BookByInfo.LastName;
                                        objContacts.CreatedBy = Convert.ToInt32(hotelId);

                                        objContacts.MobileNo = Convert.ToString(objReservation.BookByInfo.Mobile);
                                        objContacts.EmailId = objReservation.BookByInfo.Email;
                                        objBooking.lstCustomerContacts = new List<BookingCls.Contacts>();
                                        objBooking.lstCustomerContacts.Add(objContacts);

                                        objBooking.Discount = Convert.ToDouble(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Discount);

                                        objBooking.IsActive = Convert.ToInt16(1);

                                        objBooking.NoOfPersons = Convert.ToInt32(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Adult) + Convert.ToInt32(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[0].Child);
                                        decimal OTSGST = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["OTAGST"]);
                                        decimal calcAmount = 0;
                                        objBooking.lstBookingRoomChargesCls = new List<BookingRoomChargesCls>();
                                        for (int i = 0; i < objReservation.BookByInfo.lstBookingTran[j].RentalInfo.Count; i++)
                                        {
                                            BookingRoomChargesCls objBookingRoomChargesCls = new BookingRoomChargesCls();
                                            objBookingRoomChargesCls.BookingId = 0;
                                            objBookingRoomChargesCls.Fdate = Convert.ToDateTime(objReservation.BookByInfo.lstBookingTran[j].RentalInfo[i].EffectiveDate);


                                            decimal roomRate = Convert.ToDecimal(objReservation.BookByInfo.lstBookingTran[j].TotalPayment);
                                            if (roomRate == 0)
                                            {
                                                roomRate = Convert.ToDecimal(objReservation.BookByInfo.lstBookingTran[j].TotalRate);
                                            }

                                            roomRate = roomRate / objReservation.BookByInfo.lstBookingTran[j].RentalInfo.Count;

                                            decimal RoomCharges = roomRate;

                                            decimal TACommision = Convert.ToDecimal(objReservation.BookByInfo.lstBookingTran[j].TACommision);
                                            TACommision = TACommision / objReservation.BookByInfo.lstBookingTran[j].RentalInfo.Count;
                                            roomRate = roomRate - TACommision;
                                            decimal commition = 0;
                                            decimal otaGST = 0;
                                            if (!string.IsNullOrEmpty(objReservation.BookByInfo.lstBookingTran[j].PayAtHotel) && objReservation.BookByInfo.lstBookingTran[j].PayAtHotel.ToUpper() == "FALSE")
                                            {
                                                decimal tot = Convert.ToDecimal(objReservation.BookByInfo.lstBookingTran[j].TotalRate);
                                                decimal per = roomRate / (tot / 100);
                                                roomRate = per * (Convert.ToDecimal(objReservation.BookByInfo.lstBookingTran[j].TotalPayment) / 100);
                                                commition = ((roomRate * c) / 100);
                                                otaGST = ((commition * OTSGST) / 100);
                                                roomRate = roomRate - Math.Round((commition + otaGST + (roomRate / 100)), 0);

                                            }
                                            else
                                            {

                                                commition = ((roomRate * c) / 100);
                                                otaGST = ((commition * OTSGST) / 100);
                                                roomRate = roomRate - Math.Round((commition + otaGST), 0);
                                            }
                                            //commition = ((roomRate * c) / 100);
                                            //otaGST = ((commition * OTSGST) / 100);
                                            //roomRate = roomRate - Math.Round((commition + otaGST), 0);
                                            objBookingRoomChargesCls.RoomCharges = RoomCharges;
                                            objBookingRoomChargesCls.OTACommision = c;
                                            objBookingRoomChargesCls.Isonline = true;
                                            objBookingRoomChargesCls.OTAGst = OTSGST;
                                            objBookingRoomChargesCls.Price = roomRate;
                                            calcAmount += roomRate;
                                            objBooking.lstBookingRoomChargesCls.Add(objBookingRoomChargesCls);
                                        }
                                        objBooking.VoucherNo = objReservation.BookByInfo.lstBookingTran[j].VoucherNo;
                                        objBooking.CalcAmount = Convert.ToDouble(calcAmount);

                                        try
                                        {
                                            //
                                            string Response = objHotalManagment.SetBookingDetail(objBooking);
                                            DataSet dsBooking = objHotalManagment.GetBookingDetailByHBookingId(Response, Convert.ToInt32(hotelId));
                                            if (dsBooking != null && dsBooking.Tables.Count > 0)
                                            {
                                                SendMailToHotel(Convert.ToInt32(dsBooking.Tables[0].Rows[0][0]), Convert.ToInt32(dsBooking.Tables[0].Rows[0][2]), Convert.ToString(dsBooking.Tables[2].Rows[0][2]));
                                                SendMailToHotel(Convert.ToInt32(dsBooking.Tables[0].Rows[0][0]), Convert.ToInt32(dsBooking.Tables[0].Rows[0][2]), objReservation.BookByInfo.Email, 1);
                                                string HotelName, Address, LocationLink, PhoneNo, propertyName;
                                                HotelName = Convert.ToString(dsBooking.Tables[0].Rows[0]["Hotelname"]);
                                                Address = Convert.ToString(dsBooking.Tables[0].Rows[0]["Address"]);
                                                LocationLink = Convert.ToString(dsBooking.Tables[0].Rows[0]["PhoneNo"]);
                                                PhoneNo = Convert.ToString(dsBooking.Tables[0].Rows[0]["LocationLink"]);
                                                propertyName = Convert.ToString(dsBooking.Tables[0].Rows[0]["propertyName"]);
                                                string message = string.Empty;
                                                //"Dear Sir/Mam, Thanks for booking with us!\n\n*Reach your Anroute:* " + HotelName + "\nAdd- , " + Address + "\n*Map link:* " + LocationLink + "\nHotel Reception Contact - " + PhoneNo + "";
                                                message = "Dear sir/mam, Thanks for booking with us!\n\nReach Your Anroute- " + HotelName + ", " + Address + "\n\nMap Link: " + LocationLink + "\n\nHotel Reception Contact- " + PhoneNo + "";
                                                if (objBooking.lstCustomerContacts.Count > 0 && objBooking.lstCustomerContacts[0].MobileNo != "0")
                                                {
                                                    CommanClasses.SendSMS(message, objBooking.lstCustomerContacts[0].MobileNo.ToString());
                                                }


                                                string baseUrl = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["baseUrl"]);
                                                string strConfirm = string.Empty;
                                                strConfirm += "<table align='center' border='0' cellpadding='0' cellspacing='0' width='500'  background='" + baseUrl + "web/img/back.png'> <tbody><tr>";
                                                strConfirm += "<td align='center' style='border-top:1px solid #656565;border-bottom:1px solid #656565;border-left:1px solid #656565;border-right:1px solid #656565;' valign='top'>";
                                                strConfirm += "<table align='center' border='0' cellpadding='0' cellspacing='0' width='500' height='707'>";
                                                strConfirm += "<tbody><tr><td align='center' style='  padding-top:20px;  padding-bottom:20px; ' valign='top'>";
                                                strConfirm += "<table align='center' border='0' cellpadding='0' cellspacing='0' width='490'>";
                                                strConfirm += "<tbody><tr height='10px'>";
                                                strConfirm += "<td align='left' class='customfonts12' style='font-family:Calibri; font-size:16px; color:#010169; padding-bottom:2px; line-height:29px;  letter-spacing:1px; padding-top:170px; padding-left:25px;' valign='top' >";
                                                strConfirm += "<b>" + propertyName + "</b></td>";
                                                strConfirm += "<td width='270' align='left' class='customfonts12' style='font-family:Calibri; font-size:16px; color:#FFF; padding-bottom:2px; line-height:29px;  letter-spacing:1px; padding-top:170px; padding-left:25px;' valign='top' ></td>";
                                                strConfirm += "</tr>";
                                                strConfirm += "<tr height='10px'><td align='left' class='customfonts12' style='font-family:Calibri; font-size:16px; color:#010169; padding-bottom:2px; line-height:29px;  letter-spacing:1px; padding-top:13px; padding-left:25px;' valign='top' >";
                                                strConfirm += "<b>" + HotelName + "</b></td>";
                                                strConfirm += "</tr>";
                                                strConfirm += "<tr height='10px'><td align='left' class='customfonts12' style='font-family:Calibri; font-size:16px; color:#010169; padding-bottom:2px; line-height:29px;  letter-spacing:1px; padding-top:13px; padding-left:25px;' valign='top' >";
                                                strConfirm += "<b>" + Address + "</b></td>";
                                                strConfirm += "</tr>";
                                                strConfirm += "<tr height='10px'><td align='left' class='customfonts12' style='font-family:Calibri; font-size:16px; color:#010169; padding-bottom:2px; line-height:29px;  letter-spacing:1px; padding-top:13px; padding-left:25px;' valign='top' >";
                                                strConfirm += "<b>" + PhoneNo + "</b></td>";
                                                strConfirm += "</tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table>";

                                                CommanClasses.SendEmail(Convert.ToString(dsBooking.Tables[2].Rows[0][2]), "Booking confirmed- " + propertyName + "", strConfirm);
                                            }
                                            string roomid = Convert.ToString(objReservation.BookByInfo.UniqueID);
                                            string subBId = string.Empty;
                                            string[] arStr = Convert.ToString(objReservation.BookByInfo.lstBookingTran[j].SubBookingId).Split('-');

                                            if (arStr.Count() > 1)
                                            {
                                                subBId = arStr[1];
                                            }


                                            lstBooking.Add(new Booking { BookingId = Convert.ToString(roomid), PMS_BookingId = Convert.ToString(roomid), SubBookingId = subBId });
                                        }
                                        catch (Exception ex)
                                        {
                                            bookingCount--;
                                        }

                                        UpdateAvailability(Convert.ToInt32(hotelId), Convert.ToString(objBooking.FromDate), Convert.ToString(objBooking.ToDate), objBooking.categoryId);
                                    }

                                }
                            }
                        }
                        if (objRES_Response.Reservations.Reservation[0].BookByInfo.lstBookingTran.Count == bookingCount)
                        {
                            BookingResponse(Convert.ToString(ds1.Tables[0].Rows[0]["CpHotelId"]), Convert.ToString(ds1.Tables[0].Rows[0]["AuthCode"]), Convert.ToString(objReservation.BookByInfo.UniqueID), xmlDataAddBooking, null);
                        }
                        else
                        {
                            BookingResponse(Convert.ToString(ds1.Tables[0].Rows[0]["CpHotelId"]), Convert.ToString(ds1.Tables[0].Rows[0]["AuthCode"]), Convert.ToString(objReservation.BookByInfo.UniqueID), xmlDataAddBooking, lstBooking);
                        }
                    }
                }
            }
        }

        private void BookingResponse(string hotelId, string AuthCode, string roomId, string bookingXml, List<Booking> lstBooking)
        {
            if (!string.IsNullOrEmpty(hotelId) && !string.IsNullOrEmpty(AuthCode) && !string.IsNullOrEmpty(roomId))
            {
                RES_Request objRES_Request = new RES_Request();
                objRES_Request.Authentication.HotelCode = hotelId;
                objRES_Request.Authentication.AuthCode = AuthCode;

                Bookings objBookings = new Bookings();
                objBookings.Booking = new List<Booking>();
                if (string.IsNullOrEmpty(roomId))
                {
                    objBookings.Booking = lstBooking;
                }
                else
                {
                    objBookings.Booking.Add(new Booking { BookingId = Convert.ToString(roomId), PMS_BookingId = Convert.ToString(roomId) });
                }
                objRES_Request.Bookings = objBookings;
                objRES_Request.Request_Type = "BookingRecdNotification";
                string xml = objRES_Request.ToXML();
                string sResponse = CPApi(xml);

                DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
                //Insert response in CPLog table
                objDL_HotalManagment.InsertResponse(Convert.ToInt32(hotelId), bookingXml, xml, sResponse);

            }
        }


        public void UpdateRoomRates(int HotelId, string fromDate, string toDate, string categoryId, string ratetype, decimal basePrice, decimal exBPrice)
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            DataSet ds1 = objDL_HotalManagment.GetHotelDetailForCP(HotelId, 0);
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
                {
                    RES_Request objRES_Request = new RES_Request();
                    objRES_Request.Authentication.HotelCode = Convert.ToString(ds1.Tables[0].Rows[0]["CpHotelId"]);
                    objRES_Request.Authentication.AuthCode = Convert.ToString(ds1.Tables[0].Rows[0]["AuthCode"]);



                    objRES_Request.RateType.RoomTypeID = categoryId;
                    objRES_Request.RateType.RateTypeID = ratetype.Trim();
                    objRES_Request.RateType.FromDate = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd");
                    objRES_Request.RateType.ToDate = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd");
                    objRES_Request.Request_Type = "UpdateRoomRates";

                    objRES_Request.RateType.RoomRate = new RoomRate();
                    objRES_Request.RateType.RoomRate.Base = Convert.ToString(basePrice);
                    objRES_Request.RateType.RoomRate.ExtraAdult = Convert.ToString(exBPrice);
                    objRES_Request.RateType.RoomRate.ExtraChild = Convert.ToString(exBPrice);
                    string xml = objRES_Request.ToXML();

                    CPApi(xml);


                }
            }

        }

        public void CancelBooking(int HotelId, string VoucherNo)
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            objDL_HotalManagment.CancelBooking(HotelId, VoucherNo);

        }

        public string Report(DataSet objBooking, int type = 0)
        {

            decimal discount = Convert.ToDecimal(objBooking.Tables[0].Rows[0]["BasePrice"]) - Convert.ToDecimal(objBooking.Tables[0].Rows[0]["RoomCharges"]);
            string HotelName = string.Empty;
            string Address = string.Empty;
            string NoOfNights = (Convert.ToDateTime(objBooking.Tables[0].Rows[0]["ToDate"]) - Convert.ToDateTime(objBooking.Tables[0].Rows[0]["FromDate"])).TotalDays.ToString();
            string PhoneNo = string.Empty;

            int totalDays = 0;
            decimal totalAmtS = 0;
            totalDays = (NoOfNights == "0" ? 1 : Convert.ToInt32(NoOfNights));

            decimal totalPaid = 0;
            totalPaid = totalDays * Convert.ToDecimal(objBooking.Tables[0].Rows[0]["RoomCharges"]);


            decimal roomsTotal = totalPaid + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]);
            // decimal itemTotal = Convert.ToDecimal(totalAmount());

            decimal exbadCharge = Convert.ToDecimal(objBooking.Tables[0].Rows[0]["ExtrabadCharge"]) * totalDays;
            string HotelPolicy = string.Empty, cancelation = string.Empty, EmailId = string.Empty;
            if (objBooking.Tables.Count > 2)
            {
                if (objBooking.Tables[2].Rows.Count > 0)
                {
                    HotelName = Convert.ToString(objBooking.Tables[2].Rows[0]["Hotelname"]);
                    Address = Convert.ToString(objBooking.Tables[2].Rows[0]["Address"]);
                    PhoneNo = Convert.ToString(objBooking.Tables[2].Rows[0]["PhoneNo"]);
                    HotelPolicy = Convert.ToString(objBooking.Tables[2].Rows[0]["Hotelpolicy"]);
                    cancelation = Convert.ToString(objBooking.Tables[2].Rows[0]["Cancellation"]);
                    EmailId = Convert.ToString(objBooking.Tables[2].Rows[0]["EmailId"]);
                }
            }



            for (int m = 0; m != Convert.ToDecimal(objBooking.Tables[3].Rows.Count); m++)
            {
                totalAmtS += Convert.ToDecimal(objBooking.Tables[3].Rows[m]["RoomCharges"]);
            }

            decimal NetPayment = (totalAmtS) + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) +
 exbadCharge
 +
 Convert.ToDecimal(objBooking.Tables[0].Rows[0]["EarlyCheckin"])
 +
 Convert.ToDecimal(objBooking.Tables[0].Rows[0]["LateCheckout"])
 -
 Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])
 -
 Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Adjustment"])
 -
 Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Discount"]);

            NetPayment = Math.Round(NetPayment, 0);

            DL_HotalManagment objHotalManagment = new DL_HotalManagment();




            string prefix = Convert.ToString(objBooking.Tables[1].Rows[0]["Gender"]);
            prefix = (prefix.ToUpper() == "F") ? "Mrs." : "Mr.";

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
            sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>CONFIRM BOOKING</span><br><span style='font-size:20px;line-height:21px;color:#000'>BOOKING REFERENCE NO :</span> <span style='font-size:20px;line-height:21px;color:#000'><b>" + objBooking.Tables[0].Rows[0]["HBookingId"].ToString() + "</b></span><br><br><span style='font-size:15px;line-height:18px;color:#000'>Kindly print this confirmation and have it<br>ready upon check-in at the Hotel</span></p>");
            sb1.Append("               </td>");
            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;padding:7px'>");
            sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>" + HotelName + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>" + Address + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>-</span><br><span style='font-size:13px;line-height:18px;color:#000'><a href='mailto:" + EmailId + "' style='color:#000000' target='_blank'>" + EmailId + "</a></span><br><span style='font-size:13px;line-height:18px;color:#000'>Phone : " + PhoneNo + "</span></p>");
            sb1.Append("               </td>");
            sb1.Append("            </tr>");
            sb1.Append("         </tbody>");
            sb1.Append("      </table>");
            sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Dear " + prefix + " " + objBooking.Tables[1].Rows[0]["FirstName"] + " " + objBooking.Tables[1].Rows[0]["LastName"] + ",</p>");
            sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Thank you for choosing " + HotelName + " for your stay. We are pleased to inform you that your reservation request is CONFIRMED and your reservation details are as follows.</p>");
            sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><b style='font-size:14px'>Booking Details</b>");

            if (!string.IsNullOrEmpty(Convert.ToString(objBooking.Tables[0].Rows[0]["OTATranId"])) && !string.IsNullOrEmpty(Convert.ToString(objBooking.Tables[0].Rows[0]["VoucherNo"])))
            {
                sb1.Append("         <br><span>Booking Id: " + Convert.ToString(objBooking.Tables[0].Rows[0]["VoucherNo"]) + " </span>");
            }
            sb1.Append("         <br><span>Booking Date: " + Convert.ToString(objBooking.Tables[0].Rows[0]["BookingDate"]) + " </span><br><span>Check In Date: " + Convert.ToDateTime(objBooking.Tables[0].Rows[0]["FromDate"]).ToShortDateString() + " </span><br><span>Check Out Date :" + Convert.ToDateTime(objBooking.Tables[0].Rows[0]["ToDate"]).ToShortDateString() + " </span><br><span>Nights : " + totalDays + "</span><br><span>Checkin Time : " + Convert.ToString(objBooking.Tables[0].Rows[0]["CheckinTime"]) + "</span><br><span>CheckOut Time : " + Convert.ToString(objBooking.Tables[0].Rows[0]["CheckoutTime"]) + " </span></p>");
            sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><span style='font-size:14px'><b>Your Details</b></span><br><span>" + prefix + " " + objBooking.Tables[1].Rows[0]["FirstName"] + "</span><br><span>Email ID : " + Convert.ToString(objBooking.Tables[1].Rows[0]["Email"]) + "</span><br><span>Mobile No : " + Convert.ToString(objBooking.Tables[1].Rows[0]["Mobile"]) + "</span></p>");
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

            int totalPerson = 0;
            int TotalShowperson = 0;
            int remainPersons = 0;
            for (int i = 0; i < objBooking.Tables[0].Rows.Count; i++)
            {
                if (totalPerson == 0)
                {
                    totalPerson = Convert.ToInt32(objBooking.Tables[0].Rows[i]["NoOfPerson"]);
                    remainPersons = totalPerson;
                }
                if (string.IsNullOrEmpty(Convert.ToString(objBooking.Tables[0].Rows[i]["Persons"])))

                    TotalShowperson += 0;
                else
                    TotalShowperson += Convert.ToInt32(objBooking.Tables[0].Rows[i]["Persons"]);

                sb1.Append("            <tr style='font-size:13px'>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + objBooking.Tables[0].Rows[i]["CategoryName"] + "</b><br>Room No. " + objBooking.Tables[0].Rows[i]["RoomNo"] + "</td>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + objBooking.Tables[0].Rows[i]["CategoryName"] + "</b></td>");
                if (totalPerson != 0)
                {
                    if (remainPersons > Convert.ToInt32(objBooking.Tables[0].Rows[i]["Persons"]))
                    {
                        Int32 PersonStay = Convert.ToInt32(objBooking.Tables[0].Rows[i]["PersonStay"]);
                        if (PersonStay == 0)
                        {
                            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + objBooking.Tables[0].Rows[i]["Persons"] + " Person(s) </td>");
                        }
                        else
                        {
                            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + PersonStay + " Person(s) </td>");
                        }

                        remainPersons -= Convert.ToInt32(objBooking.Tables[0].Rows[i]["Persons"]);
                    }
                    else
                    {
                        sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + remainPersons + " Person(s) </td>");
                        remainPersons = 0;
                    }
                }
                else
                {
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + objBooking.Tables[0].Rows[i]["Persons"] + " Person(s) </td>");
                }
                // sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + objBooking.Tables[0].Rows[i]["Persons"] + " Person(s) </td>");
                switch (Convert.ToString(objBooking.Tables[0].Rows[i]["RoomPlanid"]))
                {
                    case "1":
                        sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>EP</td>");
                        break;
                    case "2":
                        sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>CP</td>");
                        break;
                    case "3":
                        sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>MAP</td>");
                        break;
                    default:
                        break;
                }
                sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
                sb1.Append("            </tr>");
            }
            if (totalPerson > TotalShowperson)
            {
                sb1.Append("            <tr style='font-size:13px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>Extra person</b></td>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + (totalPerson - TotalShowperson) + " Person(s) </td>");
                sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>-</td>");
                sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
                sb1.Append("            </tr>");
            }



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
            sb1.Append("      <div id='m_-4531955703134020943m_-7990745879711803507tagremove'></div>");
            if (type != 1)
            {
                sb1.Append("      <p style='margin:0'><span style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;display:inline-block;margin-top:14px;margin-bottom:7px'><b>Rates Details</b></span></p>");
                sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;margin-bottom:25px' width='100%'>");
                sb1.Append("         <tbody>");
                sb1.Append("            <tr style='font-size:14px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-right:none' width='30%'>Details</td>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none' width='20%'>Rates (Rs)</td>");
                sb1.Append("            </tr>");

                //sb1.Append("            <tr style='font-size:13px'>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Total Room Charges</td>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(totalDays * Convert.ToDecimal(objBooking.Tables[0].Rows[0]["RoomCharges"])) + "</td>");
                //sb1.Append("            </tr>");
                decimal commition = 0;
                decimal price = 0;
                decimal gst = 0;

                for (int m = 0; m != Convert.ToDecimal(objBooking.Tables[3].Rows.Count); m++)
                {
                    price += Convert.ToDecimal(objBooking.Tables[3].Rows[m]["Price"]);
                    sb1.Append("            <span class='removeTag'>");
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Room Charges (" + Convert.ToDateTime(objBooking.Tables[3].Rows[m]["FDate"]).ToShortDateString() + ")</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[3].Rows[m]["RoomCharges"]) + "</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            </span>");
                }

                sb1.Append("            <div class='removeTag'>");
                sb1.Append("            <tr style='font-size:13px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Room charges for customer</td>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + price.ToString() + "</td>");
                sb1.Append("            </tr>");
                sb1.Append("            </div>");



                commition = totalAmtS - price;
                if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) > 0)
                {
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>CGST</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) / 2) + "</td>");
                    sb1.Append("            </tr>");

                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>SGST</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Tax"]) / 2) + "</td>");
                    sb1.Append("            </tr>");
                }
                if (exbadCharge > 0)
                {
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Extra Bad Charges</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + exbadCharge + "</td>");
                    sb1.Append("            </tr>");
                }
                if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["EarlyCheckin"]) > 0)
                {
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Early Checkin Charges</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["EarlyCheckin"]) + "</td>");
                    sb1.Append("            </tr>");
                }
                if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["LateCheckout"]) > 0)
                {
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Late Checkout Charges</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["LateCheckout"]) + "</td>");
                    sb1.Append("            </tr>");
                }
                if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Adjustment"]) > 0)
                {
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Adjustment</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["Adjustment"]) + "</td>");
                    sb1.Append("            </tr>");
                }
                if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"]) > 0)
                {
                    sb1.Append("            <span class='removeTag'>");
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Advance</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["AdvanceAmount"]) + "</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            </span>");
                }
                if (Convert.ToDecimal(objBooking.Tables[0].Rows[0]["Discount"]) > 0)
                {
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Discount</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(objBooking.Tables[0].Rows[0]["Discount"]) + "</td>");
                    sb1.Append("            </tr>");
                }
                if (objBooking.Tables[3].Rows.Count > 0 && Convert.ToBoolean(objBooking.Tables[3].Rows[0]["Isonline"]))//Isonline
                {
                    sb1.Append("            <div class='removeTag'>");
                    //if (price > NetPayment - Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"]))
                    //{
                    //    sb1.Append("            <tr style='font-size:13px'>");
                    //    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Travinities pay to hotel</td>");
                    //    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"]) - commition) + "</td>");
                    //    sb1.Append("            </tr>");
                    //}
                    //else
                    //{
                    //    sb1.Append("            <tr style='font-size:13px'>");
                    //    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Hotel pay to travinities</td>");
                    //    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + Convert.ToString(commition - Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])) + "</td>");
                    //    sb1.Append("            </tr>");
                    //}
                    sb1.Append("            <tr style='font-size:13px'>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Hotel pay to travinities</td>");
                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + price.ToString() + "</td>");
                    sb1.Append("            </tr>");
                    sb1.Append("            </div>");
                }

                //sb1.Append("            <div class='removeTag'>");
                //sb1.Append("            <tr style='font-size:13px'>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Amount to be collected from guest</td>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + (NetPayment).ToString() + "</td>");
                //sb1.Append("            </tr>");
                //sb1.Append("            </div>");
                sb1.Append("            <div class='removeTag'>");
                sb1.Append("            <tr style='font-size:13px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Amount to be collected from guest</td>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>0</td>");
                sb1.Append("            </tr>");
                sb1.Append("            </div>");

                //sb1.Append("         <div class='removeTag'>");
                //sb1.Append("            <tr style='font-size:13px'>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Grand Total A</td>");
                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + (NetPayment + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])).ToString() + "</td>");
                //sb1.Append("            </tr>");
                //sb1.Append("         </div>");

                sb1.Append("         <span class='removeTag'>");
                sb1.Append("            <tr style='font-size:13px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Grand Total</td>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + (NetPayment).ToString() + "</td>");
                sb1.Append("            </tr>");
                sb1.Append("         </span>");

                sb1.Append("            <tr style='font-size:13px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif' colspan=2><hr></td>");
                sb1.Append("            </tr>");



                sb1.Append("         </tbody>");
                sb1.Append("      </table>");
                sb1.Append("      <div style='width:30%;display:inline-block;border-style:double;border-width:4px;border-color:black;padding:5px;margin-bottom:0px;vertical-align:top'>");
                //sb1.Append("         <div class='removeTag'>");
                //sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>AMOUNT IN WORDS A</p>");
                //sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>" + changeToWords((NetPayment + Convert.ToDecimal(objBooking.Tables[0].Rows[0]["AdvanceAmount"])).ToString(), true).ToUpper() + "</p>");
                //sb1.Append("         </div>");

                sb1.Append("         <div class='removeTag'>");
                sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>AMOUNT IN WORDS</p>");
                sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>" + changeToWords(NetPayment.ToString(), true).ToUpper() + "</p>");
                sb1.Append("         </div>");


                sb1.Append("         <span class='removeTag'>");
                sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>AMOUNT IN WORDS</p>");
                sb1.Append("            <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>" + changeToWords(NetPayment.ToString(), true).ToUpper() + "</p>");
                sb1.Append("         </span>");
                sb1.Append("      </div>");

            }
            sb1.Append("      <div style='width:67%;margin-bottom:14px;display:inline-block'>");
            sb1.Append("         <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px;text-align:right;margin-top:0'><b>Booked &amp; Payable By</b><br>" + prefix + " " + objBooking.Tables[1].Rows[0]["FirstName"] + " " + objBooking.Tables[1].Rows[0]["LastName"] + "<br>" + objBooking.Tables[1].Rows[0]["Email"] + "<br></p>");
            sb1.Append("      </div>");
            sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000' width='100%'>");
            sb1.Append("         <tbody>");
            sb1.Append("            <tr style='font-size:14px'>");
            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black' width='100%'>Conditions &amp; Policies</td>");
            sb1.Append("            </tr>");
            sb1.Append("            <tr style='font-size:13px'>");
            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Cancellation Policy</b><br>" + cancelation + "</td>");
            sb1.Append("            </tr>");
            sb1.Append("            <tr style='font-size:13px'>");
            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Hotel Policy </b><br>" + HotelPolicy);
            sb1.Append("                  <br><b>Hotel Check in Time : </b> 12:00 PM<br><b>Hotel Check out Time : </b> 11:00 AM</td>");
            sb1.Append("            </tr>");
            if (!string.IsNullOrEmpty(objBooking.Tables[0].Rows[0]["SpecialRequest"].ToString()))
            {
                sb1.Append("            <tr style='font-size:13px'>");
                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Special Request</b><br>" + objBooking.Tables[0].Rows[0]["SpecialRequest"] + "</td>");
                sb1.Append("            </tr>");
            }
            sb1.Append("         </tbody>");
            sb1.Append("      </table>");
            sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'><span style='font-weight:bold;text-align:center;display:block;color:#000'>This email has been sent from an automated system - please do not reply to it.</span></p>");
            sb1.Append("      <hr>");
            sb1.Append("   </div>");
            sb1.Append("   <br>");
            sb1.Append("</div>");
            return sb1.ToString();

        }



        private String changeToWords(String numb, bool isCurrency)
        {

            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";

            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {

                int decimalPlace = numb.IndexOf("."); if (decimalPlace > 0)
                {

                    wholeNo = numb.Substring(0, decimalPlace);

                    points = numb.Substring(decimalPlace + 1);

                    if (Convert.ToInt32(points) > 0)
                    {

                        andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents

                        endStr = (isCurrency) ? ("Cents " + endStr) : ("");
                        pointStr = translateCents(points);

                    }

                }

                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }

            catch { ;} return val;
        }

        private String translateWholeNumber(String number)
        {

            string word = "";

            try
            {

                bool beginsZero = false;//tests for 0XX

                bool isDone = false;//test if already translated

                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric

                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;

                    int pos = 0;//store digit grouping

                    String place = "";//digit grouping name:hundres,thousand,etc...

                    switch (numDigits)
                    {

                        case 1://ones' range

                            word = ones(number);

                            isDone = true;
                            break;

                        case 2://tens' range

                            word = tens(number);

                            isDone = true;
                            break;

                        case 3://hundreds' range

                            pos = (numDigits % 3) + 1;

                            place = " Hundred ";
                            break;

                        case 4://thousands' range

                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;

                            place = " Thousand ";

                            break;
                        case 7://millions' range

                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;

                            place = " Million ";

                            break;
                        case 10://Billions's range

                            pos = (numDigits % 10) + 1;

                            place = " Billion ";
                            break;

                        //add extra case options for anything above Billion...

                        default:
                            isDone = true;

                            break;
                    }

                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)

                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));

                        //check for trailing zeros

                        if (beginsZero) word = " and " + word.Trim();
                    }

                    //ignore digit grouping names

                    if (word.Trim().Equals(place.Trim())) word = "";
                }

            }

            catch { ;} return word.Trim();
        }

        private String tens(String digit)
        {

            int digt = Convert.ToInt32(digit);

            String name = null; switch (digt)
            {

                case 10:

                    name = "Ten";
                    break;

                case 11:
                    name = "Eleven";

                    break;
                case 12:

                    name = "Twelve";
                    break;

                case 13:
                    name = "Thirteen";

                    break;
                case 14:

                    name = "Fourteen";
                    break;

                case 15:
                    name = "Fifteen";

                    break;
                case 16:

                    name = "Sixteen";
                    break;

                case 17:
                    name = "Seventeen";

                    break;
                case 18:

                    name = "Eighteen";
                    break;

                case 19:
                    name = "Nineteen";

                    break;
                case 20:

                    name = "Twenty";
                    break;

                case 30:
                    name = "Thirty";

                    break;
                case 40:

                    name = "Fourty";
                    break;

                case 50:
                    name = "Fifty";

                    break;
                case 60:

                    name = "Sixty";
                    break;

                case 70:
                    name = "Seventy";

                    break;
                case 80:

                    name = "Eighty";
                    break;

                case 90:
                    name = "Ninety";

                    break;
                default:

                    if (digt > 0)
                    {

                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }

                    break;
            }

            return name;
        }

        private String ones(String digit)
        {

            int digt = Convert.ToInt32(digit);
            String name = "";

            switch (digt)
            {

                case 1:
                    name = "One";

                    break;
                case 2:

                    name = "Two";
                    break;

                case 3:
                    name = "Three";

                    break;
                case 4:

                    name = "Four";
                    break;

                case 5:
                    name = "Five";

                    break;
                case 6:

                    name = "Six";
                    break;

                case 7:
                    name = "Seven";

                    break;
                case 8:

                    name = "Eight";
                    break;

                case 9:
                    name = "Nine";

                    break;
            }

            return name;
        }

        private String translateCents(String cents)
        {

            String cts = "", digit = "", engOne = ""; for (int i = 0; i < cents.Length; i++)
            {

                digit = cents[i].ToString();

                if (digit.Equals("0"))
                {

                    engOne = "Zero";
                }

                else
                {

                    engOne = ones(digit);

                }

                cts += " " + engOne;
            }

            return cts;
        }

        public void SendMailToHotel(int bookingId, int UserId, string emailTo, int type = 0)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet objBooking = objHotalManagment.GetBookingInformationById(bookingId, UserId);
            if (objBooking.Tables.Count > 0 && objBooking.Tables[0].Rows.Count > 0)
            {
                string HtmlText = Report(objBooking, type);
                string str = HtmlText;// sw.GetStringBuilder().ToString();
                str = str.Replace("border=\"1\"", "border=\"0\"");
                str = new Regex("<div class='removeTag'>.*?</div>").Replace(str, string.Empty);
                str = "Dear Hotel ,<br>" + str;
                if (type == 0)
                {
                    CommanClasses.SendEmail(emailTo, "Invoice", str);
                }

            }
        }

        public void InsertLogs(string logs)
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            objDL_HotalManagment.InsertLogs(logs);
        }
    }
}

