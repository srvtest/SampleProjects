using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmGuestMaster : System.Web.UI.Page
    {
        GuestMasterDL objuserDL = new GuestMasterDL();
        private List<GuestDetailDto> GuestDetails
        {
            get
            {
                if (ViewState["GuestDetails"] == null)
                {
                    ViewState["GuestDetails"] = new List<GuestDetailDto>();
                }
                return (List<GuestDetailDto>)ViewState["GuestDetails"];
            }
            set
            {
                ViewState["GuestDetails"] = value;
            }
        }
        List<GuestMasterDto> userDto
        {
            get
            {
                //if (ViewState["GuestMaster"] == null)
                //{
                //    ViewState["GuestMaster"] = new List<GuestMasterDto>();
                //}
                return (List<GuestMasterDto>)ViewState["GuestMaster"];
            }
            set
            {
                ViewState["GuestMaster"] = value;
            }
        }
        private int snsHotelId
        {
            get
            {
                if (Session["snsHotelId"] == null)
                {
                    Session["snsHotelId"] = 0;
                }
                return (int)Session["snsHotelId"];
            }
            set
            {
                Session["snsHotelId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Guest Master Details";
            lbl2.Text = "Guest Master";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                snsHotelId = 3;
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.Guest);
                if (!isAccess)
                    Response.Redirect("dashboard.aspx");
                LoadGridData();
            }
        }

        public void LoadGridData()
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            ResponseDto obj = objuserDL.GetGuestMaster();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    userDto = (List<GuestMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        RptUser.DataSource = userDto;
                        RptUser.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            List<GuestMasterDto> GuestMasterDto = new List<GuestMasterDto>();
            GuestMasterDto masterDto = null;
            //ShowUserPanal(true);
            //lbl4.Text = "Add Guest Master";
            if (userDto != null)
            {
                foreach (var item in userDto)
                {
                    masterDto = new GuestMasterDto();
                    bool isAccess = false;
                    if (item.GuestMobileNumber != null && !item.GuestMobileNumber.Contains("NA") && item.GuestMobileNumber.Length <= 15)
                    {
                        isAccess = true;
                        masterDto.GuestMobileNumber = EncryptionHelper.Encrypt(item.GuestMobileNumber);
                    }
                    if (item.IDProofNumber != null && item.IDProofNumber.Length <= 15)
                    {
                        isAccess = true;
                        masterDto.IDProofNumber = EncryptionHelper.Encrypt(item.IDProofNumber);
                    }
                    if (isAccess)
                    {
                        masterDto.GuestId = item.GuestId;
                        GuestMasterDto.Add(masterDto);
                    }
                }
                if (GuestMasterDto.Count > 0)
                {
                    ResponseDto response = objuserDL.UpdateGuestMaster(GuestMasterDto);
                    if (response != null)
                    {
                        if (response.StatusCode == 0)
                        {
                            LoadGridData();
                            hdMessage.Value = response.Message;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                        }
                        else
                        {
                            hdMessage.Value = response.Message;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                        }
                    }
                }
            }
        }
        private void ShowUserPanal(bool v)
        {
            //pnlUser.Visible = v;
            pnluserList.Visible = !v;

            hdGuestMasterId.Value = "";
        }
        //protected void RptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    GuestMasterDL objuserDL = new GuestMasterDL();
        //    if (e.CommandName == "Update")
        //    {
        //        lbl4.Text = "Edit Guest Master";
        //        HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
        //        ResponseDto response = objuserDL.GetGuestMasterById(Convert.ToInt32(hiddenField.Value));
        //        if (response != null)
        //        {
        //            GuestMasterDto userDto = (GuestMasterDto)response.Result;
        //            if (userDto != null)
        //            {
        //                ShowUserPanal(true);
        //                txtContactNo.Text = userDto.ContactNo;

        //                txtCheckOutDate.Text = userDto.CheckOutDate;
        //                txtCheckInDate.Text = userDto.CheckInDate;
        //                txtEnterDate.Text = userDto.EnterDate;
        //                txtDEscription.Text = userDto.Description;

        //                chkActive.Checked = userDto.bActive;
        //                txtGuestName.Text = userDto.GuestName;
        //                txtIdentificationNo.Text = userDto.IdentificationNo;
        //                txtIdentificationType.Text = userDto.IdentificationType;
        //                txtAddress.Text = userDto.Address;

        //                hdGuestMasterId.Value = Convert.ToString(userDto.idGuestMaster);
        //            }
        //        }
        //    }
        //    else if (e.CommandName == "Delete")
        //    {
        //        HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
        //        GuestMasterDL objLoginDL = new GuestMasterDL();
        //        GuestMasterDto userDto = new GuestMasterDto();
        //        userDto.isDeleted = true;
        //        if (!string.IsNullOrEmpty(hiddenField.Value))
        //        {
        //            userDto.idGuestMaster = Convert.ToInt32(hiddenField.Value);
        //        }

        //        ResponseDto response = objLoginDL.InsertUpdateDeleteGuestMaster(userDto,false);
        //        if (response != null)
        //        {
        //            if (response.StatusCode == 0)
        //            {
        //                LoadGridData();
        //                hdMessage.Value = response.Message;
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //            }
        //            else
        //            {
        //                hdMessage.Value = response.Message;
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //            }
        //        }
        //    }
        //}
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ShowUserPanal(false);
        //}


        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    GuestMasterDL objGuestMasterDL = new GuestMasterDL();
        //    GuestMasterDto guestMasterDto = new GuestMasterDto();
        //    guestMasterDto.ContactNo = txtContactNo.Text;
        //    guestMasterDto.idHotel = snsHotelId;
        //    guestMasterDto.CheckOutDate = txtCheckOutDate.Text;
        //    guestMasterDto.CheckInDate = txtCheckInDate.Text;
        //    guestMasterDto.EnterDate = txtEnterDate.Text;
        //    guestMasterDto.Description = txtDEscription.Text;
        //    guestMasterDto.bActive = chkActive.Checked;
        //    guestMasterDto.GuestName = txtGuestName.Text;
        //    guestMasterDto.IdentificationNo = txtIdentificationNo.Text;
        //    guestMasterDto.IdentificationType = txtIdentificationType.Text;
        //    guestMasterDto.Address = txtAddress.Text;
        //    if (string.IsNullOrEmpty(TxtNoofGuest.Text))
        //        TxtNoofGuest.Text = "0";
        //    guestMasterDto.AddionalGuest = Convert.ToInt32(TxtNoofGuest.Text);
        //    if (!string.IsNullOrEmpty(hdGuestMasterId.Value))
        //    {
        //        guestMasterDto.idGuestMaster = Convert.ToInt32(hdGuestMasterId.Value);
        //    }
        //    guestMasterDto.Details = new List<GuestDetailDto>();
        //    foreach (RepeaterItem item in rptGuest.Items)
        //    {
        //        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            TextBox txtGName = (TextBox)item.FindControl("txtAddGuestName");
        //            TextBox txtidType = (TextBox)item.FindControl("txtAddGuestType");
        //            TextBox txtId = (TextBox)item.FindControl("txtAddGuestIdno");
        //            guestMasterDto.Details.Add(new GuestDetailDto { IdentificationNo = txtId.Text, IdentificationType = txtidType.Text, sName = txtGName.Text });
        //        }
        //    }
        //    ResponseDto response = objGuestMasterDL.InsertUpdateDeleteGuestMaster(guestMasterDto,false);
        //    if (response != null)
        //    {
        //        if (response.StatusCode == 0)
        //        {
        //            LoadGridData();
        //            hdMessage.Value = response.Message;
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //        }
        //        else
        //        {
        //            hdMessage.Value = response.Message;
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //        }
        //    }
        //}
        //protected void TxtNoofGuest_TextChanged(object sender, EventArgs e)
        //{
        //    if (Convert.ToInt32(TxtNoofGuest.Text) > 0)
        //    {
        //        for (int i = 0; i < Convert.ToInt32(TxtNoofGuest.Text); i++)
        //        {
        //            if (GuestDetails.Count < (i + 1))
        //            {
        //                GuestDetails.Add(new GuestDetailDto());
        //            }
        //        }

        //    }
        //    BindGuest();
        //}

        //public void BindGuest()
        //{
        //    rptGuest.DataSource = GuestDetails;
        //    rptGuest.DataBind();
        //}
    }
}