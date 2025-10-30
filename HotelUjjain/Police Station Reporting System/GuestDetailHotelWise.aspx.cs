using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class GuestDetailHotelWise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HotelMasterDL objHotelDL = new HotelMasterDL();
                ResponseDto obj = objHotelDL.GetHotelByPoliceStationId(Convert.ToInt32(Session["UserId"]));
                if (obj != null)
                {
                    if (obj.StatusCode == 0)
                    {
                        List<HotelMasterDto> hotelDto = (List<HotelMasterDto>)obj.Result;
                        if (hotelDto != null)
                        {
                            ddlHotel.DataSource = hotelDto;
                            ddlHotel.DataTextField = "HotelName";
                            ddlHotel.DataValueField = "idHotelMaster";
                            ddlHotel.DataBind();
                            ddlHotel.SelectedIndex = 0;
                        }
                    }
                }

                LoadGridData();
            }
        }

        public void LoadGridData()
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idUser = Convert.ToInt32(Session["UserId"]);
            if (string.IsNullOrEmpty(txtFormDate.Text))
            {
                guestFilterDto.sMonth = DateTime.Now.Month;
                guestFilterDto.sYear = DateTime.Now.Year;
            }

            else
            {
                guestFilterDto.sMonth = Convert.ToInt32(txtFormDate.Text.Split('-')[1]);
                guestFilterDto.sYear = Convert.ToInt32(txtFormDate.Text.Split('-')[0]);
            }
            guestFilterDto.idHotel = Convert.ToInt32(ddlHotel.SelectedValue);

            ResponseDto obj = objuserDL.GetHotelGuestDetailByPoliceStationId(guestFilterDto);
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
            //ShowUserPanal(false);
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
            LoadGridData();
        }
    }
}