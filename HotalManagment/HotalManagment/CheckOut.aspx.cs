using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;
using EntityLayer;
using System.Text;
using System.IO;
using System.Configuration;

namespace HotalManagment
{
    public partial class CheckOut : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        int bookingId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getBookingItem();
            }
        }

        public void getBookingItem()
        {
            DataSet ds = objHotalManagment.BookedUserDetail(Convert.ToInt32(Session["UserId"]));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddRoomList.DataSource = ds.Tables[0];
                ddRoomList.DataTextField = "RoomDate";
                ddRoomList.DataValueField = "Id";
                ddRoomList.DataBind();
                ddRoomList.Items.Insert(0, new ListItem("Select Room", "0"));

                DataSet dsRoomPlan = objHotalManagment.GetAllRoomPlan(0);
                ddRoomPlan.DataValueField = "Id";
                ddRoomPlan.DataTextField = "RoomPlanName";
                ddRoomPlan.DataSource = dsRoomPlan.Tables[0];
                ddRoomPlan.DataBind();
            }
        }
        protected void ddRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRoomList.SelectedValue != "0")
            {
                hdBookingId.Value = Convert.ToString(ddRoomList.SelectedValue);
                getDataByBookingId();
                if (Convert.ToDateTime(txtTodate.Text)<DateTime.Now.Date)
                {
                    pnlSKey.Attributes.Add("style", "display:block");
                    pnlList.Attributes.Add("style", "display:none");
                }
                else
                {
                    pnlEdit.Attributes.Add("style", "display:block");
                    pnlList.Attributes.Add("style", "display:none");
                }
            }
            else
            {
                pnlEdit.Attributes.Add("style", "display:none");
                pnlList.Attributes.Add("style", "display:block");
            }
        }

        protected void txtCalculation(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        protected void CalculateAmount()
        {
            getBookedItemByBookingId();

            lblPlanName.InnerText = ddRoomPlan.SelectedItem.Text;
          
            decimal price = 0;
            switch (ddRoomPlan.SelectedItem.Value)
            {   
                case "1":
                   // price = Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdEPCharge.Value);
                    price = Convert.ToDecimal(txtRoomCharges.Text) ;
                    break;
                case "2":
                    //price = Convert.ToDecimal(txtRoomCharges.Text) + (Convert.ToDecimal(hdCPCharge.Value));
                    price = Convert.ToDecimal(txtRoomCharges.Text);
                    break;
                case "3":
                   // price = Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdMAPCharge.Value);
                    price = Convert.ToDecimal(txtRoomCharges.Text) ;
                    break;
                default:
                    break;
            }
            lblRoomCharge.InnerText = price.ToString(); ;
           // lblRoomDiscount.InnerText = Convert.ToString(price - Convert.ToDecimal(txtRoomCharges.Text));
            lblNoofPersons.InnerText = Convert.ToString(Convert.ToInt32(hdPresons.Value)+Convert.ToInt32(ddExtrabad.SelectedItem.Value));

            List<EntityLayer.BookingCls.Contacts> lstDocument = (List<EntityLayer.BookingCls.Contacts>)Session["lstCustomer"];




            lblNoofPersons.InnerText = Convert.ToString(Convert.ToInt32(lstDocument.Count));//+ Convert.ToInt32(ddExtrabad.SelectedItem.Value));


            hdGSTPer.Value = Convert.ToString(objHotalManagment.GetTaxPercentage(Convert.ToInt32(Session["UserId"]), Convert.ToDecimal(txtRoomCharges.Text)));
            hdnTotalPP.Value = string.IsNullOrEmpty(hdnTotalPP.Value) ? "0" : hdnTotalPP.Value;
            txtDiscount.Text = string.IsNullOrEmpty(txtDiscount.Text) ? "0" : txtDiscount.Text;
            txtTax.Text = string.IsNullOrEmpty(txtTax.Text) ? "0" : txtTax.Text;
            txtAdjust.Text = string.IsNullOrEmpty(txtAdjust.Text) ? "0" : txtAdjust.Text;
            txtAdvance.Text = string.IsNullOrEmpty(txtAdvance.Text) ? "0" : txtAdvance.Text;
            txtEarlyCheckin.Text = string.IsNullOrEmpty(txtEarlyCheckin.Text) ? "0" : txtEarlyCheckin.Text;
            txtLateCheckout.Text = string.IsNullOrEmpty(txtLateCheckout.Text) ? "0" : txtLateCheckout.Text;
            //
            lblDiscount.InnerText = txtDiscount.Text;

            lblAdvance.InnerText = txtAdvance.Text;
            int totalDays = 0;
            totalDays = Convert.ToInt32((Convert.ToDateTime(txtTodate.Text) - Convert.ToDateTime(txtFromDate.Text)).TotalDays);
            if (totalDays == 0) totalDays = 1;
            lblNoOfDays.InnerText = totalDays.ToString();
            txtPaidAmount.Text = (Convert.ToDecimal(lblAdvance.InnerText) + Convert.ToDecimal(hdnTotalPP.Value)).ToString();
            decimal totalPaid = 0;

            ///////////////////////////////////////////////////////////////////////
            decimal totalAmtS = 0;
            //DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            // int bookingsId = string.IsNullOrEmpty(Convert.ToString(Request.QueryString["Id"])) ? 0 : Convert.ToInt32(Request.QueryString["Id"]);
            DataSet objBooking = objHotalManagment.GetBookingInformationById(Convert.ToInt32(hdBookingId.Value), Convert.ToInt32(Session["UserId"]));
            for (int m = 0; m != Convert.ToDecimal(objBooking.Tables[3].Rows.Count); m++)
            {
                totalAmtS += Convert.ToDecimal(objBooking.Tables[3].Rows[m]["RoomCharges"]);
            }
            //////////////////////////////////////////////////////////
            
            //totalPaid = totalDays * Convert.ToDecimal(txtRoomCharges.Text);

            totalPaid = totalAmtS;

           // txtTax.Text = (((totalPaid) / 100) * Convert.ToDecimal(hdGSTPer.Value)).ToString("0.##");
            lblTax.InnerText = txtTax.Text;
            decimal roomsTotal = totalPaid + Convert.ToDecimal(txtTax.Text);
            decimal itemTotal = Convert.ToDecimal(totalAmount());
            idExBadChargesAmt.InnerText = Convert.ToString(Convert.ToDecimal(txtExtrabadCharges.Text) * totalDays);
            lblEcharges.InnerText = txtEarlyCheckin.Text;
            lblLCharges.InnerText = txtLateCheckout.Text;
            lblAdjestmentCharge.InnerText = txtAdjust.Text;
            idExBadCharges.Visible = (txtExtrabadCharges.Text != "0");
            idEcharges.Visible = (txtEarlyCheckin.Text != "0");
            idLcharges.Visible = (txtLateCheckout.Text != "0");
            idAdjestment.Visible = (txtAdjust.Text != "0");
            txtNetTotal.Text = Convert.ToString(roomsTotal + itemTotal + Convert.ToDecimal(txtEarlyCheckin.Text) + Convert.ToDecimal(txtLateCheckout.Text) + (Convert.ToDecimal(txtExtrabadCharges.Text) * totalDays));
            decimal dueAmount = Convert.ToDecimal(txtNetTotal.Text) - Convert.ToDecimal(txtAdvance.Text) - Convert.ToDecimal(txtDiscount.Text) - Convert.ToDecimal(txtAdjust.Text) - Convert.ToDecimal(hdnTotalPP.Value);
            txtDueAmount.Text = "0";// Convert.ToString(dueAmount);
            lblDueAmount.Text = Convert.ToString(dueAmount);

             //lblTotal.InnerText = Convert.ToString(((price - (price - Convert.ToDecimal(txtRoomCharges.Text))) * totalDays) + Convert.ToDecimal(txtTax.Text));
            lblTotal.InnerText = Convert.ToString(totalPaid);
            
            //lblTotal.InnerText = Convert.ToString(totalPaid + Convert.ToDecimal(txtTax.Text));
            lblGrandTotal.InnerText = Convert.ToString((totalPaid + Convert.ToDecimal(txtTax.Text) + (Convert.ToDecimal(txtExtrabadCharges.Text) * totalDays) + Convert.ToDecimal(txtEarlyCheckin.Text) + Convert.ToDecimal(txtLateCheckout.Text)) - Convert.ToDecimal(txtAdvance.Text) - Convert.ToDecimal(txtDiscount.Text) - Convert.ToDecimal(txtAdjust.Text));
        }

        public void getBookedItemByBookingId()
        {
            BookingDetailsCls objbookingDetails = new BookingDetailsCls();
            DataSet ds = objHotalManagment.BookedItemDetail(Convert.ToInt32(hdnBookingId.Value));
            double totalAmount = 0;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataView dv1 = ds.Tables[0].DefaultView;
                dv1.RowFilter = " Status=2";
                DataTable dtNew = dv1.ToTable();
                RepterDetails.DataSource = dtNew;
                RepterDetails.DataBind();
                for (int i = 0; i < dtNew.Rows.Count; i++)
                {
                    totalAmount += (Convert.ToInt32(dtNew.Rows[i]["Price"]) * Convert.ToInt32(dtNew.Rows[i]["Quantity"])) + Convert.ToInt32(dtNew.Rows[i]["tax"]);
                }
            }
            hdItemAmount.Value = Convert.ToString(totalAmount);
            DataSet ds1 = objHotalManagment.GetPartialPaymentDetails(Convert.ToInt32(hdBookingId.Value), !string.IsNullOrEmpty(Convert.ToString(Session["UserId"])) ? Convert.ToInt32(Session["UserId"]) : 0);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0] != null)
            {
                hdnTotalPP.Value = Convert.ToString(ds1.Tables[0].Compute("SUM(Amount)", string.Empty));
                repeterPayment.DataSource = ds1.Tables[0];
                repeterPayment.DataBind();
            }
        }

        public void getDataByBookingId()
        {
            hdnBookingId.Value = hdBookingId.Value;
            BookingCls objBooking = objHotalManagment.GetBookingDetailByBookindIdAndId(Convert.ToInt32(hdBookingId.Value), Convert.ToInt32(Session["UserId"]));
            if (objBooking != null)
            {
                txtFromDate.Text = objBooking.FromDate.ToShortDateString();
                txtTodate.Text = objBooking.ToDate.ToShortDateString();
                txtCheckinDate.Text = !string.IsNullOrEmpty(objBooking.CheckinDate) ? Convert.ToDateTime(objBooking.CheckinDate).ToShortDateString() : "";
                txtCheckinTime.Text = objBooking.CheckinTime;
                txtCheckoutTime.Text = objBooking.CheckoutTime;
                ddBookingSource.SelectedValue = Convert.ToString(objBooking.BookingSourceId);
                if (objBooking.BookingSourceId > 0)
                {
                    txtBookingSourceId.Visible = true;
                }
                txtDiscount.Text = Convert.ToString(objBooking.Discount);
                txtRoomCharges.Text = Convert.ToString(objBooking.RoomCharges);
                ddCategory.SelectedValue = Convert.ToString(objBooking.categoryId);
                ddBookingStatus.SelectedValue = Convert.ToString(objBooking.Status);
                txtAdjust.Text = Convert.ToString(objBooking.Adjustment);
                txtAdvance.Text = Convert.ToString(objBooking.AdvanceAmount);
                txtTotalPay.Text = Convert.ToString(objBooking.TotalPay);
                txtBookingSourceId.Text = Convert.ToString(objBooking.OTATranId);

                txtLateCheckout.Text = Convert.ToString(objBooking.LateCheckout);
                txtEarlyCheckin.Text = Convert.ToString(objBooking.EarlyCheckin);
                txtTax.Text = Convert.ToString(objBooking.Tax);
                txtExtrabadCharges.Text = Convert.ToString(objBooking.ExtrabadCharge);
                ddExtrabad.SelectedValue = Convert.ToString(objBooking.ExtraBad);
                ddRoomPlan.SelectedValue = Convert.ToString(objBooking.RoomPlanid);
                if (objBooking.CustomerDocument != null && objBooking.CustomerDocument.Count > 0)
                {
                    Session["lstDocument"] = objBooking.CustomerDocument;
                }

                if (objBooking.lstCustomerContacts != null && objBooking.lstCustomerContacts.Count > 0)
                {
                    Session["lstCustomer"] = objBooking.lstCustomerContacts;
                }

                


                hdGSTPer.Value = "0";// Convert.ToString(objHotalManagment.GetGSTByRoomNo(Convert.ToInt32(Session["UserId"]), objBooking.RoomId));
                getRoomdata(objBooking.RoomId);
                CalculateAmount();

            }
        }


        private void getRoomdata(int roomno)
        {
            DataSet ds = objHotalManagment.GetPriceByRoomNo(Convert.ToInt32(Session["UserId"]), roomno, Convert.ToDateTime(txtFromDate.Text));
            if (ds.Tables.Count > 0)
            {
                hdBasePrice.Value = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                hdEPCharge.Value = Convert.ToString(ds.Tables[0].Rows[0]["EP"]);
                hdCPCharge.Value = Convert.ToString(ds.Tables[0].Rows[0]["CP"]);
                hdMAPCharge.Value = Convert.ToString(ds.Tables[0].Rows[0]["MAP"]);
                hdPresons.Value = Convert.ToString(ds.Tables[0].Rows[0]["Persons"]);
                hdExBadChargesEP.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExBadChargeEP"]);
                hdExBadChargesCP.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExBadChargeCP"]);
                hdExBadChargesMAP.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExBadChargeMAP"]);
            }
        }



        public string totalAmount()
        {
            decimal amt = 0;
            foreach (RepeaterItem i in RepterDetails.Items)
            {

                Label txtExample = (Label)i.FindControl("lblitemAmount");
                if (txtExample != null)
                {
                    amt += Convert.ToDecimal(txtExample.Text);
                }
            }
            return Convert.ToString(amt);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            hdMessage.Value = "Checkout |";
            BookingCls objBooking = new BookingCls();
            if (string.IsNullOrEmpty(txtTotalPay.Text))
            {
                txtTotalPay.Text = "0";
            }
            List<EntityLayer.BookingCls.Documents> objDocuments = new List<EntityLayer.BookingCls.Documents>();
            objBooking.Id = Convert.ToInt32(hdnBookingId.Value);
            objBooking.EarlyCheckin = Convert.ToDouble(txtEarlyCheckin.Text);
            objBooking.LateCheckout = Convert.ToDouble(txtLateCheckout.Text);
            objBooking.Adjustment = Convert.ToDouble(txtAdjust.Text);
            objBooking.Discount = Convert.ToDouble(txtDiscount.Text);
            objBooking.TotalPay = Convert.ToDouble(txtDueAmount.Text);
            objBooking.Status = 3;
            objBooking.CheckinDate = Convert.ToString(txtCheckinDate.Text.Trim());
            objBooking.ToDate = Convert.ToDateTime(txtTodate.Text.Trim());
            objBooking.CheckinTime = Convert.ToString(txtCheckinTime.Text.Trim());
            objBooking.CheckoutTime = CommanClasses.CurrentDateTime().ToShortTimeString();
            objBooking.ToDate = Convert.ToDateTime(txtTodate.Text.Trim());
            if (ValidateBookingData(objBooking))
            {
                int iResponse = objHotalManagment.CheckOutBooking(objBooking);
                //int Response = 200;
                objBooking.lstCustomerContacts = (List<BookingCls.Contacts>) Session["lstCustomer"];
                Session["lstContacts"] = null;
                if (iResponse > 0)
                {
                    string message = string.Empty;
                    string HotelName = Convert.ToString(Session["Hotelname"]);
                    message = "Dear Guest,/n/nThank you for stay at " + HotelName + "./n/nPlease tell us about your experience here : <review link>.";
                    if (objBooking.lstCustomerContacts.Count > 0 && objBooking.lstCustomerContacts[0].MobileNo!=null && objBooking.lstCustomerContacts[0].MobileNo != "0")
                    {
                        CommanClasses.SendSMS(message, objBooking.lstCustomerContacts[0].MobileNo.ToString());
                    }
                    Page.Response.Redirect("BookingInformation.aspx?id=" + Convert.ToString(hdnBookingId.Value) + "&type=Sendmail");
                    
                }
            }

        }



        private bool ValidateBookingData(BookingCls objBooking)
        {
            bool returnsatatus = true;


            DateTime Chartdate = Convert.ToDateTime(txtTodate.Text);
            DateTime Currdate = Convert.ToDateTime(CommanClasses.CurrentDateTime().ToShortDateString());
            double cntday = (Currdate - Chartdate).TotalDays;
            //if (cntday != 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "Checkout", "Errormsg();", true);
            //    hdMessage.Value += "Checkout Date is not Correct.";
            //    return false;
            //}
            //else //if (Convert.ToDouble(txtDueAmount.Text) != 0)
            {
                if (Convert.ToDouble(txtDueAmount.Text) != Convert.ToDouble(lblDueAmount.Text))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                    hdMessage.Value += "Please complete the payment.";
                    return false;
                }
            }
            
            {
                switch (objBooking.Status)
                {
                    case 2:
                        if (objBooking.TotalPay > 0)
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                            hdMessage.Value += "Please change booking status";
                            return false;
                        }
                        break;
                    case 3:
                        if (Convert.ToDouble(txtDueAmount.Text) != 0)
                        {
                            if (Convert.ToDouble(txtDueAmount.Text) != Convert.ToDouble(objBooking.TotalPay))
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                                hdMessage.Value += "Please complete the payment.";
                                return false;
                            }
                        }
                        if (string.IsNullOrEmpty(objBooking.CheckinDate) || string.IsNullOrEmpty(objBooking.CheckinTime) || string.IsNullOrEmpty(objBooking.CheckoutTime))
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                            hdMessage.Value += "Please complete Check-In time , Chaeck-Out detail";
                            return false;
                        }
                        break;
                }
            }
            return returnsatatus;
        }

        protected void btnPartialPay_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPayment.Text.Trim()))
            {
                int response = objHotalManagment.PartialPayment(Convert.ToInt32(hdBookingId.Value), Convert.ToDecimal(txtPayment.Text.Trim()), txtDescription.Text.Trim(), !string.IsNullOrEmpty(Convert.ToString(Session["UserId"])) ? Convert.ToInt32(Session["UserId"]) : 0);
                //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                //{
                //    repeterPayment.DataSource = ds.Tables[0];
                //    repeterPayment.DataBind();
                //}
                txtPayment.Text = "";
                txtDescription.Text = "";
                CalculateAmount();
            }
        }

        protected void btnsKey_Click(object sender, EventArgs e)
        {
            string SKey = ConfigurationManager.AppSettings["SKey"].ToString();
            if (txtSKey.Text == SKey)
            {
              
                pnlEdit.Attributes.Add("style", "display:block");
                pnlSKey.Attributes.Add("style", "display:none");
            }
            else
            {
                hdMessage.Value = "Authentication | Please enter valid key";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            pnlList.Attributes.Add("style", "display:block");
            pnlSKey.Attributes.Add("style", "display:none");
            getBookingItem();

        }

    }
}