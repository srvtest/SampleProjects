using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DataLayer;
using EntityLayer;
using System.IO;
using System.Data;
using System.Web.Services;
using System.Text;
using System.Globalization;


namespace HotalManagment
{
    public partial class addUpdateBooking : System.Web.UI.Page
    {
        string folderDocumentsName = ConfigurationManager.AppSettings["folderCustDocuments"].ToString();
        string folderCustPhotos = ConfigurationManager.AppSettings["folderCustPhotos"].ToString();
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        //List<EntityLayer.BookingCls.Documents> lstDeletedDoc;
        int bookingId = 0;
        int RoomNo = 0;
        int RoomId = 0;
        int CategoryId = 0;
        string prm = "";
        string bookingType = "";
        decimal GSTPer = 0;
        string bookFrom = "";
        string RoomDetails = "";

        #region

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }

            if (!IsPostBack)
            {

                Session["lstContacts"] = null;

                if (!string.IsNullOrEmpty(Request.QueryString["prm"]))
                {
                    prm = Convert.ToString(CommanClasses.Decrypt(Request.QueryString["prm"]));
                    foreach (string str in prm.Split('&'))
                    {
                        if (str.Split('=')[0] == "RoomNo")
                        {
                            RoomNo = Convert.ToInt32(str.Split('=')[1]);
                        }
                        else if (str.Split('=')[0] == "RoomId")
                        {
                            RoomId = Convert.ToInt32(str.Split('=')[1]);
                        }
                        else if (str.Split('=')[0] == "CategoryId")
                        {
                            CategoryId = Convert.ToInt32(str.Split('=')[1]);
                        }
                        else if (str.Split('=')[0] == "BookingId")
                        {
                            bookingId = Convert.ToInt32(str.Split('=')[1]);
                        }
                        else if (str.Split('=')[0] == "BookingType")
                        {
                            bookingType = Convert.ToString(str.Split('=')[1]);
                        }
                        else if (str.Split('=')[0] == "BookFrom")
                        {
                            bookFrom = Convert.ToString(str.Split('=')[1]);
                        }
                        else if (str.Split('=')[0] == "RoomDetails")
                        {
                            RoomDetails = Convert.ToString(str.Split('=')[1]);
                        }
                    }
                }
                getControlData();
                getBookingStatus(bookingId);


                if (!string.IsNullOrEmpty(RoomDetails))
                {
                    ddCategory.Enabled = false;
                    ddRoomNo.Enabled = false;
                    hdMultipleBookingDetail.Value = RoomDetails;
                }

                if (bookingId > 0)
                {
                    if (bookingType == "New")
                    {
                        getBookingStatus(0);
                        getDataForExpressCheckout();
                    }
                    else
                    {

                        getDataByBookingId();
                    }
                }
                else if (RoomNo > 0 && RoomId > 0)
                {
                    txtFromDate.Text = Convert.ToDateTime(bookFrom).ToShortDateString();
                    txtTodate.Text = Convert.ToDateTime(bookFrom).AddDays(1.00).ToShortDateString();
                    txtCheckinDate.Text = Convert.ToDateTime(bookFrom).ToShortDateString();
                    txtCheckinTime.Text = CommanClasses.CurrentDateTime().ToShortTimeString();
                    txtBookingDate.Text = CommanClasses.CurrentDateTime().ToShortDateString();
                    ddCategory.SelectedValue = Convert.ToString(CategoryId);
                    SetRoomNoByCategory(RoomNo, RoomId);
                    ddRoomNo.SelectedValue = Convert.ToString(RoomId);
                    ddRoomNo_SelectedIndexChanged(null, null);
                    chkCheckedIn.Checked = true;
                }

                showPage(1);
            }
            CalculateAmount();
            if (!string.IsNullOrEmpty(hdMultipleBookingDetail.Value))
            {
                string RoomDetails = hdMultipleBookingDetail.Value;
                string roomNo = string.Empty;
                string roomId = string.Empty;
                string categoryId = string.Empty;
                string personStay = string.Empty;
                string[] str = RoomDetails.Split(',');
                string rdetail = "";
                for (int i = 0; i < str.Count(); i++)
                {
                    roomNo = str[i].Split('_')[0];
                    roomId = str[i].Split('_')[1];
                    categoryId = str[i].Split('_')[2];
                    if (str[i].Split('_').Count() >= 4)
                    {
                        personStay = str[i].Split('_')[3];
                    }
                    else
                    {
                        personStay = "0";
                    }

                    if (i > 0)
                        rdetail += ", ";
                    rdetail += roomNo;
                    {
                        Label qs_label = new Label();
                        qs_label.Text = "Room no " + roomNo;
                        qs_label.ID = "lblRoom_" + roomId.ToString();
                        pnlRoom.Controls.Add(qs_label);

                        TextBox qs_textbox = new TextBox();
                        qs_textbox.Text = personStay;
                        qs_textbox.ID = "txtRoom_" + roomId.ToString();
                        qs_textbox.CssClass = "mdl-textfield__input";
                        pnlRoom.Controls.Add(qs_textbox);

                        LiteralControl htmlBR = new LiteralControl();
                        htmlBR.Text = "<br/>";
                        pnlRoom.Controls.Add(htmlBR);
                    }
                }

            }
            else
            {
                Label qs_label = new Label();
                qs_label.Text = "Room no " + RoomNo;
                qs_label.ID = "lblRoom_" + RoomId.ToString();
                pnlRoom.Controls.Add(qs_label);
            }
        }
        #endregion


        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        #region Booking

        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRoomNoByCategory();
        }

        protected void ddRoomPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPrice();
        }

        protected void ddRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddRoomNo.SelectedValue) > 0)
                getRoomdata();
            setPrice();
            CalculateAmount();
        }


        protected void grdBookedItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelivered = (e.Row.FindControl("btnItemDelivered") as Button);
                Button btnCancel = (e.Row.FindControl("btnOderCancel") as Button);
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[7].Equals(1))
                {
                    btnDelivered.Visible = true;
                    btnCancel.Visible = true;
                }
                else
                {
                    btnDelivered.Visible = false;
                    btnCancel.Visible = false;
                }
            }
        }

        protected void ddBookingSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBookingSource.SelectedValue != "0")
            {
                txtBookingSourceId.Visible = true;
            }
            else
            {
                txtBookingSourceId.Text = "";
            }
        }


        #endregion

        #region Contact
        protected void btnAddContact_Click(object sender, EventArgs e)
        {
            UploadImages();
            List<EntityLayer.BookingCls.Contacts> lstContacts = new List<BookingCls.Contacts>();
            EntityLayer.BookingCls.Contacts objContacts = new BookingCls.Contacts();
            objContacts.FirstName = txtFirstName.Text.Trim();
            objContacts.LastName = txtLastName.Text.Trim();
            objContacts.Age = string.IsNullOrEmpty(txtAge.Text.Trim()) ? 0 : Convert.ToInt16(txtAge.Text.Trim());
            objContacts.Gender = rbtGender.SelectedValue;
            objContacts.EmailId = txtEmail.Text.Trim();
            objContacts.GSTno = txtGSTno.Text.Trim();
            objContacts.MobileNo = !string.IsNullOrEmpty(txtMobile.Text.Trim()) ? txtMobile.Text.Trim() : "0";
            if (fileUploadPhotos.HasFile)
            {
                string strGuid = Guid.NewGuid().ToString();
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (fileUploadPhotos.PostedFile != null && fileUploadPhotos.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)fileUploadPhotos.PostedFile.ContentLength)) < MaxSize)
                    {
                        //lblCustomerPhotoName.Text = fCustomerPhoto.FileName;
                        objContacts.CustomerPhoto = strGuid + "_" + fileUploadPhotos.PostedFile.FileName;
                        fileUploadPhotos.PostedFile.SaveAs(Server.MapPath(Path.Combine(folderCustPhotos, strGuid + "_" + fileUploadPhotos.PostedFile.FileName)));
                        Image1.ImageUrl = folderCustPhotos.Replace("\\\\", "\\") + hdnCustomerPhoto.Value;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(hdnCustomerPhoto.Value))
                    objContacts.CustomerPhoto = hdnCustomerPhoto.Value;
                else
                    objContacts.CustomerPhoto = "NoImage.png";
                hdnCustomerPhoto.Value = "";
            }
            objContacts.ContactId = Guid.NewGuid().ToString();
            objContacts.IsActive = Convert.ToInt16(1);
            objContacts.bIsActive = true;
            if (Session["UserId"] != null)
            {
                objContacts.CreatedBy = Convert.ToInt32(Session["UserId"]);
                objContacts.Modifyby = Convert.ToInt32(Session["UserId"]);
            }
            if (Session["lstDocument"] != null)
            {
                List<EntityLayer.BookingCls.Documents> lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                lstDocument.Where(c => c.ContactsId == null).ToList().ForEach(c => { c.ContactsId = objContacts.ContactId; });
                Session["lstDocument"] = lstDocument;
            }
            if (Session["lstContacts"] != null)
            {
                lstContacts = (List<EntityLayer.BookingCls.Contacts>)Session["lstContacts"];
                if (!string.IsNullOrEmpty(hdnContactIdForDocument.Value))
                {
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().FirstName = objContacts.FirstName;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().LastName = objContacts.LastName;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().Age = objContacts.Age;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().Gender = objContacts.Gender;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().EmailId = objContacts.EmailId;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().MobileNo = objContacts.MobileNo;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().GSTno = objContacts.GSTno;
                    if (!string.IsNullOrEmpty(objContacts.CustomerPhoto))
                        lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().CustomerPhoto = objContacts.CustomerPhoto;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().IsActive = objContacts.IsActive;
                    lstContacts.Where(r => r.ContactId == hdnContactIdForDocument.Value).FirstOrDefault().bIsActive = objContacts.bIsActive;
                    hdnContactIdForDocument.Value = null;
                }
                else
                {
                    lstContacts.Add(objContacts);
                }
                Session["lstContacts"] = lstContacts;
                grdContactInfo.DataSource = lstContacts;
                grdContactInfo.DataBind();
                clearContactsControls();

            }
            else
            {
                lstContacts.Add(objContacts);
                Session["lstContacts"] = lstContacts;
                grdContactInfo.DataSource = lstContacts;
                grdContactInfo.DataBind();
                clearContactsControls();
            }
            //lblMessage.Text = "Data saved successfully";
            //Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "ShowMessageForm();", true);

        }

        protected void grdContactInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdnContactIdForDocument.Value = Convert.ToString(((HiddenField)grdContactInfo.Rows[e.NewEditIndex].FindControl("hdnContactId")).Value);
            txtFirstName.Text = ((Label)grdContactInfo.Rows[e.NewEditIndex].FindControl("lblFirstName")).Text;
            txtLastName.Text = ((Label)grdContactInfo.Rows[e.NewEditIndex].FindControl("lblLastName")).Text;
            txtAge.Text = ((Label)grdContactInfo.Rows[e.NewEditIndex].FindControl("lblAge")).Text;
            rbtGender.SelectedValue = ((Label)grdContactInfo.Rows[e.NewEditIndex].FindControl("lblGender")).Text;
            txtEmail.Text = ((Label)grdContactInfo.Rows[e.NewEditIndex].FindControl("lblEmail")).Text;
            txtMobile.Text = ((Label)grdContactInfo.Rows[e.NewEditIndex].FindControl("lblMobile")).Text;
            txtGSTno.Text = ((HiddenField)grdContactInfo.Rows[e.NewEditIndex].FindControl("hdGstno")).Value;
            Image1.ImageUrl = ((Image)grdContactInfo.Rows[e.NewEditIndex].FindControl("imgCustomer")).ImageUrl;
            // chkContactStatus.Checked = (Convert.ToInt16(((HiddenField)grdContactInfo.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value)) == 0 ? false : true; ;
            hdnCustomerPhoto.Value = null;
            if (Session["lstDocument"] != null)
            {
                List<EntityLayer.BookingCls.Documents> lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                grdDocumentList.DataSource = lstDocument.Where(a => a.ContactsId == hdnContactIdForDocument.Value);
                grdDocumentList.DataBind();
            }

        }

        protected void grdContactInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = Convert.ToString(((HiddenField)grdContactInfo.Rows[e.RowIndex].FindControl("hdnContactId")).Value);
            List<EntityLayer.BookingCls.Contacts> lstContacts = new List<BookingCls.Contacts>();
            if (Session["lstContacts"] != null)
            {
                lstContacts = (List<EntityLayer.BookingCls.Contacts>)Session["lstContacts"];
                lstContacts.RemoveAll(x => x.ContactId == id);
                Session["lstContacts"] = lstContacts;
            }
            if (Session["lstDocument"] != null)
            {
                List<EntityLayer.BookingCls.Documents> lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                lstDocument.RemoveAll(x => x.ContactsId == id);
                Session["lstDocument"] = lstDocument;
            }
            grdContactInfo.DataSource = lstContacts;
            grdContactInfo.DataBind();
        }

        #endregion


        #region Documet
        protected void grdDocumentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = Convert.ToString(((HiddenField)grdDocumentList.Rows[e.RowIndex].FindControl("hdnId")).Value);
            if (Session["lstDocument"] != null)
            {
                List<EntityLayer.BookingCls.Documents> lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                EntityLayer.BookingCls.Documents objDocument = lstDocument.Where(x => x.Id == Id).FirstOrDefault();
                lstDocument.RemoveAll(x => x.Id == Id);
                Session["lstDocument"] = lstDocument;
                grdDocumentList.DataSource = lstDocument.Where(a => a.ContactsId == hdnContactIdForDocument.Value).ToList();
                grdDocumentList.DataBind();
                string documentPath = Server.MapPath(folderDocumentsName);
                if (Directory.Exists(documentPath))
                {
                    string filePath = documentPath + objDocument.DocumentUID + "_" + objDocument.DocumentName;
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }

        #endregion




        private void getDataForExpressCheckout()
        {
            hdnBookingId.Value = bookingId.ToString();
            BookingCls objBooking = objHotalManagment.GetBookingDetailByBookindIdAndId(bookingId, Convert.ToInt32(Session["UserId"]));
            if (objBooking != null)
            {
                txtFromDate.Text = CommanClasses.CurrentDateTime().ToShortDateString();
                txtTodate.Text = CommanClasses.CurrentDateTime().AddDays(1.00).ToShortDateString();
                txtCheckinDate.Text = "";
                txtCheckinTime.Text = "";
                txtExCheckoutTime.Text = "";
                ddBookingSource.SelectedValue = Convert.ToString(objBooking.BookingSourceId);
                txtDiscount.Text = "";
                txtRoomCharges.Text = Convert.ToString(objBooking.RoomCharges);
                ddCategory.SelectedValue = Convert.ToString(objBooking.categoryId);
                SetRoomNoByCategory(objBooking.RoomNo, objBooking.RoomId);

                ddRoomNo.SelectedValue = Convert.ToString(objBooking.RoomId);
                ddBookingStatus.SelectedValue = "2";
                txtAdjust.Text = "";
                // chkStatus.Checked = objBooking.bIsActive;
                if (objBooking.lstCustomerContacts != null && objBooking.lstCustomerContacts.Count > 0)
                {
                    Session["lstContacts"] = objBooking.lstCustomerContacts;
                    grdContactInfo.DataSource = objBooking.lstCustomerContacts;
                    grdContactInfo.DataBind();
                }
                if (objBooking.CustomerDocument != null && objBooking.CustomerDocument.Count > 0)
                {
                    Session["lstDocument"] = objBooking.CustomerDocument;
                }
                double totalPaid = 0;
                double totalDays = 0;
                totalDays = (Convert.ToDateTime(txtTodate.Text) - Convert.ToDateTime(txtFromDate.Text)).TotalDays;

                totalPaid = totalDays * objBooking.RoomCharges;
                totalPaid = totalPaid - objBooking.Discount;
                hdTotal.Value = totalPaid.ToString();

                lblNoOfDays.InnerText = totalDays.ToString();
                lblRoomCharge.InnerText = Convert.ToString(objBooking.RoomCharges);
                lblDiscount.InnerText = Convert.ToString(objBooking.Discount);
                lblTax.InnerText = Convert.ToString(0);
                lblTotal.InnerText = Convert.ToString((totalDays * objBooking.RoomCharges));
            }
        }

        public void getControlData()
        {
            DataSet dsCategory = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            ddCategory.DataValueField = "Id";
            ddCategory.DataTextField = "CategoryName";
            ddCategory.DataSource = dsCategory.Tables[0];
            ddCategory.DataBind();
            ddCategory.Items.Insert(0, new ListItem("Select Category", "0"));

            ViewState["categoryview"] = dsCategory.Tables[0];

            DataSet dsBookingSource = objHotalManagment.GetBookingSource();
            ddBookingSource.DataValueField = "Id";
            ddBookingSource.DataTextField = "BookingSourceName";
            ddBookingSource.DataSource = dsBookingSource.Tables[0];
            ddBookingSource.DataBind();
            ddBookingSource.Items.Insert(0, new ListItem("Select Booking Source", "0"));

            DataSet dsRoomPlan = objHotalManagment.GetAllRoomPlan(0);
            ddRoomPlan.DataValueField = "Id";
            ddRoomPlan.DataTextField = "RoomPlanName";
            ddRoomPlan.DataSource = dsRoomPlan.Tables[0];
            ddRoomPlan.DataBind();
        }

        public void getBookingStatus(int BookingId)
        {
            DataSet dsBookingStatus = objHotalManagment.GetBookingStatus(BookingId);
            ddBookingStatus.DataValueField = "Id";
            ddBookingStatus.DataTextField = "BookingStatus";
            ddBookingStatus.DataSource = dsBookingStatus.Tables[0];
            ddBookingStatus.DataBind();
        }

        public void getDataByBookingId()
        {
            hdnBookingId.Value = bookingId.ToString();
            BookingCls objBooking = objHotalManagment.GetBookingDetailByBookindIdAndId(bookingId, Convert.ToInt32(Session["UserId"]));
            if (objBooking != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(objBooking.OTATranId)))
                {


                    //  txtFromDate.Enabled = false;
                    //  //txtTodate.Enabled = false;
                    //  txtCheckinDate.Enabled = false;
                    //  txtCheckinTime.Enabled = false;
                    ////  txtBookingDate.Enabled = false;
                    //  txtDiscount.Enabled = false;
                    //  txtAdjust.Enabled = false;
                    //  txtAdvance.Enabled = false;
                    //  txtLateCheckout.Enabled = false;
                    //  txtEarlyCheckin.Enabled = false;
                    //  chkInclusive.Enabled = false;
                    //  txtNoOfPerson.Enabled = false;

                    Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "DisableControls();", true);

                }


                txtFromDate.Text = objBooking.FromDate.ToShortDateString();
                txtTodate.Text = objBooking.ToDate.ToShortDateString();
                txtCheckinDate.Text = !string.IsNullOrEmpty(objBooking.CheckinDate) ? Convert.ToDateTime(objBooking.CheckinDate).ToShortDateString() : "";
                txtCheckinTime.Text = objBooking.CheckinTime;
                txtExCheckoutTime.Text = objBooking.CheckoutTime;
                txtBookingDate.Text = CommanClasses.CurrentDateTime().ToShortDateString();
                ddBookingSource.SelectedValue = Convert.ToString(objBooking.BookingSourceId);
                //if (objBooking.BookingSourceId > 0)
                //{
                //    txtBookingSourceId.Visible = true;
                //}
                txtDiscount.Text = Convert.ToString(objBooking.Discount);

                if (string.IsNullOrEmpty(objBooking.OTATranId))
                {
                    txtRoomCharges.Text = Convert.ToString(objBooking.RoomCharges);
                }
                else
                {
                    roomcharges.Visible = false;
                    txtRoomCharges.Text = Convert.ToString(objBooking.OTARoomCharges);
                }

                ddCategory.SelectedValue = Convert.ToString(objBooking.categoryId);
                SetRoomNoByCategory(RoomNo, objBooking.RoomId);
                ddRoomNo.SelectedValue = Convert.ToString(objBooking.RoomId);
                ddBookingStatus.SelectedValue = Convert.ToString(objBooking.Status);
                txtAdjust.Text = Convert.ToString(objBooking.Adjustment);
                txtAdvance.Text = Convert.ToString(objBooking.AdvanceAmount);
                txtTotalPay.Text = Convert.ToString(objBooking.TotalPay);
                txtBookingSourceId.Text = Convert.ToString(objBooking.OTATranId);
                txtLateCheckout.Text = Convert.ToString(objBooking.LateCheckout);
                txtEarlyCheckin.Text = Convert.ToString(objBooking.EarlyCheckin);

                txtExtrabadCharges.Text = Convert.ToString(objBooking.ExtrabadCharge);
                ddExtrabad.SelectedValue = Convert.ToString(objBooking.ExtraBad);
                ddRoomPlan.SelectedValue = Convert.ToString(objBooking.RoomPlanid);

                chkInclusive.Checked = objBooking.IsInclusive == 1 ? true : false;
                chkCheckedIn.Checked = objBooking.PersonCheckIn == 1 ? true : false;

                txtNoOfPerson.Text = Convert.ToString(objBooking.NoOfPersons);

                txtcommission.Text = Convert.ToString(objBooking.Commission);

                txtSpRequest.Text = Convert.ToString(objBooking.SpecialRequest);
                // chkStatus.Checked = objBooking.bIsActive;
                if (objBooking.lstCustomerContacts != null && objBooking.lstCustomerContacts.Count > 0)
                {
                    Session["lstContacts"] = objBooking.lstCustomerContacts;
                    grdContactInfo.DataSource = objBooking.lstCustomerContacts;
                    grdContactInfo.DataBind();
                }
                if (objBooking.CustomerDocument != null && objBooking.CustomerDocument.Count > 0)
                {
                    Session["lstDocument"] = objBooking.CustomerDocument;
                }
                hdMultipleBookingDetail.Value = objBooking.BookingGroupDetail;
                getRoomdata();
                CalculateAmount();
            }
        }

        public void SetRoomNoByCategory(int roomNo = 0, int roomId = 0)
        {
            if (!string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtTodate.Text))
            {
                DataSet ds = objHotalManagment.GetRoomNoByCategory(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddCategory.SelectedValue), txtFromDate.Text, txtTodate.Text, Convert.ToInt32(hdnBookingId.Value));
                ddRoomNo.DataSource = ds;
                ddRoomNo.DataTextField = "RoomNo";
                ddRoomNo.DataValueField = "Id";
                ddRoomNo.DataBind();
                ddRoomNo.Items.Insert(0, new ListItem("Select RoomNo", "0"));
                ddRoomNo.SelectedValue = Convert.ToString(roomId);

                ddChangeRoom.DataSource = ds;
                ddChangeRoom.DataTextField = "RoomNo";
                ddChangeRoom.DataValueField = "Id";
                ddChangeRoom.DataBind();
                ddChangeRoom.Items.Insert(0, new ListItem("Select RoomNo", "0"));
                ddChangeRoom.SelectedValue = Convert.ToString(roomId);
                //if (roomId > 0)
                //{
                //    if (ddRoomNo.Items.FindByValue(roomId.ToString()) == null)
                //        ddRoomNo.Items.Insert(1, new ListItem(Convert.ToString(roomNo), Convert.ToString(roomId)));
                //}
            }
            else
            {
                if (string.IsNullOrEmpty(txtFromDate.Text))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Select from date before category')", true);
                if (string.IsNullOrEmpty(txtTodate.Text))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Select to date before category')", true);
                ddCategory.SelectedValue = "0";
                ddRoomNo.ClearSelection();
            }
        }

        public void ClearControl()
        {
            txtFromDate.Text = "";
            txtTodate.Text = "";
            ddCategory.ClearSelection();
            ddRoomNo.ClearSelection();
            ddBookingSource.ClearSelection();
            ddBookingStatus.ClearSelection();
            txtRoomCharges.Text = "";
            txtDiscount.Text = "";
            txtAdjust.Text = "";
            //chkStatus.Checked = true;
            txtCheckinDate.Text = "";
            txtCheckinTime.Text = "";
            txtExCheckoutTime.Text = "";
            Image1.ImageUrl = "/Cust_Photos/NoImage.png";
            grdDocumentList.DataSource = null;
            grdContactInfo.DataSource = null;
        }


        private void getRoomdata()
        {
            if (!string.IsNullOrEmpty(hdMultipleBookingDetail.Value))
            {
                string roomNo = string.Empty;
                string roomId = string.Empty;
                string categoryId = string.Empty;
                string[] str = hdMultipleBookingDetail.Value.Split(',');
                string rdetail = "";

                if (string.IsNullOrEmpty(baseRoomCharges.Text)) baseRoomCharges.Text = "0";
                for (int i = 0; i < str.Count(); i++)
                {
                    roomNo = str[i].Split('_')[0];
                    roomId = str[i].Split('_')[1];
                    categoryId = str[i].Split('_')[2];

                    if (i > 0)
                        rdetail += ", ";
                    rdetail += roomNo;

                    DataSet ds = objHotalManagment.GetPriceByRoomNo(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(roomId), Convert.ToDateTime(txtFromDate.Text));
                    if (ds.Tables.Count > 0)
                    {
                        hdBasePrice.Value = (Convert.ToInt32(hdBasePrice.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["Price"])).ToString();
                        baseRoomCharges.Text = (Convert.ToInt32(baseRoomCharges.Text) + Convert.ToInt32(ds.Tables[0].Rows[0]["Price"])).ToString();
                        hdEPCharge.Value = (Convert.ToInt32(hdEPCharge.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["EP"])).ToString();
                        hdCPCharge.Value = (Convert.ToInt32(hdCPCharge.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["CP"])).ToString();
                        hdMAPCharge.Value = (Convert.ToInt32(hdMAPCharge.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["MAP"])).ToString();
                        hdPresons.Value = (Convert.ToInt32(hdPresons.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["Persons"])).ToString();

                        //hdExBadChargesEP.Value = (Convert.ToInt32(hdExBadChargesEP.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeEP"])).ToString();
                        //hdExBadChargesCP.Value = (Convert.ToInt32(hdExBadChargesCP.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeCP"])).ToString();
                        //hdExBadChargesMAP.Value = (Convert.ToInt32(hdExBadChargesMAP.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeMAP"])).ToString();  
                        if (categoryId == ddCategory.SelectedValue)
                        {
                            // hdExBadChargesEP.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeEP"]).ToString();
                            hdExBadChargesEP.Value = (Convert.ToInt32(hdExBadChargesEP.Value) + Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeEP"])).ToString();
                            hdExBadChargesCP.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeCP"]).ToString();
                            hdExBadChargesMAP.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["ExBadChargeMAP"]).ToString();
                        }

                        if (string.IsNullOrEmpty(hdMultipleBookingDetail_all.Value))
                            hdMultipleBookingDetail_all.Value += roomNo + "_" + roomId + "_" + categoryId + "_" + Convert.ToInt32(ds.Tables[0].Rows[0]["Persons"]).ToString();
                        else
                            hdMultipleBookingDetail_all.Value += ", " + roomNo + "_" + roomId + "_" + categoryId + "_" + Convert.ToInt32(ds.Tables[0].Rows[0]["Persons"]).ToString();
                    }
                }
                //lblRoomsDetail.Text = rdetail;
                ddCategory.Enabled = false;
                ddRoomNo.Enabled = false;
            }
            else
            {
                DataSet ds = objHotalManagment.GetPriceByRoomNo(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddRoomNo.SelectedValue), Convert.ToDateTime(txtFromDate.Text));
                if (ds.Tables.Count > 0)
                {
                    hdBasePrice.Value = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                    baseRoomCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                    hdEPCharge.Value = Convert.ToString(ds.Tables[0].Rows[0]["EP"]);
                    hdCPCharge.Value = Convert.ToString(ds.Tables[0].Rows[0]["CP"]);
                    hdMAPCharge.Value = Convert.ToString(ds.Tables[0].Rows[0]["MAP"]);
                    hdPresons.Value = Convert.ToString(ds.Tables[0].Rows[0]["Persons"]);
                    hdExBadChargesEP.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExBadChargeEP"]);
                    hdExBadChargesCP.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExBadChargeCP"]);
                    hdExBadChargesMAP.Value = Convert.ToString(ds.Tables[0].Rows[0]["ExBadChargeMAP"]);


                }
            }
        }

        private void setPrice()
        {



            decimal price = 0;
            switch (ddRoomPlan.SelectedItem.Value)
            {
                case "1":
                    price = Convert.ToDecimal(hdBasePrice.Value) + Convert.ToDecimal(hdEPCharge.Value);
                    txtExtrabadCharges.Text = Convert.ToString(Convert.ToDecimal(hdExBadChargesEP.Value) * Convert.ToDecimal(ddExtrabad.SelectedItem.Value));
                    break;
                case "2":
                    price = Convert.ToDecimal(hdBasePrice.Value) + Convert.ToDecimal(hdCPCharge.Value);
                    txtExtrabadCharges.Text = Convert.ToString(Convert.ToDecimal(hdExBadChargesCP.Value) * Convert.ToDecimal(ddExtrabad.SelectedItem.Value));
                    break;
                case "3":
                    price = Convert.ToDecimal(hdBasePrice.Value) + Convert.ToDecimal(hdMAPCharge.Value);
                    txtExtrabadCharges.Text = Convert.ToString(Convert.ToDecimal(hdExBadChargesMAP.Value) * Convert.ToDecimal(ddExtrabad.SelectedItem.Value));
                    break;
                default:
                    break;
            }

            txtRoomCharges.Text = price.ToString();
            CalculateAmount();
        }

        public void ShowDocument()
        {
            List<EntityLayer.BookingCls.Documents> lstDocument = new List<EntityLayer.BookingCls.Documents>();
            dynamic fileUploadControl = fileUploadDocuments;
            if (fileUploadControl.HasFiles)
            {
                if (!string.IsNullOrEmpty(hdnContactIdForDocument.Value))
                {
                    foreach (var file in fileUploadControl.PostedFiles)
                    {
                        string strGuid = Guid.NewGuid().ToString();
                        if (Session["lstDocument"] != null && Session["UserId"] != null)
                        {
                            lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                            lstDocument.Add(new EntityLayer.BookingCls.Documents() { Id = strGuid, DocumentName = file.FileName, DocumentUID = strGuid, ContactsId = hdnContactIdForDocument.Value, Notes = txtDocNo.Text });
                            Session["lstDocument"] = lstDocument;
                        }
                        else
                        {
                            lstDocument.Add(new EntityLayer.BookingCls.Documents() { Id = strGuid, DocumentName = file.FileName, DocumentUID = strGuid, ContactsId = hdnContactIdForDocument.Value, Notes = txtDocNo.Text });
                            Session["lstDocument"] = lstDocument;
                        }
                    }
                    txtDocNo.Text = "";
                    lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                    grdDocumentList.DataSource = lstDocument.Where(a => a.ContactsId == hdnContactIdForDocument.Value).ToList();
                    grdDocumentList.DataBind();
                }
                else
                {
                    foreach (var file in fileUploadControl.PostedFiles)
                    {
                        string strGuid = Guid.NewGuid().ToString();
                        if (Session["lstDocument"] != null)
                        {
                            lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                            lstDocument.Add(new EntityLayer.BookingCls.Documents() { Id = strGuid, DocumentName = file.FileName, DocumentUID = strGuid, Notes = txtDocNo.Text });
                            Session["lstDocument"] = lstDocument;
                        }
                        else
                        {
                            lstDocument.Add(new EntityLayer.BookingCls.Documents() { Id = strGuid, DocumentName = file.FileName, DocumentUID = strGuid, Notes = txtDocNo.Text });
                            Session["lstDocument"] = lstDocument;
                        }
                    }
                    txtDocNo.Text = "";
                    lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                    grdDocumentList.DataSource = lstDocument.Where(a => a.ContactsId == null).ToList();
                    grdDocumentList.DataBind();
                }
            }
        }

        public void clearContactsControls()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            Image1.ImageUrl = "/Cust_Photos/NoImage.png";
            grdDocumentList.DataSource = null;
            grdDocumentList.DataBind();

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

        }

        protected void CalculateAmount()
        {
            txtRoomCharges.Text = string.IsNullOrEmpty(txtRoomCharges.Text) ? "0" : txtRoomCharges.Text;
            txtDiscount.Text = string.IsNullOrEmpty(txtDiscount.Text) ? "0" : txtDiscount.Text;

            txtTax.Text = string.IsNullOrEmpty(txtTax.Text) ? "0" : txtTax.Text;
            txtAdjust.Text = string.IsNullOrEmpty(txtAdjust.Text) ? "0" : txtAdjust.Text;
            txtAdvance.Text = string.IsNullOrEmpty(txtAdvance.Text) ? "0" : txtAdvance.Text;
            txtEarlyCheckin.Text = string.IsNullOrEmpty(txtEarlyCheckin.Text) ? "0" : txtEarlyCheckin.Text;
            txtNoOfPerson.Text = string.IsNullOrEmpty(txtNoOfPerson.Text) ? "0" : txtNoOfPerson.Text;
            txtExtrabadCharges.Text = string.IsNullOrEmpty(txtExtrabadCharges.Text) ? "0" : txtExtrabadCharges.Text;
            decimal totalPaid = 0;
            decimal totalPaidExBad = 0;

            int totalDays = 0;
            totalDays = Convert.ToInt32((Convert.ToDateTime(txtTodate.Text) - Convert.ToDateTime(txtFromDate.Text)).TotalDays);
            if (totalDays == 0) totalDays = 1;

            DataSet objBooking = objHotalManagment.GetBookingInformationById(Convert.ToInt32(hdnBookingId.Value), Convert.ToInt32(Session["UserId"]));
            if (objBooking != null && objBooking.Tables.Count > 3 && objBooking.Tables[3].Rows.Count > 0)
            {
                for (int m = 0; m != Convert.ToDecimal(objBooking.Tables[3].Rows.Count); m++)
                {
                    totalPaid += Convert.ToDecimal(objBooking.Tables[3].Rows[m]["price"]);
                }
            }
            else
            {
                totalPaid = totalDays * Convert.ToDecimal(txtRoomCharges.Text);
            }

            totalPaidExBad = totalDays * Convert.ToDecimal(txtExtrabadCharges.Text);
            decimal taxpaidAmount = 0;
            switch (ddRoomPlan.SelectedItem.Value)
            {
                case "1":
                    taxpaidAmount = totalDays * (Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdEPCharge.Value));
                    hdGSTPer.Value = Convert.ToString(objHotalManagment.GetTaxPercentage(Convert.ToInt32(Session["UserId"]), (Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdEPCharge.Value))));
                    break;
                case "2":
                    taxpaidAmount = totalDays * (Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdCPCharge.Value));
                    hdGSTPer.Value = Convert.ToString(objHotalManagment.GetTaxPercentage(Convert.ToInt32(Session["UserId"]), (Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdCPCharge.Value))));
                    break;
                case "3":
                    taxpaidAmount = totalDays * (Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdMAPCharge.Value));
                    hdGSTPer.Value = Convert.ToString(objHotalManagment.GetTaxPercentage(Convert.ToInt32(Session["UserId"]), (Convert.ToDecimal(txtRoomCharges.Text) + Convert.ToDecimal(hdMAPCharge.Value))));
                    break;
            }
            if (chkInclusive.Checked)
            {
                hdGSTPer.Value = "0";
            }
            txtTax.Text = (((taxpaidAmount) / 100) * Convert.ToDecimal(hdGSTPer.Value)).ToString("0.##");
            hdTotal.Value = totalPaid.ToString();
            decimal dueAmount = totalPaid + totalPaidExBad + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(hdItemAmount.Value) - Convert.ToDecimal(txtAdvance.Text) - Convert.ToDecimal(txtDiscount.Text) - Convert.ToDecimal(txtAdjust.Text);
            txtDueAmount.Text = Convert.ToString(dueAmount);
            decimal earlyCheckinCharges = Convert.ToDecimal(txtEarlyCheckin.Text);
            lblNoOfDays.InnerText = totalDays.ToString();
            lblRoomCharge.InnerText = txtRoomCharges.Text;
            lblDiscount.InnerText = txtDiscount.Text;
            lblTax.InnerText = txtTax.Text;
            lblTotal.InnerText = Convert.ToString(totalPaid + totalPaidExBad + Convert.ToDecimal(txtTax.Text));
            //lblTotalAmount.Text = Convert.ToString(totalPaid + totalPaidExBad + Convert.ToDecimal(txtTax.Text));

            lblAdvance.InnerText = txtAdvance.Text;
            lblExtraBad.InnerText = totalPaidExBad.ToString(); ;
            lblEarlyCheckinCharges.InnerText = earlyCheckinCharges.ToString("0.##");
            decimal roomsTotal = totalPaid + Convert.ToDecimal(txtTax.Text);
            decimal itemTotal = Convert.ToDecimal(totalAmount());
            txtNetTotal.Text = Convert.ToString(roomsTotal + itemTotal);

            if (!string.IsNullOrEmpty(txtBookingSourceId.Text.Trim()))
            {
                lblTotalAmount.Text = Convert.ToString(totalPaid + totalPaidExBad + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(lblEarlyCheckinCharges.InnerText) - Convert.ToDecimal(txtDiscount.Text));
            }
            else
            {
                lblTotalAmount.Text = Convert.ToString(totalPaid + totalPaidExBad + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(lblEarlyCheckinCharges.InnerText) - Convert.ToDecimal(txtAdvance.Text) - Convert.ToDecimal(txtDiscount.Text));
            }
            

            lblGrandTotal.InnerText = Convert.ToString(totalPaid + totalPaidExBad + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(lblEarlyCheckinCharges.InnerText) - Convert.ToDecimal(txtAdvance.Text) - Convert.ToDecimal(txtDiscount.Text));
            //   lblAmount.InnerHtml = "Total Amount: <b>" + (totalPaid + Convert.ToDecimal(txtTax.Text) + Convert.ToDecimal(hdItemAmount.Value)).ToString() + "</b> Due Amount: <b>" + txtDueAmount.Text + "</b>";
            hdCalcAmount.Value = lblTotalAmount.Text;

            getBookedItemByBookingId();
        }

        protected void txtCalculation(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private bool ValidateBookingData(BookingCls objBooking)
        {
            bool returnsatatus = true;
            if (objBooking.RoomId == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                hdMessage.Value += "Please select room.";
                return false;
            }
            else if (objBooking.categoryId == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                hdMessage.Value += "Please select category.";
                return false;
            }



            switch (objBooking.Status)
            {
                case 2:
                    if (objBooking.TotalPay > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                        hdMessage.Value += "Please change booking status.";
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
                        hdMessage.Value += "Please complete Check-In , Chaeck-Out detail.";
                        return false;
                    }
                    break;
            }
            return returnsatatus;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            hdMessage.Value = "";
            if ((grdContactInfo.Rows.Count > 0 && grdContactInfo.Rows.Count <= (Convert.ToInt32(hdPresons.Value) + Convert.ToInt32(ddExtrabad.SelectedItem.Value))) || !string.IsNullOrEmpty(txtBookingSourceId.Text.Trim()))
            {
                string strGuid = Guid.NewGuid().ToString();
                bool isDelete = false;
                BookingCls objBooking = new BookingCls();
                if (string.IsNullOrEmpty(txtTotalPay.Text))
                {
                    txtTotalPay.Text = "0";
                }
                List<EntityLayer.BookingCls.Documents> objDocuments = new List<EntityLayer.BookingCls.Documents>();
                objBooking.Id = Convert.ToInt32(hdnBookingId.Value);

                if (objBooking.Id == 0)
                {
                    hdMessage.Value = "Booking Insert |";
                }
                else
                {
                    hdMessage.Value = "Booking Update |";
                }

                if (string.IsNullOrEmpty(txtEarlyCheckin.Text))
                {
                    txtEarlyCheckin.Text = "0";
                }
                if (string.IsNullOrEmpty(txtLateCheckout.Text))
                {
                    txtLateCheckout.Text = "0";
                }
                if (string.IsNullOrEmpty(txtcommission.Text))
                {
                    txtcommission.Text = "0";
                }
                objBooking.CreatedBy = Convert.ToInt32(Session["UserId"]);
                objBooking.Modifyby = Convert.ToInt32(Session["UserId"]);
                objBooking.FromDate = Convert.ToDateTime(txtFromDate.Text);
                objBooking.ToDate = Convert.ToDateTime(txtTodate.Text);
                objBooking.CheckinDate = Convert.ToString(txtCheckinDate.Text.Trim());
                objBooking.CheckinTime = Convert.ToString(txtCheckinTime.Text.Trim());
                objBooking.ExCheckout = Convert.ToString(txtExCheckoutTime.Text.Trim());
                objBooking.categoryId = Convert.ToInt32(ddCategory.SelectedValue);
                objBooking.RoomId = Convert.ToInt32(ddRoomNo.SelectedValue);
                objBooking.BookingSourceId = Convert.ToInt32(ddBookingSource.SelectedValue);
                objBooking.Status = !string.IsNullOrEmpty(objBooking.CheckoutTime) ? 3 : Convert.ToInt32(ddBookingStatus.SelectedValue);
                objBooking.RoomCharges = Convert.ToDouble(txtRoomCharges.Text);
                objBooking.TotalPay = Convert.ToDouble(txtTotalPay.Text);
                objBooking.AdvanceAmount = Convert.ToDouble(txtAdvance.Text);
                objBooking.OTATranId = txtBookingSourceId.Text.Trim();
                objBooking.ArrivalFrom = txtArrivalFrom.Text.Trim();
                objBooking.DepartureTo = txtDepartureTo.Text.Trim();
                objBooking.Tax = Convert.ToDouble(txtTax.Text);
                objBooking.EarlyCheckin = Convert.ToDouble(txtEarlyCheckin.Text);
                objBooking.LateCheckout = Convert.ToDouble(txtLateCheckout.Text);
                objBooking.IsInclusive = Convert.ToInt16(chkInclusive.Checked ? 1 : 0);
            
                switch (ddRoomPlan.SelectedItem.Value)
                {
                    case "1":
                        objBooking.BasePrice = Convert.ToDouble(hdBasePrice.Value) + Convert.ToDouble(hdEPCharge.Value);
                        break;
                    case "2":
                        objBooking.BasePrice = Convert.ToDouble(hdBasePrice.Value) + Convert.ToDouble(hdCPCharge.Value);
                        break;
                    case "3":
                        objBooking.BasePrice = Convert.ToDouble(hdBasePrice.Value) + Convert.ToDouble(hdMAPCharge.Value);
                        break;
                    default:
                        break;
                }

                objBooking.ExtrabadCharge = Convert.ToDouble(txtExtrabadCharges.Text);
                objBooking.RoomPlanid = Convert.ToInt32(ddRoomPlan.SelectedItem.Value);
                objBooking.ExtraBad = Convert.ToInt32(ddExtrabad.SelectedItem.Value);
                objBooking.Persons = Convert.ToInt32(hdPresons.Value);
                objBooking.Commission = Convert.ToDouble(txtcommission.Text);

                objBooking.SpecialRequest = Convert.ToString(txtSpRequest.Text);
                objBooking.PersonCheckIn = Convert.ToInt16(chkCheckedIn.Checked ? 1 : 0);
                if (!string.IsNullOrEmpty(hdCalcAmount.Value))
                    objBooking.CalcAmount = Convert.ToDouble(hdCalcAmount.Value);

                if (!string.IsNullOrEmpty(objBooking.OTATranId))
                {
                    List<EntityLayer.BookingCls.Contacts> lstContacts = (List<EntityLayer.BookingCls.Contacts>)Session["lstContacts"];
                    if (lstContacts == null) lstContacts = new List<BookingCls.Contacts>();
                    if (lstContacts.Count == 0)
                    {
                        EntityLayer.BookingCls.Contacts objContacts = new BookingCls.Contacts();
                        objContacts.FirstName = ddBookingSource.SelectedItem.Text;
                        objContacts.LastName = "";
                        objContacts.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        lstContacts.Add(objContacts);
                        Session["lstContacts"] = lstContacts;
                    }
                }

                if (!string.IsNullOrEmpty(txtDiscount.Text))
                {
                    objBooking.Discount = Convert.ToDouble(txtDiscount.Text);
                }

                if (!string.IsNullOrEmpty(txtAdjust.Text))
                {
                    objBooking.Adjustment = Convert.ToDouble(txtAdjust.Text);
                }

                objBooking.IsActive = Convert.ToInt16(1);
                string documentPath = Server.MapPath(folderDocumentsName);
                if (Session["lstDocument"] != null)
                {
                    List<EntityLayer.BookingCls.Documents> lstDocument = (List<EntityLayer.BookingCls.Documents>)Session["lstDocument"];
                    foreach (EntityLayer.BookingCls.Documents obj in lstDocument)
                    {
                        objDocuments.Add(new EntityLayer.BookingCls.Documents() { DocumentName = obj.DocumentUID + "_" + obj.DocumentName, ContactsId = obj.ContactsId, CreatedBy = Convert.ToInt32(Session["UserId"]) });
                        if (Directory.Exists(documentPath))
                        {
                            if (!File.Exists(documentPath + obj.DocumentUID + "_" + obj.DocumentName))
                            {
                                FileStream writeStream = new FileStream(documentPath + obj.DocumentUID + "_" + obj.DocumentName, FileMode.Create);
                            }
                        }
                    }
                }
                objBooking.CustomerDocument = objDocuments;
                objBooking.lstCustomerContacts = (List<EntityLayer.BookingCls.Contacts>)Session["lstContacts"];

                if (objBooking.lstCustomerContacts.Count() > Convert.ToInt32(txtNoOfPerson.Text))
                {
                    txtNoOfPerson.Text = Convert.ToString(objBooking.lstCustomerContacts.Count());
                }
                objBooking.NoOfPersons = Convert.ToInt32(txtNoOfPerson.Text); ;

                if (!string.IsNullOrEmpty(hdMultipleBookingDetail.Value))
                {
                    string bdetail = string.Empty;
                    string[] str = hdMultipleBookingDetail.Value.Split(',');
                    string roomNo, roomId, categoryId;
                    for (int i = 0; i < str.Count(); i++)
                    {
                        roomNo = str[i].Split('_')[0];
                        roomId = str[i].Split('_')[1];
                        categoryId = str[i].Split('_')[2];
                        if (!string.IsNullOrEmpty(bdetail))
                        {
                            bdetail += ",";
                        }


                        TextBox btn;
                        btn = pnlRoom.FindControl("txtRoom_" + roomId) as TextBox;

                        if (btn != null && !string.IsNullOrEmpty(btn.Text))
                        {
                            bdetail += roomNo + "_" + roomId + "_" + categoryId + "_" + btn.Text;
                        }
                        else
                        {
                            bdetail += roomNo + "_" + roomId + "_" + categoryId + "_0";
                        }

                    }
                    objBooking.BookingGroupDetail = bdetail;
                }
                List<DateTime> allDates = new List<DateTime>();
                objBooking.lstBookingRoomChargesCls = new List<BookingRoomChargesCls>();
                for (DateTime date = objBooking.FromDate; date < objBooking.ToDate; date = date.AddDays(1))
                {
                    BookingRoomChargesCls objBookingRoomChargesCls = new BookingRoomChargesCls();
                    objBookingRoomChargesCls.BookingId = 0;
                    objBookingRoomChargesCls.Fdate = date;
                    objBookingRoomChargesCls.RoomCharges = Convert.ToDecimal(objBooking.RoomCharges);
                    objBookingRoomChargesCls.Price = Convert.ToDecimal(objBooking.RoomCharges);
                    objBooking.lstBookingRoomChargesCls.Add(objBookingRoomChargesCls);
                }


                CommonUtilitys objCommonUtilitys = new CommonUtilitys();
                if (ValidateBookingData(objBooking))
                {
                    string Response = objHotalManagment.SetBookingDetail(objBooking);
                    Session["lstContacts"] = null;
                    if (Response != "0")
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
                        {
                            if (objBooking.Id == 0)
                            {
                                string HotelName = Convert.ToString(Session["Hotelname"]);
                                string PropertyName = Convert.ToString(Session["PropertyName"]);
                                string Address = Convert.ToString(Session["Address"]);
                                string NoOfNights = (Convert.ToDateTime(txtTodate.Text) - Convert.ToDateTime(txtFromDate.Text)).TotalDays.ToString();
                                string PhoneNo = string.Empty;
                                string MobileNo = string.Empty;
                                string LocationLink = string.Empty;
                                HttpCookie reqCookies = Request.Cookies["travinitiesUserInfo"];
                                if (reqCookies != null)
                                {
                                    string rdata = reqCookies["Rdata"].ToString();
                                    rdata = CommanClasses.Decrypt(rdata);
                                    Char delimiter = '~';
                                    String[] substrings = rdata.Split(delimiter);
                                    PhoneNo = substrings[7];
                                    MobileNo = substrings[8];
                                    LocationLink = substrings[9];
                                }
                                string preFix = objBooking.lstCustomerContacts[0].Gender;
                                preFix = (preFix == "M") ? "Mr." : "Mrs.";
                                string HotelPolicy = string.Empty, cancelation = string.Empty;
                                DataSet ds = objHotalManagment.GetHotelPolicy(Convert.ToInt32(Session["UserId"]));
                                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    HotelPolicy = ds.Tables[0].Rows[0]["Hotelpolicy"].ToString();
                                    cancelation = ds.Tables[0].Rows[0]["Cancellation"].ToString();
                                }

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
                                sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>CONFIRM BOOKING</span><br><span style='font-size:20px;line-height:21px;color:#000'>BOOKING REFERENCE NO :</span> <span style='font-size:20px;line-height:21px;color:#000'><b>" + Response + "</b></span><br><br><span style='font-size:15px;line-height:18px;color:#000'>Kindly print this confirmation and have it<br>ready upon check-in at the Hotel</span></p>");
                                sb1.Append("               </td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;padding:7px'>");
                                sb1.Append("                  <p style='font-family:Verdana,Arial,Helvetica,sans-serif'><span style='font-size:24px;line-height:26px;color:#000'>" + HotelName + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>" + Address + "</span><br><span style='font-size:13px;line-height:18px;color:#000'>-</span><br><span style='font-size:13px;line-height:18px;color:#000'><a href='mailto:" + Convert.ToString(Session["UserName"]) + "' style='color:#000000' target='_blank'>" + Convert.ToString(Session["UserName"]) + "</a></span><br><span style='font-size:13px;line-height:18px;color:#000'>Phone : " + PhoneNo + "</span></p>");
                                sb1.Append("               </td>");
                                sb1.Append("            </tr>");
                                sb1.Append("         </tbody>");
                                sb1.Append("      </table>");
                                sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Dear " + preFix + " " + objBooking.lstCustomerContacts[0].FirstName + ",</p>");
                                sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'>Thank you for choosing " + HotelName + " for your stay. We are pleased to inform you that your reservation request is CONFIRMED and your reservation details are as follows.</p>");
                                sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><b style='font-size:14px'>Booking Details</b><br><span>Booking Date: " + CommanClasses.CurrentDateTime().ToShortDateString() + " </span><br><span>Check In Date: " + txtFromDate.Text + " </span><br><span>Check Out Date :" + txtTodate.Text + " </span><br><span>Exepected Checkout  : " + txtExCheckoutTime.Text + "</span><br><span>Nights : " + NoOfNights + "</span><br><span>Arrival Time : " + objBooking.CheckinTime + "</span></p>");
                                sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'><span style='font-size:14px'><b>Your Details</b></span><br><span>" + preFix + " " + objBooking.lstCustomerContacts[0].FirstName + " " + objBooking.lstCustomerContacts[0].LastName + " </span><br><span>Email ID : " + objBooking.lstCustomerContacts[0].EmailId + "</span><br><span>Contact : " + ((objBooking.lstCustomerContacts[0].MobileNo!=null)?objBooking.lstCustomerContacts[0].MobileNo:"-") + "</span></p>");
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

                                List<CategoryCls> lstCat = new List<CategoryCls>();
                                if (!string.IsNullOrEmpty(hdMultipleBookingDetail.Value))
                                {
                                    string[] str = hdMultipleBookingDetail.Value.Split(',');
                                    string[] strAll = hdMultipleBookingDetail_all.Value.Split(',');
                                    int totalPerson = Convert.ToInt32(txtNoOfPerson.Text);
                                    string roomNo, roomId, categoryId, categoryName = string.Empty;
                                    DataTable dt = (DataTable)ViewState["categoryview"];
                                    for (int i = 0; i < str.Count(); i++)
                                    {
                                        roomNo = str[i].Split('_')[0];
                                        roomId = str[i].Split('_')[1];
                                        categoryId = str[i].Split('_')[2];

                                        for (int j = 0; j < dt.Rows.Count; j++)
                                        {
                                            if (Convert.ToString(dt.Rows[j]["Id"]) == categoryId)
                                            {
                                                categoryName = Convert.ToString(dt.Rows[j]["CategoryName"]);
                                            }
                                        }

                                        lstCat.Add(new CategoryCls() { Id = Convert.ToInt32(categoryId), CategoryName = categoryName });
                                        if (Convert.ToInt32(strAll[i].Split('_')[3]) <= totalPerson)
                                        {

                                            sb1.Append("            <tr style='font-size:13px'>");
                                            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + categoryName + "</b></td>");

                                            TextBox btn;
                                            btn = pnlRoom.FindControl("txtRoom_" + roomId) as TextBox;
                                            if (btn != null && !string.IsNullOrEmpty(btn.Text))
                                            {
                                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + btn.Text + " Person(s) </td>");
                                            }
                                            else
                                            {
                                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + strAll[i].Split('_')[3] + " Person(s) </td>");
                                            }
                                            sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>" + ddRoomPlan.SelectedItem.Text + "</td>");
                                            sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
                                            sb1.Append("            </tr>");
                                            totalPerson -= Convert.ToInt32(strAll[i].Split('_')[3]);
                                        }
                                        else
                                        {
                                            sb1.Append("            <tr style='font-size:13px'>");
                                            sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + categoryName + "</b></td>");

                                            TextBox btn;
                                            btn = pnlRoom.FindControl("txtRoom_" + roomId) as TextBox;
                                            if (btn != null && !string.IsNullOrEmpty(btn.Text))
                                            {
                                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + btn.Text + " Person(s) </td>");
                                            }
                                            else
                                            {
                                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + totalPerson + " Person(s) </td>");
                                            }
                                            sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>" + ddRoomPlan.SelectedItem.Text + "</td>");
                                            sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
                                            sb1.Append("            </tr>");
                                            totalPerson -= totalPerson;
                                        }
                                    }

                                    if (totalPerson > 0)
                                    {
                                        sb1.Append("            <tr style='font-size:13px'>");
                                        sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>Extra Person</b></td>");
                                        sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + totalPerson + " Person(s) </td>");
                                        sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>" + ddRoomPlan.SelectedItem.Text + "</td>");
                                        sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>None</td>");
                                        sb1.Append("            </tr>");
                                    }
                                }
                                else
                                {
                                    lstCat.Add(new CategoryCls() { Id = Convert.ToInt32(ddCategory.SelectedItem.Value), CategoryName = ddCategory.SelectedItem.Text });
                                    sb1.Append("            <tr style='font-size:13px'>");
                                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='30%'><b>" + ddCategory.SelectedItem.Text + "</b></td>");
                                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;vertical-align:top' width='15%'>" + txtNoOfPerson.Text + " Person(s) </td>");
                                    sb1.Append("               <td style='vertical-align:top;text-align:right' width='20%'>" + ddRoomPlan.SelectedItem.Text + "</td>");
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
                                sb1.Append("      <p style='margin:0'><span style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;display:inline-block;margin-top:14px;margin-bottom:7px'><b>Rates Details</b></span></p>");
                                sb1.Append("      <table cellpadding='3' style='border-collapse:collapse;font-family:Verdana,Arial,Helvetica,sans-serif;font-size:14px;color:#000;margin-bottom:25px' width='100%'>");
                                sb1.Append("         <tbody>");
                                sb1.Append("            <tr style='font-size:14px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;border-style:double;border-width:4px;border-color:black;border-right:none' width='30%'>Details</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right;border-style:double;border-width:4px;border-color:black;border-left:none' width='20%'>Rates (Rs)</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Total Room Charges</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + hdTotal.Value + "</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Room Charges Tax</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + lblTax.InnerText + "</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Early Checkin Charges</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + lblEarlyCheckinCharges.InnerText + "</td>");
                                sb1.Append("            </tr>");

                                //sb1.Append("            <tr style='font-size:13px'>");
                                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Extras Including Tax</td>");
                                //sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>0.00</td>");
                                //sb1.Append("            </tr>");

                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Extra bad charges</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + lblExtraBad.InnerText + "</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Round Off</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>0.00</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Grand Total</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + lblTotal.InnerText + "</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-size:13px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Total Paid</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + lblAdvance.InnerText + "</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("            <tr style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px'>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'>Amount due at time of check in</td>");
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif;text-align:right'>" + lblGrandTotal.InnerText + "</td>");
                                sb1.Append("            </tr>");
                                sb1.Append("         </tbody>");
                                sb1.Append("      </table>");
                                sb1.Append("      <div style='width:30%;display:inline-block;border-style:double;border-width:4px;border-color:black;padding:5px;margin-bottom:0px;vertical-align:top'>");
                                sb1.Append("         <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:20px;color:#000;text-align:center;margin:0px'>PENDING AMOUNT</p>");
                                sb1.Append("         <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:17px;color:#000;text-align:center;margin:0px'>Rs " + lblGrandTotal.InnerText + " (INR)</p>");
                                sb1.Append("      </div>");
                                sb1.Append("      <div style='width:67%;margin-bottom:14px;display:inline-block'>");
                                sb1.Append("         <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000;line-height:18px;text-align:right;margin-top:0'><b>Booked &amp; Payable By</b><br>" + preFix + " " + objBooking.lstCustomerContacts[0].FirstName + "<br>" + objBooking.lstCustomerContacts[0].EmailId + "<br></p>");
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
                                sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Hotel Policy </b><br>" + HotelPolicy + "");
                                sb1.Append("               <br><b>Hotel Check in Time : </b> 12:00 PM<br><b>Hotel Check out Time : </b> 11:00 AM</td>");
                                sb1.Append("            </tr>");
                                if (!string.IsNullOrEmpty(txtSpRequest.Text.Trim()))
                                {
                                    sb1.Append("            <tr style='font-size:13px'>");
                                    sb1.Append("               <td style='font-family:Verdana,Arial,Helvetica,sans-serif'><b>Special Request</b><br>" + txtSpRequest.Text + "</td>");
                                    sb1.Append("            </tr>");
                                }
                                sb1.Append("         </tbody>");
                                sb1.Append("      </table>");
                                sb1.Append("      <p style='font-family:Verdana,Arial,Helvetica,sans-serif;font-size:13px;color:#000'><span style='font-weight:bold;text-align:center;display:block;color:#000'>This email has been sent from an automated system - please do not reply to it.</span></p>");
                                sb1.Append("      <hr>");
                                sb1.Append("   </div>");
                                sb1.Append("   <br>");
                                sb1.Append("</div>");
                                
                                CommanClasses.SendEmail(Convert.ToString(Session["UserName"]), "Booked Room Information", sb1.ToString());
                                  string baseUrl = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["baseUrl"]);
                                                string strConfirm = string.Empty;
                                                strConfirm += "<table align='center' border='0' cellpadding='0' cellspacing='0' width='500'  background='" + baseUrl + "web/img/back.png'> <tbody><tr>";
                                                strConfirm += "<td align='center' style='border-top:1px solid #656565;border-bottom:1px solid #656565;border-left:1px solid #656565;border-right:1px solid #656565;' valign='top'>";
                                                strConfirm += "<table align='center' border='0' cellpadding='0' cellspacing='0' width='500' height='707'>";
                                                strConfirm += "<tbody><tr><td align='center' style='  padding-top:20px;  padding-bottom:20px; ' valign='top'>";
                                                strConfirm += "<table align='center' border='0' cellpadding='0' cellspacing='0' width='490'>";
                                                strConfirm += "<tbody><tr height='10px'>";
                                                strConfirm += "<td align='left' class='customfonts12' style='font-family:Calibri; font-size:16px; color:#010169; padding-bottom:2px; line-height:29px;  letter-spacing:1px; padding-top:170px; padding-left:25px;' valign='top' >";
                                                strConfirm += "<b>" + PropertyName + "</b></td>";
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

                                                


                                if (objBooking.lstCustomerContacts.Count > 0 && !string.IsNullOrEmpty(objBooking.lstCustomerContacts[0].EmailId))
                                {
                                    //CommanClasses.SendEmail(objBooking.lstCustomerContacts[0].EmailId, "Booked Room Information", sb1.ToString());
                                    CommanClasses.SendEmail(objBooking.lstCustomerContacts[0].EmailId, "Booking confirmed- " + PropertyName + "", strConfirm);
                                }
                                var result = from p in lstCat group p by new { p.Id, p.CategoryName } into g select new { CategoryName = g.Count() + " " + g.Key.CategoryName };
                                string roomsDetails = string.Empty;
                                foreach (var group in result)
                                {
                                    if (!string.IsNullOrEmpty(roomsDetails))
                                    {
                                        roomsDetails += " And ";
                                    }
                                    roomsDetails += group.CategoryName;
                                }
                                string message = string.Empty;
                                    //"Dear " + objBooking.lstCustomerContacts[0].FirstName + ",\nGreetings from " + HotelName + ". Your booking for quadruple room on " + txtFromDate.Text + " for " + txtNoOfPerson.Text + " guest is confirmed. your tariff is Rs " + objBooking.RoomCharges + " and you prepaid Rs " + objBooking.AdvanceAmount + ". Please contact on " + MobileNo + " for more details.Location " + LocationLink + "";
                                //message = "Dear " + preFix + " " + objBooking.lstCustomerContacts[0].FirstName + ",\nGreetings from " + HotelName + "\nYour booking is confirmed, BookingId-" + Response + "\ncheck-in " + txtFromDate.Text + " " + objBooking.CheckinTime + "\ncheckout " + txtTodate.Text + " " + txtExCheckoutTime.Text + "\nRoom- " + roomsDetails + "\nPax- " + txtNoOfPerson.Text + "\nTariff- " + objBooking.RoomCharges + "/-\nAdv.- " + objBooking.AdvanceAmount + "\nPay@hotel- " + lblGrandTotal.InnerText + "\nContact-" + MobileNo + " \nLocation-" + LocationLink + " ";
                                //message = "Dear Sir/Ma’am, Thanks for booking with us!\n\n*Reach your Anroute:* " + HotelName + "\nAdd- , " + Address + "\n*Map link:* " + LocationLink + "\nHotel Reception Contact - " + PhoneNo + "";
                                message = "Dear sir/mam, Thanks for booking with us!\n\nReach Your Anroute- " + HotelName + ", " + Address + "\n\nMap Link: " + LocationLink + "\n\nHotel Reception Contact- " + PhoneNo + "";
                                CommanClasses.SendSMS(message, MobileNo);
                                if (objBooking.lstCustomerContacts.Count > 0 && !string.IsNullOrEmpty(objBooking.lstCustomerContacts[0].MobileNo) && objBooking.lstCustomerContacts[0].MobileNo != "0")
                                {
                                    CommanClasses.SendSMS(message, objBooking.lstCustomerContacts[0].MobileNo.ToString());
                                }

                                

                            }

                        }

                        objCommonUtilitys.UpdateAvailability(Convert.ToInt32(Session["UserId"]), txtFromDate.Text, Convert.ToDateTime(txtTodate.Text).AddDays(-1).ToShortDateString(), Convert.ToInt32(ddCategory.SelectedValue));
                        ClearControl();
                        Server.Transfer("ShowBookingData.aspx");
                    }
                    objCommonUtilitys.UpdateAvailability(Convert.ToInt32(Session["UserId"]), txtFromDate.Text, Convert.ToDateTime(txtTodate.Text).AddDays(-1).ToShortDateString(), Convert.ToInt32(ddCategory.SelectedValue));
                    ClearControl();
                    Server.Transfer("ShowBookingData.aspx");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "Errormsg();", true);
                if (Convert.ToInt32(hdPresons.Value) == 0)
                {
                    hdMessage.Value += "Please enter person capacity in selected room.";
                }
                else
                {
                    if ((grdContactInfo.Rows.Count <= (Convert.ToInt32(hdPresons.Value) + Convert.ToInt32(ddExtrabad.SelectedItem.Value))))
                    {
                        hdMessage.Value += "Please Add Profile information / Select Booking Source.";
                    }
                    else
                    {
                        hdMessage.Value += "Please fill contact information";
                    }
                }

                //Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "ShowMessageForm();", true);
                //lblMessage.Text = "Please fill contact information";
                //return;
            }
        }






        public void showPage(int id)
        {
            Head1.Visible = false;
            body1.Visible = false;
            Head2.Visible = false;
            body2.Visible = false;
            Head3.Visible = false;
            body3.Visible = false;
            Head4.Visible = false;
            body4.Visible = false;
            li1.Attributes.Add("Class", "done");
            li2.Attributes.Add("Class", "done");
            li3.Attributes.Add("Class", "done");

            switch (id)
            {
                case 1:
                    Head1.Visible = true;
                    body1.Visible = true;
                    li1.Attributes.Add("Class", "current");
                    break;
                case 2:
                    Head2.Visible = true;
                    body2.Visible = true;
                    li2.Attributes.Add("Class", "current");
                    break;
                case 3:
                    Head3.Visible = true;
                    body3.Visible = true;
                    li3.Attributes.Add("Class", "current");
                    Head4.Visible = true;
                    body4.Visible = true;
                    break;
                default:
                    break;
            }

        }

        protected void lnkpage1_Click(object sender, EventArgs e)
        {
            showPage(1);
        }

        protected void lnkpage2_Click(object sender, EventArgs e)
        {
            showPage(2);
        }

        protected void lnkpage3_Click(object sender, EventArgs e)
        {
            showPage(3);
        }

        public void UploadImages()
        {
            //Page.ClientScript.RegisterStartupScript(GetType(), "Booking", "ShowEditForm();", true);
            if (fileUploadPhotos.HasFile)
            {
                string strGuid = Guid.NewGuid().ToString();
                int MaxSize = 10 * 1024 * 1024;//10MB
                if (fileUploadPhotos.PostedFile != null && fileUploadPhotos.PostedFile.ContentLength > 0)
                {
                    if (Math.Round(((decimal)fileUploadPhotos.PostedFile.ContentLength)) < MaxSize)
                    {
                        //lblCustomerPhotoName.Text = fCustomerPhoto.FileName;
                        hdnCustomerPhoto.Value = strGuid + "_" + fileUploadPhotos.PostedFile.FileName;
                        fileUploadPhotos.PostedFile.SaveAs(Server.MapPath(Path.Combine(folderCustPhotos, strGuid + "_" + fileUploadPhotos.PostedFile.FileName)));
                        Image1.ImageUrl = folderCustPhotos.Replace("\\\\", "\\") + hdnCustomerPhoto.Value;
                    }
                }
            }
            ShowDocument();
        }

        protected void RepterDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

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

        protected void chkInclusive_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        protected void txtTodate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdMultipleBookingDetail.Value))
            {
                SetRoomNoByCategory();
            }
        }

        protected void btnChangeRoom_Click(object sender, EventArgs e)
        {
            ddRoomNo.SelectedValue = Convert.ToString(ddChangeRoom.SelectedValue);
        }
    }
}
