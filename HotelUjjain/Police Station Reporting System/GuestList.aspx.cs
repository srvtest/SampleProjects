using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class GuestList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtFormDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

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
                            ddlHotel.Items.Insert(0, new ListItem() { Text = "Select Hotel", Value = "0" });
                            ddlHotel.SelectedIndex = 0;
                        }
                    }
                }
                ddlDays.SelectedValue = "0";
                LoadGridData();
            }            
        }
        public void LoadGridData()
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idUser = Convert.ToInt32(Session["UserId"]);
            switch (ddlDays.SelectedValue)
            {
                case "0":
                    guestFilterDto.FilterFromDate = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
                    guestFilterDto.FilterToDate = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
                    break;
                case "1":
                    guestFilterDto.FilterFromDate = DateTime.Now.AddDays(-7).Date.ToString("yyyy-MM-dd");
                    guestFilterDto.FilterToDate = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
                    break;
                case "2":
                    guestFilterDto.FilterFromDate = DateTime.Now.AddDays(-15).Date.ToString("yyyy-MM-dd");
                    guestFilterDto.FilterToDate = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
                    break;
                case "3":
                    guestFilterDto.FilterFromDate = DateTime.Now.AddDays(-30).Date.ToString("yyyy-MM-dd");
                    guestFilterDto.FilterToDate = DateTime.Now.AddDays(-1).Date.ToString("yyyy-MM-dd");
                    break;
                case "4":
                    guestFilterDto.FilterFromDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    guestFilterDto.FilterToDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    break;
                default:
                    break;
            }
            if (ddlHotel.SelectedIndex > 0)
            {
                guestFilterDto.idHotel = Convert.ToInt32(ddlHotel.SelectedValue);
            }
            ResponseDto obj = objuserDL.GetNotSubmitGuestDetailByPoliceStationId(guestFilterDto);
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
        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {

                HiddenField hdnIdHotel_1 = (HiddenField)e.Item.FindControl("hdnIdHotel");
               // HiddenField hdnSubDate_1 = (HiddenField)e.Item.FindControl("hdnSubDate");

                Response.Redirect("HotelProfile.aspx?idHotel=" + UtilityFunction.Encrypt(Convert.ToString(hdnIdHotel_1.Value)));
            }
            //if (e.CommandName == "View")
            //{
            //    HiddenField hdnIdHotel = (HiddenField)e.Item.FindControl("hdnIdHotel");
            //}
        }

        protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }
        protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}