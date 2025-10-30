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
    public partial class SearchGuests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
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
            lblMessage1.Visible = false;
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idUser = Convert.ToInt32(Session["UserId"]);
            guestFilterDto.GuestName = txtName.Text.Trim();
            guestFilterDto.IdentificationNo = txtAdhar.Text.Trim();
            guestFilterDto.ContactNo = txtContact.Text.Trim();

            ResponseDto obj = objuserDL.GetGuestDetailSearchByPoliceStationId(guestFilterDto);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        rptGuest.DataSource = userDto;
                        rptGuest.DataBind();
                        if (userDto.Count == 0)
                        {
                            lblMessage1.Visible = true;
                            lblMessage1.InnerHtml = obj.Message;
                            //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "SearchGuestData();", true);
                        }
                    }
                }
            }
            
        }

        private void ClearControls()
        {
            txtName.Text = "";
            txtAdhar.Text = "";
            txtContact.Text = "";
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
                        foreach (var item in userDto)
                        {
                            if (string.IsNullOrEmpty(NewControl.Text))
                            {
                                NewControl.Text = Convert.ToString(item.AddionalGuest);
                            }
                            else
                            {
                                NewControl.Text = Convert.ToString(item.AddionalGuest);
                            }        
                        }

                        //List<GuestDetailDto> guestDetailDtos = userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).FirstOrDefault().Details;
                        //if (guestDetailDtos != null)
                        //{
                        //    foreach (var item in guestDetailDtos)
                        //    {
                        //        if (string.IsNullOrEmpty(NewControl.Text))
                        //        {
                        //            NewControl.Text = item.sName + " (" + item.gender + ")";
                        //        }
                        //        else
                        //        {
                        //            NewControl.Text += "<br>" + item.sName + " (" + item.gender + ")";
                        //        }

                        //    }
                        //}
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
            ClearControls();
        }

        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {

                HiddenField hdIdGuest = (HiddenField)e.Item.FindControl("hdnIdGuest");

                Response.Redirect("GuestInformation.aspx?idGuestMaster=" + UtilityFunction.Encrypt(Convert.ToString(hdIdGuest.Value)));
            }
        }
    }
}