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
    public partial class SearchGuest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl1.Text = "Search Guest";
                lbl2.Text = "Search Guest";
            }
        }

        public void LoadGridData()
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idUser = Convert.ToInt32(Session["UserId"]);
            guestFilterDto.FilterName = txtName.Text;
            guestFilterDto.FilterAdhar = txtAdhar.Text;
            guestFilterDto.FilterContact = txtContact.Text;

            ResponseDto obj = objuserDL.GetGuestMasterAdmin(guestFilterDto);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        rptGuest.DataSource = userDto;
                        rptGuest.DataBind();
                    }
                }
            }
        }

        protected void rptGuest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                           e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
                Label NewControl = e.Item.FindControl("lblAddGuest") as Label;
                if (NewControl != null)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)rptGuest.DataSource;
                    if (userDto != null && userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).Count() > 0)
                    {
                        List<GuestDetailDto> guestDetailDtos = userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).FirstOrDefault().Details;
                        if (guestDetailDtos != null)
                        {
                            foreach (var item in guestDetailDtos)
                            {
                                if (string.IsNullOrEmpty(NewControl.Text))
                                {
                                    NewControl.Text = item.sName + " (" + item.gender + ")";
                                }
                                else
                                {
                                    NewControl.Text += "<br>" + item.sName + " (" + item.gender + ")";
                                }

                            }
                        }
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtAdhar.Text) && string.IsNullOrEmpty(txtContact.Text))
            {

            }
            else
            {
                LoadGridData();
            }


        }

        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                HiddenField hdnBookingId = (HiddenField)e.Item.FindControl("hdnBookingId");
                HiddenField hdIdGuest = (HiddenField)e.Item.FindControl("hdnIdGuest");
                HiddenField hdnHotelID = (HiddenField)e.Item.FindControl("hdnHotelID");
                HiddenField hdnCheckInDate = (HiddenField)e.Item.FindControl("hdnCheckinDate");

                //Response.Redirect("GuestInformation.aspx?idGuestMaster=" + UtilityFunction.Encrypt(Convert.ToString(hdIdGuest.Value)) 
                //    + "&HotelID="+ hdnHotelID.Value + "&CheckinDate="+ hdnCheckInDate.Value);
                Response.Redirect("GuestInformation.aspx?BookingId=" + (Convert.ToString(hdnBookingId.Value))
                    + "&HotelID=" + (hdnHotelID.Value) + "&CheckinDate=" + (hdnCheckInDate.Value));
                //Response.Redirect("GuestInformation.aspx?BookingId=" + EncryptionHelper.Encrypt(Convert.ToString(hdnBookingId.Value))
                //    + "&HotelID=" + EncryptionHelper.Encrypt(hdnHotelID.Value) + "&CheckinDate=" + EncryptionHelper.Encrypt(hdnCheckInDate.Value));
            }
        }
    }
}