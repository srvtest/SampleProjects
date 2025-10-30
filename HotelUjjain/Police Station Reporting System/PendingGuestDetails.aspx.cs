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
    public partial class PendingGuestDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtfrom.Text = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy");
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
                //ddlDays.SelectedValue = "0";
                LoadGridData();
            }
            string strFolderTemp;
            strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
            foreach (var file in Directory.GetFiles(strFolderTemp.ToString()))
            {
                File.Delete(file);
            }
        }
        public void LoadGridData()
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idUser = Convert.ToInt32(Session["UserId"]);
            guestFilterDto.FilterFromDate = Convert.ToDateTime(txtfrom.Text).ToString("dd/MMM/yyyy");
            //guestFilterDto.FilterToDate = Convert.ToDateTime(txtfrom.Text).ToString("dd/MMM/yyyy");
            if (ddlHotel.SelectedIndex > 0)
            {
                guestFilterDto.idHotel = Convert.ToInt32(ddlHotel.SelectedValue);
            }
            ResponseDto obj = objuserDL.GetPendingGuestDetailByPoliceStationId(guestFilterDto);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<SubmitSummeryDto> userDto = (List<SubmitSummeryDto>)obj.Result;  
                    if (userDto != null)
                    {    
                        //if (!chkShowReport.Checked)
                        //    userDto.RemoveAll(a => a.TotalGuest == "0");
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
                Repeater repeater = e.Item.FindControl("rptPendingGuestDetail") as Repeater;
                HiddenField hdnIdHotel_1 = (HiddenField)e.Item.FindControl("hdnIdHotel");
                HiddenField hdnSubDate_1 = (HiddenField)e.Item.FindControl("hdnSubDate");                
                repeater.DataSource = GetData(hdnIdHotel_1.Value, hdnSubDate_1.Value);
                repeater.DataBind();
            }
        }
        private object GetData(string HotelId, string Date)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(HotelId);
            guestFilterDto.FilterFromDate = Convert.ToDateTime(Date).ToString("dd-MMM-yyyy");
            guestFilterDto.FilterToDate = Convert.ToDateTime(Date).ToString("dd-MMM-yyyy");
            ResponseDto obj = objuserDL.GetGuestPendingDetailForPoliceReport(guestFilterDto, false);
            List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
            if (userDto != null)
            {
                for (int i = 0; i < userDto.Count; i++)
                {
                    userDto[i].IdentificationNo = new string('x', userDto[i].IdentificationNo.Length - 4) + userDto[i].IdentificationNo.Substring(userDto[i].IdentificationNo.Length - 4);
                    userDto[i].ContactNo = userDto[i].ContactNo == "" ? "NA" : userDto[i].ContactNo;
                }                
            }
            return userDto;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

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
                HiddenField hdnSubDate_1 = (HiddenField)e.Item.FindControl("hdnSubDate");

                Response.Redirect("PendingReport.aspx?idHotel=" + UtilityFunction.Encrypt(Convert.ToString(hdnIdHotel_1.Value)) + "&SubmitDate=" + UtilityFunction.Encrypt(Convert.ToString(hdnSubDate_1.Value)));
            }
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